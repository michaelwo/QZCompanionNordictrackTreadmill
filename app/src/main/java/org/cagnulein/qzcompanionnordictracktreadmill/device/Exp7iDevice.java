package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Exp7iDevice extends TreadmillDevice {
    public Exp7iDevice() { super(430, 442); }

    @Override
    public String displayName() { return "EXP 7i Treadmill"; }

    @Override
    protected int speedX() { return 950; }

    @Override
    protected int targetSpeedY(double v) {
        return 453 - (int) ((v * 0.621371 - 1.0) * 22.702);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    protected int inclineX() { return 74; }

    @Override
    protected int targetInclineY(double v) {
        return 442 - (int) (v * 21.802);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
