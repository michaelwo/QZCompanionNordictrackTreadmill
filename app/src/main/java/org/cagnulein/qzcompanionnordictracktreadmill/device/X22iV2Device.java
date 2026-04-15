package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class X22iV2Device extends TreadmillDevice {
    public X22iV2Device() { super(785, 785); }

    @Override
    public String displayName() { return "X22i V2 Treadmill"; }

    @Override
    protected int speedX() { return 1845; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (838 - 26.136 * v);
    }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (742 - 11.9 * (v + 6));
    }
}
