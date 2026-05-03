package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class OtherDevice extends TreadmillDevice {

    public OtherDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Fallback device. initialThumbY=0 for both sliders — no initial position assumed; first swipe starts from Y=0.
        super(
            new Slider(ScreenProfile.W1280.leftTrackX,  0, v -> (int)(520.11 - 21.804 * v)),
            new Slider(ScreenProfile.W1280.rightTrackX, 0, v -> (int)(631.03 - 19.921 * v))
        );
    }

    @Override public String displayName() { return "Other Treadmill"; }
}
