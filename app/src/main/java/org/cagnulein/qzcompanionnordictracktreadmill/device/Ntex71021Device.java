package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.DirectLogcatMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class Ntex71021Device extends BikeDevice {
    public Ntex71021Device() {         super(
            new Slider(480) {
                public int trackX() { return 950; }
                public int targetY(double v) { return (int) (493 - 13.57 * v); }
            },
            null
        ); }

    @Override
    public String displayName() { return "NTEX71021 Bike"; }

    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new DirectLogcatMetricReader(); }


}
