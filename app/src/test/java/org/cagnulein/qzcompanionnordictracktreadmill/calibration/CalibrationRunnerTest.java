package org.cagnulein.qzcompanionnordictracktreadmill.calibration;

import org.cagnulein.qzcompanionnordictracktreadmill.console.MonoStdoutMetricHub;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceCalibration;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricPacket;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.robolectric.RobolectricTestRunner;
import org.robolectric.annotation.Config;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.function.Consumer;
import java.util.function.LongSupplier;

import static org.junit.Assert.*;

@RunWith(RobolectricTestRunner.class)
@Config(sdk = 34)
public class CalibrationRunnerTest {

    @Test
    public void inclineOnlyRunner_savesAndAppliesCalibration() throws Exception {
        ManualClock clock = new ManualClock();
        CalibrationMetricCollector collector =
                new CalibrationMetricCollector(clock::nowMs, clock::advance);
        FakeSubscriptionSource source = new FakeSubscriptionSource();
        ScriptedGestures gestures = new ScriptedGestures();
        File output = File.createTempFile("qz-calibration-runner", ".json");
        CalibrationRunner.Config config = fastConfig(output);

        CalibrationRunner runner = new CalibrationRunner(
                1920, 1000, config, gestures, collector, source,
                ms -> {
                    if (gestures.pendingY != null && source.subscriber != null) {
                        int y = gestures.pendingY;
                        gestures.pendingY = null;
                        clock.advance(1);
                        float grade = (float) ((622.0 - y) / 18.57);
                        source.subscriber.accept(new QZMetricPacket(
                                QZMetricPacket.Metric.GRADE, grade));
                    }
                    clock.advance(ms);
                },
                clock);

        CapturingListener listener = new CapturingListener();
        runner.run(listener);

        assertNull(listener.failure);
        assertNotNull(listener.result);
        assertTrue(output.exists());
        assertEquals(57, listener.result.incline.trackX);
        assertEquals(622.0, listener.fit.origin, 0.01);
        assertEquals(18.57, listener.fit.scale, 0.01);
        assertTrue(listener.fit.r2 > 0.999);
        assertSame(listener.calibration, DeviceCalibration.current);
        assertTrue(source.closed);
        assertFalse(gestures.swipes.isEmpty());

        output.delete();
    }

    @Test
    public void inclineOnlyRunner_failsWhenNotEnoughReadings() throws Exception {
        ManualClock clock = new ManualClock();
        CalibrationMetricCollector collector =
                new CalibrationMetricCollector(clock::nowMs, clock::advance);
        FakeSubscriptionSource source = new FakeSubscriptionSource();
        ScriptedGestures gestures = new ScriptedGestures();
        File output = File.createTempFile("qz-calibration-runner", ".json");
        output.delete();
        CalibrationRunner.Config config = fastConfig(output);

        CalibrationRunner runner = new CalibrationRunner(
                1920, 1000, config, gestures, collector, source,
                clock::advance,
                clock);

        CapturingListener listener = new CapturingListener();
        runner.run(listener);

        assertNull(listener.result);
        assertNotNull(listener.failure);
        assertTrue(listener.failure.contains("at least 3 readings"));
        assertFalse(output.exists());
        assertTrue(source.closed);
    }

    private static CalibrationRunner.Config fastConfig(File output) {
        CalibrationRunner.Config config = new CalibrationRunner.Config();
        config.outputFile = output;
        config.coarseSettleMs = 1;
        config.coarseTimeoutMs = 1;
        config.fineSettleMs = 1;
        config.fineTimeoutMs = 1;
        config.stableSettleMs = 1;
        return config;
    }

    private static final class CapturingListener implements CalibrationRunner.Listener {
        CalibrationResult result;
        DeviceCalibration calibration;
        CalibrationFit.FitResult fit;
        String failure;

        @Override
        public void onState(CalibrationRunner.State state, String detail) {}

        @Override
        public void onComplete(CalibrationResult result, DeviceCalibration calibration,
                               CalibrationFit.FitResult inclineFit) {
            this.result = result;
            this.calibration = calibration;
            this.fit = inclineFit;
        }

        @Override
        public void onFailed(String message, Throwable error) {
            this.failure = message;
        }
    }

    private static final class FakeSubscriptionSource
            implements CalibrationRunner.MetricSubscriptionSource {
        Consumer<QZMetricPacket> subscriber;
        boolean closed = false;

        @Override
        public MonoStdoutMetricHub.Subscription subscribe(Consumer<QZMetricPacket> subscriber) {
            this.subscriber = subscriber;
            return () -> closed = true;
        }
    }

    private static final class ScriptedGestures implements CalibrationRunner.Gestures {
        final List<Integer> swipes = new ArrayList<>();
        Integer pendingY;

        @Override
        public boolean isReady() {
            return true;
        }

        @Override
        public boolean swipe(int x, int fromY, int toY) {
            swipes.add(toY);
            pendingY = toY;
            return true;
        }
    }

    private static final class ManualClock implements LongSupplier {
        long now = 1000;

        long nowMs() {
            return now;
        }

        void advance(long ms) {
            now += ms;
        }

        @Override
        public long getAsLong() {
            return now;
        }
    }
}
