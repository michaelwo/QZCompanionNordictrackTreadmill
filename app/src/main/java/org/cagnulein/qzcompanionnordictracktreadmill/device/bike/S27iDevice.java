package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.InclineSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.ResistanceSlider;

public class S27iDevice extends BikeDevice {

    public S27iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            InclineSlider.live(   ScreenProfile.W1920.leftTrackX,  803, v -> 803 - (int)((v + 10) * (803.0 - 248.0) / 30.0)),
            ResistanceSlider.live(ScreenProfile.W1920.rightTrackX, 803, v -> 803 - (int)((v -  1) * (803.0 - 248.0) / 23.0))
        );
    }

    @Override public String displayName() { return "S27i Bike"; }
}
