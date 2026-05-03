package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class S40Device extends TreadmillDevice {

    public S40Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            Slider.linear(ScreenProfile.W1024.leftTrackX,  490, 21.4),
            Slider.linear(ScreenProfile.W1024.rightTrackX, 507, 12.5)
        );
    }

    @Override public String displayName() { return "S40 Treadmill"; }
}
