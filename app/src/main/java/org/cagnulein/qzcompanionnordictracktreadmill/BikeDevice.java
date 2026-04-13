package org.cagnulein.qzcompanionnordictracktreadmill;

abstract class BikeDevice extends Device {
    private int yIncline;
    private int yResistance;

    protected BikeDevice(int initialInclineY, int initialResistanceY) {
        this.yIncline = initialInclineY;
        this.yResistance = initialResistanceY;
    }

    protected abstract int inclineX();
    protected abstract int targetInclineY(double value);
    protected int currentInclineY(MetricSnapshot current) { return yIncline; }

    /**
     * Quantizes an incoming grade to the nearest value this device can physically reach.
     * Default: identity (no quantization). Override for devices whose slider snaps to
     * a fixed grid (e.g. S22i snaps to 0.5% increments).
     */
    protected float quantizeIncline(float grade) { return grade; }

    protected int resistanceX()               { return -1; }
    protected int targetResistanceY(double v) { return -1; }
    protected int currentResistanceY(MetricSnapshot current) { return yResistance; }

    public final void applyIncline(double value, MetricSnapshot current) {
        int y2 = targetInclineY(value);
        swipe(inclineX(), currentInclineY(current), y2);
        yIncline = y2;
    }

    public final void applyResistance(double level, MetricSnapshot current) {
        if (resistanceX() == -1) return;
        int y2 = targetResistanceY(level);
        swipe(resistanceX(), currentResistanceY(current), y2);
        yResistance = y2;
    }

    @Override
    MetricSnapshot parseCommand(String[] parts, char decimalSeparator) {
        MetricSnapshot.Builder b = new MetricSnapshot.Builder();
        if (parts.length == 2) {
            Float v = parseField(parts[0], decimalSeparator);
            if (v != null && v != -1 && v != -100) b.inclinePct(roundToOneDecimal(v));
        }
        if (parts.length == 1) {
            Float v = parseField(parts[0], decimalSeparator);
            if (v != null && v != -1 && v != -100) b.resistanceLvl(roundToOneDecimal(v));
        }
        return b.build();
    }
}
