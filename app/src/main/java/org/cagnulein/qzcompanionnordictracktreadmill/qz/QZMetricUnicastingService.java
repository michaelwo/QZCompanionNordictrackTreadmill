package org.cagnulein.qzcompanionnordictracktreadmill.qz;

import org.cagnulein.qzcompanionnordictracktreadmill.ui.MainActivity;

import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.net.DhcpInfo;
import android.net.wifi.WifiManager;
import android.os.IBinder;
import android.os.StrictMode;
import android.util.Log;

import org.cagnulein.qzcompanionnordictracktreadmill.console.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.console.MonoStdoutMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

public class QZMetricUnicastingService extends Service {
    private static final String LOG_TAG = "QZ:MetricReaderService";
    IBinder binder;
    boolean allowRebind;
    /** UDP port on the QZ host that receives unicast metric updates. */
    static final int UNICAST_PORT = 8002;

    private static final StrictMode.ThreadPolicy PERMIT_ALL =
            new StrictMode.ThreadPolicy.Builder().permitAll().build();

    /** MonoStdout reader — started once in onCreate, runs for the lifetime of the service. */
    private MetricReader cachedReader = null;

    /** Singleton pointer — set in onCreate, cleared in onDestroy. */
    private static volatile QZMetricUnicastingService instance;

    /** Subscriber that receives decoded slider metrics. Set by DeviceController via setSubscriber(). */
    private volatile QZMetricSubscriber subscriber = null;

    /** LAN broadcast address computed once at startup; used when QZ has not yet been discovered. */
    private static InetAddress broadcastAddress = null;

    /** Persistent send socket — reused across all unicast/broadcast sends. Null forces re-creation. */
    private static volatile DatagramSocket persistentSocket = null;

    @Override
    public void onCreate() {
        instance = this;
        broadcastAddress = computeBroadcastAddress();
        writeLog("Service onCreate");
        applyDeviceInternal();
    }

    public static void setSubscriber(QZMetricSubscriber s) {
        if (instance != null) instance.subscriber = s;
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

    private void applyDeviceInternal() {
        cachedReader = new MonoStdoutMetricReader();
        MonoStdoutMetricReader.onError = e -> Log.e(LOG_TAG, "mono-stdout stream error", e);
        MonoStdoutMetricReader.onLine  = line -> writeLog("ifit: " + line);
        cachedReader.subscribe(this::applyAndUnicast);
        writeLog("Metric reader: streaming active");
        try { cachedReader.read(); } catch (IOException e) { Log.e(LOG_TAG, "stream start failed", e); }
    }

    private void applyAndUnicast(QZMetricPacket packet) {
        String msg = packet.serialize();
        logMetric(msg);
        sendUnicast(msg);
        SliderMetric sliderMetric = SliderMetric.from(packet.metric);
        if (sliderMetric != null && subscriber != null)
            subscriber.onMetric(sliderMetric, packet.value);
    }

    private static void logMetric(String msg) {
        if (MainActivity.isDebugLog()) {
            MainActivity.writeLog(msg);
            Log.i(LOG_TAG, msg);
        }
    }

    public static void sendUnicast(String messageStr) {
        InetAddress target = QZCommandListenerService.qzAddress;
        long lastHb = QZCommandListenerService.lastQzHeartbeatMs;
        boolean qzActive = target != null && lastHb > 0
                && (System.currentTimeMillis() - lastHb) <= QZCommandListenerService.QZ_HEARTBEAT_TIMEOUT_MS;

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
