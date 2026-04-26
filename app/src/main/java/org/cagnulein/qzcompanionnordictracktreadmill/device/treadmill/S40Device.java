package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class S40Device extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 482;
    private static final int THUMB_Y_LEFT  = 490;

    public S40Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1024.rightTrackX) {
                public int targetY(double v) { return (int) (507 - 12.5 * v); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1024.leftTrackX) {
                public int targetY(double v) { return (int) (THUMB_Y_LEFT - 21.4 * v); }
            }
        ); }


    @Override
    public String displayName() { return "S40 Treadmill"; }
}
