package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750_2020Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 520;
    private static final int ORIGIN_SPEED_THUMBY   = 575;

    public C1750_2020Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1280.leftTrackX, ORIGIN_INCLINE_THUMBY, C1750_2020Device::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1280.rightTrackX, ORIGIN_SPEED_THUMBY, C1750_2020Device::offsetSpeedThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.speed()); }
            }
        );
    }

    @Override public String displayName() { return "C1750 Treadmill (2020)"; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int) (v * 20); }
    private static int offsetSpeedThumbY(double v)   { return ORIGIN_SPEED_THUMBY - (int) ((v * 0.621371 - 1.0) * 28.91); }
}
