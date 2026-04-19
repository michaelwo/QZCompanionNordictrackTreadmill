package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformPro9000Device extends TreadmillDevice {
    public ProformPro9000Device() {         super(
            new Slider(800) {
                public int trackX() { return 1825; }
                public int targetY(double v) { return 800 - (int) ((v * 0.621371 - 1.0) * 41.6666); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(715) {
                public int trackX() { return 90; }
                public int targetY(double v) { return 720 - (int) (v * 34.583); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "ProForm Pro 9000 Treadmill"; }






}
