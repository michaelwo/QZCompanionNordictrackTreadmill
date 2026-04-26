package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750_2021Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 553;
    private static final int ORIGIN_SPEED_THUMBY   = 620;

    public C1750_2021Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Incline trackX=79 is 4.5px off APK-expected 74.5; matches hardware calibration.
        super(
            new Slider(ScreenProfile.W1280.leftTrackX, ORIGIN_INCLINE_THUMBY, C1750_2021Device::offsetInclineThumbY),
            new Slider(ScreenProfile.W1280.rightTrackX, ORIGIN_SPEED_THUMBY, C1750_2021Device::offsetSpeedThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.speed()); }
            }
        );
    }

    @Override public String displayName() { return "C1750 Treadmill (2021)"; }

    private static int offsetInclineThumbY(double v) { return (int) (ORIGIN_INCLINE_THUMBY - 22 * v); }
    private static int offsetSpeedThumbY(double v)   { return ORIGIN_SPEED_THUMBY - (int) ((v - 1.0) * 20.73); }
}
