package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class Nordictrack2450Device extends TreadmillDevice {

    public Nordictrack2450Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            Slider.inclineLive(ScreenProfile.W1920.leftTrackX,  715, v -> 715 - (int)((v + 3) * 29.26)),
            Slider.speedLive(  ScreenProfile.W1920.rightTrackX, 807, v -> (int)(831.39 - 26.33 * v * KMH_TO_MPH))
        );
    }

    @Override public String displayName() { return "NordicTrack 2450 Treadmill"; }
}
