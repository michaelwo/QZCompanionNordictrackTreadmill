package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Exp7iDevice extends TreadmillDevice {
    public Exp7iDevice() {         super(
            new Slider(430) {
                public int trackX() { return 950; }
                public int targetY(double v) { return 453 - (int) ((v * 0.621371 - 1.0) * 22.702); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(442) {
                public int trackX() { return 74; }
                public int targetY(double v) { return 442 - (int) (v * 21.802); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "EXP 7i Treadmill"; }






}
