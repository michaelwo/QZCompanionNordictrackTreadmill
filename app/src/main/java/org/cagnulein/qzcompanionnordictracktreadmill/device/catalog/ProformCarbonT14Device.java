package org.cagnulein.qzcompanionnordictracktreadmill.device.catalog;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class ProformCarbonT14Device extends TreadmillDevice {
    public ProformCarbonT14Device() {         super(
            new Slider(807) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return (int) (810 - 52.8 * v * 0.621371); }
            },
            new Slider(844) {
                public int trackX() { return 76; }
                public int targetY(double v) { return (int) (844 - 46.833 * v); }
            }
        ); }

    @Override
    public String displayName() { return "ProForm Carbon T14 Treadmill"; }



    @Override public MetricReader defaultMetricReader() { return new CatFileMetricReader(); }


}
