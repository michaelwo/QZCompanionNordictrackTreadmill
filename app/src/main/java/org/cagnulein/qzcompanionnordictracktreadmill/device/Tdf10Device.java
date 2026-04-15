package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class Tdf10Device extends BikeDevice {
    public Tdf10Device() {         super(
            new Slider(604) {
                public int trackX() { return 1205; }
                public int targetY(double v) { return (int) (619.91 - 15.913 * v); }
            },
            null
        ); }

    @Override
    public String displayName() { return "TDF10 Bike"; }


}
