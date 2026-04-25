package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.service.MyAccessibilityService;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class T95sDevice extends TreadmillDevice {
    public T95sDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
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







    @Override public boolean requiresAdb() { return false; }
    @Override public boolean requiresAccessibility() { return true; }

    @Override
    protected void swipe(int x, int y1, int y2) {
        MyAccessibilityService.performSwipe(x, y1, x, y2, 200);
    }
}
