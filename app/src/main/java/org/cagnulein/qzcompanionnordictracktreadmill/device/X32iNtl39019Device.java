package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class X32iNtl39019Device extends TreadmillDevice {
    public X32iNtl39019Device() {         super(
            new Slider(779) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return (int) (817.5 - 42.5 * v * 0.621371); }
            },
            new Slider(740) {
                public int trackX() { return 74; }
                public int targetY(double v) { return (int) (749 - 11.8424 * v); }
            }
        ); }

    @Override
    public String displayName() { return "X32i Treadmill (NTL39019)"; }




}
