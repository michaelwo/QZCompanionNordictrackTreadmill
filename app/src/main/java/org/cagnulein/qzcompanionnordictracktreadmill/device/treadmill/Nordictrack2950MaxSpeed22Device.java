package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Nordictrack2950MaxSpeed22Device extends TreadmillDevice {
    public Nordictrack2950MaxSpeed22Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(807, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return 682 - (int) ((v - 1.0) * 26.5); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(717, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return 807 - (int) ((v + 3) * 31.1); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "NordicTrack 2950 Treadmill (Max Speed 22)"; }






}
