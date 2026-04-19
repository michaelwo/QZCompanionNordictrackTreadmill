package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformCarbonE7Device extends BikeDevice {
    public ProformCarbonE7Device() {         super(
            new Slider(440) {
                public int trackX() { return 75; }
                public int targetY(double v) { return 440 - (int) (v * 11); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            },
            new Slider(440) {
                public int trackX() { return 950; }
                public int targetY(double v) { return 440 - (int) (v * 9.16); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.resistance()); }
            }
        ); }

    @Override
    public String displayName() { return "ProForm Carbon E7 Bike"; }






}
