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

import java.io.File;
import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

public class QZService extends Service {
    private static final String LOG_TAG = "QZ:Service";
    int startMode;       // indicates how to behave if the service is killed
    IBinder binder;      // interface for clients that bind
    boolean allowRebind; // indicates whether onRebind should be used    
    static int clientPort = 8002;
    Handler handler = new Handler();
    Runnable runnable = null;
    static DatagramSocket socket = null;

    byte[] lmessage = new byte[1024];
    DatagramPacket packet = new DatagramPacket(lmessage, lmessage.length);
    static InetAddress broadcastAddress = null;

    boolean firstTime = false;
    static SharedPreferences sharedPreferences;

    private final DeviceState state = DeviceState.INSTANCE;

    boolean ifit_v2 = false;

    private final ShellRuntime shellRuntime = new ShellRuntime();

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

        try {
            runnable = new Runnable() {
                @Override
                public void run() {
                    writeLog( "Service run");
                    if(sharedPreferences.getBoolean("OCR", false)) {
                        getOCR();
                        handler.postDelayed(runnable, 100);
                    }
                    else
                        parse();
                }
            };
        } finally {
            if(socket != null){
                socket.close();
                writeLog("socket.close()");
            }
        }

        if(runnable != null) {
            writeLog( "Service postDelayed");
            handler.postDelayed(runnable, 100);
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
                            state.lastSnapshot.watts = (float) w;
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
        if (file.isEmpty()) return;

        try {
            socket = new DatagramSocket();
            socket.setBroadcast(true);
            writeLog("Device: " + (state.currentDevice != null ? state.currentDevice.displayName() : "none"));

            MetricReader reader = sharedPreferences.getBoolean("ADBLog", false)
                    ? new DirectLogcatMetricReader()
                    : state.currentDevice.defaultMetricReader(ifit_v2);

            applyAndBroadcast(reader.read(file, shellRuntime));
        } catch (Exception ex) {
            ex.printStackTrace();
            return;
        }
        socket.close();
        handler.postDelayed(runnable, 100);
    }

    private void applySnapshot(MetricSnapshot m) {
        if (m.speedKmh      != null) state.lastSnapshot.speedKmh      = m.speedKmh;
        if (m.inclinePct    != null) state.lastSnapshot.inclinePct    = m.inclinePct;
        if (m.resistanceLvl != null) state.lastSnapshot.resistanceLvl = m.resistanceLvl;
        if (m.cadenceRpm    != null) state.lastSnapshot.cadenceRpm    = m.cadenceRpm;
        if (m.watts         != null) state.lastSnapshot.watts         = m.watts;
        if (m.gearLevel     != null) state.lastSnapshot.gearLevel     = m.gearLevel;
        if (m.heartRate     != null) state.lastSnapshot.heartRate     = m.heartRate;
    }

    private void broadcastLastKnown() {
        if (state.lastSnapshot.speedKmh      != null) sendBroadcast("Changed KPH "         + state.lastSnapshot.speedKmh);
        if (state.lastSnapshot.inclinePct    != null) sendBroadcast("Changed Grade "       + state.lastSnapshot.inclinePct);
        if (state.lastSnapshot.watts         != null) sendBroadcast("Changed Watts "       + state.lastSnapshot.watts.intValue());
        if (state.lastSnapshot.cadenceRpm    != null) sendBroadcast("Changed RPM "         + state.lastSnapshot.cadenceRpm);
        if (state.lastSnapshot.gearLevel     != null) sendBroadcast("Changed CurrentGear " + state.lastSnapshot.gearLevel);
        if (state.lastSnapshot.resistanceLvl != null) sendBroadcast("Changed Resistance "  + state.lastSnapshot.resistanceLvl);
        if (state.lastSnapshot.heartRate     != null) sendBroadcast("HeartRateDataUpdate " + state.lastSnapshot.heartRate.intValue());
    }

    private void applyAndBroadcast(MetricSnapshot m) {
        applySnapshot(m);
        broadcastLastKnown();
    }

    public static void sendBroadcast(String messageStr) {
        try {
            socket = new DatagramSocket();
            socket.setBroadcast(true);

            StrictMode.ThreadPolicy policy = new   StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);

            if (broadcastAddress == null) {
                Log.e(LOG_TAG, "Broadcast address is null, cannot send packet");
                return;
            }

            byte[] sendData = messageStr.getBytes();
            DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, broadcastAddress, clientPort);
            socket.send(sendPacket);

            socket.close();
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
        // The service is no longer used and is being destroyed
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
