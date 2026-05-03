package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class Tdf10Device extends BikeDevice {

    public Tdf10Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(new Slider(ScreenProfile.W1280.rightTrackX, 604, v -> (int)(619.91 - 15.913 * v)), null);
    }

    @Override public String displayName() { return "TDF10 Bike"; }
}
