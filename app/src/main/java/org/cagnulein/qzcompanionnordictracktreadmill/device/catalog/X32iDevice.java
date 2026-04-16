package org.cagnulein.qzcompanionnordictracktreadmill.device.catalog;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X32iDevice extends TreadmillDevice {
    public X32iDevice() {         super(
            new Slider(927) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return (int) (834.85 - 26.946 * v); }
            },
            new Slider(881) {
                public int trackX() { return 76; }
                public int targetY(double v) { return (int) (734.07 - 12.297 * v); }
            }
        ); }

    @Override
    public String displayName() { return "X32i Treadmill"; }




}
