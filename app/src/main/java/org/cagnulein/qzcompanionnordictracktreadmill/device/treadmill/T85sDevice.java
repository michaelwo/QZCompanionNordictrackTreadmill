package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class T85sDevice extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 609;
    private static final int THUMB_Y_LEFT  = 609;

    public T85sDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1280.rightTrackX) {
                public int targetY(double v) { return (int) (629.81 - 20.81 * v); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1280.leftTrackX) {
                public int targetY(double v) { return (int) (THUMB_Y_LEFT - 36.417 * v); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }


    @Override
    public String displayName() { return "T8.5s Treadmill"; }
}
