package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class OtherDevice extends TreadmillDevice {
    public OtherDevice() {         super(
            new Slider(0) {
                public int trackX() { return 1205; }
                public int targetY(double v) { return (int) (631.03 - 19.921 * v); }
            },
            new Slider(0) {
                public int trackX() { return 79; }
                public int targetY(double v) { return (int) (520.11 - 21.804 * v); }
            }
        ); }

    @Override
    public String displayName() { return "Other Treadmill"; }




}
