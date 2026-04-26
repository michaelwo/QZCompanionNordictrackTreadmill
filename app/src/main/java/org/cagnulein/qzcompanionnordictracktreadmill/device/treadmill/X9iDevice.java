package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X9iDevice extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 332;
    private static final int THUMB_Y_LEFT  = 332;

    public X9iDevice() {
        // Screen: 800px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W800.rightTrackX) {
                public int targetY(double v) { return (int) (345.6315 - 13.6315 * v); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W800.leftTrackX) {
                public int targetY(double v) { return (int) (311.91 - 3.3478 * v); }
            }
        );
    }


    @Override
    public String displayName() { return "X9i Treadmill"; }
}
