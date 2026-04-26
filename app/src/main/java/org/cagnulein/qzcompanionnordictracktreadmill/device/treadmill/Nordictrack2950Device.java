package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Nordictrack2950Device extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 807;
    private static final int THUMB_Y_LEFT  = 717;

    public Nordictrack2950Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return THUMB_Y_RIGHT - (int) ((v - 1.0) * 31); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return 807 - (int) ((v + 3) * 31.1); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }


    @Override
    public String displayName() { return "NordicTrack 2950 Treadmill"; }
}
