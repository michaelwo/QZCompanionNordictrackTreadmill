package org.cagnulein.qzcompanionnordictracktreadmill;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.dispatch.CommandDispatcher;
import org.cagnulein.qzcompanionnordictracktreadmill.dispatch.UDPReceiveLoop;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.text.DecimalFormatSymbols;
import java.util.Locale;
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
public class UDPListenerService extends Service {
    private static final String LOG_TAG = "QZ:UDP";

    static String UDP_BROADCAST = "UDPBroadcast";

    static DatagramSocket socket;

    static SharedPreferences sharedPreferences;

    private CommandDispatcher dispatcher;
    private UDPReceiveLoop receiveLoop;
    private PowerManager.WakeLock wakeLock;

    private void writeLog(String command) {
        if (sharedPreferences.getBoolean("debugLog", false)) {
            MainActivity.writeLog(command);
            Log.i(LOG_TAG, command);
            QZService.sendBroadcast(command);
        }
    }

    private void listenAndWaitAndThrowIntent(InetAddress broadcastIP, Integer port) throws Exception {
        if (socket == null || socket.isClosed()) {
            DecimalFormatSymbols symbols = new DecimalFormatSymbols(Locale.getDefault());
            char decimalSeparator = symbols.getDecimalSeparator();
            socket = new DatagramSocket(port);
            socket.setBroadcast(true);
            receiveLoop = new UDPReceiveLoop(dispatcher, decimalSeparator);
        }

        writeLog("Waiting for UDP broadcast");

        wakeLock.acquire(10_000L); // 10-second timeout — auto-releases if receive hangs
        try {
            Device currentDevice = Device.instance;
            if (currentDevice != null) {
                receiveLoop.receiveOne(socket, currentDevice, currentDevice.lastSnapshot);
            } else {
                // No device selected yet — receive and discard the packet.
                byte[] buf = new byte[15000];
                socket.receive(new DatagramPacket(buf, buf.length));
                writeLog("Packet discarded: no device selected");
            }
        } finally {
            if (wakeLock.isHeld()) wakeLock.release();
        }
    }

    private void broadcastIntent(String senderIP, String message) {
        Intent intent = new Intent(UDPListenerService.UDP_BROADCAST);
        intent.putExtra("sender", senderIP);
        intent.putExtra("message", message);
        sendBroadcast(intent);
    }

    Thread UDPBroadcastThread;

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

    void startListenForUDPBroadcast() {
        UDPBroadcastThread = new Thread(new Runnable() {
            public void run() {
				{					
					try {
						InetAddress broadcastIP = getBroadcastAddress();
						Integer port = 8003;
						while (shouldRestartSocketListen) {
							listenAndWaitAndThrowIntent(broadcastIP, port);
						}
						//if (!shouldListenForUDPBroadcast) throw new ThreadDeath();
					} catch (Exception e) {
                        writeLog("no longer listening for UDP broadcasts cause of error " + e.getMessage());
					}
				}
            }
        });
        UDPBroadcastThread.start();
    }

    private volatile boolean shouldRestartSocketListen = true;

    void stopListen() {
        shouldRestartSocketListen = false;
        socket.close();
    }

    @Override
    public void onCreate() {
        sharedPreferences = getSharedPreferences("QZ",MODE_PRIVATE);
        dispatcher = new CommandDispatcher(this::writeLog);
        PowerManager powerManager = (PowerManager) getSystemService(POWER_SERVICE);
        wakeLock = powerManager.newWakeLock(PowerManager.PARTIAL_WAKE_LOCK, "QZCompanion::UDPListener");
        Log.i(LOG_TAG, "QZCompanion starting, listening on UDP port 8003");
        Log.i(LOG_TAG, "Device: " + (Device.instance != null ? Device.instance.displayName() : "none selected"));
    }

    @Override
    public void onDestroy() {
        stopListen();
    }


    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        shouldRestartSocketListen = true;
        startListenForUDPBroadcast();
        Log.i(LOG_TAG, "UDP listener started on port 8003");
        writeLog("Service started");
        return START_STICKY;
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }
}
