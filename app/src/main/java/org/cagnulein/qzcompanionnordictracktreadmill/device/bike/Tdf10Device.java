package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class Tdf10Device extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 604;

    public Tdf10Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1280.rightTrackX, ORIGIN_INCLINE_THUMBY, Tdf10Device::offsetInclineThumbY),
            null
        );
    }

    @Override public String displayName() { return "TDF10 Bike"; }

    private static int offsetInclineThumbY(double v) { return (int) (619.91 - 15.913 * v); }
}
