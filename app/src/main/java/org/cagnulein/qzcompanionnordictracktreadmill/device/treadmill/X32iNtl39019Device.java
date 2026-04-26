package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X32iNtl39019Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 749;
    private static final int ORIGIN_SPEED_THUMBY   = 779;

    public X32iNtl39019Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY,  X32iNtl39019Device::offsetInclineThumbY),
            new Slider(ScreenProfile.W1920.rightTrackX,   ORIGIN_SPEED_THUMBY, X32iNtl39019Device::offsetSpeedThumbY)
        );
    }

    @Override public String displayName() { return "X32i Treadmill (NTL39019)"; }

    private static int offsetInclineThumbY(double v) { return (int) (ORIGIN_INCLINE_THUMBY - 11.8424 * v); }
    private static int offsetSpeedThumbY(double v)   { return (int) (817.5 - 42.5 * v * 0.621371); }
}
