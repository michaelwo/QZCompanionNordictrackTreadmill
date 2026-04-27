package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class T65sDevice extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 585;
    private static final int ORIGIN_SPEED_THUMBY   = 495;

    private final String name;

    public T65sDevice(String name) {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1280.leftTrackX, ORIGIN_INCLINE_THUMBY,  T65sDevice::offsetInclineThumbY),
            new Slider(ScreenProfile.W1280.rightTrackX,   ORIGIN_SPEED_THUMBY, T65sDevice::offsetSpeedThumbY)
        );
        this.name = name;
    }

    @Override public String displayName() { return name; }

    private static int offsetInclineThumbY(double v) { return (int) (576.91 - 34.182 * v); }
    private static int offsetSpeedThumbY(double v)   { return (int) (578.36 - 35.866 * v * KMH_TO_MPH); }
}
