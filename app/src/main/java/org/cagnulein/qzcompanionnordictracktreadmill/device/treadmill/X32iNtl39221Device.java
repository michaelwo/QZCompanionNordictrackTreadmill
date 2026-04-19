package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class X32iNtl39221Device extends TreadmillDevice {
    public X32iNtl39221Device() {         super(
            new Slider(579) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return (int) (900.26 - 46.63 * v * 0.621371); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(635) {
                public int trackX() { return 75; }
                public int targetY(double v) { return 750 - (int) (v * 12.05); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "X32i Treadmill (NTL39221)"; }






}
