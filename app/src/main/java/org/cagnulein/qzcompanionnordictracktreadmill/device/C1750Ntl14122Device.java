package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750Ntl14122Device extends TreadmillDevice {
    public C1750Ntl14122Device() { super(787, 787); }

    @Override
    public String displayName() { return "C1750 Treadmill (NTL14122.2 MPH)"; }

    @Override
    protected int speedX() { return 1850; }

    @Override
    protected int targetSpeedY(double v) {
        return 787 - (int) (v * 43.5);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    protected int inclineX() { return 70; }

    @Override
    protected int targetInclineY(double v) {
        return 787 - (int) ((v + 3) * 29);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }
}
