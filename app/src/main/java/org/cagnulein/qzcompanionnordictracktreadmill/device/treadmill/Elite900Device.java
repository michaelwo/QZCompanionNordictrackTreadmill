package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Elite900Device extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 450;
    private static final int THUMB_Y_LEFT  = 450;

    public Elite900Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1024.rightTrackX) {
                public int targetY(double v) { return THUMB_Y_RIGHT - (int) (v * 14.705); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1024.leftTrackX) {
                public int targetY(double v) { return THUMB_Y_LEFT - (int) (v * 20.83); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }


    @Override
    public String displayName() { return "Elite 900 Treadmill"; }
}
