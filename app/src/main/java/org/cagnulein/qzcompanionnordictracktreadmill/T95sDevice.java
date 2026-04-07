package org.cagnulein.qzcompanionnordictracktreadmill;

class T95sDevice extends TreadmillDevice {
    T95sDevice() { super(817, 817); }

    @Override
    String displayName() { return "T9.5s Treadmill"; }

    @Override
    protected int speedX() { return 1845; }

    @Override
    protected int targetSpeedY(double v) {
        return 847 - (int) (30.0 * v);
    }

    @Override
    protected int currentSpeedY(MetricSnapshot current) {
        return targetSpeedY(current.speed());
    }

    @Override
    protected int inclineX() { return 76; }

    @Override
    protected int targetInclineY(double v) {
        return 846 - (int) (46.0 * v);
    }

    @Override
    protected int currentInclineY(MetricSnapshot current) {
        return targetInclineY(current.incline());
    }

    @Override
    protected void swipe(int x, int y1, int y2) {
        MyAccessibilityService.performSwipe(x, y1, x, y2, 200);
    }
}
