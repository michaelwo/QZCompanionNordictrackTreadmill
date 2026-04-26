package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class S40Device extends TreadmillDevice {
    public S40Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(482, ScreenProfile.W1024.rightTrackX) {
                public int targetY(double v) { return (int) (507 - 12.5 * v); }
            },
            new Slider(490, ScreenProfile.W1024.leftTrackX) {
                public int targetY(double v) { return (int) (490 - 21.4 * v); }
            }
        ); }

    @Override
    public String displayName() { return "S40 Treadmill"; }




}
