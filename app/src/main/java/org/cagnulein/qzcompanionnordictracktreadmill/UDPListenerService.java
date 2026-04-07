package org.cagnulein.qzcompanionnordictracktreadmill;

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
    private static final String LOG_TAG = "QZ:UDPListenerService";

    static String UDP_BROADCAST = "UDPBroadcast";

    static DatagramSocket socket;

    static SharedPreferences sharedPreferences;

    private final ShellRuntime shellRuntime = new ShellRuntime();
    private CommandDispatcher dispatcher;

    private void writeLog(String command) {
        if (sharedPreferences.getBoolean("debugLog", false)) {
            MainActivity.writeLog(command);
            Log.i(LOG_TAG, command);
            QZService.sendBroadcast(command);
        }
    }

    private void listenAndWaitAndThrowIntent(InetAddress broadcastIP, Integer port) throws Exception {
        PowerManager powerManager = (PowerManager) getSystemService(POWER_SERVICE);
        PowerManager.WakeLock wakeLock = powerManager.newWakeLock(PowerManager.PARTIAL_WAKE_LOCK,
                "MyApp::MyWakelockTag");
        wakeLock.acquire();

        DecimalFormatSymbols symbols = new DecimalFormatSymbols(Locale.getDefault());
        char decimalSeparator = symbols.getDecimalSeparator();

        byte[] recvBuf = new byte[15000];
        if (socket == null || socket.isClosed()) {
            socket = new DatagramSocket(port);
            socket.setBroadcast(true);
        }
        //socket.setSoTimeout(1000);
        DatagramPacket packet = new DatagramPacket(recvBuf, recvBuf.length);
        writeLog("Waiting for UDP broadcast");
        socket.receive(packet);

        String senderIP = packet.getAddress().getHostAddress();
        String message = new String(packet.getData()).trim();

        writeLog("Got UDP broadcast from " + senderIP + ", message: " + message);

        writeLog(message);
        Device currentDevice = DeviceState.INSTANCE.currentDevice;
        if (currentDevice != null) {
            dispatcher.dispatch(message, decimalSeparator, currentDevice, DeviceState.INSTANCE.lastSnapshot);
        }

        broadcastIntent(senderIP, message);
        //socket.close();
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

    private Boolean shouldRestartSocketListen=true;

    void stopListen() {
        shouldRestartSocketListen = false;
        socket.close();
    }

    @Override
    public void onCreate() {
        sharedPreferences = getSharedPreferences("QZ",MODE_PRIVATE);
        dispatcher = new CommandDispatcher(this::writeLog);
    }

    @Override
    public void onDestroy() {
        stopListen();
    }


    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        shouldRestartSocketListen = true;
        startListenForUDPBroadcast();
        writeLog("Service started");
        return START_STICKY;
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }
}
