package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.MyAccessibilityService;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class X22iNoAdbDevice extends TreadmillDevice {
    public X22iNoAdbDevice() {         super(
            new Slider(785) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return (int) (785 - 23.636363636363636 * v); }
            },
            new Slider(785) {
                public int trackX() { return 75; }
                public int targetY(double v) { return (int) (658 - 12 * v); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "X22i Treadmill (No ADB)"; }






    @Override public boolean requiresAdb() { return false; }

    @Override
    protected void swipe(int x, int y1, int y2) {
        MyAccessibilityService.performSwipe(x, y1, x, y2, 200);
    }
}
