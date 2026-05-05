package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.InclineSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.SpeedSlider;

public class ProformPro9000Device extends TreadmillDevice {

    public ProformPro9000Device() {
        // Screen: 1920px wide — updated to iFit APK 2.6.90 standard
        //   (original hardware calibration: left=90, right=1825).
        super(
            InclineSlider.live(ScreenProfile.W1920.leftTrackX,  720, v -> 720 - (int)(v * 34.583)),
            SpeedSlider.live(  ScreenProfile.W1920.rightTrackX, 800, v -> 800 - (int)((v * KMH_TO_MPH - 1.0) * 41.6666))
        );
    }

    @Override public String displayName() { return "ProForm Pro 9000 Treadmill"; }
}
