package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750_2020Device extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 575;
    private static final int THUMB_Y_LEFT  = 525;

    public C1750_2020Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1280.rightTrackX) {
                public int targetY(double v) { return THUMB_Y_RIGHT - (int) ((v * 0.621371 - 1.0) * 28.91); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1280.leftTrackX) {
                public int targetY(double v) { return 520 - (int) (v * 20); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }


    @Override
    public String displayName() { return "C1750 Treadmill (2020)"; }
}
