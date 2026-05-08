package org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.slider.ResistanceSlider;

public class ProformCarbonC10Device extends BikeDevice {

    public ProformCarbonC10Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/discover-device/validate_swipe_targets.py).
        super(ResistanceSlider.live(ScreenProfile.W1280.rightTrackX, 632, v -> 632 - (int)(v * 18.45)), null);
    }

    @Override public String displayName() { return "ProForm Carbon C10 Bike"; }
}
