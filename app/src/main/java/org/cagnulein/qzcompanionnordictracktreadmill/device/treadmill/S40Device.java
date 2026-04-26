package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class S40Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 490;
    private static final int ORIGIN_SPEED_THUMBY   = 507;

    public S40Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1024.leftTrackX, ORIGIN_INCLINE_THUMBY,  S40Device::offsetInclineThumbY),
            new Slider(ScreenProfile.W1024.rightTrackX,   ORIGIN_SPEED_THUMBY, S40Device::offsetSpeedThumbY)
        );
    }

    @Override public String displayName() { return "S40 Treadmill"; }

    private static int offsetInclineThumbY(double v) { return (int) (ORIGIN_INCLINE_THUMBY - 21.4 * v); }
    private static int offsetSpeedThumbY(double v)   { return (int) (ORIGIN_SPEED_THUMBY - 12.5 * v); }
}
