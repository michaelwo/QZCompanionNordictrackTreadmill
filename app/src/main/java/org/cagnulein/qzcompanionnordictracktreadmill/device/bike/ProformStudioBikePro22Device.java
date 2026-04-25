package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class ProformStudioBikePro22Device extends BikeDevice {
    public ProformStudioBikePro22Device() {
        // Screen width unconfirmed: right trackX=1828 implies ~1903px — not a standard iFit screen width.
        // Calibrated from hardware; may use non-standard slider margins.
        super(
            new Slider(805, 1828) {
                public int targetY(double v) { return (int) (826.25 - 21.25 * v); }
            },
            null
        ); }

    @Override
    public String displayName() { return "ProForm Studio Bike Pro 2.2"; }


}
