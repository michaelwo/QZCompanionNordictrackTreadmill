package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class T85sDevice extends TreadmillDevice {
    public T85sDevice() {         super(
            new Slider(609) {
                public int trackX() { return 1207; }
                public int targetY(double v) { return (int) (629.81 - 20.81 * v); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(609) {
                public int trackX() { return 75; }
                public int targetY(double v) { return (int) (609 - 36.417 * v); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "T8.5s Treadmill"; }






}
