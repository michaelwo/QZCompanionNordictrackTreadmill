package org.cagnulein.qzcompanionnordictracktreadmill.reader;

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

import org.cagnulein.qzcompanionnordictracktreadmill.command.CommandListenerService;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.function.Consumer;

public class MetricReaderUnicastingService extends Service {
    private static final String LOG_TAG = "QZ:MetricReaderService";
    IBinder binder;
    boolean allowRebind;
    /** UDP port on the QZ host that receives unicast metric updates. */
    static final int UNICAST_PORT = 8002;

    static SharedPreferences sharedPreferences;

    /** Tracks the last value sent for each metric — only changed values are unicast. */
    private final MetricSnapshot unicastedSoFar = new MetricSnapshot();

    /** Current reader; replaced on every device switch via {@link #applyDevice(Device)}. */
    private MetricReader cachedReader = null;

    /** Singleton pointer — set in onCreate, cleared in onDestroy. */
    private static MetricReaderUnicastingService instance;

    /** LAN broadcast address computed once at startup; used when QZ has not yet been discovered. */
    private static InetAddress broadcastAddress = null;

    @Override
    public void onCreate() {
        instance = this;
        sharedPreferences = getSharedPreferences("QZ", MODE_PRIVATE);
        broadcastAddress = computeBroadcastAddress();
        writeLog("Service onCreate");
        if (Device.instance != null) applyDeviceInternal(Device.instance);
    }

    private InetAddress computeBroadcastAddress() {
        try {
            WifiManager wifi = (WifiManager) getApplicationContext().getSystemService(Context.WIFI_SERVICE);
            DhcpInfo dhcp = wifi.getDhcpInfo();
            int bcast = (dhcp.ipAddress & dhcp.netmask) | ~dhcp.netmask;
            byte[] quads = new byte[4];
            for (int k = 0; k < 4; k++) quads[k] = (byte) ((bcast >> k * 8) & 0xFF);
            return InetAddress.getByAddress(quads);
        } catch (Exception e) {
            Log.e(LOG_TAG, "Failed to compute broadcast address: " + e.getMessage());
            return null;
        }
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
        cachedReader.subscribe(this::applyAndUnicast);
        writeLog("Device " + device.displayName() + ": streaming reader active");
        try { cachedReader.read(); } catch (IOException e) { Log.e(LOG_TAG, "stream start failed", e); }
    }

    private void unicastLastKnown() {
        if (Device.instance == null) return;
        MetricSnapshot s = Device.instance.lastSnapshot;
        sendIfChanged(s.speedKmh,      unicastedSoFar.speedKmh,      QZMetricPacket.Metric.KPH,          v -> unicastedSoFar.speedKmh      = v);
        sendIfChanged(s.inclinePct,    unicastedSoFar.inclinePct,    QZMetricPacket.Metric.GRADE,        v -> unicastedSoFar.inclinePct    = v);
        sendIfChanged(s.cadenceRpm,    unicastedSoFar.cadenceRpm,    QZMetricPacket.Metric.RPM,          v -> unicastedSoFar.cadenceRpm    = v);
        sendIfChanged(s.gearLevel,     unicastedSoFar.gearLevel,     QZMetricPacket.Metric.CURRENT_GEAR, v -> unicastedSoFar.gearLevel     = v);
        sendIfChanged(s.resistanceLvl, unicastedSoFar.resistanceLvl, QZMetricPacket.Metric.RESISTANCE,   v -> unicastedSoFar.resistanceLvl = v);
        sendIfChanged(s.watts,         unicastedSoFar.watts,         QZMetricPacket.Metric.WATTS,        v -> unicastedSoFar.watts         = v);
        sendIfChanged(s.heartRate,     unicastedSoFar.heartRate,     QZMetricPacket.Metric.HEART_RATE,   v -> unicastedSoFar.heartRate     = v);
    }

    private void sendIfChanged(Float current, Float last, QZMetricPacket.Metric metric, Consumer<Float> save) {
        if (current != null && !current.equals(last)) {
            String msg = new QZMetricPacket(metric, current).serialize();
            logMetric(msg);
            sendUnicast(msg);
            save.accept(current);
        }
    }

    private static void logMetric(String msg) {
        if (sharedPreferences.getBoolean("debugLog", false)) {
            MainActivity.writeLog(msg);
            Log.i(LOG_TAG, msg);
        }
    }

    private void applyAndUnicast(MetricSnapshot m) {
        if (Device.instance != null) Device.instance.updateSnapshot(m);
        unicastLastKnown();
    }

    public static void sendUnicast(String messageStr) {
        InetAddress target = CommandListenerService.qzAddress;
        long lastHb = CommandListenerService.lastQzHeartbeatMs;
        boolean qzActive = target != null && lastHb > 0
                && (System.currentTimeMillis() - lastHb) <= CommandListenerService.QZ_HEARTBEAT_TIMEOUT_MS;

        InetAddress dest = qzActive ? target : broadcastAddress;
        if (dest == null) return;

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        try (DatagramSocket s = new DatagramSocket()) {
            if (!qzActive) s.setBroadcast(true);
            byte[] sendData = messageStr.getBytes();
            s.send(new DatagramPacket(sendData, sendData.length, dest, UNICAST_PORT));
        } catch (IOException e) {
            Log.e(LOG_TAG, "IOException: " + e.getMessage());
        }
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
            sendUnicast(command);
        }
    }
}
