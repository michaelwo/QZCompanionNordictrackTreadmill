package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.InclineSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.SpeedSlider;

public class ProformCarbonT14Device extends TreadmillDevice {

    public ProformCarbonT14Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new InclineSlider(ScreenProfile.W1920.leftTrackX,  844, v -> (int)(844 - 46.833 * v)),
            new SpeedSlider(  ScreenProfile.W1920.rightTrackX, 810, v -> (int)(810 - 52.8 * KMH_TO_MPH * v))
        );
    }

    @Override public String displayName() { return "ProForm Carbon T14 Treadmill"; }
}
