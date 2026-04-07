package org.cagnulein.qzcompanionnordictracktreadmill;

class S22iDevice extends BikeDevice {
    S22iDevice() { super(618, 618); }

    @Override
    String displayName() { return "S22i Bike"; }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (616.18 - 17.223 * v);
    }
}
