package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class ProformCarbonT14Device extends TreadmillDevice {

    public ProformCarbonT14Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            Slider.linear(ScreenProfile.W1920.leftTrackX,  844, 46.833),
            Slider.linear(ScreenProfile.W1920.rightTrackX, 810, 52.8 * KMH_TO_MPH)
        );
    }

    @Override public String displayName() { return "ProForm Carbon T14 Treadmill"; }
}
