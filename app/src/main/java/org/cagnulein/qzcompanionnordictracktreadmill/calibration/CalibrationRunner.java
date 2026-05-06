package org.cagnulein.qzcompanionnordictracktreadmill.calibration;

import android.os.Environment;
import android.util.DisplayMetrics;
import android.util.Log;

import org.cagnulein.qzcompanionnordictracktreadmill.console.MonoStdoutMetricHub;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceCalibration;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricPacket;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.function.Consumer;
import java.util.function.LongSupplier;

/**
 * Phase-2 incline-only calibration runner.
 *
 * Runs off the UI thread, drives the incline slider with Accessibility gestures,
 * consumes the shared mono-stdout metric stream, fits Y = origin - scale * grade,
 * writes qz-calibration.json, and updates DeviceCalibration.current immediately.
 */
public final class CalibrationRunner {
    private static final String TAG = "QZ:Calibration";

    public enum State {
        IDLE,
        PREFLIGHT,
        INCLINE_COARSE,
        INCLINE_FINE,
        FIT,
        SAVE,
        COMPLETE,
        FAILED,
        CANCELLED
    }

    public interface Gestures {
        boolean isReady();
        boolean swipe(int x, int fromY, int toY);
    }

    public interface Listener {
        void onState(State state, String detail);
        void onComplete(CalibrationResult result, DeviceCalibration calibration,
                        CalibrationFit.FitResult inclineFit);
        void onFailed(String message, Throwable error);
    }

    public static final class Config {
        public int coarseSettleMs = 2500;
        public int coarseTimeoutMs = 4000;
        public int fineSettleMs = 2000;
        public int fineTimeoutMs = 6000;
        public int stableSettleMs = 1000;
        public int minY = CalibrationFit.COARSE_MARGIN;
        public File outputFile = new File(Environment.getExternalStorageDirectory(),
                "qz-calibration.json");
    }

    private final int screenWidth;
    private final int screenHeight;
    private final Config config;
    private final Gestures gestures;
    private final CalibrationMetricCollector metrics;
    private final MetricSubscriptionSource subscriptionSource;
    private final Sleeper sleeper;
    private final LongSupplier clock;
    private final AtomicBoolean cancelled = new AtomicBoolean(false);

    private Thread thread;

    public CalibrationRunner(DisplayMetrics displayMetrics) {
        this(displayMetrics.widthPixels, displayMetrics.heightPixels,
                new Config(), new CalibrationGestureDriver(), new CalibrationMetricCollector(),
                subscriber -> MonoStdoutMetricHub.shared().subscribe(subscriber),
                Thread::sleep, System::currentTimeMillis);
    }

    public CalibrationRunner(int screenWidth, int screenHeight, Config config,
                             Gestures gestures, CalibrationMetricCollector metrics,
                             MetricSubscriptionSource subscriptionSource, Sleeper sleeper,
                             LongSupplier clock) {
        this.screenWidth = screenWidth;
        this.screenHeight = screenHeight;
        this.config = config;
        this.gestures = gestures;
        this.metrics = metrics;
        this.subscriptionSource = subscriptionSource;
        this.sleeper = sleeper;
        this.clock = clock;
    }

    public synchronized void start(Listener listener) {
        if (thread != null && thread.isAlive()) {
            throw new IllegalStateException("Calibration already running");
        }
        cancelled.set(false);
        thread = new Thread(() -> run(listener), "QZ-InclineCalibration");
        thread.setDaemon(true);
        thread.start();
    }

    public void cancel() {
        cancelled.set(true);
        Thread t = thread;
        if (t != null) t.interrupt();
    }

