package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class T95sDevice extends TreadmillDevice {

    public T95sDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            Slider.inclineLive(ScreenProfile.W1920.leftTrackX,  846, v -> 846 - (int)(46.0 * v)),
            Slider.speedLive(  ScreenProfile.W1920.rightTrackX, 847, v -> 847 - (int)(30.0 * v))
        );
    }

    @Override public String displayName() { return "T9.5s Treadmill"; }
}
