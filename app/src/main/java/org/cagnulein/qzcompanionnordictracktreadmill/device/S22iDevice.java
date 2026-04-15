package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class S22iDevice extends BikeDevice {
    public S22iDevice() { super(618, 618); }

    @Override
    public String displayName() { return "S22i Bike"; }

    @Override
    protected int inclineX() { return 75; }

    @Override
    public float quantizeIncline(float grade) {
        // iFit slider snaps to 0.5% increments. Round to nearest 0.5 so swipes
        // only target positions the slider can physically reach.
        return Math.round(grade * 2) / 2.0f;
    }

    @Override
    protected int targetInclineY(double v) {
        // For grades above 3%, the formula lands just short of the target snap point;
        // adding 0.5 corrects this overshoot to land in the right snap zone.
        return (int) (616.18 - 17.223 * (v > 3.0 ? v + 0.5 : v));
    }
}
