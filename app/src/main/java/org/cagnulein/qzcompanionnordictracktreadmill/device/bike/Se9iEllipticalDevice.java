package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Se9iEllipticalDevice extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY    = 858;
    private static final int ORIGIN_RESISTANCE_THUMBY = 858;

    public Se9iEllipticalDevice() {
        // Screen: assumed 1920px, but both trackX values deviate from APK-expected:
        //   incline trackX=57 (expected≈75, −18px), resistance trackX=1857 (+11.5px).
        // Asymmetric offsets suggest non-standard slider margins on this model.
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY, Se9iEllipticalDevice::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1920.rightTrackX, ORIGIN_RESISTANCE_THUMBY, Se9iEllipticalDevice::offsetResistanceThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.resistance()); }
            }
        );
    }

    @Override public String displayName() { return "SE9i Elliptical"; }

    private static int offsetInclineThumbY(double v)    { return ORIGIN_INCLINE_THUMBY - (int) (v * (858.0 - 208.0) / 20.0); }
    private static int offsetResistanceThumbY(double v) { return ORIGIN_RESISTANCE_THUMBY - (int) ((v - 1) * (858.0 - 208.0) / 23.0); }
}
