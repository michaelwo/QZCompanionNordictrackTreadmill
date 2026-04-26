package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X32iNtl39019Device extends TreadmillDevice {
    public X32iNtl39019Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(779, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return (int) (817.5 - 42.5 * v * 0.621371); }
            },
            new Slider(740, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return (int) (749 - 11.8424 * v); }
            }
        ); }

    @Override
    public String displayName() { return "X32i Treadmill (NTL39019)"; }




}
