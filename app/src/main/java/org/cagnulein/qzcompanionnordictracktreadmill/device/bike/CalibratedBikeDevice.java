package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;

import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceCalibration;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;

/**
 * Bike device whose swipe formulas are loaded at runtime from DeviceCalibration
 * rather than baked in as compile-time constants.
 *
 * DeviceCalibration is populated either from /sdcard/qz-calibration.json (written
 * by tools/discover-device.py) or from SharedPreferences (legacy in-app flow).
 * MainActivity loads it before the device list is rendered.
 *
 * Falls back gracefully when DeviceCalibration.current is null or resistance data
 * is absent: incline defaults to S22i constants, resistance slider is omitted.
 */
public class CalibratedBikeDevice extends BikeDevice {

    private static final int    S22I_DEFAULT_NEUTRAL_Y      = 622;
    private static final double S22I_DEFAULT_INCLINE_SCALE  = 14.8;
    private static final int    S22I_DEFAULT_RES_TRACK_X    = 1845;

    public CalibratedBikeDevice() {
        super(buildInclineSlider(), buildResistanceSlider());
    }

    @Override
    public String displayName() { return "Custom (Calibrated)"; }

    // ── incline ───────────────────────────────────────────────────────────────

    private static Slider buildInclineSlider() {
        DeviceCalibration cal = DeviceCalibration.current;
        int initial = cal != null ? cal.neutralY : S22I_DEFAULT_NEUTRAL_Y;
        return (new Slider(initial) {

            @Override
            public int trackX() {
                DeviceCalibration c = DeviceCalibration.current;
                return c != null ? c.x : 75;
            }

            @Override
            public int targetThumbY(double grade) {
                DeviceCalibration c = DeviceCalibration.current;
                return c != null
                        ? c.targetThumbY((float) grade)
                        : (int) (S22I_DEFAULT_NEUTRAL_Y - S22I_DEFAULT_INCLINE_SCALE * grade);
            }

            @Override
            protected int hysteresisPixels(int fromY, int toY) {
                DeviceCalibration c = DeviceCalibration.current;
                if (c == null) return Math.abs(toY - fromY) >= 40 ? 15 : 10;
                return Math.abs(toY - fromY) >= c.hystThresholdPx
                        ? c.hystLargePx : c.hystSmallPx;
            }

            @Override
            public float quantize(float v) {
                return Math.round(v * 2) / 2.0f;
            }

            @Override
            protected int currentThumbY() {
                return liveValue != null ? targetThumbY(liveValue) : thumbY();
            }
        }).withMetric(SliderMetric.GRADE);
    }

    // ── resistance ────────────────────────────────────────────────────────────

    private static Slider buildResistanceSlider() {
        DeviceCalibration cal = DeviceCalibration.current;
        if (cal == null || cal.resistanceOrigin == null) return null;
        int initY = (int) cal.resistanceOrigin.doubleValue();
        return (new Slider(initY) {

            @Override
            public int trackX() {
                DeviceCalibration c = DeviceCalibration.current;
                return (c != null && c.resistanceTrackX != null)
                        ? c.resistanceTrackX : S22I_DEFAULT_RES_TRACK_X;
            }

            @Override
            public int targetThumbY(double level) {
                DeviceCalibration c = DeviceCalibration.current;
                if (c == null || c.resistanceOrigin == null) return initY;
                return (int) (c.resistanceOrigin
                        - c.resistanceScale * (level - c.resistanceMinLevel));
            }

            @Override
            public float quantize(float v) {
                return Math.round(v);
            }

            @Override
            protected int currentThumbY() {
                return (liveValue != null && liveValue >= 1)
                        ? targetThumbY(liveValue) : thumbY();
            }
        }).withMetric(SliderMetric.RESISTANCE);
    }
}
