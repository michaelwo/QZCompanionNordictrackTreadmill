package org.cagnulein.qzcompanionnordictracktreadmill.service;

import org.cagnulein.qzcompanionnordictracktreadmill.MainActivity;

import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.DhcpInfo;
import android.net.wifi.WifiManager;
import android.os.IBinder;
import android.os.StrictMode;
import android.util.Log;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MonoStdoutMetricReader;

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

    byte[] lmessage = new byte[1024];
    DatagramPacket packet = new DatagramPacket(lmessage, lmessage.length);
    static InetAddress broadcastAddress = null;

    static SharedPreferences sharedPreferences;

    /** Tracks the last value sent for each metric — only changed values are broadcast. */
    private final MetricSnapshot broadcastedSoFar = new MetricSnapshot();

    /** Current reader; replaced on every device switch via {@link #applyDevice(Device)}. */
    private MetricReader cachedReader = null;

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

        if (Device.instance != null) applyDeviceInternal(Device.instance);
    }

    /**
     * Called by {@link org.cagnulein.qzcompanionnordictracktreadmill.MainActivity} whenever the
     * user selects a different device. Creates the MonoStdout reader and subscribes to its
     * push notifications.
     */
    public static void applyDevice(Device device) {
        if (instance != null) instance.applyDeviceInternal(device);
    }

    private void applyDeviceInternal(Device device) {
        cachedReader = device.defaultMetricReader();
        MonoStdoutMetricReader.onError = e -> Log.e(LOG_TAG, "mono-stdout stream error", e);
        MonoStdoutMetricReader.onLine  = line -> writeLog("ifit: " + line);
        cachedReader.subscribe(this::applyAndBroadcast);
        writeLog("Device " + device.displayName() + ": streaming reader active");
        try { cachedReader.read(null, null); } catch (IOException e) { Log.e(LOG_TAG, "stream start failed", e); }
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
            String msg = label + current;
            logMetric(msg);
            sendBroadcast(msg);
            save.accept(current);
        }
    }

    private void sendIfChangedInt(Float current, Float last, String label, Consumer<Float> save) {
        if (current != null && !current.equals(last)) {
            String msg = label + current.intValue();
            logMetric(msg);
            sendBroadcast(msg);
            save.accept(current);
        }
    }

    private static void logMetric(String msg) {
        if (sharedPreferences.getBoolean("debugLog", false)) {
            MainActivity.writeLog(msg);
            Log.i(LOG_TAG, msg);
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
        WifiManager wifi = (WifiManager) getApplicationContext().getSystemService(Context.WIFI_SERVICE);
        DhcpInfo dhcp = null;
        try {
            dhcp = wifi.getDhcpInfo();
            int broadcast = (dhcp.ipAddress & dhcp.netmask) | ~dhcp.netmask;
            byte[] quads = new byte[4];
            for (int k = 0; k < 4; k++)
                quads[k] = (byte) ((broadcast >> k * 8) & 0xFF);
            return InetAddress.getByAddress(quads);
        } catch (Exception e) {
            writeLog("IOException: " + e.getMessage());
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
        return binder;
    }

    @Override
    public boolean onUnbind(Intent intent) {
        return allowRebind;
    }

    @Override
    public void onRebind(Intent intent) {
    }

    @Override
    public void onDestroy() {
        cachedReader = null;
        instance = null;
    }

    private static void writeLog(String command) {
        if (sharedPreferences.getBoolean("debugLog", false)) {
            MainActivity.writeLog(command);
            Log.i(LOG_TAG, command);
            sendBroadcast(command);
        }
    }
}
