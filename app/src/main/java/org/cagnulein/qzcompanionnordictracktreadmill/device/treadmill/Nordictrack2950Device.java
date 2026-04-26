package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Nordictrack2950Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 807;
    private static final int ORIGIN_SPEED_THUMBY   = 807;

    public Nordictrack2950Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY, Nordictrack2950Device::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1920.rightTrackX, ORIGIN_SPEED_THUMBY, Nordictrack2950Device::offsetSpeedThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.speed()); }
            }
        );
    }

    @Override public String displayName() { return "NordicTrack 2950 Treadmill"; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int) ((v + 3) * 31.1); }
    private static int offsetSpeedThumbY(double v)   { return ORIGIN_SPEED_THUMBY - (int) ((v - 1.0) * 31); }
}
