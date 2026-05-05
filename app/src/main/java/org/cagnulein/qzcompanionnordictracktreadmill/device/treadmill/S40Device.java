package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.InclineSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.SpeedSlider;

public class S40Device extends TreadmillDevice {

    public S40Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new InclineSlider(ScreenProfile.W1024.leftTrackX,  490, v -> (int)(490 - 21.4 * v)),
            new SpeedSlider(  ScreenProfile.W1024.rightTrackX, 507, v -> (int)(507 - 12.5 * v))
        );
    }

    @Override public String displayName() { return "S40 Treadmill"; }
}
