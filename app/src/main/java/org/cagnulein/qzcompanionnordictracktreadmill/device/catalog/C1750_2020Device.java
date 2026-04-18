package org.cagnulein.qzcompanionnordictracktreadmill.device.catalog;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750_2020Device extends TreadmillDevice {
    public C1750_2020Device() {         super(
            new Slider(575) {
                public int trackX() { return 1205; }
                public int targetY(double v) { return 575 - (int) ((v * 0.621371 - 1.0) * 28.91); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(525) {
                public int trackX() { return 75; }
                public int targetY(double v) { return 520 - (int) (v * 20); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "C1750 Treadmill (2020)"; }




    @Override public MetricReader defaultMetricReader() { return new CatFileMetricReader(); }



}
