package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X22iDevice extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 785;
    private static final int THUMB_Y_LEFT  = 785;

    public X22iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return (int) (THUMB_Y_RIGHT - 23.636363636363636 * v); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return (int) (THUMB_Y_LEFT - 11.304347826086957 * (v + 6)); }
            }
        );
    }


    @Override
    public String displayName() { return "X22i Treadmill"; }
}
