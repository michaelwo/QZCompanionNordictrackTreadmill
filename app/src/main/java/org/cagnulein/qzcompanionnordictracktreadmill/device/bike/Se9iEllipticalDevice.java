package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Se9iEllipticalDevice extends BikeDevice {
    private static final int THUMB_Y_LEFT  = 858;
    private static final int THUMB_Y_RIGHT = 858;

    public Se9iEllipticalDevice() {
        // Screen: assumed 1920px, but both trackX values deviate from APK-expected:
        //   incline trackX=57 (expected≈75, −18px), resistance trackX=1857 (+11.5px).
        // Asymmetric offsets suggest non-standard slider margins on this model.
        super(
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return THUMB_Y_LEFT - (int) (v * (858.0 - 208.0) / 20.0); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            },
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return THUMB_Y_RIGHT - (int) ((v - 1) * (858.0 - 208.0) / 23.0); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.resistance()); }
            }
        ); }


    @Override
    public String displayName() { return "SE9i Elliptical"; }
}
