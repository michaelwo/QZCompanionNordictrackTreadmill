package org.cagnulein.qzcompanionnordictracktreadmill;

class Se9iEllipticalDevice extends BikeDevice {
    Se9iEllipticalDevice() { super(858, 858); }

    @Override
    String displayName() { return "SE9i Elliptical"; }

    @Override
    protected int inclineX() { return 57; }

    @Override
    protected int targetInclineY(double v) {
        return 858 - (int) (v * (858.0 - 208.0) / 20.0);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }

    @Override
    protected int resistanceX() { return 1857; }

    @Override
    protected int targetResistanceY(double v) {
        return 858 - (int) ((v - 1) * (858.0 - 208.0) / 23.0);
    }

    @Override
    protected int currentResistanceY(MetricSnapshot current) {
        return targetResistanceY(current.resistance());
    }
}
