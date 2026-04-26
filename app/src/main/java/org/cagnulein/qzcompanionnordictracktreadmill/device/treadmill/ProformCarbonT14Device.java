package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class ProformCarbonT14Device extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 807;
    private static final int THUMB_Y_LEFT  = 844;

    public ProformCarbonT14Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return (int) (810 - 52.8 * v * 0.621371); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return (int) (THUMB_Y_LEFT - 46.833 * v); }
            }
        ); }


    @Override
    public String displayName() { return "ProForm Carbon T14 Treadmill"; }
}
