package org.cagnulein.qzcompanionnordictracktreadmill;

class S27iDevice extends BikeDevice {
    S27iDevice() { super(803, 803); }

    @Override
    String displayName() { return "S27i Bike"; }

    @Override
    protected int inclineX() { return 76; }

    @Override
    protected int targetInclineY(double v) {
        return 803 - (int) ((v + 10) * (803.0 - 248.0) / 30.0);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }

    @Override
    protected int resistanceX() { return 1847; }

    @Override
    protected int targetResistanceY(double v) {
        return 803 - (int) ((v - 1) * (803.0 - 248.0) / 23.0);
    }

    @Override
    protected int currentResistanceY(MetricSnapshot current) {
        return targetResistanceY(current.resistance());
    }
}
