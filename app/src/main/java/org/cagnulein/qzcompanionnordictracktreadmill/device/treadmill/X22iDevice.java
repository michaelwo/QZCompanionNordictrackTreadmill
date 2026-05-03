package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class X22iDevice extends TreadmillDevice {

    public X22iDevice() { this(785, 11.304347826086957, 785, 23.636363636363636); }

    // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
    protected X22iDevice(int originIncline, double inclineScale, int originSpeed, double speedScale) {
        super(
            Slider.linear(ScreenProfile.W1920.leftTrackX,  originIncline, inclineScale, 6),
            Slider.linear(ScreenProfile.W1920.rightTrackX, originSpeed,   speedScale)
        );
    }

    @Override public String displayName() { return "X22i Treadmill"; }
}
