package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.C1750Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Elite1000Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Nordictrack2950Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.T65sDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.X11iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.X22iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.X32iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.X9iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Command;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 * Verifies that TreadmillDevice subclasses generate correct "input swipe" commands
 * for speed and incline gestures.
 *
 * Tests install a capturing CommandExecutor so no Android or ADB calls happen.
 */
public class TreadmillDeviceTest {

    /** Captures the last command sent via Device.commandExecutor. */
    private String lastCommand;

    /** Wraps a device to capture its swipe commands into lastCommand. */
    private <T extends Device> T dev(T d) {
        d.commandExecutor = cmd -> lastCommand = cmd;
        return d;
    }

    @Before
    public void installCaptureExecutor() {
        lastCommand = null;
    }

    @After
    public void restoreDefaultExecutor() {
    }

    // ── X11iDevice ────────────────────────────────────────────────────────────
    // speedX=1207, targetSpeedY(v)=(int)(621.997 - 21.785*v), initialSpeedY=600
    // inclineX=75, targetInclineY(v)=(int)(565.491 - 8.44*v), initialInclineY=557

    @Test
    public void x11i_applySpeed_atZero_generatesCorrectSwipe() {
        X11iDevice dev = dev(new X11iDevice());
        dev.applySpeed(0.0);
        // y2=(int)(621.997 - 0) = 621; y1=600
        assertEquals("input swipe 1207 600 1207 621 200", lastCommand);
    }

    @Test
    public void x11i_applySpeed_atTen_generatesCorrectSwipe() {
        X11iDevice dev = dev(new X11iDevice());
        dev.applySpeed(10.0);
        // y2=(int)(621.997 - 217.85) = (int)404.147 = 404; y1=600
        assertEquals("input swipe 1207 600 1207 404 200", lastCommand);
    }

    @Test
    public void x11i_applySpeed_updatesCurrentY() {
        X11iDevice dev = dev(new X11iDevice());
        dev.applySpeed(10.0); // y2=404; currentSpeedY becomes 404
        dev.applySpeed(5.0);  // y2=(int)(621.997 - 108.925) = (int)513.072 = 513; y1=404
        assertEquals("input swipe 1207 404 1207 513 200", lastCommand);
    }

    @Test
    public void x11i_applyIncline_atZero_generatesCorrectSwipe() {
        X11iDevice dev = dev(new X11iDevice());
        dev.applyIncline(0.0);
        // y2=(int)(565.491 - 0) = 565; y1=557
        assertEquals("input swipe 75 557 75 565 200", lastCommand);
    }

    @Test
    public void x11i_applyIncline_atTen_generatesCorrectSwipe() {
        X11iDevice dev = dev(new X11iDevice());
        dev.applyIncline(10.0);
        // y2=(int)(565.491 - 84.4) = (int)481.091 = 481; y1=557
        assertEquals("input swipe 75 557 75 481 200", lastCommand);
    }

    @Test
    public void x11i_applyIncline_updatesCurrentY() {
        X11iDevice dev = dev(new X11iDevice());
        dev.applyIncline(10.0); // y2=481; currentInclineY becomes 481
        dev.applyIncline(5.0);  // y2=(int)(565.491 - 42.2) = (int)523.291 = 523; y1=481
        assertEquals("input swipe 75 481 75 523 200", lastCommand);
    }

    @Test
    public void x11i_isInstanceOfTreadmillDevice() {
        assertTrue(new X11iDevice() instanceof TreadmillDevice);
    }

    @Test
    public void x11i_hasCorrectDisplayName() {
        assertEquals("X11i Treadmill", new X11iDevice().displayName());
    }

    // ── X32iDevice ────────────────────────────────────────────────────────────

    @Test
    public void x32i_isInstanceOfTreadmillDevice() {
        assertTrue(new X32iDevice() instanceof TreadmillDevice);
    }

    @Test
    public void x32i_hasCorrectDisplayName() {
        assertEquals("X32i Treadmill", new X32iDevice().displayName());
    }

    // ── Nordictrack2950Device ─────────────────────────────────────────────────

    @Test
    public void nordictrack2950_isInstanceOfTreadmillDevice() {
        assertTrue(new Nordictrack2950Device() instanceof TreadmillDevice);
    }

    // ── C1750Device ───────────────────────────────────────────────────────────

    @Test
    public void c1750_isInstanceOfTreadmillDevice() {
        assertTrue(new C1750Device() instanceof TreadmillDevice);
    }

    // ── T65sDevice ────────────────────────────────────────────────────────────

    @Test
    public void t65s_isInstanceOfTreadmillDevice() {
        assertTrue(new T65sDevice("T6.5s Treadmill") instanceof TreadmillDevice);
    }

    @Test
    public void t65s_hasCorrectDisplayName() {
        assertEquals("T6.5s Treadmill", new T65sDevice("T6.5s Treadmill").displayName());
    }

    // ── Elite1000Device ───────────────────────────────────────────────────────

