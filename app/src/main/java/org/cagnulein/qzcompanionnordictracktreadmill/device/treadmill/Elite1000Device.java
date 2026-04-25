package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Elite1000Device extends TreadmillDevice {
    private final String name;

    public Elite1000Device(String name) {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Speed trackX=1209 is 3.5px off APK-expected 1205.5; matches hardware calibration.
        super(
            new Slider(600) {
                public int trackX() { return 1209; }
                public int targetY(double v) { return 600 - (int) (v * 0.621371 * 31.33); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(600) {
                public int trackX() { return 76; }
                public int targetY(double v) { return 589 - (int) (v * 32.8); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        );
        this.name = name;
    }

    @Override
    public String displayName() { return name; }






}
