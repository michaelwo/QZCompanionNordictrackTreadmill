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
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.S22iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.X11iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

import static org.junit.Assert.*;

/**
 * Robolectric integration tests for multi-grade Zwift ride sequences.
 *
 * These tests send multiple UDP messages through the live UDPListenerService
 * socket, verifying that the full pipeline — service receive loop →
 * CommandDispatcher → Device.applyCommand() → Device.swipe() — produces
 * the correct swipe chain across throttle window boundaries.
 *
 * Unlike ZwiftRideSimulationTest (which injects time), these tests use real
 * wall-clock time and real UDP sockets, so throttle behavior is exercised as
 * it will run on the device.  Messages are spaced 600ms apart — just outside
 * the 500ms throttle window — so every grade change should produce a swipe.
 *
 * S22i formula: x=75, y2 = (int)(616.18 - 17.223 * (grade > 3.0 ? grade + 0.5 : grade))
 */
@RunWith(RobolectricTestRunner.class)
@Config(sdk = 34)
public class ZwiftRideRobolectricTest {

    private ServiceController<UDPListenerService> controller;
    private final List<String> commands = new ArrayList<>();

    @Before
    public void setUp() { commands.clear(); }

    @After
    public void tearDown() {
        Device.instance = null;
        if (controller != null) {
            try { controller.destroy(); } catch (Exception ignored) {}
        }
    }

    // ── helpers ───────────────────────────────────────────────────────────────

    private static int targetY(float grade) {
        return (int) (616.18 - 17.223 * (grade > 3.0f ? grade + 0.5f : grade));
    }

    private static String swipe(int y1, int y2) {
        return "input swipe 75 " + y1 + " 75 " + y2 + " 200";
    }

    /**
     * Sends a UDP grade change to port 8003 on loopback and waits 600ms.
     * The 600ms gap ensures each message arrives outside the 500ms throttle window.
     */
    private static void sendGrade(float grade) throws Exception {
        try (DatagramSocket sender = new DatagramSocket()) {
            String msg = grade + ";0";
            byte[] data = msg.getBytes("UTF-8");
            sender.send(new DatagramPacket(
                    data, data.length,
                    InetAddress.getLoopbackAddress(), 8003));
        }
        Thread.sleep(600);
    }

    /** Starts the service and waits for its socket to open. */
    private void startService() throws InterruptedException {
        controller = Robolectric.buildService(UDPListenerService.class);
        controller.create().startCommand(0, 1);
        Thread.sleep(200);  // allow background thread to bind its DatagramSocket
    }

    // ── tests ─────────────────────────────────────────────────────────────────

    /**
     * Three grade changes spaced 600ms apart (outside the 500ms throttle window).
     * Each should produce exactly one swipe, and y1 of each swipe must match y2
     * of the previous — confirming the Slider's thumbY state is maintained end-to-end
     * through the service socket layer.
     */
    @Test
    public void s22i_threeGradeChanges_correctSwipeChain() throws Exception {
        S22iDevice device = new S22iDevice();
        CountDownLatch latch = new CountDownLatch(3);
        device.commandExecutor = cmd -> { commands.add(cmd); latch.countDown(); };
        Device.instance = device;

        startService();

        float[] grades = {5f, 10f, 0f};
        for (float g : grades) {
            sendGrade(g);
        }

        assertTrue("all 3 swipes should arrive within 5s", latch.await(5, TimeUnit.SECONDS));
        assertEquals(3, commands.size());

        int y1 = 618;
        for (int i = 0; i < grades.length; i++) {
            int y2 = targetY(grades[i]);
            assertEquals("swipe " + i + " (grade " + grades[i] + "%)", swipe(y1, y2), commands.get(i));
            y1 = y2;
        }
    }

    /**
     * Sends the same grade twice through the service.  The second message should
     * be suppressed by de-dup (same value as lastApplied), producing only one swipe.
     */
    @Test
    public void s22i_duplicateGrade_onlyOneSwipeFires() throws Exception {
        S22iDevice device = new S22iDevice();
        CountDownLatch firstSwipe = new CountDownLatch(1);
        device.commandExecutor = cmd -> { commands.add(cmd); firstSwipe.countDown(); }
        Device.instance = device;

        startService();

        sendGrade(7f);
        assertTrue("first swipe should arrive", firstSwipe.await(3, TimeUnit.SECONDS));

        // Send the same grade again — should be de-duped
        CountDownLatch secondSwipe = new CountDownLatch(1);
        Device.instance.commandExecutor = cmd -> { commands.add(cmd); secondSwipe.countDown(); };
        sendGrade(7f);

        assertFalse("duplicate grade should be suppressed by de-dup",
                secondSwipe.await(400, TimeUnit.MILLISECONDS));
        assertEquals("exactly one swipe expected", 1, commands.size());
    }

    /**
     * Sends a "-1;-100" sentinel through the real service socket.
     * No swipe should be produced.
     */
    @Test
    public void s22i_sentinelMessage_noSwipeFires() throws Exception {
        S22iDevice device = new S22iDevice();
        CountDownLatch latch = new CountDownLatch(1);
        device.commandExecutor = cmd -> { commands.add(cmd); latch.countDown(); };
        Device.instance = device;

        startService();
        Thread.sleep(200);

        try (DatagramSocket sender = new DatagramSocket()) {
            byte[] data = "-1;-100".getBytes("UTF-8");
            sender.send(new DatagramPacket(data, data.length,
                    InetAddress.getLoopbackAddress(), 8003));
        }

        assertFalse("sentinel should produce no swipe", latch.await(500, TimeUnit.MILLISECONDS));
        assertTrue(commands.isEmpty());
    }

    /**
     * No device selected — service should silently discard the packet.
     */
    @Test
    public void noDevice_messageDiscarded() throws Exception {
        Device.instance = null;
        // No device selected — no executor to configure; any dispatch would be discarded.
        CountDownLatch latch = new CountDownLatch(1);

        startService();
        Thread.sleep(200);

        try (DatagramSocket sender = new DatagramSocket()) {
            byte[] data = "7.0;0".getBytes("UTF-8");
            sender.send(new DatagramPacket(data, data.length,
                    InetAddress.getLoopbackAddress(), 8003));
        }

        assertFalse("no swipe expected when device is null", latch.await(500, TimeUnit.MILLISECONDS));
        assertTrue(commands.isEmpty());
    }

    /**
     * Treadmill (X11i) through the service: one speed+incline message, device must
     * be moving (speed > 0) for the speed gate to allow through.
     * Expected: input swipe 1207 600 1207 447 200
     */
    @Test
    public void x11i_speedMessage_producesExpectedSwipe() throws Exception {
        X11iDevice x11i = new X11iDevice();
        x11i.lastSnapshot = new MetricSnapshot.Builder().speedKmh(5.0f).build();
        CountDownLatch latch = new CountDownLatch(1);
        x11i.commandExecutor = cmd -> { commands.add(cmd); latch.countDown(); };
        Device.instance = x11i;

        startService();
        Thread.sleep(200);

        try (DatagramSocket sender = new DatagramSocket()) {
            byte[] data = "8.0;3.0".getBytes("UTF-8");
            sender.send(new DatagramPacket(data, data.length,
                    InetAddress.getLoopbackAddress(), 8003));
        }

        assertTrue("swipe should arrive within 3s", latch.await(3, TimeUnit.SECONDS));
        assertEquals(1, commands.size());
        assertEquals("input swipe 1207 600 1207 447 200", commands.get(0));
    }
}
