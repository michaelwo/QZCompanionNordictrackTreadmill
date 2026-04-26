package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Proform2000Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 520;
    private static final int ORIGIN_SPEED_THUMBY   = 598;

    public Proform2000Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Incline trackX=79 is 4.5px off APK-expected 74.5; matches hardware calibration.
        super(
            new Slider(ScreenProfile.W1280.leftTrackX, ORIGIN_INCLINE_THUMBY, Proform2000Device::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1280.rightTrackX, ORIGIN_SPEED_THUMBY, Proform2000Device::offsetSpeedThumbY)
        );
    }

    @Override public String displayName() { return "ProForm 2000 Treadmill"; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int) ((v + 3) * 21.804); }
    private static int offsetSpeedThumbY(double v)   { return (int) (631.03 - 19.921 * v); }
}
