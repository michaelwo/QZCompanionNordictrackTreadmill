package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Se9iEllipticalDevice extends BikeDevice {

    public Se9iEllipticalDevice() {
        // Screen: assumed 1920px, but both trackX values deviate from APK-expected:
        //   incline trackX=57 (expected≈75, −18px), resistance trackX=1857 (+11.5px).
        // Asymmetric offsets suggest non-standard slider margins on this model.
        super(
            Slider.inclineLive(   ScreenProfile.W1920.leftTrackX,  858, v -> 858 - (int)(v       * (858.0 - 208.0) / 20.0)),
            Slider.resistanceLive(ScreenProfile.W1920.rightTrackX, 858, v -> 858 - (int)((v - 1) * (858.0 - 208.0) / 23.0))
        );
    }

    @Override public String displayName() { return "SE9i Elliptical"; }
}
