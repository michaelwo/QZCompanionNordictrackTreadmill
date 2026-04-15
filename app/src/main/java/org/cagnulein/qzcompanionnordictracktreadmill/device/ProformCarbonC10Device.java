package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.DirectLogcatMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformCarbonC10Device extends BikeDevice {
    public ProformCarbonC10Device() {         super(
            new Slider(632) {
                public int trackX() { return 1205; }
                public int targetY(double v) { return 632 - (int) (v * 18.45); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.resistance()); }
            },
            null
        ); }

    @Override
    public String displayName() { return "ProForm Carbon C10 Bike"; }

    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new DirectLogcatMetricReader(); }



}
