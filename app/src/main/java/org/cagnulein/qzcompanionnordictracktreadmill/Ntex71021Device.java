package org.cagnulein.qzcompanionnordictracktreadmill;

class Ntex71021Device extends BikeDevice {
    Ntex71021Device() { super(480, 480); }

    @Override
    String displayName() { return "NTEX71021 Bike"; }

    @Override
    MetricReader defaultMetricReader(boolean ifitV2) { return new DirectLogcatMetricReader(); }

    @Override
    protected int inclineX() { return 950; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (493 - 13.57 * v);
    }
}
