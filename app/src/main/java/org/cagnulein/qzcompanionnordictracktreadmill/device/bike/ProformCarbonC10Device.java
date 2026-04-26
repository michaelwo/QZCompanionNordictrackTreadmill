package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformCarbonC10Device extends BikeDevice {
    private static final int THUMB_Y_LEFT = 632;

    public ProformCarbonC10Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1280.rightTrackX) {
                public int targetY(double v) { return THUMB_Y_LEFT - (int) (v * 18.45); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.resistance()); }
            },
            null
        ); }


    @Override
    public String displayName() { return "ProForm Carbon C10 Bike"; }
}
