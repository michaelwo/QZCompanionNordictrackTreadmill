package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class ProformCarbonT14Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 844;
    private static final int ORIGIN_SPEED_THUMBY   = 810;

    public ProformCarbonT14Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY,  ProformCarbonT14Device::offsetInclineThumbY),
            new Slider(ScreenProfile.W1920.rightTrackX,   ORIGIN_SPEED_THUMBY, ProformCarbonT14Device::offsetSpeedThumbY)
        );
    }

    @Override public String displayName() { return "ProForm Carbon T14 Treadmill"; }

    private static int offsetInclineThumbY(double v) { return (int) (ORIGIN_INCLINE_THUMBY - 46.833 * v); }
    private static int offsetSpeedThumbY(double v)   { return (int) (ORIGIN_SPEED_THUMBY - 52.8 * v * KMH_TO_MPH); }
}
