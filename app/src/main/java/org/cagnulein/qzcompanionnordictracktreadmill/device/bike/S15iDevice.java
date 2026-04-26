package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S15iDevice extends BikeDevice {
    private static final int THUMB_Y_LEFT  = 618;
    private static final int THUMB_Y_RIGHT = 790;

    public S15iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return 616 - (int) (v * 17.65); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            },
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return THUMB_Y_RIGHT - (int) (v * 23.16); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.gear()); }
            }
        ); }


    @Override
    public String displayName() { return "S15i Bike"; }
}
