package org.cagnulein.qzcompanionnordictracktreadmill;

class S40Device extends TreadmillDevice {
    S40Device() { super(482, 490); }

    @Override
    String displayName() { return "S40 Treadmill"; }

    @Override
    protected int speedX() { return 949; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (507 - 12.5 * v);
    }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (490 - 21.4 * v);
    }
}
