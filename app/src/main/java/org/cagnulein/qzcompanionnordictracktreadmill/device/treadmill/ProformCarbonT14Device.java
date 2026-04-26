package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class ProformCarbonT14Device extends TreadmillDevice {
    public ProformCarbonT14Device() {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(807, ScreenProfile.W1920.rightTrackX) {
                public int targetY(double v) { return (int) (810 - 52.8 * v * 0.621371); }
            },
            new Slider(844, ScreenProfile.W1920.leftTrackX) {
                public int targetY(double v) { return (int) (844 - 46.833 * v); }
            }
        ); }

    @Override
    public String displayName() { return "ProForm Carbon T14 Treadmill"; }



    @Override public MetricReader defaultMetricReader() { return new CatFileMetricReader(); }


}
