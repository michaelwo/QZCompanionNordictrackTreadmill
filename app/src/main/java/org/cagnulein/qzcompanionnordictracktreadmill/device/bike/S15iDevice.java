package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S15iDevice extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY    = 616;
    private static final int ORIGIN_RESISTANCE_THUMBY = 790;

    public S15iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY, S15iDevice::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1920.rightTrackX, ORIGIN_RESISTANCE_THUMBY, S15iDevice::offsetResistanceThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.gear()); }
            }
        );
    }

    @Override public String displayName() { return "S15i Bike"; }

    private static int offsetInclineThumbY(double v)    { return ORIGIN_INCLINE_THUMBY - (int) (v * 17.65); }
    private static int offsetResistanceThumbY(double v) { return ORIGIN_RESISTANCE_THUMBY - (int) (v * 23.16); }
}
