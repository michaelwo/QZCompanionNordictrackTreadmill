package org.cagnulein.qzcompanionnordictracktreadmill.device.catalog;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Se9iEllipticalDevice extends BikeDevice {
    public Se9iEllipticalDevice() {         super(
            new Slider(858) {
                public int trackX() { return 57; }
                public int targetY(double v) { return 858 - (int) (v * (858.0 - 208.0) / 20.0); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            },
            new Slider(858) {
                public int trackX() { return 1857; }
                public int targetY(double v) { return 858 - (int) ((v - 1) * (858.0 - 208.0) / 23.0); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.resistance()); }
            }
        ); }

    @Override
    public String displayName() { return "SE9i Elliptical"; }






}
