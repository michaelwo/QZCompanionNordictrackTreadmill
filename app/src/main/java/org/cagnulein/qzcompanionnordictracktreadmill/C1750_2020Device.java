package org.cagnulein.qzcompanionnordictracktreadmill;

class C1750_2020Device extends TreadmillDevice {
    C1750_2020Device() { super(575, 525); }

    @Override
    String displayName() { return "C1750 Treadmill (2020)"; }

    @Override
    protected int speedX() { return 1205; }

    @Override
    protected int targetSpeedY(double v) {
        return 575 - (int) ((v * 0.621371 - 1.0) * 28.91);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return 520 - (int) (v * 20);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
