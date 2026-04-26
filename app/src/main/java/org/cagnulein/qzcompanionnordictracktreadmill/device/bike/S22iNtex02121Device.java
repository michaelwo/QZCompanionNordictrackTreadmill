package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S22iNtex02121Device extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 800;

    public S22iNtex02121Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY, S22iNtex02121Device::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            null
        );
    }

    @Override public String displayName() { return "S22i Bike (NTEX02121.5)"; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int) ((v + 10) * 19); }
}
