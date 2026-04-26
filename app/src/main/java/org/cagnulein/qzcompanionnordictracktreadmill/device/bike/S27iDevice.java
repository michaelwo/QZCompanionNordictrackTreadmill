package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S27iDevice extends BikeDevice {
    private static final int THUMB_Y_LEFT  = 803;
    private static final int THUMB_Y_RIGHT = 803;

    public S27iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return THUMB_Y_LEFT - (int) ((v + 10) * (803.0 - 248.0) / 30.0); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            },
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return THUMB_Y_RIGHT - (int) ((v - 1) * (803.0 - 248.0) / 23.0); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.resistance()); }
            }
        ); }


    @Override
    public String displayName() { return "S27i Bike"; }
}
