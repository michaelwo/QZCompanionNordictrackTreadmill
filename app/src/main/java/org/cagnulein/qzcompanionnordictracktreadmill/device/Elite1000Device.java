package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Elite1000Device extends TreadmillDevice {
    private final String name;

    public Elite1000Device(String name) {
        super(600, 600);
        this.name = name;
    }

    @Override
    public String displayName() { return name; }

    @Override
    protected int speedX() { return 1209; }

    @Override
    protected int targetSpeedY(double v) {
        return 600 - (int) (v * 0.621371 * 31.33);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    protected int inclineX() { return 76; }

    @Override
    protected int targetInclineY(double v) {
        return 589 - (int) (v * 32.8);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
