package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.DirectLogcatMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformCarbonC10Device extends BikeDevice {
    public ProformCarbonC10Device() { super(632, 632); }

    @Override
    public String displayName() { return "ProForm Carbon C10 Bike"; }

    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new DirectLogcatMetricReader(); }

    @Override
    protected int inclineX() { return 1205; }

    @Override
    protected int targetInclineY(double v) {
        return 632 - (int) (v * 18.45);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.resistance());
    }
}
