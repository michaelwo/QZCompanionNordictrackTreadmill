package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class T65sDevice extends TreadmillDevice {
    private static final int THUMB_Y_RIGHT = 495;
    private static final int THUMB_Y_LEFT  = 585;

    private final String name;

    public T65sDevice(String name) {
        // Screen: 1280px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(THUMB_Y_RIGHT, ScreenProfile.W1280.rightTrackX) {
                public int targetY(double v) { return (int) (578.36 - 35.866 * v * 0.621371); }
            },
            new Slider(THUMB_Y_LEFT, ScreenProfile.W1280.leftTrackX) {
                public int targetY(double v) { return (int) (576.91 - 34.182 * v); }
            }
        );
        this.name = name;
    }


    @Override
    public String displayName() { return name; }
}
