package org.cagnulein.qzcompanionnordictracktreadmill.device.catalog;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750_2020KphDevice extends TreadmillDevice {
    private static final double[][] INCLINE_TABLE = {
        {-3.0, 592}, {-2.5, 584}, {-2.0, 576}, {-1.5, 568}, {-1.0, 560},
        {-0.5, 544}, {0.0, 528}, {0.5, 520}, {1.0, 512}, {1.5, 504},
        {2.0, 496}, {2.5, 488}, {3.0, 480}, {3.5, 472}, {4.0, 464},
        {4.5, 456}, {5.0, 448}, {5.5, 440}, {6.0, 432}, {6.5, 424},
        {7.0, 400}, {7.5, 384}, {8.0, 368}, {8.5, 360}, {9.0, 352},
        {9.5, 344}, {10.0, 336}, {10.5, 328}, {11.0, 320}, {11.5, 312},
        {12.0, 304}, {12.5, 288}, {13.0, 272}, {13.5, 264}, {14.0, 256},
        {14.5, 248}, {15.0, 240}
    };

    public C1750_2020KphDevice() {         super(
            new Slider(598) {
                public int trackX() { return 1205; }
                public int targetY(double v) {
                    if (v <= 11) return (int)(v + 16.0 - 16.0 * 592);
                    else if (v < 12) return (int)(v + 8.0 - 16.0 * 592);
                    else return (int)(v + 0.0 - 16.0 * 592);
                }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(525) {
                public int trackX() { return 75; }
                public int targetY(double v) { return lookupStep(INCLINE_TABLE, v); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "C1750 Treadmill (2020 KPH)"; }




    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }




    private static int lookupStep(double[][] table, double value) {
        for (double[] row : table) if (value <= row[0]) return (int) row[1];
        return (int) table[table.length - 1][1];
    }
}
