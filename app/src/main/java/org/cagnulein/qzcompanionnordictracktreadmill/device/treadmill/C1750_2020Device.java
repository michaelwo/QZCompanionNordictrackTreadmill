package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class C1750_2020Device extends TreadmillDevice {

    public C1750_2020Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            Slider.inclineLive(ScreenProfile.W1280.leftTrackX,  520, v -> 520 - (int)(v * 20)),
            Slider.speedLive(  ScreenProfile.W1280.rightTrackX, 575, v -> 575 - (int)((v * KMH_TO_MPH - 1.0) * 28.91))
        );
    }

    @Override public String displayName() { return "C1750 Treadmill (2020)"; }
}
