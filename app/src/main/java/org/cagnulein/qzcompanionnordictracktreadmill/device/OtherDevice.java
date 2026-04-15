package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class OtherDevice extends TreadmillDevice {
    public OtherDevice() { super(0, 0); }

    @Override
    public String displayName() { return "Other Treadmill"; }

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
        return (int) (520.11 - 21.804 * v);
    }
}
