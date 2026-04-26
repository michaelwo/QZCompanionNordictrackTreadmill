package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Exp7iDevice extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 430;
    private static final int THUMB_Y_LEFT  = 442;

    public Exp7iDevice() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1024.rightTrackX) {
                public int targetY(double v) { return 453 - (int) ((v * 0.621371 - 1.0) * 22.702); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1024.leftTrackX) {
                public int targetY(double v) { return THUMB_Y_LEFT - (int) (v * 21.802); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }


    @Override
    public String displayName() { return "EXP 7i Treadmill"; }
}
