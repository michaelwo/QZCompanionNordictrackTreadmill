package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S27iDevice extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY    = 803;
    private static final int ORIGIN_RESISTANCE_THUMBY = 803;

    public S27iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY, S27iDevice::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1920.rightTrackX, ORIGIN_RESISTANCE_THUMBY, S27iDevice::offsetResistanceThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.resistance()); }
            }
        );
    }

    @Override public String displayName() { return "S27i Bike"; }

    private static int offsetInclineThumbY(double v)    { return ORIGIN_INCLINE_THUMBY - (int) ((v + 10) * (803.0 - 248.0) / 30.0); }
    private static int offsetResistanceThumbY(double v) { return ORIGIN_RESISTANCE_THUMBY - (int) ((v - 1) * (803.0 - 248.0) / 23.0); }
}
