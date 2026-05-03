package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class S15iDevice extends BikeDevice {

    public S15iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            Slider.inclineLive(ScreenProfile.W1920.leftTrackX,  616, v -> 616 - (int)(v * 17.65)),
            Slider.gearLive(   ScreenProfile.W1920.rightTrackX, 790, v -> 790 - (int)(v * 23.16))
        );
    }

    @Override public String displayName() { return "S15i Bike"; }
}
