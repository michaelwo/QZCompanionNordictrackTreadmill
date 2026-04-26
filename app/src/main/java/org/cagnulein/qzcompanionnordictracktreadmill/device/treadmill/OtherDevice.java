package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class OtherDevice extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 0;
    private static final int ORIGIN_SPEED_THUMBY   = 0;

    public OtherDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Fallback device. initialThumbY=0 for both sliders — no initial position assumed; first swipe starts from Y=0.
        super(
            new Slider(ScreenProfile.W1280.leftTrackX, ORIGIN_INCLINE_THUMBY,  OtherDevice::offsetInclineThumbY),
            new Slider(ScreenProfile.W1280.rightTrackX,   ORIGIN_SPEED_THUMBY, OtherDevice::offsetSpeedThumbY)
        );
    }

    @Override public String displayName() { return "Other Treadmill"; }

    private static int offsetInclineThumbY(double v) { return (int) (520.11 - 21.804 * v); }
    private static int offsetSpeedThumbY(double v)   { return (int) (631.03 - 19.921 * v); }
}
