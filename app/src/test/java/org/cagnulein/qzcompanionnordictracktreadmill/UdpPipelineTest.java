package org.cagnulein.qzcompanionnordictracktreadmill;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicReference;

/**
 * End-to-end pipeline tests using real UDP datagrams.
 *
 * These tests verify the complete chain:
 *   DatagramSocket.receive() → message string → CommandDispatcher.dispatch()
 *   → Device.parseCommand() → applySpeed/applyResistance → Device.commandExecutor
 *
 * The Android Service layer (PowerManager, WifiManager, lifecycle) is not involved;
 * only the core UDP receive + dispatch logic is exercised.
 *
 * Run via run-tests.sh (pure JVM, no Android SDK required).
 */
public class UdpPipelineTest {

    /** Port used by UDPListenerService in production. */
    private static final int UDP_PORT = 8003;

    private DatagramSocket serverSocket;
    private Thread         listenerThread;
    private String         lastCommand;
    private CommandDispatcher dispatcher;

    @Before
    public void setUp() throws Exception {
        lastCommand = null;
        Device.commandExecutor = cmd -> lastCommand = cmd;
        serverSocket = new DatagramSocket(UDP_PORT);
        dispatcher   = new CommandDispatcher();
    }

    @After
    public void tearDown() {
        Device.commandExecutor = cmd -> {};
        if (listenerThread != null) listenerThread.interrupt();
        if (serverSocket  != null) serverSocket.close();
    }

    // ── helpers ───────────────────────────────────────────────────────────────

    /**
     * Starts a background thread that receives one UDP packet, dispatches it, then
     * signals the latch.  Mirrors the core of UDPListenerService.listenAndWaitAndThrowIntent
     * without the Android PowerManager/WifiManager calls.
     */
    private void startReceiver(Device device, MetricSnapshot current, CountDownLatch latch) {
        listenerThread = new Thread(() -> {
            try {
                byte[] buf = new byte[1024];
                DatagramPacket pkt = new DatagramPacket(buf, buf.length);
                serverSocket.receive(pkt);
                String message = new String(pkt.getData(), 0, pkt.getLength()).trim();
                dispatcher.dispatch(message, '.', device, current);
                latch.countDown();
            } catch (Exception e) {
                // Socket closed by tearDown — normal shutdown path.
            }
        });
        listenerThread.setDaemon(true);
        listenerThread.start();
    }

    /** Sends a UDP datagram to the server socket on loopback. */
    private static void sendUdp(String message) throws Exception {
        try (DatagramSocket sender = new DatagramSocket()) {
            byte[] data = message.getBytes("UTF-8");
            sender.send(new DatagramPacket(
                    data, data.length,
                    InetAddress.getLoopbackAddress(), UDP_PORT));
        }
    }

    // ── treadmill tests ───────────────────────────────────────────────────────

    @Test
    public void treadmill_speedMessage_producesExpectedSwipe() throws Exception {
        // X11i: speed 8.0 km/h from a moving device (5.0 km/h current)
        // Expected: input swipe 1207 600 1207 447 200
        CountDownLatch latch = new CountDownLatch(1);
        MetricSnapshot current = new MetricSnapshot.Builder().speedKmh(5.0f).build();
        startReceiver(new X11iDevice(), current, latch);

        sendUdp("8.0;3.0");

        assertTrue("dispatch should complete within 2 s", latch.await(2, TimeUnit.SECONDS));
        assertEquals("input swipe 1207 600 1207 447 200", lastCommand);
    }

    @Test
    public void treadmill_sentinelMessage_noCommand() throws Exception {
        // "-1;-100" has no actionable values — nothing should be dispatched.
        AtomicReference<String> captured = new AtomicReference<>(null);
        CountDownLatch commandLatch = new CountDownLatch(1);
        Device.commandExecutor = cmd -> { captured.set(cmd); commandLatch.countDown(); };

        MetricSnapshot current = new MetricSnapshot.Builder().speedKmh(5.0f).build();
        startReceiver(new X11iDevice(), current, new CountDownLatch(1));

        sendUdp("-1;-100");

        assertFalse("no swipe expected for sentinels",
                commandLatch.await(400, TimeUnit.MILLISECONDS));
        assertNull(captured.get());
    }

    @Test
    public void treadmill_commaDecimalSeparator_parsesCorrectly() throws Exception {
        // Same expected swipe as the dot-separator test — parsing must handle both.
        CountDownLatch latch = new CountDownLatch(1);
        MetricSnapshot current = new MetricSnapshot.Builder().speedKmh(5.0f).build();

        // Simulate a listener with comma as decimal separator.
        X11iDevice device = new X11iDevice();
        listenerThread = new Thread(() -> {
            try {
                byte[] buf = new byte[1024];
                DatagramPacket pkt = new DatagramPacket(buf, buf.length);
                serverSocket.receive(pkt);
                String message = new String(pkt.getData(), 0, pkt.getLength()).trim();
                dispatcher.dispatch(message, ',', device, current);
                latch.countDown();
            } catch (Exception e) { /* closed */ }
        });
        listenerThread.setDaemon(true);
        listenerThread.start();

        sendUdp("8.0;3.0");

        assertTrue("dispatch should complete within 2 s", latch.await(2, TimeUnit.SECONDS));
        assertEquals("input swipe 1207 600 1207 447 200", lastCommand);
    }

    // ── bike tests ────────────────────────────────────────────────────────────

    @Test
    public void bike_resistanceMessage_producesExpectedSwipe() throws Exception {
        // S15i: resistance 10 → input swipe 1848 790 1848 559 200
        CountDownLatch latch = new CountDownLatch(1);
        startReceiver(new S15iDevice(), new MetricSnapshot(), latch);

        sendUdp("10.0");

        assertTrue("dispatch should complete within 2 s", latch.await(2, TimeUnit.SECONDS));
        assertEquals("input swipe 1848 790 1848 559 200", lastCommand);
    }

    @Test
    public void bike_sentinelResistance_noCommand() throws Exception {
        AtomicReference<String> captured = new AtomicReference<>(null);
        CountDownLatch commandLatch = new CountDownLatch(1);
        Device.commandExecutor = cmd -> { captured.set(cmd); commandLatch.countDown(); };

        startReceiver(new S15iDevice(), new MetricSnapshot(), new CountDownLatch(1));

        sendUdp("-1");

        assertFalse("no swipe expected for -1 sentinel",
                commandLatch.await(400, TimeUnit.MILLISECONDS));
        assertNull(captured.get());
    }
}
