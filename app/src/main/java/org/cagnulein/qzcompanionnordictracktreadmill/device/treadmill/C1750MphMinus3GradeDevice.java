package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750MphMinus3GradeDevice extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 603;
    private static final int THUMB_Y_LEFT  = 603;

    public C1750MphMinus3GradeDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1280.rightTrackX) {
                public int targetY(double v) {
                    double mph = Math.max(0.5, Math.min(12.0, v * 0.621371));
                    return THUMB_Y_RIGHT - (int) ((mph - 0.5) * 34.0);
                }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1280.leftTrackX) {
                public int targetY(double v) { return THUMB_Y_LEFT - (int) ((v + 3.0) * 21.7222222); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }


    @Override
    public String displayName() { return "C1750 Treadmill (MPH -3% Grade)"; }
}
