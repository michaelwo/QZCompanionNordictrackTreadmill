package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Proform2000Device extends TreadmillDevice {
    public Proform2000Device() { super(598, 522); }

    @Override
    public String displayName() { return "ProForm 2000 Treadmill"; }

    @Override
    protected int speedX() { return 1205; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (631.03 - 19.921 * v);
    }

    @Override
    protected int inclineX() { return 79; }

    @Override
    protected int targetInclineY(double v) {
        return 520 - (int) ((v + 3) * 21.804);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
