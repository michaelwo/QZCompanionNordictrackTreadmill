package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X11iDevice extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 600;
    private static final int THUMB_Y_LEFT  = 557;

    public X11iDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1280.rightTrackX) {
                public int targetY(double v) { return (int) (621.997 - 21.785 * v); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1280.leftTrackX) {
                public int targetY(double v) { return (int) (565.491 - 8.44 * v); }
            }
        ); }


    @Override
    public String displayName() { return "X11i Treadmill"; }
}
