package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X32iDevice extends TreadmillDevice {
    public X32iDevice() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Speed initialThumbY=927 starts below targetY(0)≈835; conservative position ensures the first speed swipe always travels upward.
        super(
            new Slider(927, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return (int) (834.85 - 26.946 * v); }
            },
            new Slider(881, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return (int) (734.07 - 12.297 * v); }
            }
        ); }

    @Override
    public String displayName() { return "X32i Treadmill"; }




}
