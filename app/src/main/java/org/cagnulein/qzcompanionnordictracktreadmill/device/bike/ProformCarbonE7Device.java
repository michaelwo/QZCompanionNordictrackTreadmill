package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class ProformCarbonE7Device extends BikeDevice {

    public ProformCarbonE7Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            Slider.inclineLive(   ScreenProfile.W1024.leftTrackX,  440, v -> 440 - (int)(v * 11)),
            Slider.resistanceLive(ScreenProfile.W1024.rightTrackX, 440, v -> 440 - (int)(v * 9.16))
        );
    }

    @Override public String displayName() { return "ProForm Carbon E7 Bike"; }
}
