package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class C1750_2020Device extends TreadmillDevice {
    public C1750_2020Device() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(575, ScreenProfile.W1280.rightTrackX) {
                public int targetY(double v) { return 575 - (int) ((v * 0.621371 - 1.0) * 28.91); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(525, ScreenProfile.W1280.leftTrackX) {
                public int targetY(double v) { return 520 - (int) (v * 20); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "C1750 Treadmill (2020)"; }




    @Override public MetricReader defaultMetricReader() { return new CatFileMetricReader(); }



}
