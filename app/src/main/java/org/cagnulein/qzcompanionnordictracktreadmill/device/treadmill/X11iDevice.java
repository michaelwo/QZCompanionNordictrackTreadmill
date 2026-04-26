package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X11iDevice extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 557;
    private static final int ORIGIN_SPEED_THUMBY   = 600;

    public X11iDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1280.leftTrackX, ORIGIN_INCLINE_THUMBY,  X11iDevice::offsetInclineThumbY),
            new Slider(ScreenProfile.W1280.rightTrackX,   ORIGIN_SPEED_THUMBY, X11iDevice::offsetSpeedThumbY)
        );
    }

    @Override public String displayName() { return "X11i Treadmill"; }

    private static int offsetInclineThumbY(double v) { return (int) (565.491 - 8.44 * v); }
    private static int offsetSpeedThumbY(double v)   { return (int) (621.997 - 21.785 * v); }
}
