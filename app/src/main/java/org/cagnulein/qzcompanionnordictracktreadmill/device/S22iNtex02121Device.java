package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S22iNtex02121Device extends BikeDevice {
    public S22iNtex02121Device() { super(535, 535); }

    @Override
    public String displayName() { return "S22i Bike (NTEX02121.5)"; }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return 800 - (int) ((v + 10) * 19);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
