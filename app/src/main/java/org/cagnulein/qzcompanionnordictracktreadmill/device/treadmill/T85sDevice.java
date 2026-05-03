package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class T85sDevice extends TreadmillDevice {

    public T85sDevice() {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            Slider.inclineLive(ScreenProfile.W1280.leftTrackX,  609, v -> 609 - (int)(36.417 * v)),
            Slider.speedLive(  ScreenProfile.W1280.rightTrackX, 609, v -> (int)(629.81 - 20.81 * v))
        );
    }

    @Override public String displayName() { return "T8.5s Treadmill"; }
}
