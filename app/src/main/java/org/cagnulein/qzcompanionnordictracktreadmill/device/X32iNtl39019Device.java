package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class X32iNtl39019Device extends TreadmillDevice {
    public X32iNtl39019Device() { super(779, 740); }

    @Override
    public String displayName() { return "X32i Treadmill (NTL39019)"; }

    @Override
    protected int speedX() { return 1845; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (817.5 - 42.5 * v * 0.621371);
    }

    @Override
    protected int inclineX() { return 74; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (749 - 11.8424 * v);
    }
}
