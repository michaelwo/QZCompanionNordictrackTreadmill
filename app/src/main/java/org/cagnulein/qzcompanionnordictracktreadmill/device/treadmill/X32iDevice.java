package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.InclineSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.SpeedSlider;

public class X32iDevice extends TreadmillDevice {

    public X32iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // initialThumbYRight=927 starts below targetThumbY(0)≈835; conservative position ensures the first speed swipe always travels upward.
        super(
            new InclineSlider(ScreenProfile.W1920.leftTrackX,  881, v -> (int)(734.07 - 12.297 * v)),
            new SpeedSlider(  ScreenProfile.W1920.rightTrackX, 927, v -> (int)(834.85 - 26.946 * v))
        );
    }

    @Override public String displayName() { return "X32i Treadmill"; }
}
