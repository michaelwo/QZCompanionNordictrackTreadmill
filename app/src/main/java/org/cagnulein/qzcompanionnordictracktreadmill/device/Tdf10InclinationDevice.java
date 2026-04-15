package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class Tdf10InclinationDevice extends BikeDevice {
    public Tdf10InclinationDevice() { super(482, 482); }

    @Override
    public String displayName() { return "TDF10 Bike (Inclination)"; }

    @Override
    protected int inclineX() { return 74; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (-12.499 * v + 482.2);
    }
}
