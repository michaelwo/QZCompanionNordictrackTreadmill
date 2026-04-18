package org.cagnulein.qzcompanionnordictracktreadmill;

import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.DhcpInfo;
import android.net.wifi.WifiManager;
import android.os.Handler;
import android.os.IBinder;
import android.os.StrictMode;
import android.util.Log;
import android.graphics.Rect;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.ocr.OcrBlock;
import org.cagnulein.qzcompanionnordictracktreadmill.ocr.Ocr;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.DirectLogcatMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

import java.io.File;
import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.function.Consumer;

public class QZService extends Service {
    private static final String LOG_TAG = "QZ:Service";
    IBinder binder;
    boolean allowRebind;
    static int clientPort = 8002;
    Handler handler = new Handler();
    Runnable runnable = null;

    byte[] lmessage = new byte[1024];
    DatagramPacket packet = new DatagramPacket(lmessage, lmessage.length);
    static InetAddress broadcastAddress = null;

    boolean firstTime = false;
    static SharedPreferences sharedPreferences;

    boolean ifit_v2 = false;

    private final ShellRuntime shellRuntime = new ShellRuntime();

    /** Tracks the last value sent for each metric — only changed values are broadcast. */
    private final MetricSnapshot broadcastedSoFar = new MetricSnapshot();

    /** Log file and UDP broadcast poll interval. The iFit firmware writes metrics at ~1 Hz;
     *  250 ms gives four reads per source update — fast enough to catch every change while
     *  reducing CPU, shell-exec, and network load by 60% versus the previous 100 ms. */
    private static final int POLL_INTERVAL_MS = 250;

    @Override
    public void onCreate() {

        sharedPreferences = getSharedPreferences("QZ",MODE_PRIVATE);
        try {
            broadcastAddress = getBroadcastAddress();
        } catch (IOException e) {
            Log.e(LOG_TAG, e.getMessage());
        }

        // The service is being created
        //Toast.makeText(this, "Service created!", Toast.LENGTH_LONG).show();
        writeLog( "Service onCreate");

        runnable = new Runnable() {
            @Override
            public void run() {
                writeLog( "Service run");
                if(sharedPreferences.getBoolean("OCR", false)) {
                    pollOCR();
                    handler.postDelayed(runnable, POLL_INTERVAL_MS);
                }
                else
                    pollLogFile();
            }
        };

        if(runnable != null) {
            writeLog( "Service postDelayed");
            handler.postDelayed(runnable, POLL_INTERVAL_MS);
        }
    }


    private final WattRectFallback wattFallback = new WattRectFallback();

    private void pollOCR() {
        String textExtended = ScreenCaptureService.getLastTextExtended();
        if (textExtended == null || textExtended.isEmpty()) return;

        OcrBlock[] blocks = Ocr.blocks(textExtended);
        MetricSnapshot ocr = Ocr.extractMetrics(blocks);

        if (ocr.speedKmh      != null) writeLog("OCRlines speed found!");
        if (ocr.inclinePct    != null) writeLog("OCRlines incline found!");
        if (ocr.resistanceLvl != null) writeLog("OCRlines resistance found!");
        if (ocr.cadenceRpm    != null) writeLog("OCRlines cadence found!");
        if (ocr.watts         != null) writeLog("OCRlines watts found!");

        if (Device.instance != null) Device.instance.updateSnapshot(ocr);

        wattFallback.update(blocks, ocr.watts);
        if (ocr.watts == null) {
            Float recovered = wattFallback.tryRecover(blocks);
            if (recovered != null) {
                writeLog("OCRlines watts found with cache!");
                if (Device.instance != null)
                    Device.instance.updateSnapshot(new MetricSnapshot.Builder().watts(recovered).build());
            }
        }

        broadcastLastKnown();
    }

    /**
     * Remembers where on screen the watt value appeared so it can be recovered
     * in frames where OCR misses it.  Keeps the Android Rect dependency out of
     * Ocr, which must stay pure-Java for unit testing.
     */
    private class WattRectFallback {
        private Rect cache = null;

        /**
         * If {@code watts} was just parsed, records the screen rect of the value
         * block that preceded the "watt" label for use as a fallback region later.
         */
        void update(OcrBlock[] blocks, Float watts) {
            if (watts == null) return;
            for (int i = 1; i < blocks.length; i++) {
                if (blocks[i].text.toLowerCase().contains("watt")) {
                    Rect r = rectFromString(blocks[i - 1].rectString);
                    if (r != null) { cache = r; return; }
                }
            }
        }

        /**
         * Tries to recover a watt value when Ocr found none.
         * Expands the cached rect by 50% horizontally and returns the first
         * numeric value above MIN_WATTS found in an intersecting block.
         */
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

