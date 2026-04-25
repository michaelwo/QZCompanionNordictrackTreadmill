package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S15iDevice extends BikeDevice {
    public S15iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(618, 75) {
                public int targetY(double v) { return 616 - (int) (v * 17.65); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            },
            new Slider(790, 1848) {
                public int targetY(double v) { return 790 - (int) (v * 23.16); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.gear()); }
            }
        ); }

    @Override
    public String displayName() { return "S15i Bike"; }






}
