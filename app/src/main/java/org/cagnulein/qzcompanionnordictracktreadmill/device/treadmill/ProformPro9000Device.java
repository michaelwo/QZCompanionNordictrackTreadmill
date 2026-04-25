package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformPro9000Device extends TreadmillDevice {
    public ProformPro9000Device() {
        // Screen width unconfirmed: right trackX=1825 implies ~1900px — not a standard iFit screen width.
        // Incline trackX=90 is 15.5px off APK-expected 74.5. Calibrated from hardware; may use non-standard slider margins.
        super(
            new Slider(800) {
                public int trackX() { return 1825; }
                public int targetY(double v) { return 800 - (int) ((v * 0.621371 - 1.0) * 41.6666); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(715) {
                public int trackX() { return 90; }
                public int targetY(double v) { return 720 - (int) (v * 34.583); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "ProForm Pro 9000 Treadmill"; }






}
