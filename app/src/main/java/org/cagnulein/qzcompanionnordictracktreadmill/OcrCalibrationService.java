package org.cagnulein.qzcompanionnordictracktreadmill;

import android.app.Service;
import android.content.Intent;
import android.graphics.Rect;
import android.os.Handler;
import android.os.IBinder;
import android.util.Log;

import org.cagnulein.qzcompanionnordictracktreadmill.ocr.Ocr;
import org.cagnulein.qzcompanionnordictracktreadmill.ocr.OcrBlock;
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

    /**
     * Remembers where on screen the watt value appeared so it can be recovered
     * in frames where OCR misses it. Keeps the Android Rect dependency out of Ocr,
     * which must stay pure-Java for unit testing.
     */
    private static class WattRectFallback {
        private Rect cache = null;

        void update(OcrBlock[] blocks, Float watts) {
            if (watts == null) return;
            for (int i = 1; i < blocks.length; i++) {
                if (blocks[i].text.toLowerCase().contains("watt")) {
                    Rect r = rectFromString(blocks[i - 1].rectString);
                    if (r != null) { cache = r; return; }
                }
            }
        }

        Float tryRecover(OcrBlock[] blocks) {
            if (cache == null) return null;
            int expandedWidth = (int) (cache.width() * 1.5);
            int expandedLeft  = cache.left - (expandedWidth - cache.width()) / 2;
            Rect expanded = new Rect(expandedLeft, cache.top, expandedLeft + expandedWidth, cache.bottom);
            for (OcrBlock block : blocks) {
                Rect r = rectFromString(block.rectString);
                if (r != null && Rect.intersects(expanded, r)) {
                    try {
                        String[] numbers = block.text.trim().replaceAll("[^0-9]", " ").trim().split("\\s+");
                        int w = Integer.parseInt(numbers[numbers.length - 1]);
                        if (w > Ocr.MIN_WATTS) return (float) w;
                    } catch (Exception ignored) {}
                }
            }
            return null;
        }

        private static Rect rectFromString(String str) {
            if (str == null) return null;
            String s = str.replace("Rect(", "").replace(")", "");
            String[] halves = s.split("-");
            if (halves.length != 2) return null;
            String[] lt = halves[0].split(",");
            String[] rb = halves[1].split(",");
            if (lt.length != 2 || rb.length != 2) return null;
            try {
                return new Rect(
                    Integer.parseInt(lt[0].trim()), Integer.parseInt(lt[1].trim()),
                    Integer.parseInt(rb[0].trim()), Integer.parseInt(rb[1].trim()));
            } catch (NumberFormatException e) {
                return null;
            }
        }
    }
}
