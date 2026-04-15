package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class X32iDevice extends TreadmillDevice {
    public X32iDevice() { super(927, 881); }

    @Override
    public String displayName() { return "X32i Treadmill"; }

    @Override
    protected int speedX() { return 1845; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (834.85 - 26.946 * v);
    }

    @Override
    protected int inclineX() { return 76; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (734.07 - 12.297 * v);
    }
}