    void run(Listener listener) {
        MonoStdoutMetricHub.Subscription subscription = null;
        try {
            state(listener, State.PREFLIGHT, "Checking Accessibility gestures and metric stream");
            if (!gestures.isReady()) {
                throw new IllegalStateException("AccessibilityService is not connected");
            }
            subscription = subscriptionSource.subscribe(metrics);

            CalibrationFit.TrackProfile profile = CalibrationFit.trackProfileForWidth(screenWidth);
            int trackX = profile.inclineTrackX;
            int bottomY = screenHeight - config.minY;
            int previousY = config.minY;

            state(listener, State.INCLINE_COARSE, "Coarse incline sweep at x=" + trackX);
            List<CalibrationFit.Point> coarse = new ArrayList<>();
            for (int y = config.minY; y <= bottomY; y += CalibrationFit.COARSE_STEP) {
                checkCancelled();
                long ts = clock.getAsLong();
                gestures.swipe(trackX, previousY, y);
                previousY = y;
                sleep(config.coarseSettleMs);
                Float grade = metrics.waitFreshGrade(ts, config.coarseTimeoutMs);
                if (grade != null) {
                    coarse.add(new CalibrationFit.Point(y, grade));
                    Log.i(TAG, "coarse y=" + y + " grade=" + grade);
                } else {
                    Log.i(TAG, "coarse y=" + y + " no grade change");
                }
            }
            if (coarse.size() < 3) {
                throw new IllegalStateException("Incline calibration requires at least 3 readings; got "
                        + coarse.size());
            }

            state(listener, State.FIT, "Fitting coarse incline readings");
            CalibrationFit.FitResult fit = CalibrationFit.fitLinear(coarse);
            if (fit.r2 < 0.99) {
                int[] range = CalibrationFit.findActiveRange(coarse, screenHeight);
                if (range != null) {
                    state(listener, State.INCLINE_FINE, "Fine incline sweep from y="
                            + range[0] + " to y=" + range[1]);
                    List<CalibrationFit.Point> fine = fineSweep(trackX, range[0], range[1]);
                    if (fine.size() >= 3) {
                        state(listener, State.FIT, "Fitting fine incline readings");
                        fit = CalibrationFit.fitLinear(fine);
                    }
                }
            }
            if (!fit.isValid()) throw new IllegalStateException("Incline fit is invalid");
            if (fit.isWarningQuality()) {
                Log.w(TAG, "Incline fit quality warning r2=" + fit.r2);
            }

            state(listener, State.SAVE, "Writing qz-calibration.json");
            CalibrationResult result = new CalibrationResult(
                    new CalibrationResult.SliderCalibration(
                            trackX, fit.origin, fit.scale),
                    null);
            result.writeTo(config.outputFile);
            DeviceCalibration calibration = result.toDeviceCalibration();
            DeviceCalibration.current = calibration;

            state(listener, State.COMPLETE, "Incline calibration saved");
            listener.onComplete(result, calibration, fit);
        } catch (CancelledException e) {
            state(listener, State.CANCELLED, "Calibration cancelled");
        } catch (Throwable t) {
            state(listener, State.FAILED, t.getMessage());
            listener.onFailed(t.getMessage(), t);
        } finally {
            if (subscription != null) subscription.close();
        }
    }

    private List<CalibrationFit.Point> fineSweep(int trackX, int topY, int bottomY)
            throws InterruptedException, CancelledException {
        gestures.swipe(trackX, bottomY, topY);
        sleep(config.fineSettleMs * 2L);
        int previousY = topY;
        List<CalibrationFit.Point> raw = new ArrayList<>();
        for (int y = topY; y <= bottomY; y += CalibrationFit.FINE_STEP) {
            checkCancelled();
            long ts = clock.getAsLong();
            gestures.swipe(trackX, previousY, y);
            previousY = y;
            sleep(config.fineSettleMs);
            Float grade = metrics.waitStableGrade(ts, config.stableSettleMs, config.fineTimeoutMs);
            if (grade != null) {
                raw.add(new CalibrationFit.Point(y, grade));
                Log.i(TAG, "fine y=" + y + " grade=" + grade);
            } else {
                Log.i(TAG, "fine y=" + y + " timeout");
            }
        }
        return CalibrationFit.filterMonotonicDescending(raw, 1.0);
    }

    private void state(Listener listener, State state, String detail) {
        Log.i(TAG, state + ": " + detail);
        listener.onState(state, detail);
    }

    private void checkCancelled() throws CancelledException {
        if (cancelled.get()) throw new CancelledException();
    }

    private void sleep(long ms) throws InterruptedException {
        sleeper.sleepMs(ms);
    }

    @FunctionalInterface
    public interface MetricSubscriptionSource {
        MonoStdoutMetricHub.Subscription subscribe(Consumer<QZMetricPacket> subscriber)
                throws IOException;
    }

    @FunctionalInterface
    public interface Sleeper {
        void sleepMs(long ms) throws InterruptedException;
    }

    private static final class CancelledException extends Exception {}
}
