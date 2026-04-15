package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.DirectLogcatMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class Ntex71021Device extends BikeDevice {
    public Ntex71021Device() { super(480, 480); }

    @Override
    public String displayName() { return "NTEX71021 Bike"; }

    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new DirectLogcatMetricReader(); }

    @Override
    protected int inclineX() { return 950; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (493 - 13.57 * v);
    }
}
