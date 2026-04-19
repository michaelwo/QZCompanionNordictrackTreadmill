package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class S40Device extends TreadmillDevice {
    public S40Device() {         super(
            new Slider(482) {
                public int trackX() { return 949; }
                public int targetY(double v) { return (int) (507 - 12.5 * v); }
            },
            new Slider(490) {
                public int trackX() { return 75; }
                public int targetY(double v) { return (int) (490 - 21.4 * v); }
            }
        ); }

    @Override
    public String displayName() { return "S40 Treadmill"; }




}
