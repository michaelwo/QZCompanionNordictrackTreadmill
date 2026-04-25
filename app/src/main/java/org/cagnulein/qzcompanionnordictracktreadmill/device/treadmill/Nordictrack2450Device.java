package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Nordictrack2450Device extends TreadmillDevice {
    public Nordictrack2450Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Incline trackX=72 is 2.5px off APK-expected 74.5; matches hardware calibration.
        super(
            new Slider(807, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return (int) (-26.33 * (v * 0.621371) + 831.39); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(717, 72) {
                public int targetY(double v) { return 715 - (int) ((v + 3) * 29.26); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "NordicTrack 2450 Treadmill"; }






}
