package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750_2021Device extends TreadmillDevice {
    public C1750_2021Device() {         super(
            new Slider(592) {
                public int trackX() { return 1205; }
                public int targetY(double v) { return 620 - (int) ((v - 1.0) * 20.73); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(547) {
                public int trackX() { return 79; }
                public int targetY(double v) { return (int) (553 - 22 * v); }
            }
        ); }

    @Override
    public String displayName() { return "C1750 Treadmill (2021)"; }




    @Override public MetricReader defaultMetricReader() { return new CatFileMetricReader(); }


}
