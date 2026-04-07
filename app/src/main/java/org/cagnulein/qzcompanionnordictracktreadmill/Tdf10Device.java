package org.cagnulein.qzcompanionnordictracktreadmill;

class Tdf10Device extends BikeDevice {
    Tdf10Device() { super(604, 604); }

    @Override
    String displayName() { return "TDF10 Bike"; }

    @Override
    protected int inclineX() { return 1205; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (619.91 - 15.913 * v);
    }
}
