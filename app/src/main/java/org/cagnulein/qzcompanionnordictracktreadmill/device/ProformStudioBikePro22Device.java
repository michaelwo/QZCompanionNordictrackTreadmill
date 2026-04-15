package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class ProformStudioBikePro22Device extends BikeDevice {
    public ProformStudioBikePro22Device() { super(805, 805); }

    @Override
    public String displayName() { return "ProForm Studio Bike Pro 2.2"; }

    @Override
    protected int inclineX() { return 1828; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (826.25 - 21.25 * v);
    }
}
