package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class ProformPro9000Device extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 720;
    private static final int ORIGIN_SPEED_THUMBY   = 800;

    public ProformPro9000Device() {
        // Screen: 1920px wide — updated to iFit APK 2.6.90 standard
        //   (original hardware calibration: left=90, right=1825).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY, ProformPro9000Device::offsetInclineThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.incline()); }
            },
            new Slider(ScreenProfile.W1920.rightTrackX, ORIGIN_SPEED_THUMBY, ProformPro9000Device::offsetSpeedThumbY) {
                protected int currentThumbY(MetricSnapshot current) { return targetThumbY(current.speed()); }
            }
        );
    }

    @Override public String displayName() { return "ProForm Pro 9000 Treadmill"; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int) (v * 34.583); }
    private static int offsetSpeedThumbY(double v)   { return ORIGIN_SPEED_THUMBY - (int) ((v * 0.621371 - 1.0) * 41.6666); }
}
