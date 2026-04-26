package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class Ntex71021Device extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 493;

    public Ntex71021Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1024.rightTrackX, ORIGIN_INCLINE_THUMBY, Ntex71021Device::offsetInclineThumbY),
            null
        );
    }

    @Override public String displayName() { return "NTEX71021 Bike"; }

    private static int offsetInclineThumbY(double v) { return (int) (ORIGIN_INCLINE_THUMBY - 13.57 * v); }
}
