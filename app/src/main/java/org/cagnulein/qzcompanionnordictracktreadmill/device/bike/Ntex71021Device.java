package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class Ntex71021Device extends BikeDevice {
    private static final int THUMB_Y_LEFT = 480;

    public Ntex71021Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1024.rightTrackX) {
                public int targetY(double v) { return (int) (493 - 13.57 * v); }
            },
            null
        ); }


    @Override
    public String displayName() { return "NTEX71021 Bike"; }
}
