package org.cagnulein.qzcompanionnordictracktreadmill.command;

import org.cagnulein.qzcompanionnordictracktreadmill.BuildConfig;
import org.cagnulein.qzcompanionnordictracktreadmill.MainActivity;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReaderUnicastingService;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import android.content.SharedPreferences;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.net.DhcpInfo;
import android.net.wifi.WifiManager;
import android.os.IBinder;
import android.os.PowerManager;
import android.util.Log;
import android.widget.TextView;

/*
 * Linux command to send UDP:
 * #socat - UDP-DATAGRAM:192.168.1.255:8002,broadcast,sp=8002
 */
public class CommandListenerService extends Service {
    private static final String LOG_TAG = "QZ:CommandListenerService";

    static String UDP_BROADCAST = "UDPBroadcast";

    /** Wall-clock ms of the last -100;N heartbeat packet from QZ. 0 = never received. */
    public static volatile long lastQzHeartbeatMs = 0;

    /** Source IP of the last QZ heartbeat; null until first heartbeat received. */
    public static volatile java.net.InetAddress qzAddress = null;

    /** Staleness threshold: QZ is considered disconnected after this many ms without a heartbeat. */
    public static final long QZ_HEARTBEAT_TIMEOUT_MS = 30_000;

    /** UDP port this service listens on for incoming QZ commands. */
    public static final int LISTEN_PORT = 8003;

    private static final int UDP_BUFFER_SIZE = 15_000;

    static DatagramSocket socket;

    static SharedPreferences sharedPreferences;

    private CommandDispatcher dispatcher;
    private PowerManager.WakeLock wakeLock;

    private void writeLog(String command) {
        if (sharedPreferences.getBoolean("debugLog", false)) {
            MainActivity.writeLog(command);
            Log.i(LOG_TAG, command);
            MetricReaderUnicastingService.sendUnicast(command);
        }
    }

    private void listenAndWaitAndThrowIntent(Integer port) throws Exception {
        if (socket == null || socket.isClosed()) {
            socket = new DatagramSocket(port);
            socket.setBroadcast(true);
        }

        writeLog("Waiting for UDP packet");

        wakeLock.acquire(10_000L); // 10-second timeout — auto-releases if receive hangs
        try {
            byte[] buf = new byte[UDP_BUFFER_SIZE];
            DatagramPacket pkt = new DatagramPacket(buf, buf.length);
            socket.receive(pkt);
            String msg = new String(pkt.getData(), 0, pkt.getLength()).trim();
            Log.i(LOG_TAG, "rx: " + msg);

            if (msg.startsWith("CALSWIPE:")) {
                handleCalibrationSwipe(msg);
                return;
            }

            Device currentDevice = Device.instance;
            if (currentDevice == null) {
                writeLog("Packet discarded: no device selected");
                return;
            }

            if (msg.equals(QZCommandPacket.END_OF_RIDE)) {
                lastQzHeartbeatMs = 0;
                qzAddress = null;
            } else {
                lastQzHeartbeatMs = System.currentTimeMillis();
                qzAddress = pkt.getAddress();
            }
            dispatcher.dispatch(msg, currentDevice);
        } finally {
            if (wakeLock.isHeld()) wakeLock.release();
        }
    }

    /** Dispatches a raw swipe via AccessibilityService. Format: CALSWIPE:<x>:<from_y>:<to_y> */
    private void handleCalibrationSwipe(String msg) {
        if (!MyAccessibilityService.isConnected()) {
            Log.w(LOG_TAG, "CALSWIPE: accessibility service not connected");
            return;
        }
        try {
            String[] parts = msg.split(":");
            float x     = Float.parseFloat(parts[1]);
            float fromY = Float.parseFloat(parts[2]);
            float toY   = Float.parseFloat(parts[3]);
            MyAccessibilityService.performSwipe(x, fromY, x, toY, 200);
            Log.i(LOG_TAG, "CALSWIPE x=" + (int)x + " " + (int)fromY + "→" + (int)toY);
        } catch (Exception e) {
            Log.e(LOG_TAG, "CALSWIPE parse error: " + e.getMessage());
        }
    }

    private void broadcastIntent(String senderIP, String message) {
        Intent intent = new Intent(CommandListenerService.UDP_BROADCAST);
        intent.putExtra("sender", senderIP);
        intent.putExtra("message", message);
        sendBroadcast(intent);
    }

    Thread UDPListenerThread;

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
            Log.e(LOG_TAG, "IOException: " + e.getMessage());
        }
        byte[] quads = new byte[4];
        return InetAddress.getByAddress(quads);
    }

    void startListenForUDP() {
        UDPListenerThread = new Thread(() -> {
            int port = LISTEN_PORT;
            while (shouldRestartSocketListen) {
                try {
                    listenAndWaitAndThrowIntent(port);
                } catch (Exception e) {
                    Log.e(LOG_TAG, "UDP receive error, continuing: " + e.getMessage());
                }
            }
        });
        UDPListenerThread.start();
    }

    private volatile boolean shouldRestartSocketListen = true;

    void stopListen() {
        shouldRestartSocketListen = false;
        socket.close();
    }

    @Override
    public void onCreate() {
        sharedPreferences = getSharedPreferences("QZ",MODE_PRIVATE);
        dispatcher = new CommandDispatcher();
        PowerManager powerManager = (PowerManager) getSystemService(POWER_SERVICE);
        wakeLock = powerManager.newWakeLock(PowerManager.PARTIAL_WAKE_LOCK, "QZCompanion::UDPListener");
        Log.i(LOG_TAG, "QZCompanion v" + BuildConfig.VERSION_NAME
                + " (" + BuildConfig.VERSION_CODE + ") starting");
        Log.i(LOG_TAG, "Listening on UDP port " + LISTEN_PORT);
        Log.i(LOG_TAG, "Device: " + (Device.instance != null ? Device.instance.displayName() : "none selected"));
    }

    @Override
    public void onDestroy() {
        stopListen();
    }


    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        shouldRestartSocketListen = true;
        startListenForUDP();
        Log.i(LOG_TAG, "UDP listener started on port " + LISTEN_PORT);
        writeLog("Service started");
        return START_STICKY;
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }
}
