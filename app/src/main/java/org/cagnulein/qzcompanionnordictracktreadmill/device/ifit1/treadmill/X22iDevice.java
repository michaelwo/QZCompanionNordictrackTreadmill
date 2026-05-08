package org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.InclineSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.SpeedSlider;

public class X22iDevice extends TreadmillDevice {

    public X22iDevice() { this(785, 11.304347826086957, 785, 23.636363636363636); }

    // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/discover-device/validate_swipe_targets.py).
    protected X22iDevice(int originIncline, double inclineScale, int originSpeed, double speedScale) {
        super(
            new InclineSlider(ScreenProfile.W1920.leftTrackX,  originIncline, v -> (int)(originIncline - inclineScale * (v + 6))),
            new SpeedSlider(  ScreenProfile.W1920.rightTrackX, originSpeed,   v -> (int)(originSpeed - speedScale * v))
        );
    }

    @Override public String displayName() { return "X22i Treadmill"; }
}
