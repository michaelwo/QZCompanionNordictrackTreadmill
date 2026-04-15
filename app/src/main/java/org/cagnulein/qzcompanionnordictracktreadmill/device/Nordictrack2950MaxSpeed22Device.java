package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Nordictrack2950MaxSpeed22Device extends TreadmillDevice {
    public Nordictrack2950MaxSpeed22Device() { super(807, 717); }

    @Override
    public String displayName() { return "NordicTrack 2950 Treadmill (Max Speed 22)"; }

    @Override
    protected int speedX() { return 1845; }

    @Override
    protected int targetSpeedY(double v) {
        return 682 - (int) ((v - 1.0) * 26.5);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return 807 - (int) ((v + 3) * 31.1);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
