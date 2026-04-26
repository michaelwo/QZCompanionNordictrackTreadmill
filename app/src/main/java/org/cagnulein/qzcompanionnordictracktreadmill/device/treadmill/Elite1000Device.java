package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Elite1000Device extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 600;
    private static final int THUMB_Y_LEFT  = 600;

    private final String name;

    public Elite1000Device(String name) {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1280.rightTrackX) {
                public int targetY(double v) { return THUMB_Y_RIGHT - (int) (v * 0.621371 * 31.33); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1280.leftTrackX) {
                public int targetY(double v) { return 589 - (int) (v * 32.8); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        );
        this.name = name;
    }


    @Override
    public String displayName() { return name; }
}
