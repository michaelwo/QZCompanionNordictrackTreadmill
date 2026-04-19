package org.cagnulein.qzcompanionnordictracktreadmill.device.catalog;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S22iDevice extends BikeDevice {
    public S22iDevice() {         super(
            new Slider(622) {
                public int trackX() { return 75; }
                // Three-point calibration: v=-10→Y=722, v=0→Y=622, v=20→Y=326.
                // Slope differs across zero: −10 px/% for negative incline, −14.8 px/% for positive.
                public int targetY(double v) {
                    return v <= 0.0 ? (int) (622.0 - 10.0 * v)
                                    : (int) (622.0 - 14.8 * v);
                }
                public float quantize(float v) {
                    // iFit slider snaps to 0.5% increments.
                    return Math.round(v * 2) / 2.0f;
                }
                @Override
                protected int currentThumbY(MetricSnapshot s) {
                    return s.inclinePct != null ? targetY(s.inclinePct) : thumbY();
                }
                // Physical hysteresis: slider undershoots ~0.5-1% in both directions.
                // Spring-back is ~15px for swipes ≥ 40px travel (mid-range grades),
                // ~8px for shorter swipes (near physical limits or small grade steps).
                // 10px overshoot for short travel lands within 2px of target after spring-back.
                @Override
                protected int hysteresisPixels(int fromY, int toY) {
                    return Math.abs(toY - fromY) >= 40 ? 15 : 10;
                }
            },
            new Slider(724) {
                public int trackX() { return 1845; }
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
        ); }

    @Override
    public String displayName() { return "S22i Bike"; }



}
