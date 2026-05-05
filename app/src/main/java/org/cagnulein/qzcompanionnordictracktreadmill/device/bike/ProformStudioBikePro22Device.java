package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.InclineSlider;

public class ProformStudioBikePro22Device extends BikeDevice {

    public ProformStudioBikePro22Device() {
        // Screen: 1920px wide — updated to iFit APK 2.6.90 standard
        //   (original hardware calibration: right=1828).
        super(new InclineSlider(ScreenProfile.W1920.rightTrackX, 805, v -> (int)(826.25 - 21.25 * v)), null);
    }

    @Override public String displayName() { return "ProForm Studio Bike Pro 2.2"; }
}
