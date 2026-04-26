package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class Tdf10InclinationDevice extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 482;

    public Tdf10InclinationDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1280.leftTrackX, ORIGIN_INCLINE_THUMBY, Tdf10InclinationDevice::offsetInclineThumbY),
            null
        );
    }

    @Override public String displayName() { return "TDF10 Bike (Inclination)"; }

    private static int offsetInclineThumbY(double v) { return (int) (-12.499 * v + 482.2); }
}
