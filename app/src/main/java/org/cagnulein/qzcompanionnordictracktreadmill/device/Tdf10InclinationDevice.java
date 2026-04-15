package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class Tdf10InclinationDevice extends BikeDevice {
    public Tdf10InclinationDevice() {         super(
            new Slider(482) {
                public int trackX() { return 74; }
                public int targetY(double v) { return (int) (-12.499 * v + 482.2); }
            },
            null
        ); }

    @Override
    public String displayName() { return "TDF10 Bike (Inclination)"; }


}
