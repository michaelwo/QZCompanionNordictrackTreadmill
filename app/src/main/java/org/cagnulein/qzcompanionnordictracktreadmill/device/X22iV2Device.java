package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class X22iV2Device extends TreadmillDevice {
    public X22iV2Device() {         super(
            new Slider(785) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return (int) (838 - 26.136 * v); }
            },
            new Slider(785) {
                public int trackX() { return 75; }
                public int targetY(double v) { return (int) (742 - 11.9 * (v + 6)); }
            }
        ); }

    @Override
    public String displayName() { return "X22i V2 Treadmill"; }




}
