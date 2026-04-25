package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class Tdf10InclinationDevice extends BikeDevice {
    public Tdf10InclinationDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(482, 74) {
                public int targetY(double v) { return (int) (-12.499 * v + 482.2); }
            },
            null
        ); }

    @Override
    public String displayName() { return "TDF10 Bike (Inclination)"; }


}
