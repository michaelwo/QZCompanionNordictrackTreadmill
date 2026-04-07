package org.cagnulein.qzcompanionnordictracktreadmill;

class ProformCarbonC10Device extends BikeDevice {
    ProformCarbonC10Device() { super(632, 632); }

    @Override
    String displayName() { return "ProForm Carbon C10 Bike"; }

    @Override
    MetricReader defaultMetricReader(boolean ifitV2) { return new DirectLogcatMetricReader(); }

    @Override
    protected int inclineX() { return 1205; }

    @Override
    protected int targetInclineY(double v) {
        return 632 - (int) (v * 18.45);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.resistance());
    }
}
