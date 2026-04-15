package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S15iDevice extends BikeDevice {
    public S15iDevice() { super(618, 790); }

    @Override
    public String displayName() { return "S15i Bike"; }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return 616 - (int) (v * 17.65);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }

    @Override
    protected int resistanceX() { return 1848; }

    @Override
    protected int targetResistanceY(double v) {
        return 790 - (int) (v * 23.16);
    }

    @Override
    protected int currentResistanceY(MetricSnapshot current) {
        return targetResistanceY(current.gear());
    }
}
