package org.cagnulein.qzcompanionnordictracktreadmill;

class Elite900Device extends TreadmillDevice {
    Elite900Device() { super(450, 450); }

    @Override
    String displayName() { return "Elite 900 Treadmill"; }

    @Override
    protected int speedX() { return 950; }

    @Override
    protected int targetSpeedY(double v) {
        return 450 - (int) (v * 14.705);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    protected int inclineX() { return 76; }

    @Override
    protected int targetInclineY(double v) {
        return 450 - (int) (v * 20.83);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
