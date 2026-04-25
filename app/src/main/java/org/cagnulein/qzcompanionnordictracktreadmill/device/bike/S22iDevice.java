package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S22iDevice extends BikeDevice {
    public S22iDevice() { this(15, 10); }

    // hystLong: overshoot pixels for travel ≥ 40px; hystShort: for shorter swipes.
    // S22iNoAdbDevice passes (0, 0) — AccessibilityService swipes have no spring-back.
    protected S22iDevice(int hystLong, int hystShort) {
        // Screen: 1920px wide — trackX confirmed against iFit APK layout XML (tools/validate_swipe_targets.py).
        super(
            new Slider(622, ScreenProfile.W1920.leftTrackX) {
                // Calibration 2026-04-19 (positive) + 2026-04-22 (negative):
                // Single linear fit — 18.57 px/% across the full range.
                // Intercept 622 = device-reported neutral (0% grade in iFit log).
                public int targetY(double v) {
                    return (int) (622.0 - 18.57 * v);
                }
                public float quantize(float v) {
                    // iFit slider snaps to 0.5% increments.
                    return Math.round(v * 2) / 2.0f;
                }
                @Override
                protected int currentThumbY(MetricSnapshot s) {
                    return s.inclinePct != null ? targetY(s.inclinePct) : thumbY();
                }
                @Override
                protected int hysteresisPixels(int fromY, int toY) {
                    return Math.abs(toY - fromY) >= 40 ? hystLong : hystShort;
                }
            },
            new Slider(724, ScreenProfile.W1920.rightTrackX) {
                // Two-point calibration: resistance=1 → Y=724, resistance=24 → Y=323.
                // Slope = (323−724) / 23 = −401/23 ≈ −17.43 px per level.
                public int targetY(double v) { return (int) (724.0 - 401.0 / 23 * (v - 1)); }
                public float quantize(float v) { return Math.round(v); }
                @Override
                protected int currentThumbY(MetricSnapshot s) {
                    // Guard against the "Changed Resistance to: 0" noise readings emitted
                    // during coast/reset — 0 is not a valid level and would swipe off-range.
                    return (s.resistanceLvl != null && s.resistanceLvl >= 1)
                            ? targetY(s.resistanceLvl) : thumbY();
                }
            }
        );
    }

    @Override
    public String displayName() { return "S22i Bike"; }
}
