package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750Ntl14122Device extends TreadmillDevice {
    public C1750Ntl14122Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Speed trackX=1850 (+4.5px) and incline trackX=70 (−4.5px) both deviate from APK-expected; matches hardware calibration.
        super(
            new Slider(787) {
                public int trackX() { return 1850; }
                public int targetY(double v) { return 787 - (int) (v * 43.5); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(787) {
                public int trackX() { return 70; }
                public int targetY(double v) { return 787 - (int) ((v + 3) * 29); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "C1750 Treadmill (NTL14122.2 MPH)"; }






}
