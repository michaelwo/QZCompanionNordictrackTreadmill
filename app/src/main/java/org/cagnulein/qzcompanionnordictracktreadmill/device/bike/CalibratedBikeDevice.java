package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;

import org.cagnulein.qzcompanionnordictracktreadmill.calibration.CalibrationResult;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

/**
 * Bike device whose swipe formula and hysteresis are derived at runtime from
 * CalibrationResult rather than baked in as compile-time constants.
 *
 * CalibrationActivity writes CalibrationResult.current and persists it to
 * SharedPreferences; MainActivity loads it back on startup so this device
 * class itself has no Android dependency.
 *
 * Falls back to S22i defaults if no calibration has been saved yet, so the
 * device is non-crashing even if selected before calibration runs.
 */
public class CalibratedBikeDevice extends BikeDevice {

    public CalibratedBikeDevice() {
        super(buildSlider(), null);
    }

    @Override
    public String displayName() { return "Custom (Calibrated)"; }

    private static Slider buildSlider() {
        CalibrationResult cal = CalibrationResult.current;
        int initial = cal != null ? cal.neutralY : 622;
        return new Slider(initial) {

            @Override
            public int trackX() {
                CalibrationResult c = CalibrationResult.current;
                return c != null ? c.x : 75;
            }

            @Override
            public int targetY(double grade) {
                CalibrationResult c = CalibrationResult.current;
                return c != null ? c.targetY((float) grade)
                                 : (int) (622.0 - 14.8 * grade);
            }

            @Override
            protected int hysteresisPixels(int fromY, int toY) {
                CalibrationResult c = CalibrationResult.current;
                if (c == null) return Math.abs(toY - fromY) >= 40 ? 15 : 10;
                return Math.abs(toY - fromY) >= c.hystThresholdPx
                        ? c.hystLargePx : c.hystSmallPx;
            }

            @Override
            public float quantize(float v) {
                return Math.round(v * 2) / 2.0f;
            }
        };
    }
}
