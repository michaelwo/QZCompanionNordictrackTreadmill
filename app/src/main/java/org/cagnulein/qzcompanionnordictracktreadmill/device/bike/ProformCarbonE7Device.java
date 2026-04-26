package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformCarbonE7Device extends BikeDevice {
    private static final int THUMB_Y_LEFT  = 440;
    private static final int THUMB_Y_RIGHT = 440;

    public ProformCarbonE7Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1024.leftTrackX) {
                public int targetY(double v) { return THUMB_Y_LEFT - (int) (v * 11); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            },
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1024.rightTrackX) {
                public int targetY(double v) { return THUMB_Y_RIGHT - (int) (v * 9.16); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.resistance()); }
            }
        ); }


    @Override
    public String displayName() { return "ProForm Carbon E7 Bike"; }
}
