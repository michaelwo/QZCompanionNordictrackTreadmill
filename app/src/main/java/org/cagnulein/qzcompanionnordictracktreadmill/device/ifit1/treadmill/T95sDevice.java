package org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.InclineSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.SpeedSlider;

public class T95sDevice extends TreadmillDevice {

    public T95sDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/discover-device/validate_swipe_targets.py).
        super(
            InclineSlider.live(ScreenProfile.W1920.leftTrackX,  846, v -> 846 - (int)(46.0 * v)),
            SpeedSlider.live(  ScreenProfile.W1920.rightTrackX, 847, v -> 847 - (int)(30.0 * v))
        );
    }

    @Override public String displayName() { return "T9.5s Treadmill"; }
}
