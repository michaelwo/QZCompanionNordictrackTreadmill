package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class C1750Device extends TreadmillDevice {

    public C1750Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Incline trackX=79 is 4.5px off APK-expected 74.5; matches hardware calibration.
        super(
            Slider.linear(   ScreenProfile.W1920.leftTrackX,  700, 34.9),
            Slider.speedLive(ScreenProfile.W1920.rightTrackX, 785, v -> 785 - (int)((v - 1.0) * 31.42))
        );
    }

    @Override public String displayName() { return "C1750 Treadmill"; }
}
