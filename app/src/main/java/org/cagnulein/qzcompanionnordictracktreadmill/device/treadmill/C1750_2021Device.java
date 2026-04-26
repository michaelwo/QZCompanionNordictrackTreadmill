package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750_2021Device extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 592;
    private static final int THUMB_Y_LEFT  = 547;

    public C1750_2021Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Incline trackX=79 is 4.5px off APK-expected 74.5; matches hardware calibration.
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1280.rightTrackX) {
                public int targetY(double v) { return 620 - (int) ((v - 1.0) * 20.73); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1280.leftTrackX) {
                public int targetY(double v) { return (int) (553 - 22 * v); }
            }
        ); }


    @Override
    public String displayName() { return "C1750 Treadmill (2021)"; }
}
