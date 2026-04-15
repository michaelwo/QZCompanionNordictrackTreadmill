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
import org.cagnulein.qzcompanionnordictracktreadmill.ocr.OcrParser;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.DirectLogcatMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

import java.io.File;
import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

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

    /** Tracks the last value broadcast for each metric — only changed values are sent. */
    private final MetricSnapshot lastBroadcast = new MetricSnapshot();

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
                    getOCR();
                    handler.postDelayed(runnable, POLL_INTERVAL_MS);
                }
                else
                    parse();
            }
        };

        if(runnable != null) {
            writeLog( "Service postDelayed");
            handler.postDelayed(runnable, POLL_INTERVAL_MS);
        }
    }


    private static Rect wattRectCache = null;

    private Rect rectFromString(String str) {
        if (str == null) return null;
        String replaced = str.replace("Rect(", "").replace(")", "");
        String[] parts = replaced.split("-");
        if (parts.length != 2) return null;

        String[] leftTop = parts[0].split(",");
        if (leftTop.length != 2) return null;

        String[] rightBottom = parts[1].split(",");
        if (rightBottom.length != 2) return null;
        
        try {
            int left = Integer.parseInt(leftTop[0].trim());
            int top = Integer.parseInt(leftTop[1].trim());
            int right = Integer.parseInt(rightBottom[0].trim());
            int bottom = Integer.parseInt(rightBottom[1].trim());
            return new Rect(left, top, right, bottom);
        } catch (NumberFormatException e) {
            return null;
        }
    }

    public String[] getOCR() {
        String textExtended = ScreenCaptureService.getLastTextExtended();
        if (textExtended == null || textExtended.isEmpty()) return new String[2];

        Log.i(LOG_TAG, "getOCR");

        MetricSnapshot ocr = OcrParser.parse(textExtended);
        if (ocr.speedKmh      != null) writeLog("OCRlines speed found!");
        if (ocr.inclinePct    != null) writeLog("OCRlines incline found!");
        if (ocr.resistanceLvl != null) writeLog("OCRlines resistance found!");
        if (ocr.cadenceRpm    != null) writeLog("OCRlines cadence found!");
        if (ocr.watts         != null) writeLog("OCRlines watts found!");

        // Apply snapshot to static fields without broadcasting yet.
        applySnapshot(ocr);

        // Watt rect caching — requires Android Rect, kept here rather than in OcrParser.
        String[] ocrBlocks = textExtended.split("§§");
        String[] lines = new String[ocrBlocks.length];
        Rect[] rects = new Rect[ocrBlocks.length];
        for (int i = 0; i < ocrBlocks.length; i++) {
            String[] parts = ocrBlocks[i].split("\\$\\$");
            lines[i] = parts[0];
            rects[i] = parts.length == 2 ? rectFromString(parts[1]) : null;
        }
        for (int i = 1; i < lines.length; i++) {
            writeLog("OCRlines " + i + " " + lines[i]);
            if (lines[i].toLowerCase().contains("watt") && ocr.watts != null && rects[i-1] != null) {
                wattRectCache = rects[i-1];
                writeLog("OCRlines watts rect cached!");
            }
        }
        if (ocr.watts == null && wattRectCache != null) {
            writeLog("OCRlines watts not found, trying with cache");
            int expandedWidth = (int)(wattRectCache.width() * 1.5);
            int expandedLeft  = wattRectCache.left - (expandedWidth - wattRectCache.width()) / 2;
            Rect expandedCache = new Rect(expandedLeft, wattRectCache.top, expandedLeft + expandedWidth, wattRectCache.bottom);
            for (int i = 0; i < lines.length; i++) {
                if (rects[i] != null && Rect.intersects(expandedCache, rects[i])) {
                    try {
                        String[] numbers = lines[i].trim().replaceAll("[^0-9]", " ").trim().split("\\s+");
                        int w = Integer.parseInt(numbers[numbers.length - 1]);
                        if (w > 20) {
                            if (Device.instance != null) Device.instance.lastSnapshot.watts = (float) w;
                            writeLog("OCRlines watts found with cache!");
                        }
                    } catch (Exception ignored) {}
                }
            }
        }

        broadcastLastKnown();
        return new String[2];
    }

    private void parse() {
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
                    : Device.instance.defaultMetricReader(ifit_v2);

            applyAndBroadcast(reader.read(file, shellRuntime));
        } catch (Exception ex) {
            Log.e(LOG_TAG, "parse error: " + ex.getMessage());
        }
        handler.postDelayed(runnable, POLL_INTERVAL_MS);
    }

    private void applySnapshot(MetricSnapshot m) {
        if (Device.instance == null) return;
        MetricSnapshot s = Device.instance.lastSnapshot;
        if (m.speedKmh      != null) s.speedKmh      = m.speedKmh;
        if (m.inclinePct    != null) s.inclinePct    = m.inclinePct;
        if (m.resistanceLvl != null) s.resistanceLvl = m.resistanceLvl;
        if (m.cadenceRpm    != null) s.cadenceRpm    = m.cadenceRpm;
        if (m.watts         != null) s.watts         = m.watts;
        if (m.gearLevel     != null) s.gearLevel     = m.gearLevel;
        if (m.heartRate     != null) s.heartRate     = m.heartRate;
    }

    private void broadcastLastKnown() {
        if (Device.instance == null) return;
        MetricSnapshot s = Device.instance.lastSnapshot;
        if (s.speedKmh      != null && !s.speedKmh.equals(lastBroadcast.speedKmh)) {
            sendBroadcast("Changed KPH "         + s.speedKmh);
            lastBroadcast.speedKmh      = s.speedKmh;
        }
        if (s.inclinePct    != null && !s.inclinePct.equals(lastBroadcast.inclinePct)) {
            sendBroadcast("Changed Grade "       + s.inclinePct);
            lastBroadcast.inclinePct    = s.inclinePct;
        }
        if (s.watts         != null && !s.watts.equals(lastBroadcast.watts)) {
            sendBroadcast("Changed Watts "       + s.watts.intValue());
            lastBroadcast.watts         = s.watts;
        }
        if (s.cadenceRpm    != null && !s.cadenceRpm.equals(lastBroadcast.cadenceRpm)) {
            sendBroadcast("Changed RPM "         + s.cadenceRpm);
            lastBroadcast.cadenceRpm    = s.cadenceRpm;
        }
        if (s.gearLevel     != null && !s.gearLevel.equals(lastBroadcast.gearLevel)) {
            sendBroadcast("Changed CurrentGear " + s.gearLevel);
            lastBroadcast.gearLevel     = s.gearLevel;
        }
        if (s.resistanceLvl != null && !s.resistanceLvl.equals(lastBroadcast.resistanceLvl)) {
            sendBroadcast("Changed Resistance "  + s.resistanceLvl);
            lastBroadcast.resistanceLvl = s.resistanceLvl;
        }
        if (s.heartRate     != null && !s.heartRate.equals(lastBroadcast.heartRate)) {
            sendBroadcast("HeartRateDataUpdate " + s.heartRate.intValue());
            lastBroadcast.heartRate     = s.heartRate;
        }
    }

    private void applyAndBroadcast(MetricSnapshot m) {
        applySnapshot(m);
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
