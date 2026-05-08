package org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.slider.InclineSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.slider.SpeedSlider;

public class Elite900Device extends TreadmillDevice {

    public Elite900Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/discover-device/validate_swipe_targets.py).
        super(
            InclineSlider.live(ScreenProfile.W1024.leftTrackX,  450, v -> 450 - (int)(v * 20.83)),
            SpeedSlider.live(  ScreenProfile.W1024.rightTrackX, 450, v -> 450 - (int)(v * 14.705))
        );
    }

    @Override public String displayName() { return "Elite 900 Treadmill"; }
}
