package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750MphMinus3GradeDevice extends TreadmillDevice {
    public C1750MphMinus3GradeDevice() { super(603, 603); }

    @Override
    public String displayName() { return "C1750 Treadmill (MPH -3% Grade)"; }

    @Override
    protected int speedX() { return 1206; }

    @Override
    protected int targetSpeedY(double v) {
        double mph = Math.max(0.5, Math.min(12.0, v * 0.621371));
        return 603 - (int) ((mph - 0.5) * 34.0);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return 603 - (int) ((v + 3.0) * 21.7222222);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
