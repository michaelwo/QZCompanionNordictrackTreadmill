package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750_2021Device extends TreadmillDevice {
    public C1750_2021Device() { super(592, 547); }

    @Override
    public String displayName() { return "C1750 Treadmill (2021)"; }

    @Override
    protected int speedX() { return 1205; }

    @Override
    protected int targetSpeedY(double v) {
        return 620 - (int) ((v - 1.0) * 20.73);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }

    @Override
    protected int inclineX() { return 79; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (553 - 22 * v);
    }
}
