package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750MphMinus3GradeDevice extends TreadmillDevice {
    public C1750MphMinus3GradeDevice() {         super(
            new Slider(603) {
                public int trackX() { return 1206; }
                public int targetY(double v) {
                    double mph = Math.max(0.5, Math.min(12.0, v * 0.621371));
                    return 603 - (int) ((mph - 0.5) * 34.0);
                }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(603) {
                public int trackX() { return 75; }
                public int targetY(double v) { return 603 - (int) ((v + 3.0) * 21.7222222); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "C1750 Treadmill (MPH -3% Grade)"; }






}
