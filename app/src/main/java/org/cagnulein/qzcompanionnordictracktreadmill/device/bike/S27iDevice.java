package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S27iDevice extends BikeDevice {
    public S27iDevice() {         super(
            new Slider(803) {
                public int trackX() { return 76; }
                public int targetY(double v) { return 803 - (int) ((v + 10) * (803.0 - 248.0) / 30.0); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            },
            new Slider(803) {
                public int trackX() { return 1847; }
                public int targetY(double v) { return 803 - (int) ((v - 1) * (803.0 - 248.0) / 23.0); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.resistance()); }
            }
        ); }

    @Override
    public String displayName() { return "S27i Bike"; }






}
