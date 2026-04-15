package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class ProformCarbonT14Device extends TreadmillDevice {
    public ProformCarbonT14Device() { super(807, 844); }

    @Override
    public String displayName() { return "ProForm Carbon T14 Treadmill"; }

    @Override
    protected int speedX() { return 1845; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (810 - 52.8 * v * 0.621371);
    }

    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }

    @Override
    protected int inclineX() { return 76; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (844 - 46.833 * v);
    }
}
