package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class ProformStudioBikePro22Device extends BikeDevice {
    public ProformStudioBikePro22Device() {         super(
            new Slider(805) {
                public int trackX() { return 1828; }
                public int targetY(double v) { return (int) (826.25 - 21.25 * v); }
            },
            null
        ); }

    @Override
    public String displayName() { return "ProForm Studio Bike Pro 2.2"; }


}
