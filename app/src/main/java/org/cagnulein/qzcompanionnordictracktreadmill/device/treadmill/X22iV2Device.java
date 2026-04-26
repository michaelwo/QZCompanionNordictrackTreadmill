package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X22iV2Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 742;
    private static final int ORIGIN_SPEED_THUMBY   = 838;

    public X22iV2Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY,  X22iV2Device::offsetInclineThumbY),
            new Slider(ScreenProfile.W1920.rightTrackX,   ORIGIN_SPEED_THUMBY, X22iV2Device::offsetSpeedThumbY)
        );
    }

    @Override public String displayName() { return "X22i V2 Treadmill"; }

    private static int offsetInclineThumbY(double v) { return (int) (ORIGIN_INCLINE_THUMBY - 11.9 * (v + 6)); }
    private static int offsetSpeedThumbY(double v)   { return (int) (ORIGIN_SPEED_THUMBY - 26.136 * v); }
}