    @Test
    public void elite1000_isInstanceOfTreadmillDevice() {
        assertTrue(new Elite1000Device("Elite 1000 Treadmill") instanceof TreadmillDevice);
    }

    @Test
    public void elite1000_hasCorrectDisplayName() {
        assertEquals("Elite 1000 Treadmill", new Elite1000Device("Elite 1000 Treadmill").displayName());
    }

    // ── TreadmillDevice.decodeCommand ─────────────────────────────────────────

    @Test
    public void decodeCommand_twoParts_setsBothFields() {
        Command cmd = new X11iDevice().decodeCommand(new String[]{"8.0", "5.0"}, '.');
        assertEquals(8.0f, cmd.speedKmh,   0.001f);
        assertEquals(5.0f, cmd.inclinePct, 0.001f);
    }

    @Test
    public void decodeCommand_roundsToOneDecimal() {
        Command cmd = new X11iDevice().decodeCommand(new String[]{"8.25", "5.14"}, '.');
        assertEquals(8.3f, cmd.speedKmh,   0.001f);
        assertEquals(5.1f, cmd.inclinePct, 0.001f);
    }

    @Test
    public void decodeCommand_sentinelMinusOne_speed_returnsNull() {
        Command cmd = new X11iDevice().decodeCommand(new String[]{"-1", "5.0"}, '.');
        assertNull(cmd.speedKmh);
        assertEquals(5.0f, cmd.inclinePct, 0.001f);
    }

    @Test
    public void decodeCommand_sentinelMinusOneHundred_incline_returnsNull() {
        Command cmd = new X11iDevice().decodeCommand(new String[]{"8.0", "-100"}, '.');
        assertEquals(8.0f, cmd.speedKmh, 0.001f);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeCommand_bothSentinels_returnsAllNull() {
        Command cmd = new X11iDevice().decodeCommand(new String[]{"-1", "-100"}, '.');
        assertNull(cmd.speedKmh);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeCommand_commaDecimalSeparator_parsesCorrectly() {
        Command cmd = new X11iDevice().decodeCommand(new String[]{"8.5", "3.0"}, ',');
        assertEquals(8.5f, cmd.speedKmh,   0.001f);
        assertEquals(3.0f, cmd.inclinePct, 0.001f);
    }

    @Test
    public void decodeCommand_onePart_returnsAllNull() {
        Command cmd = new X11iDevice().decodeCommand(new String[]{"8.0"}, '.');
        assertNull(cmd.speedKmh);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeCommand_zeroParts_returnsAllNull() {
        Command cmd = new X11iDevice().decodeCommand(new String[]{}, '.');
        assertNull(cmd.speedKmh);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeCommand_threeParts_returnsAllNull() {
        Command cmd = new X11iDevice().decodeCommand(new String[]{"1.0", "2.0", "3.0"}, '.');
        assertNull(cmd.speedKmh);
        assertNull(cmd.inclinePct);
    }

    // ── Speed monotonicity ────────────────────────────────────────────────────

    @Test
    public void x11i_speedY_isMonotonicallyDecreasing() {
        // Higher speed → lower Y (slider moves up = less Y value)
        X11iDevice dev = dev(new X11iDevice());
        dev.applySpeed(5.0);
        int y5 = Integer.parseInt(lastCommand.split(" ")[5]);
        // Reset by using a fresh device
        X11iDevice dev2 = dev(new X11iDevice());
        dev2.applySpeed(10.0);
        int y10 = Integer.parseInt(lastCommand.split(" ")[5]);
        assertTrue("Y at speed=10 should be less than Y at speed=5", y10 < y5);
    }

    @Test
    public void x11i_inclineY_isMonotonicallyDecreasing() {
        // Higher incline → lower Y (slider moves up = less Y value)
        X11iDevice dev = dev(new X11iDevice());
        dev.applyIncline(5.0);
        int y5 = Integer.parseInt(lastCommand.split(" ")[5]);
        X11iDevice dev2 = dev(new X11iDevice());
        dev2.applyIncline(10.0);
        int y10 = Integer.parseInt(lastCommand.split(" ")[5]);
        assertTrue("Y at incline=10 should be less than Y at incline=5", y10 < y5);
    }

    // ── X22iDevice (shell runtime, overrides execute) ─────────────────────────

    @Test
    public void x22i_isInstanceOfTreadmillDevice() {
        assertTrue(new X22iDevice() instanceof TreadmillDevice);
    }

    @Test
    public void x22i_hasCorrectDisplayName() {
        assertEquals("X22i Treadmill", new X22iDevice().displayName());
    }

    // ── X9iDevice ────────────────────────────────────────────────────────────

    @Test
    public void x9i_isInstanceOfTreadmillDevice() {
        assertTrue(new X9iDevice() instanceof TreadmillDevice);
    }

    @Test
    public void x9i_hasCorrectDisplayName() {
        assertEquals("X9i Treadmill", new X9iDevice().displayName());
    }
}
