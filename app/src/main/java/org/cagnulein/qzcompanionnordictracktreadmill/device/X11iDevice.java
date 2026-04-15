package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class X11iDevice extends TreadmillDevice {
    public X11iDevice() { super(600, 557); }

    @Override
    public String displayName() { return "X11i Treadmill"; }

    @Override
    protected int speedX() { return 1207; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (621.997 - 21.785 * v);
    }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (565.491 - 8.44 * v);
    }
}
