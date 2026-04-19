package org.cagnulein.qzcompanionnordictracktreadmill.calibration;

import android.content.SharedPreferences;

/**
 * Holds calibration coefficients derived by CalibrationActivity and consumed by
 * CalibratedBikeDevice. Persisted to SharedPreferences and loaded into the
 * static {@link #current} field at app start so the device class has no
 * Android dependency.
 */
public class CalibrationResult {

    private static final String KEY_A            = "cal_a";
    private static final String KEY_B            = "cal_b";
    private static final String KEY_X            = "cal_x";
    private static final String KEY_NEUTRAL_Y    = "cal_neutral_y";
    private static final String KEY_HYST_THRESH  = "cal_hyst_thresh";
    private static final String KEY_HYST_SMALL   = "cal_hyst_small";
    private static final String KEY_HYST_LARGE   = "cal_hyst_large";

    /** Swipe formula: Y = a − b × grade */
    public final double a, b;
    /** Horizontal track coordinate and neutral (grade=0) Y position. */
    public final int x, neutralY;
    /** Hysteresis: travel threshold and overshoot pixels for short/long swipes. */
    public final int hystThresholdPx, hystSmallPx, hystLargePx;

    /** In-memory singleton. Set by CalibrationActivity after a successful calibration
     *  and loaded from SharedPreferences by MainActivity on startup. */
    public static volatile CalibrationResult current;

    public CalibrationResult(double a, double b, int x, int neutralY,
                             int hystThresholdPx, int hystSmallPx, int hystLargePx) {
        this.a = a; this.b = b;
        this.x = x; this.neutralY = neutralY;
        this.hystThresholdPx = hystThresholdPx;
        this.hystSmallPx     = hystSmallPx;
        this.hystLargePx     = hystLargePx;
    }

    public int targetY(float grade) { return (int) (a - b * grade); }

    public void save(SharedPreferences prefs) {
        prefs.edit()
            .putLong(KEY_A,           Double.doubleToLongBits(a))
            .putLong(KEY_B,           Double.doubleToLongBits(b))
            .putInt (KEY_X,           x)
            .putInt (KEY_NEUTRAL_Y,   neutralY)
            .putInt (KEY_HYST_THRESH, hystThresholdPx)
            .putInt (KEY_HYST_SMALL,  hystSmallPx)
            .putInt (KEY_HYST_LARGE,  hystLargePx)
            .apply();
    }

    /** Returns null if no calibration has been saved yet. */
    public static CalibrationResult load(SharedPreferences prefs) {
        if (!prefs.contains(KEY_A)) return null;
        return new CalibrationResult(
            Double.longBitsToDouble(prefs.getLong(KEY_A, 0)),
            Double.longBitsToDouble(prefs.getLong(KEY_B, 0)),
            prefs.getInt(KEY_X,           75),
            prefs.getInt(KEY_NEUTRAL_Y,   622),
            prefs.getInt(KEY_HYST_THRESH, 40),
            prefs.getInt(KEY_HYST_SMALL,  10),
            prefs.getInt(KEY_HYST_LARGE,  15)
        );
    }
}
