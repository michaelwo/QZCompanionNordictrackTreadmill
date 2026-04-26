package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750Device extends TreadmillDevice {
    public C1750Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        // Incline trackX=79 is 4.5px off APK-expected 74.5; matches hardware calibration.
        super(
            new Slider(793, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return 785 - (int) ((v - 1.0) * 31.42); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(694, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return (int) (700 - 34.9 * v); }
            }
        ); }

    @Override
    public String displayName() { return "C1750 Treadmill"; }




    @Override public MetricReader defaultMetricReader() { return new CatFileMetricReader(); }


}
