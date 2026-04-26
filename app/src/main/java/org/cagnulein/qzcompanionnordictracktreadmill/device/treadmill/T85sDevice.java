package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class T85sDevice extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 609;
    private static final int ORIGIN_SPEED_THUMBY   = 609;

    public T85sDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1280.leftTrackX, ORIGIN_INCLINE_THUMBY, T85sDevice::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1280.rightTrackX, ORIGIN_SPEED_THUMBY, T85sDevice::offsetSpeedThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.speed()); }
            }
        );
    }

    @Override public String displayName() { return "T8.5s Treadmill"; }

    private static int offsetInclineThumbY(double v) { return (int) (ORIGIN_INCLINE_THUMBY - 36.417 * v); }
    private static int offsetSpeedThumbY(double v)   { return (int) (629.81 - 20.81 * v); }
}
