package org.cagnulein.qzcompanionnordictracktreadmill.service;

import android.app.Service;
import android.content.Intent;
import android.os.Handler;
import android.os.IBinder;
import android.util.Log;

import org.cagnulein.qzcompanionnordictracktreadmill.calibration.Ocr;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.OcrBlock;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.WattRectFallback;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

/**
 * Polls the iFit screen via ScreenCaptureService and logs every metric it reads.
 *
 * Intended for device onboarding and calibration only — not for production rides.
 * Writes to logcat under QZ:OcrCalibration so a calibration script can correlate
 * screen ground-truth against firmware log output to discover a new device's
 * log format and derive swipe formulas.
 *
 * Started when the user grants screen-capture permission (Screen Calibration mode).
 */
public class OcrCalibrationService extends Service {

    private static final String LOG_TAG = "QZ:OcrCalibration";
    private static final int POLL_INTERVAL_MS = 250;

    /** Latest parsed OCR snapshot. Written on every poll; read by CalibrationActivity. */
    public static volatile MetricSnapshot latestReading;

    private final Handler handler = new Handler();
    private Runnable runnable;
    private final WattRectFallback wattFallback = new WattRectFallback();

    @Override
    public void onCreate() {
        runnable = () -> {
            poll();
            handler.postDelayed(runnable, POLL_INTERVAL_MS);
        };
        handler.postDelayed(runnable, POLL_INTERVAL_MS);
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        return START_STICKY;
    }

    @Override
    public void onDestroy() {
        if (runnable != null) handler.removeCallbacks(runnable);
    }

    @Override
    public IBinder onBind(Intent intent) { return null; }

    private void poll() {
        String textExtended = ScreenCaptureService.getLastTextExtended();
        if (textExtended == null || textExtended.isEmpty()) return;

        OcrBlock[] blocks = Ocr.blocks(textExtended);
        MetricSnapshot ocr = Ocr.extractMetrics(blocks);
        latestReading = ocr;

        if (ocr.speedKmh      != null) Log.i(LOG_TAG, "speed="      + ocr.speedKmh);
        if (ocr.inclinePct    != null) Log.i(LOG_TAG, "incline="    + ocr.inclinePct);
        if (ocr.resistanceLvl != null) Log.i(LOG_TAG, "resistance=" + ocr.resistanceLvl);
        if (ocr.cadenceRpm    != null) Log.i(LOG_TAG, "cadence="    + ocr.cadenceRpm);
        if (ocr.watts         != null) Log.i(LOG_TAG, "watts="      + ocr.watts);

        wattFallback.update(blocks, ocr.watts);
        if (ocr.watts == null) {
            Float recovered = wattFallback.tryRecover(blocks);
            if (recovered != null) Log.i(LOG_TAG, "watts(rect)=" + recovered);
        }
    }

}
