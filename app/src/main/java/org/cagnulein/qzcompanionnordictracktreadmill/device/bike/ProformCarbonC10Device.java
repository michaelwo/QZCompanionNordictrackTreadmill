package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformCarbonC10Device extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 632;

    public ProformCarbonC10Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1280.rightTrackX, ORIGIN_INCLINE_THUMBY, ProformCarbonC10Device::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.resistance()); }
            },
            null
        );
    }

    @Override public String displayName() { return "ProForm Carbon C10 Bike"; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int) (v * 18.45); }
}
