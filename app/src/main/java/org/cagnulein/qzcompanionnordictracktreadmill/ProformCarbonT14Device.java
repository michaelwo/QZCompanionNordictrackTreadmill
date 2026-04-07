package org.cagnulein.qzcompanionnordictracktreadmill;

class ProformCarbonT14Device extends TreadmillDevice {
    ProformCarbonT14Device() { super(807, 844); }

    @Override
    String displayName() { return "ProForm Carbon T14 Treadmill"; }

    @Override
    protected int speedX() { return 1845; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (810 - 52.8 * v * 0.621371);
    }

    @Override
    MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }

    @Override
    protected int inclineX() { return 76; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (844 - 46.833 * v);
    }
}
