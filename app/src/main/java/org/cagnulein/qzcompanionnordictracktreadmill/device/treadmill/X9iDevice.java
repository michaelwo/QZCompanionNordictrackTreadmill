package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X9iDevice extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 332;
    private static final int ORIGIN_SPEED_THUMBY   = 332;

    public X9iDevice() {
        // Screen: 800px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W800.leftTrackX, ORIGIN_INCLINE_THUMBY,  X9iDevice::offsetInclineThumbY),
            new Slider(ScreenProfile.W800.rightTrackX,   ORIGIN_SPEED_THUMBY, X9iDevice::offsetSpeedThumbY)
        );
    }

    @Override public String displayName() { return "X9i Treadmill"; }

    private static int offsetInclineThumbY(double v) { return (int) (311.91 - 3.3478 * v); }
    private static int offsetSpeedThumbY(double v)   { return (int) (345.6315 - 13.6315 * v); }
}
