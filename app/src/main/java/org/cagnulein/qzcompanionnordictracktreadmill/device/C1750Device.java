package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750Device extends TreadmillDevice {
    public C1750Device() {         super(
            new Slider(793) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return 785 - (int) ((v - 1.0) * 31.42); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(694) {
                public int trackX() { return 79; }
                public int targetY(double v) { return (int) (700 - 34.9 * v); }
            }
        ); }

    @Override
    public String displayName() { return "C1750 Treadmill"; }




    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }


}
