package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformCarbonE7Device extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY    = 440;
    private static final int ORIGIN_RESISTANCE_THUMBY = 440;

    public ProformCarbonE7Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1024.leftTrackX, ORIGIN_INCLINE_THUMBY, ProformCarbonE7Device::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1024.rightTrackX, ORIGIN_RESISTANCE_THUMBY, ProformCarbonE7Device::offsetResistanceThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.resistance()); }
            }
        );
    }

    @Override public String displayName() { return "ProForm Carbon E7 Bike"; }

    private static int offsetInclineThumbY(double v)    { return ORIGIN_INCLINE_THUMBY - (int) (v * 11); }
    private static int offsetResistanceThumbY(double v) { return ORIGIN_RESISTANCE_THUMBY - (int) (v * 9.16); }
}
