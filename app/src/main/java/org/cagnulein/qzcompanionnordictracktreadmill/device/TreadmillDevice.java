package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public abstract class TreadmillDevice extends Device {
    private int ySpeed;
    private int yIncline;

    protected TreadmillDevice(int initialSpeedY, int initialInclineY) {
        this.ySpeed = initialSpeedY;
        this.yIncline = initialInclineY;
    }

    protected abstract int speedX();
    protected abstract int targetSpeedY(double kmh);
    protected int currentSpeedY(MetricSnapshot current) { return ySpeed; }

    protected abstract int inclineX();
    protected abstract int targetInclineY(double pct);
    protected int currentInclineY(MetricSnapshot current) { return yIncline; }

    public final void applySpeed(double kmh, MetricSnapshot current) {
        int y2 = targetSpeedY(kmh);
        swipe(speedX(), currentSpeedY(current), y2);
        ySpeed = y2;
    }

    public final void applyIncline(double pct, MetricSnapshot current) {
        int y2 = targetInclineY(pct);
        swipe(inclineX(), currentInclineY(current), y2);
        yIncline = y2;
    }

    @Override
    public MetricSnapshot parseCommand(String[] parts, char decimalSeparator) {
        MetricSnapshot.Builder b = new MetricSnapshot.Builder();
        if (parts.length == 2) {
            Float s = parseField(parts[0], decimalSeparator);
            Float i = parseField(parts[1], decimalSeparator);
            if (s != null && s != -1)   b.speedKmh(roundToOneDecimal(s));
            if (i != null && i != -100) b.inclinePct(roundToOneDecimal(i));
        }
        return b.build();
    }
}
