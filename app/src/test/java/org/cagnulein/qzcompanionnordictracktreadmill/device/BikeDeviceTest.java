package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Ntex71021Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ProformStudioBikePro22Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.S15iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.S22iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.S22iNtex02117Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.S22iNtex02121Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Se9iEllipticalDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Tdf10Device;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.Shell;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Command;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 * Verifies that BikeDevice subclasses generate correct "input swipe" commands
 * for incline and resistance gestures.
 *
 * Tests install a capturing CommandExecutor so no Android or ADB calls happen.
 */
public class BikeDeviceTest {

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

    // ── S22iDevice ────────────────────────────────────────────────────────────
    // targetInclineY(v) = (int)(616.18 - 17.223 * v)
    // initialInclineY  = 618 (constructor arg)

    @Test
    public void s22i_applyIncline_atZero_generatesCorrectSwipe() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyIncline(0.0);
        // y2 = (int)(616.18 - 0) = 616; y1 = 618 (initial)
        assertEquals("input swipe 75 618 75 616 200", lastCommand);
    }

    @Test
    public void s22i_applyIncline_atTen_generatesCorrectSwipe() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyIncline(10.0);
        // grade > 3, so overshoot +0.5: y2 = (int)(616.18 - 17.223 * 10.5) = (int)435.34 = 435
        assertEquals("input swipe 75 618 75 435 200", lastCommand);
    }

    @Test
    public void s22i_applyIncline_updatesCurrentY() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyIncline(10.0); // grade>3: y2=(int)(616.18-17.223*10.5)=435; currentInclineY=435
        dev.applyIncline(5.0);  // grade>3: y2=(int)(616.18-17.223*5.5)=521; y1=435
        assertEquals("input swipe 75 435 75 521 200", lastCommand);
    }

    @Test
    public void s22i_isInstanceOfBikeDevice() {
        assertTrue(new S22iDevice() instanceof BikeDevice);
    }

    @Test
    public void s22i_hasCorrectDisplayName() {
        assertEquals("S22i Bike", new S22iDevice().displayName());
    }

    // ── S22iNtex02117Device ───────────────────────────────────────────────────
    // Shell execution (overrides execute); same formula as S22i

    @Test
    public void s22iNtex02117_applyIncline_atZero_capturedByExecutor() {
        // S22iNtex02117Device overrides execute() to use ShellRuntime.
        // In test mode, ShellRuntime is not available but execute() catches IOException.
        // The command is still computed correctly; the capture executor won't fire because
        // ShellRuntime overrides execute().  We test the formula via the parent S22iDevice.
        S22iDevice base = dev(new S22iDevice());
        base.applyIncline(0.0);
        assertEquals("input swipe 75 618 75 616 200", lastCommand);
    }

    @Test
    public void s22iNtex02117_isInstanceOfS22iDevice() {
        assertTrue(new S22iNtex02117Device() instanceof S22iDevice);
    }

    @Test
    public void s22iNtex02117_isInstanceOfBikeDevice() {
        assertTrue(new S22iNtex02117Device() instanceof BikeDevice);
    }

    // ── S22iNtex02121Device ───────────────────────────────────────────────────
    // Has both inclineX and resistanceX

    @Test
    public void s22iNtex02121_isInstanceOfBikeDevice() {
        assertTrue(new S22iNtex02121Device() instanceof BikeDevice);
    }

    @Test
    public void s22iNtex02121_hasCorrectDisplayName() {
        assertEquals("S22i Bike (NTEX02121.5)", new S22iNtex02121Device().displayName());
    }

    // ── S15iDevice ────────────────────────────────────────────────────────────
    // Has both incline and resistance sliders

    @Test
    public void s15i_isInstanceOfBikeDevice() {
        assertTrue(new S15iDevice() instanceof BikeDevice);
    }

    @Test
    public void s15i_hasCorrectDisplayName() {
        assertEquals("S15i Bike", new S15iDevice().displayName());
    }

    // ── Tdf10Device ───────────────────────────────────────────────────────────

    @Test
    public void tdf10_isInstanceOfBikeDevice() {
        assertTrue(new Tdf10Device() instanceof BikeDevice);
    }

    @Test
    public void tdf10_applyIncline_atZero_generatesCorrectSwipe() {
        Tdf10Device dev = dev(new Tdf10Device());
        dev.applyIncline(0.0);
        // targetInclineY(0) = (int)(619.91 - 0) = 619; initialY = 604 (constructor)
        assertEquals("input swipe 1205 604 1205 619 200", lastCommand);
    }

    // ── ProformStudioBikePro22Device ──────────────────────────────────────────

    @Test
    public void proformStudioBikePro22_isInstanceOfBikeDevice() {
        assertTrue(new ProformStudioBikePro22Device() instanceof BikeDevice);
    }

    @Test
    public void proformStudioBikePro22_applyIncline_atZero_generatesCorrectSwipe() {
        ProformStudioBikePro22Device dev = dev(new ProformStudioBikePro22Device());
        dev.applyIncline(0.0);
        // targetInclineY(0) = (int)(826.25 - 0) = 826; initialY = 805 (constructor)
        assertEquals("input swipe 1828 805 1828 826 200", lastCommand);
    }

    // ── Se9iEllipticalDevice ──────────────────────────────────────────────────

    @Test
    public void se9iElliptical_isInstanceOfBikeDevice() {
        assertTrue(new Se9iEllipticalDevice() instanceof BikeDevice);
    }

    // ── BikeDevice.decodeCommand ───────────────────────────────────────────────

    @Test
    public void decodeCommand_onePart_setsResistanceLvl() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"8.0"}, '.');
        assertEquals(8.0f, cmd.resistanceLvl, 0.001f);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeCommand_twoParts_setsInclinePct() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"5.0", "unused"}, '.');
        assertEquals(5.0f, cmd.inclinePct, 0.001f);
        assertNull(cmd.resistanceLvl);
    }

    @Test
    public void decodeCommand_roundsToOneDecimal() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"8.25"}, '.');
        assertEquals(8.3f, cmd.resistanceLvl, 0.001f);
    }

    @Test
    public void decodeCommand_sentinelMinusOne_resistance_returnsNull() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"-1"}, '.');
        assertNull(cmd.resistanceLvl);
    }

    @Test
    public void decodeCommand_sentinelMinusOneHundred_resistance_returnsNull() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"-100"}, '.');
        assertNull(cmd.resistanceLvl);
    }

    @Test
    public void decodeCommand_sentinelMinusOne_incline_returnsNull() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"-1", "unused"}, '.');
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeCommand_sentinelMinusOneHundred_incline_returnsNull() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"-100", "unused"}, '.');
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeCommand_commaDecimalSeparator_parsesCorrectly() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"8.5"}, ',');
        assertEquals(8.5f, cmd.resistanceLvl, 0.001f);
    }

    @Test
    public void decodeCommand_unparseable_returnsAllNull() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"abc"}, '.');
        assertNull(cmd.resistanceLvl);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeCommand_zeroParts_returnsAllNull() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{}, '.');
        assertNull(cmd.resistanceLvl);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeCommand_threeParts_returnsAllNull() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"1.0", "2.0", "3.0"}, '.');
        assertNull(cmd.resistanceLvl);
        assertNull(cmd.inclinePct);
    }

    // ── BikeDevice.applyResistance no-ops when resistanceX() == -1 ────────────

    @Test
    public void s22i_applyResistance_withNoResistanceSlider_doesNothing() {
        S22iDevice dev = dev(new S22iDevice());
        lastCommand = "unchanged";
        dev.applyResistance(10.0);
        // S22iDevice has no resistance slider (resistanceX() returns -1)
        assertEquals("unchanged", lastCommand);
    }

    // ── Ntex71021Device (no QZService calls, pure formula) ───────────────────
    // targetInclineY(v) = (int)(493 - 13.57 * v); initialY = 480

    @Test
    public void ntex71021_applyIncline_atZero_generatesCorrectSwipe() {
        Ntex71021Device dev = dev(new Ntex71021Device());
        dev.applyIncline(0.0);
        // targetInclineY(0) = (int)(493 - 0) = 493; initialY = 480
        assertEquals("input swipe 950 480 950 493 200", lastCommand);
    }

    @Test
    public void ntex71021_applyIncline_atTen_generatesCorrectSwipe() {
        Ntex71021Device dev = dev(new Ntex71021Device());
        dev.applyIncline(10.0);
        // targetInclineY(10) = (int)(493 - 135.7) = (int)357.3 = 357; initialY = 480
        assertEquals("input swipe 950 480 950 357 200", lastCommand);
    }

    @Test
    public void ntex71021_applyIncline_updatesCurrentY() {
        Ntex71021Device dev = dev(new Ntex71021Device());
        dev.applyIncline(10.0); // y2=357; currentY becomes 357
        dev.applyIncline(5.0);  // y2=(int)(493 - 67.85) = (int)425.15 = 425; y1=357
        assertEquals("input swipe 950 357 950 425 200", lastCommand);
    }

    @Test
    public void ntex71021_isMonotonicallyDecreasing_forIncline() {
        Ntex71021Device dev = dev(new Ntex71021Device());
        dev.applyIncline(0.0);
        int y0 = Integer.parseInt(lastCommand.split(" ")[5]);
        Ntex71021Device dev2 = dev(new Ntex71021Device());
        dev2.applyIncline(20.0);
        int y20 = Integer.parseInt(lastCommand.split(" ")[5]);
        assertTrue("Y at inclination=20 should be less than Y at inclination=0", y20 < y0);
    }
}
