package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X32iDevice extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 881;
    private static final int ORIGIN_SPEED_THUMBY   = 927;

    public X32iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // initialThumbYRight=927 starts below targetThumbY(0)≈835; conservative position ensures the first speed swipe always travels upward.
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY,  X32iDevice::offsetInclineThumbY),
            new Slider(ScreenProfile.W1920.rightTrackX,   ORIGIN_SPEED_THUMBY, X32iDevice::offsetSpeedThumbY)
        );
    }

    @Override public String displayName() { return "X32i Treadmill"; }

    private static int offsetInclineThumbY(double v) { return (int) (734.07 - 12.297 * v); }
    private static int offsetSpeedThumbY(double v)   { return (int) (834.85 - 26.946 * v); }
}
