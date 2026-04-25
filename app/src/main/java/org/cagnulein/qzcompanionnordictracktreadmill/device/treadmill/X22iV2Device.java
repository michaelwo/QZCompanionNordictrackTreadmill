package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X22iV2Device extends TreadmillDevice {
    public X22iV2Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(785, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return (int) (838 - 26.136 * v); }
            },
            new Slider(785, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return (int) (742 - 11.9 * (v + 6)); }
            }
        ); }

    @Override
    public String displayName() { return "X22i V2 Treadmill"; }




}
