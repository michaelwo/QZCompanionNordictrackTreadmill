package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class X32iNtl39221Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 750;
    private static final int ORIGIN_SPEED_THUMBY   = 579;

    public X32iNtl39221Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY, X32iNtl39221Device::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1920.rightTrackX, ORIGIN_SPEED_THUMBY, X32iNtl39221Device::offsetSpeedThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.speed()); }
            }
        );
    }

    @Override public String displayName() { return "X32i Treadmill (NTL39221)"; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int) (v * 12.05); }
    private static int offsetSpeedThumbY(double v)   { return (int) (900.26 - 46.63 * v * 0.621371); }
}
