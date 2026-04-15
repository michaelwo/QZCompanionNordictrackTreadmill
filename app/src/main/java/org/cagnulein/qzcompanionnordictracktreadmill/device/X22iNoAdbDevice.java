package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.MyAccessibilityService;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class X22iNoAdbDevice extends TreadmillDevice {
    public X22iNoAdbDevice() { super(785, 785); }

    @Override
    public String displayName() { return "X22i Treadmill (No ADB)"; }

    @Override
    protected int speedX() { return 1845; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (785 - 23.636363636363636 * v);
    }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (658 - 12 * v);
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
