package org.cagnulein.qzcompanionnordictracktreadmill.device.catalog;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class S22iDevice extends BikeDevice {
    public S22iDevice() {         super(
            new Slider(618) {
                public int trackX() { return 75; }
                public int targetY(double v) {
                    // For grades above 3%, the formula lands just short of the target snap point;
                    // adding 0.5 corrects this overshoot to land in the right snap zone.
                    return (int) (616.18 - 17.223 * (v > 3.0 ? v + 0.5 : v));
                }
                public float quantize(float v) {
                    // iFit slider snaps to 0.5% increments. Round to nearest 0.5 so swipes
                    // only target positions the slider can physically reach.
                    return Math.round(v * 2) / 2.0f;
                }
            },
            null
        ); }

    @Override
    public String displayName() { return "S22i Bike"; }



}
