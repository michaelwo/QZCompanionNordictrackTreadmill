package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S22iNtex02121Device extends BikeDevice {
    private static final int THUMB_Y_LEFT = 535;

    public S22iNtex02121Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return 800 - (int) ((v + 10) * 19); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            },
            null
        ); }


    @Override
    public String displayName() { return "S22i Bike (NTEX02121.5)"; }
}
