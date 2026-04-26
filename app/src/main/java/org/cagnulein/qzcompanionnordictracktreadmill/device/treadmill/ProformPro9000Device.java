package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformPro9000Device extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 800;
    private static final int THUMB_Y_LEFT  = 715;

    public ProformPro9000Device() {
        // Screen: 1920px wide — updated to iFit APK 2.6.90 standard
        //   (original hardware calibration: left=90, right=1825).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return THUMB_Y_RIGHT - (int) ((v * 0.621371 - 1.0) * 41.6666); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return 720 - (int) (v * 34.583); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }


    @Override
    public String displayName() { return "ProForm Pro 9000 Treadmill"; }
}
