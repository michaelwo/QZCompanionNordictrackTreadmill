package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Elite900Device extends TreadmillDevice {
    public Elite900Device() {         super(
            new Slider(450) {
                public int trackX() { return 950; }
                public int targetY(double v) { return 450 - (int) (v * 14.705); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(450) {
                public int trackX() { return 76; }
                public int targetY(double v) { return 450 - (int) (v * 20.83); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "Elite 900 Treadmill"; }






}
