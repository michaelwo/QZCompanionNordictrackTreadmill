package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class Nordictrack2950Device extends TreadmillDevice {

    public Nordictrack2950Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            Slider.inclineLive(ScreenProfile.W1920.leftTrackX,  807, v -> 807 - (int)((v + 3) * 31.1)),
            Slider.speedLive(  ScreenProfile.W1920.rightTrackX, 807, v -> 807 - (int)((v - 1.0) * 31))
        );
    }

    @Override public String displayName() { return "NordicTrack 2950 Treadmill"; }
}
