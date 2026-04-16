package org.cagnulein.qzcompanionnordictracktreadmill;

import android.content.Intent;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.robolectric.Robolectric;
import org.robolectric.RobolectricTestRunner;
import org.robolectric.android.controller.ServiceController;
import org.robolectric.annotation.Config;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.catalog.S15iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.catalog.X11iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

import static org.junit.Assert.*;

/**
 * End-to-end Robolectric tests for UDPListenerService.
 *
 * These tests exercise the full pipeline:
 *   real UDP datagram → service receive loop → CommandDispatcher → Device.execute()
 *
 * Android framework classes (PowerManager, WifiManager, SharedPreferences) are
 * provided by Robolectric shadows — no physical device or emulator needed.
 */
@RunWith(RobolectricTestRunner.class)
@Config(sdk = 34)
public class UDPListenerServiceTest {

    private ServiceController<UDPListenerService> controller;
    private String lastCommand;

    @Before
    public void setUp() {
        lastCommand = null;
    }

    @After
    public void tearDown() {
        Device.instance = null;
        if (controller != null) {
            try { controller.destroy(); } catch (Exception ignored) {}
        }
    }

    // ── Lifecycle ─────────────────────────────────────────────────────────────

    @Test
    public void serviceCreates_withoutThrowingExceptions() {
        controller = Robolectric.buildService(UDPListenerService.class);
        assertNotNull(controller.create().get());
    }

    @Test
    public void serviceStarts_withoutThrowingExceptions() {
        controller = Robolectric.buildService(UDPListenerService.class);
        UDPListenerService svc = controller.create().startCommand(0, 1).get();
        assertNotNull(svc);
    }

    @Test
    public void serviceDestroysCleanly() {
        controller = Robolectric.buildService(UDPListenerService.class);
        controller.create().startCommand(0, 1).destroy();
        // No exception = pass
    }

    // ── Full UDP pipeline ─────────────────────────────────────────────────────

    @Test
    public void treadmill_udpMessage_producesExpectedSwipe() throws Exception {
        // X11i: speed 8.0 km/h from a moving device (5.0 km/h current)
        // Expected: input swipe 1207 600 1207 447 200
        X11iDevice x11i = new X11iDevice();
        x11i.lastSnapshot = new MetricSnapshot.Builder().speedKmh(5.0f).build();
        CountDownLatch latch = new CountDownLatch(1);
        x11i.commandExecutor = cmd -> { lastCommand = cmd; latch.countDown(); };
        Device.instance = x11i;

        controller = Robolectric.buildService(UDPListenerService.class);
        controller.create().startCommand(0, 1);

        sendUdp("8.0;3.0");

        assertTrue("swipe command should arrive within 3 s", latch.await(3, TimeUnit.SECONDS));
        assertEquals("input swipe 1207 600 1207 447 200", lastCommand);
    }

    @Test
    public void bike_udpMessage_producesExpectedSwipe() throws Exception {
        // S15i: resistance level 10 from a stopped device
        // Expected: input swipe 1848 790 1848 559 200
        S15iDevice s15i = new S15iDevice();  // lastSnapshot defaults to empty (stopped)
        CountDownLatch latch = new CountDownLatch(1);
        s15i.commandExecutor = cmd -> { lastCommand = cmd; latch.countDown(); };
        Device.instance = s15i;

        controller = Robolectric.buildService(UDPListenerService.class);
        controller.create().startCommand(0, 1);

        sendUdp("10.0");

        assertTrue("swipe command should arrive within 3 s", latch.await(3, TimeUnit.SECONDS));
        assertEquals("input swipe 1848 790 1848 559 200", lastCommand);
    }

    @Test
    public void noDevice_selected_noCommandProduced() throws Exception {
        // When currentDevice is null the service should silently drop the message.
        Device.instance = null;
        CountDownLatch latch = new CountDownLatch(1);

        controller = Robolectric.buildService(UDPListenerService.class);
        controller.create().startCommand(0, 1);

        sendUdp("8.0;3.0");

        // Give the service a moment to process (or not).
        assertFalse("no command should be generated when device is null",
                    latch.await(500, TimeUnit.MILLISECONDS));
        assertNull(lastCommand);
    }

    @Test
    public void sentinel_message_noCommandProduced() throws Exception {
        // "-1;-100" is the all-sentinel message — no values to apply.
        X11iDevice x11i2 = new X11iDevice();
        x11i2.lastSnapshot = new MetricSnapshot.Builder().speedKmh(5.0f).build();
        CountDownLatch latch = new CountDownLatch(1);
        x11i2.commandExecutor = cmd -> { lastCommand = cmd; latch.countDown(); };
        Device.instance = x11i2;

        controller = Robolectric.buildService(UDPListenerService.class);
        controller.create().startCommand(0, 1);

        sendUdp("-1;-100");

        assertFalse("no command should be generated for sentinels",
                    latch.await(500, TimeUnit.MILLISECONDS));
        assertNull(lastCommand);
    }

    // ── helpers ───────────────────────────────────────────────────────────────

    /**
     * Sends a single UDP datagram to the service's listen port (8003) on loopback.
     * A brief sleep before sending gives the service thread time to bind its socket.
     */
    private static void sendUdp(String message) throws Exception {
        // Wait for the service's background thread to open its DatagramSocket.
        Thread.sleep(200);

        try (DatagramSocket sender = new DatagramSocket()) {
            byte[] data = message.getBytes("UTF-8");
            sender.send(new DatagramPacket(
                    data, data.length,
                    InetAddress.getLoopbackAddress(), 8003));
        }
    }
}
