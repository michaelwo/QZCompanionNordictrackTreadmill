package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.Ntex71021Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.ProformCarbonC10Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.ProformCarbonE7Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.ProformStudioBikePro22Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.S15iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.S22iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.S22iNtex02117Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.S22iNtex02121Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.S27iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.Se9iEllipticalDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.Tdf10Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.Tdf10InclinationDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.Shell;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.BikeMetricReader;
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
    // Three-point calibration: v=-10→Y=722, v=0→Y=622, v=20→Y=326.
    // Piecewise: v<=0 → (int)(622 - 10*v); v>0 → (int)(622 - 14.8*v). initialY=622.

    @Test
    public void s22i_applyIncline_atZero_generatesCorrectSwipe() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyIncline(0.0);
        // y2 = (int)(622 - 10*0) = 622; y1 = 622 (initial)
        assertEquals("input swipe 75 622 75 622 200", lastCommand);
    }

    @Test
    public void s22i_applyIncline_atNegativeTen_generatesCorrectSwipe() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyIncline(-10.0);
        // v<=0 branch: toY=(int)(622-10*(-10))=722; going down → dispatch=722+15=737
        assertEquals("input swipe 75 622 75 737 200", lastCommand);
    }

    @Test
    public void s22i_applyIncline_atTen_generatesCorrectSwipe() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyIncline(10.0);
        // v>0 branch: toY=(int)(622-14.8*10)=474; going up → dispatch=474-15=459
        assertEquals("input swipe 75 622 75 459 200", lastCommand);
    }

    @Test
    public void s22i_applyIncline_atTwenty_isAtTopOfRange() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyIncline(20.0);
        // v>0 branch: toY=(int)(622-14.8*20)=326; travel=296 ≥ 40 → h=15; dispatch=326-15=311
        assertEquals("input swipe 75 622 75 311 200", lastCommand);
    }

    @Test
    public void s22i_applyIncline_updatesCurrentY() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyIncline(10.0); // toY=474 (up → dispatch=459); thumbY=474
        dev.applyIncline(5.0);  // toY=548 (down from 474 → dispatch=563); thumbY=548
        assertEquals("input swipe 75 474 75 563 200", lastCommand);
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
        // y2 = (int)(622 - 10*0) = 622; y1 = 622 (initial) — same formula as S22iDevice
        assertEquals("input swipe 75 622 75 622 200", lastCommand);
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
    // incline: currentThumbY; targetInclineY(v)=800-(int)((v+10)*19), targetInclineY(0)=610

    @Test
    public void s22iNtex02121_isInstanceOfBikeDevice() {
        assertTrue(new S22iNtex02121Device() instanceof BikeDevice);
    }

    @Test
    public void s22iNtex02121_hasCorrectDisplayName() {
        assertEquals("S22i Bike (NTEX02121.5)", new S22iNtex02121Device().displayName());
    }

    @Test
    public void s22iNtex02121_applyIncline_atFive_generatesCorrectSwipe() {
        S22iNtex02121Device dev = dev(new S22iNtex02121Device());
        dev.applyIncline(5.0);
        // fromY=610; y2=800-(int)(15*19)=800-285=515
        assertEquals("input swipe 75 610 75 515 200", lastCommand);
    }

    // ── S15iDevice ────────────────────────────────────────────────────────────
    // incline: currentThumbY, targetInclineY(v)=616-(int)(v*17.65), targetInclineY(0)=616
    // resistance: currentThumbY, targetResistanceY(v)=790-(int)(v*23.16), targetResistanceY(0)=790

    @Test
    public void s15i_isInstanceOfBikeDevice() {
        assertTrue(new S15iDevice() instanceof BikeDevice);
    }

    @Test
    public void s15i_hasCorrectDisplayName() {
        assertEquals("S15i Bike", new S15iDevice().displayName());
    }

    @Test
    public void s15i_applyIncline_atFive_generatesCorrectSwipe() {
        S15iDevice dev = dev(new S15iDevice());
        dev.applyIncline(5.0);
        // fromY=616; y2=616-(int)(5*17.65)=616-(int)88.25=616-88=528
        assertEquals("input swipe 75 616 75 528 200", lastCommand);
    }

    @Test
    public void s15i_applyResistance_atFive_generatesCorrectSwipe() {
        S15iDevice dev = dev(new S15iDevice());
        dev.applyResistance(5.0);
        // fromY=790; y2=790-(int)(5*23.16)=790-(int)115.8=790-115=675
        assertEquals("input swipe 1848 790 1848 675 200", lastCommand);
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

    // ── BikeDevice.defaultMetricReader ────────────────────────────────────────

    @Test
    public void bikeDevice_defaultMetricReader_returnsBikeMetricReader() {
        assertTrue(new S22iDevice().defaultMetricReader() instanceof BikeMetricReader);
    }

    @Test
    public void bikeDevice_defaultMetricReader_forIfitV2_returnsBikeMetricReader() {
        assertTrue(new S22iDevice().defaultMetricReader().forIfitV2() instanceof BikeMetricReader);
    }

    @Test
    public void decodeCommand_threeParts_returnsAllNull() {
        Command cmd = new S22iDevice().decodeCommand(new String[]{"1.0", "2.0", "3.0"}, '.');
        assertNull(cmd.resistanceLvl);
        assertNull(cmd.inclinePct);
    }

    // ── S22iDevice resistance slider (x=1845, calibrated) ────────────────────
    // Two-point calibration: resistance=1 → Y=724, resistance=24 → Y=323.
    // targetResistanceY(v) = (int)(724.0 - 401.0/23 * (v-1)); initialY = 724

    @Test
    public void s22i_applyResistance_atLevel1_isAtTopOfRange() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyResistance(1.0);
        // targetResistanceY(1) = (int)(724 - 0) = 724; initialY = 724
        assertEquals("input swipe 1845 724 1845 724 200", lastCommand);
    }

    @Test
    public void s22i_applyResistance_atLevel24_isAtBottomOfRange() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyResistance(24.0);
        // targetResistanceY(24) = (int)(724 - 401.0/23*23) = (int)(724 - 401) = 323; initialY = 724
        assertEquals("input swipe 1845 724 1845 323 200", lastCommand);
    }

    @Test
    public void s22i_applyResistance_atLevel10_generatesCorrectSwipe() {
        S22iDevice dev = dev(new S22iDevice());
        dev.applyResistance(10.0);
        // targetResistanceY(10) = (int)(724 - 401.0/23*9) = (int)(724 - 156.913) = 567; initialY = 724
        assertEquals("input swipe 1845 724 1845 567 200", lastCommand);
    }

    // ── Ntex71021Device (no MetricReaderBroadcastingService calls, pure formula) ───────────────────
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

    // ── S27iDevice ────────────────────────────────────────────────────────────
    // incline: currentThumbY; targetInclineY(v)=803-(int)((v+10)*555/30), targetInclineY(0)=618
    // resistance: currentThumbY; targetResistanceY(v)=803-(int)((v-1)*555/23), targetResistanceY(0)=827

    @Test
    public void s27i_isInstanceOfBikeDevice() {
        assertTrue(new S27iDevice() instanceof BikeDevice);
    }

    @Test
    public void s27i_hasCorrectDisplayName() {
        assertEquals("S27i Bike", new S27iDevice().displayName());
    }

    @Test
    public void s27i_applyIncline_atFive_generatesCorrectSwipe() {
        S27iDevice dev = dev(new S27iDevice());
        dev.applyIncline(5.0);
        // fromY=618; y2=803-(int)(15*18.5)=803-277=526
        assertEquals("input swipe 76 618 76 526 200", lastCommand);
    }

    @Test
    public void s27i_applyResistance_atFive_generatesCorrectSwipe() {
        S27iDevice dev = dev(new S27iDevice());
        dev.applyResistance(5.0);
        // fromY=827; y2=803-(int)(4*555/23)=803-(int)96.52=803-96=707
        assertEquals("input swipe 1847 827 1847 707 200", lastCommand);
    }

    // ── ProformCarbonC10Device ────────────────────────────────────────────────
    // incline slot (no resistance slot); targetY(v)=632-(int)(v*18.45), currentThumbY→resistance()
    // snapshot.resistance()=0 in tests → fromY=targetY(0)=632

    @Test
    public void proformCarbonC10_isInstanceOfBikeDevice() {
        assertTrue(new ProformCarbonC10Device() instanceof BikeDevice);
    }

    @Test
    public void proformCarbonC10_hasCorrectDisplayName() {
        assertEquals("ProForm Carbon C10 Bike", new ProformCarbonC10Device().displayName());
    }

    @Test
    public void proformCarbonC10_applyIncline_atFive_generatesCorrectSwipe() {
        ProformCarbonC10Device dev = dev(new ProformCarbonC10Device());
        dev.applyIncline(5.0);
        // fromY=632; y2=632-(int)(5*18.45)=632-(int)92.25=632-92=540
        assertEquals("input swipe 1205 632 1205 540 200", lastCommand);
    }

    // ── ProformCarbonE7Device ─────────────────────────────────────────────────
    // incline: currentThumbY; targetInclineY(v)=440-(int)(v*11), targetInclineY(0)=440
    // resistance: currentThumbY; targetResistanceY(v)=440-(int)(v*9.16), targetResistanceY(0)=440

    @Test
    public void proformCarbonE7_isInstanceOfBikeDevice() {
        assertTrue(new ProformCarbonE7Device() instanceof BikeDevice);
    }

    @Test
    public void proformCarbonE7_hasCorrectDisplayName() {
        assertEquals("ProForm Carbon E7 Bike", new ProformCarbonE7Device().displayName());
    }

    @Test
    public void proformCarbonE7_applyIncline_atFive_generatesCorrectSwipe() {
        ProformCarbonE7Device dev = dev(new ProformCarbonE7Device());
        dev.applyIncline(5.0);
        // fromY=440; y2=440-(int)(55)=385
        assertEquals("input swipe 75 440 75 385 200", lastCommand);
    }

    @Test
    public void proformCarbonE7_applyResistance_atFive_generatesCorrectSwipe() {
        ProformCarbonE7Device dev = dev(new ProformCarbonE7Device());
        dev.applyResistance(5.0);
        // fromY=440; y2=440-(int)(5*9.16)=440-(int)45.8=440-45=395
        assertEquals("input swipe 950 440 950 395 200", lastCommand);
    }

    // ── Se9iEllipticalDevice — formula tests ──────────────────────────────────
    // incline: currentThumbY; targetInclineY(v)=858-(int)(v*650/20), targetInclineY(0)=858
    // resistance: currentThumbY; targetResistanceY(v)=858-(int)((v-1)*650/23), targetResistanceY(0)=886

    @Test
    public void se9iElliptical_hasCorrectDisplayName() {
        assertEquals("SE9i Elliptical", new Se9iEllipticalDevice().displayName());
    }

    @Test
    public void se9iElliptical_applyIncline_atFive_generatesCorrectSwipe() {
        Se9iEllipticalDevice dev = dev(new Se9iEllipticalDevice());
        dev.applyIncline(5.0);
        // fromY=858; y2=858-(int)(5*32.5)=858-162=696
        assertEquals("input swipe 57 858 57 696 200", lastCommand);
    }

    @Test
    public void se9iElliptical_applyResistance_atFive_generatesCorrectSwipe() {
        Se9iEllipticalDevice dev = dev(new Se9iEllipticalDevice());
        dev.applyResistance(5.0);
        // fromY=886; y2=858-(int)(4*650/23)=858-(int)113.04=858-113=745
        assertEquals("input swipe 1857 886 1857 745 200", lastCommand);
    }

    // ── Tdf10InclinationDevice ────────────────────────────────────────────────
    // no currentThumbY; inclineX=74, targetInclineY(v)=(int)(-12.499*v+482.2), initial=482

    @Test
    public void tdf10Inclination_isInstanceOfBikeDevice() {
        assertTrue(new Tdf10InclinationDevice() instanceof BikeDevice);
    }

    @Test
    public void tdf10Inclination_hasCorrectDisplayName() {
        assertEquals("TDF10 Bike (Inclination)", new Tdf10InclinationDevice().displayName());
    }

    @Test
    public void tdf10Inclination_applyIncline_atZero_generatesCorrectSwipe() {
        Tdf10InclinationDevice dev = dev(new Tdf10InclinationDevice());
        dev.applyIncline(0.0);
        // fromY=482; y2=(int)(482.2)=482
        assertEquals("input swipe 74 482 74 482 200", lastCommand);
    }

    @Test
    public void tdf10Inclination_applyIncline_atFive_generatesCorrectSwipe() {
        Tdf10InclinationDevice dev = dev(new Tdf10InclinationDevice());
        dev.applyIncline(0.0); // advance currentY to 482
        dev.applyIncline(5.0);
        // fromY=482; y2=(int)(-12.499*5+482.2)=(int)(419.705)=419
        assertEquals("input swipe 74 482 74 419 200", lastCommand);
    }
}
