package org.cagnulein.qzcompanionnordictracktreadmill.service;

import org.cagnulein.qzcompanionnordictracktreadmill.MainActivity;
import org.cagnulein.qzcompanionnordictracktreadmill.ShellRuntime;

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

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.DirectLogcatMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MonoStdoutMetricReader;

import java.io.File;
import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.function.Consumer;

public class MetricReaderBroadcastingService extends Service {
    private static final String LOG_TAG = "QZ:MetricReaderService";
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

    /** Current reader; replaced on every device switch via {@link #applyDevice(Device)}. */
    private MetricReader cachedReader = null;

    /** Log file and UDP broadcast poll interval. The iFit firmware writes metrics at ~1 Hz;
     *  250 ms gives four reads per source update — fast enough to catch every change while
     *  reducing CPU, shell-exec, and network load by 60% versus the previous 100 ms. */
    private static final int POLL_INTERVAL_MS = 250;

    /** Singleton pointer — set in onCreate, cleared in onDestroy. */
    private static MetricReaderBroadcastingService instance;

    @Override
    public void onCreate() {
        instance = this;
        sharedPreferences = getSharedPreferences("QZ", MODE_PRIVATE);
        try {
            broadcastAddress = getBroadcastAddress();
        } catch (IOException e) {
            Log.e(LOG_TAG, e.getMessage());
        }

        writeLog("Service onCreate");

        runnable = new Runnable() {
            @Override
            public void run() {
                writeLog("Service run");
                pollLogFile();
            }
        };
    }

    /**
     * Called by {@link org.cagnulein.qzcompanionnordictracktreadmill.MainActivity} whenever the
     * user selects a different device. Stops the poll loop (if running), creates the appropriate
     * reader, and either starts the poll loop (pull-based) or subscribes to the reader's push
     * notifications (streaming).
     */
    public static void applyDevice(Device device) {
        if (instance != null) instance.applyDeviceInternal(device);
    }

    private void applyDeviceInternal(Device device) {
        handler.removeCallbacks(runnable);

        cachedReader = sharedPreferences.getBoolean("ADBLog", false)
                ? new DirectLogcatMetricReader()
                : device.defaultMetricReader();
        if (ifit_v2) cachedReader = cachedReader.forIfitV2();

        if (cachedReader instanceof MonoStdoutMetricReader) {
            MonoStdoutMetricReader.onError = e -> Log.e(LOG_TAG, "mono-stdout stream error", e);
        }
        if (cachedReader.subscribe(this::applyAndBroadcast)) {
            writeLog("Device " + device.displayName() + ": streaming reader active");
            try { cachedReader.read(null, shellRuntime); } catch (IOException e) { Log.e(LOG_TAG, "stream start failed", e); }
        } else {
            writeLog("Device " + device.displayName() + ": starting poll loop");
            handler.postDelayed(runnable, POLL_INTERVAL_MS);
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
            applyAndBroadcast(cachedReader.read(file, shellRuntime));
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
        handler.removeCallbacks(runnable);
        cachedReader = null;
        instance = null;
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
