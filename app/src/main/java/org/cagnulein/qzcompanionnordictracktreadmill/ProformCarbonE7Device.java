package org.cagnulein.qzcompanionnordictracktreadmill;

class ProformCarbonE7Device extends BikeDevice {
    ProformCarbonE7Device() { super(440, 440); }

    @Override
    String displayName() { return "ProForm Carbon E7 Bike"; }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return 440 - (int) (v * 11);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }

    @Override
    protected int resistanceX() { return 950; }

    @Override
    protected int targetResistanceY(double v) {
        return 440 - (int) (v * 9.16);
    }

    @Override
    protected int currentResistanceY(MetricSnapshot current) {
        return targetResistanceY(current.resistance());
    }
}
