package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Elite1000Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 589;
    private static final int ORIGIN_SPEED_THUMBY   = 600;

    private final String name;

    public Elite1000Device(String name) {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1280.leftTrackX, ORIGIN_INCLINE_THUMBY, Elite1000Device::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1280.rightTrackX, ORIGIN_SPEED_THUMBY, Elite1000Device::offsetSpeedThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.speed()); }
            }
        );
        this.name = name;
    }

    @Override public String displayName() { return name; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int) (v * 32.8); }
    private static int offsetSpeedThumbY(double v)   { return ORIGIN_SPEED_THUMBY - (int) (v * 0.621371 * 31.33); }
}