        private Rect rectFromString(String str) {
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

    private void pollLogFile() {
        String file = pickLatestFileFromDownloads();
        writeLog("Parsing " + file);
        if (file.isEmpty()) {
            handler.postDelayed(runnable, POLL_INTERVAL_MS);
            return;
        }

        try {
            writeLog("Device: " + (Device.instance != null ? Device.instance.displayName() : "none"));

            MetricReader reader = sharedPreferences.getBoolean("ADBLog", false)
                    ? new DirectLogcatMetricReader()
                    : Device.instance.defaultMetricReader();
            if (ifit_v2) reader = reader.forIfitV2();

            applyAndBroadcast(reader.read(file, shellRuntime));
        } catch (Exception ex) {
            Log.e(LOG_TAG, "parse error: " + ex.getMessage());
        }
        handler.postDelayed(runnable, POLL_INTERVAL_MS);
    }

    private void broadcastLastKnown() {
        if (Device.instance == null) return;
        MetricSnapshot s = Device.instance.lastSnapshot;
        sendIfChanged(s.speedKmh,      broadcastedSoFar.speedKmh,      "Changed KPH ",         v -> broadcastedSoFar.speedKmh      = v);
        sendIfChanged(s.inclinePct,    broadcastedSoFar.inclinePct,    "Changed Grade ",       v -> broadcastedSoFar.inclinePct    = v);
        sendIfChanged(s.cadenceRpm,    broadcastedSoFar.cadenceRpm,    "Changed RPM ",         v -> broadcastedSoFar.cadenceRpm    = v);
        sendIfChanged(s.gearLevel,     broadcastedSoFar.gearLevel,     "Changed CurrentGear ", v -> broadcastedSoFar.gearLevel     = v);
        sendIfChanged(s.resistanceLvl, broadcastedSoFar.resistanceLvl, "Changed Resistance ",  v -> broadcastedSoFar.resistanceLvl = v);
        sendIfChangedInt(s.watts,      broadcastedSoFar.watts,         "Changed Watts ",       v -> broadcastedSoFar.watts         = v);
        sendIfChangedInt(s.heartRate,  broadcastedSoFar.heartRate,     "HeartRateDataUpdate ", v -> broadcastedSoFar.heartRate     = v);
    }

    private void sendIfChanged(Float current, Float last, String label, Consumer<Float> save) {
        if (current != null && !current.equals(last)) {
            sendBroadcast(label + current);
            save.accept(current);
        }
    }

    private void sendIfChangedInt(Float current, Float last, String label, Consumer<Float> save) {
        if (current != null && !current.equals(last)) {
            sendBroadcast(label + current.intValue());
            save.accept(current);
        }
    }

    private void applyAndBroadcast(MetricSnapshot m) {
        if (Device.instance != null) Device.instance.updateSnapshot(m);
        broadcastLastKnown();
    }

    public static void sendBroadcast(String messageStr) {
        if (broadcastAddress == null) {
            Log.e(LOG_TAG, "Broadcast address is null, cannot send packet");
            return;
        }

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        try (DatagramSocket s = new DatagramSocket()) {
            s.setBroadcast(true);
            byte[] sendData = messageStr.getBytes();
            DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, broadcastAddress, clientPort);
            s.send(sendPacket);
        } catch (IOException e) {
            Log.e(LOG_TAG, "IOException: " + e.getMessage());
        }
    }

    InetAddress getBroadcastAddress() throws IOException {
        WifiManager wifi = (WifiManager)    getApplicationContext().getSystemService(Context.WIFI_SERVICE);
        DhcpInfo dhcp = null;
        try {
            dhcp = wifi.getDhcpInfo();
            int broadcast = (dhcp.ipAddress & dhcp.netmask) | ~dhcp.netmask;
            byte[] quads = new byte[4];
            for (int k = 0; k < 4; k++)
                quads[k] = (byte) ((broadcast >> k * 8) & 0xFF);
            return InetAddress.getByAddress(quads);
        } catch (Exception e) {
            writeLog( "IOException: " + e.getMessage());
        }
        byte[] quads = new byte[4];
        return InetAddress.getByAddress(quads);
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        writeLog("Service started");
      
        return START_STICKY;
    }
    @Override
    public IBinder onBind(Intent intent) {
        // A client is binding to the service with bindService()
        return binder;
    }
    @Override
    public boolean onUnbind(Intent intent) {
        // All clients have unbound with unbindService()
        return allowRebind;
    }
    @Override
    public void onRebind(Intent intent) {
        // A client is binding to the service with bindService(),
        // after onUnbind() has already been called
    }
    @Override
    public void onDestroy() {
        if (runnable != null) handler.removeCallbacks(runnable);
    }

    public String pickLatestFileFromDownloads() {
        File file = new File("/sdcard/android/data/com.ifit.glassos_service/files/.valinorlogs/log.latest.txt");
        if (file.exists()) {
            ifit_v2 = true;
            return "/sdcard/android/data/com.ifit.glassos_service/files/.valinorlogs/log.latest.txt";
        } else {
            String ret = pickLatestFileFromDownloadsInternal("/sdcard/.wolflogs/");
            if(ret.equals("")) {
                ret = pickLatestFileFromDownloadsInternal("/.wolflogs/");
                if(ret.equals("")) {
                    ret = pickLatestFileFromDownloadsInternal("/sdcard/eru/");
                    if(ret.equals("")) {
                        ret = pickLatestFileFromDownloadsInternal("/storage/emulated/0/.wolflogs/");
                    }
                }
            }
            return ret;
        }
    }

    public static String pickLatestFileFromDownloadsInternal(String path) {
        File dir = new File(path);
        File[] files = dir.listFiles();
        if (files == null || files.length == 0) {
            writeLog("There is no file in the folder");
            return "";
        }

        File lastModifiedFile = files[0];
        for (int i = 1; i < files.length; i++) {
            if (lastModifiedFile.lastModified() < files[i].lastModified() && (files[i].getName().contains("_logs.txt") || files[i].getName().contains("FitPro_"))) {
                lastModifiedFile = files[i];
            }
        }
        String k = lastModifiedFile.toString();

        writeLog(path);
        writeLog("lastModifiedFile " + lastModifiedFile);
        writeLog("string: " + k);
        return k;

    }

    private static void writeLog(String command) {

        if(sharedPreferences.getBoolean("debugLog", false)) {
            MainActivity.writeLog(command);
            Log.i(LOG_TAG, command);
            sendBroadcast(command);
        }
    }
}
