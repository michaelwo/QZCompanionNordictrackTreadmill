package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;

public class S22iDevice extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY    = 622;
    private static final int ORIGIN_RESISTANCE_THUMBY = 724;

    public S22iDevice() { this(0, 0); }

    protected S22iDevice(int hystLong, int hystShort) {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY, S22iDevice::offsetInclineThumbY) {
                // Calibration 2026-04-19 (positive) + 2026-04-22 (negative):
                // Single linear fit — 18.57 px/% across the full range.
                // Intercept 622 = device-reported neutral (0% grade in iFit log).
                public float quantize(float v) {
                    // iFit slider snaps to 0.5% increments.
                    return Math.round(v * 2) / 2.0f;
                }
                @Override
                protected int currentThumbY() {
                    return liveValue != null ? targetThumbY(liveValue) : thumbY();
                }
                @Override
                protected int hysteresisPixels(int fromY, int toY) {
                    return Math.abs(toY - fromY) >= 40 ? hystLong : hystShort;
                }
            }.withMetric(SliderMetric.GRADE),
            new Slider(ScreenProfile.W1920.rightTrackX, ORIGIN_RESISTANCE_THUMBY, S22iDevice::offsetResistanceThumbY) {
                // Two-point calibration: resistance=1 → Y=724, resistance=24 → Y=323.
                // Slope = (323−724) / 23 = −401/23 ≈ −17.43 px per level.
                public float quantize(float v) { return Math.round(v); }
                @Override
                protected int currentThumbY() {
                    // Guard against the "Changed Resistance to: 0" noise readings emitted
                    // during coast/reset — 0 is not a valid level and would swipe off-range.
                    return (liveValue != null && liveValue >= 1)
                            ? targetThumbY(liveValue) : thumbY();
                }
            }.withMetric(SliderMetric.RESISTANCE)
        );
    }

    @Override public String displayName() { return "S22i Bike"; }

    private static int offsetInclineThumbY(double v)    { return (int) (ORIGIN_INCLINE_THUMBY - 18.57 * v); }
    private static int offsetResistanceThumbY(double v) { return (int) (ORIGIN_RESISTANCE_THUMBY - 401.0 / 23 * (v - 1)); }
}
