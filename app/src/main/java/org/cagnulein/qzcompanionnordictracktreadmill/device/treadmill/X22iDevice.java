package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X22iDevice extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 785;
    private static final int ORIGIN_SPEED_THUMBY   = 785;

    public X22iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY,  X22iDevice::offsetInclineThumbY),
            new Slider(ScreenProfile.W1920.rightTrackX,   ORIGIN_SPEED_THUMBY, X22iDevice::offsetSpeedThumbY)
        );
    }

    @Override public String displayName() { return "X22i Treadmill"; }

    private static int offsetInclineThumbY(double v) { return (int) (ORIGIN_INCLINE_THUMBY - 11.304347826086957 * (v + 6)); }
    private static int offsetSpeedThumbY(double v)   { return (int) (ORIGIN_SPEED_THUMBY - 23.636363636363636 * v); }
}
