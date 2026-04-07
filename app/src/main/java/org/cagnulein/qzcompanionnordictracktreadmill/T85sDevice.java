package org.cagnulein.qzcompanionnordictracktreadmill;

class T85sDevice extends TreadmillDevice {
    T85sDevice() { super(609, 609); }

    @Override
    String displayName() { return "T8.5s Treadmill"; }

    @Override
    protected int speedX() { return 1207; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (629.81 - 20.81 * v);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (609 - 36.417 * v);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
