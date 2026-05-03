package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import org.cagnulein.qzcompanionnordictracktreadmill.MainActivity;

import android.app.Service;
import android.content.Context;
import android.content.Intent;
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

public class MetricReaderUnicastingService extends Service {
    private static final String LOG_TAG = "QZ:MetricReaderService";
    IBinder binder;
    boolean allowRebind;
    /** UDP port on the QZ host that receives unicast metric updates. */
    static final int UNICAST_PORT = 8002;

    private static final StrictMode.ThreadPolicy PERMIT_ALL =
            new StrictMode.ThreadPolicy.Builder().permitAll().build();

    /** Current reader; replaced on every device switch via {@link #applyDevice(Device)}. */
    private MetricReader cachedReader = null;

    /** Singleton pointer — set in onCreate, cleared in onDestroy. */
    private static volatile MetricReaderUnicastingService instance;

    /** LAN broadcast address computed once at startup; used when QZ has not yet been discovered. */
    private static InetAddress broadcastAddress = null;

    /** Persistent send socket — reused across all unicast/broadcast sends. Null forces re-creation. */
    private static volatile DatagramSocket persistentSocket = null;

    @Override
    public void onCreate() {
        instance = this;
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

    private void applyAndUnicast(QZMetricPacket packet) {
        String msg = packet.serialize();
        logMetric(msg);
        sendUnicast(msg);
        SliderMetric sliderMetric = toSliderMetric(packet.metric);
        if (sliderMetric != null && Device.instance != null)
            Device.instance.applyMetric(sliderMetric, packet.value);
    }

    private static SliderMetric toSliderMetric(QZMetricPacket.Metric m) {
        switch (m) {
            case KPH:          return SliderMetric.KPH;
            case GRADE:        return SliderMetric.GRADE;
            case RESISTANCE:   return SliderMetric.RESISTANCE;
            case CURRENT_GEAR: return SliderMetric.CURRENT_GEAR;
            default:           return null;
        }
    }

    private static void logMetric(String msg) {
        if (MainActivity.isDebugLog()) {
            MainActivity.writeLog(msg);
            Log.i(LOG_TAG, msg);
        }
    }

    public static void sendUnicast(String messageStr) {
        InetAddress target = CommandListenerService.qzAddress;
        long lastHb = CommandListenerService.lastQzHeartbeatMs;
        boolean qzActive = target != null && lastHb > 0
                && (System.currentTimeMillis() - lastHb) <= CommandListenerService.QZ_HEARTBEAT_TIMEOUT_MS;

        InetAddress dest = qzActive ? target : broadcastAddress;
        if (dest == null) return;

        StrictMode.setThreadPolicy(PERMIT_ALL);

        try {
            DatagramSocket s = getSocket();
            byte[] sendData = messageStr.getBytes();
            s.send(new DatagramPacket(sendData, sendData.length, dest, UNICAST_PORT));
        } catch (IOException e) {
            Log.e(LOG_TAG, "IOException: " + e.getMessage());
            persistentSocket = null;
        }
    }

    private static synchronized DatagramSocket getSocket() throws java.net.SocketException {
        if (persistentSocket == null || persistentSocket.isClosed()) {
            persistentSocket = new DatagramSocket();
            persistentSocket.setBroadcast(true);
        }
        return persistentSocket;
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

    private static void writeLog(String msg) {
        if (MainActivity.isDebugLog()) {
            MainActivity.writeLog(msg);
            Log.i(LOG_TAG, msg);
            sendUnicast(msg);
        }
    }
}
