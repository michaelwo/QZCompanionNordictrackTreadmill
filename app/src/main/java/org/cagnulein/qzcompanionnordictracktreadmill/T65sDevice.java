package org.cagnulein.qzcompanionnordictracktreadmill;

class T65sDevice extends TreadmillDevice {
    private final String name;
    private final MetricReader reader;

    T65sDevice(String name) { this(name, null); }

    T65sDevice(String name, MetricReader reader) {
        super(495, 585);
        this.name = name;
        this.reader = reader;
    }

    @Override
    String displayName() { return name; }

    @Override
    MetricReader defaultMetricReader(boolean ifitV2) {
        return reader != null ? reader : super.defaultMetricReader(ifitV2);
    }

    @Override
    protected int speedX() { return 1205; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (578.36 - 35.866 * v * 0.621371);
    }

    @Override
    protected int inclineX() { return 74; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (576.91 - 34.182 * v);
    }
}
