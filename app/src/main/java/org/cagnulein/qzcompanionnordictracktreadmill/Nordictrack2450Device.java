package org.cagnulein.qzcompanionnordictracktreadmill;

class Nordictrack2450Device extends TreadmillDevice {
    Nordictrack2450Device() { super(807, 717); }

    @Override
    String displayName() { return "NordicTrack 2450 Treadmill"; }

    @Override
    protected int speedX() { return 1845; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (-26.33 * (v * 0.621371) + 831.39);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    protected int inclineX() { return 72; }

    @Override
    protected int targetInclineY(double v) {
        return 715 - (int) ((v + 3) * 29.26);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
