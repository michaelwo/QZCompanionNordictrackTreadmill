package org.cagnulein.qzcompanionnordictracktreadmill;

class ProformPro9000Device extends TreadmillDevice {
    ProformPro9000Device() { super(800, 715); }

    @Override
    String displayName() { return "ProForm Pro 9000 Treadmill"; }

    @Override
    protected int speedX() { return 1825; }

    @Override
    protected int targetSpeedY(double v) {
        return 800 - (int) ((v * 0.621371 - 1.0) * 41.6666);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    protected int inclineX() { return 90; }

    @Override
    protected int targetInclineY(double v) {
        return 720 - (int) (v * 34.583);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
