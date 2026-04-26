package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750MphMinus3GradeDevice extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 603;
    private static final int ORIGIN_SPEED_THUMBY   = 603;

    public C1750MphMinus3GradeDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1280.leftTrackX, ORIGIN_INCLINE_THUMBY, C1750MphMinus3GradeDevice::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1280.rightTrackX, ORIGIN_SPEED_THUMBY, C1750MphMinus3GradeDevice::offsetSpeedThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.speed()); }
            }
        );
    }

    @Override public String displayName() { return "C1750 Treadmill (MPH -3% Grade)"; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int) ((v + 3.0) * 21.7222222); }
    private static int offsetSpeedThumbY(double v) {
        double mph = Math.max(0.5, Math.min(12.0, v * 0.621371));
        return ORIGIN_SPEED_THUMBY - (int) ((mph - 0.5) * 34.0);
    }
}
