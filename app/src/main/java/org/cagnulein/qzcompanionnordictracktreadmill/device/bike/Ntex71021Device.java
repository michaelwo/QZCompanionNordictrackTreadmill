package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.DirectLogcatMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class Ntex71021Device extends BikeDevice {
    public Ntex71021Device() {
        // Screen: 1024px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(480, ScreenProfile.W1024.rightTrackX) {
                public int targetY(double v) { return (int) (493 - 13.57 * v); }
            },
            null
        ); }

    @Override
    public String displayName() { return "NTEX71021 Bike"; }

    @Override public MetricReader defaultMetricReader() { return new DirectLogcatMetricReader(); }


}
