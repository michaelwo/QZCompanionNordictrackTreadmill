package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.MyAccessibilityService;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class T95sDevice extends TreadmillDevice {
    public T95sDevice() {         super(
            new Slider(817) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return 847 - (int) (30.0 * v); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(817) {
                public int trackX() { return 76; }
                public int targetY(double v) { return 846 - (int) (46.0 * v); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "T9.5s Treadmill"; }







    @Override
    protected void swipe(int x, int y1, int y2) {
        MyAccessibilityService.performSwipe(x, y1, x, y2, 200);
    }
}
