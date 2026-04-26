package org.cagnulein.qzcompanionnordictracktreadmill;

import org.cagnulein.qzcompanionnordictracktreadmill.calibration.FormulaFitter;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.FormulaFitter.DataPoint;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.FormulaFitter.Result;

import org.junit.Test;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import static org.junit.Assert.*;

/**
 * Verifies FormulaFitter: least-squares fit, R², hysteresis classification,
 * degenerate-input guards, Result accessors, and format strings.
 *
 * Reference dataset: 3 points on Y = 600 − 20×grade (perfect fit).
 *   grade=0 → Y=600, grade=5 → Y=500, grade=10 → Y=400
 */
public class FormulaFitterTest {

    private static final List<DataPoint> PERFECT_3 = Arrays.asList(
            new DataPoint(600, 0f),
            new DataPoint(500, 5f),
            new DataPoint(400, 10f)
    );

    // ── Least-squares coefficients ────────────────────────────────────────────

    @Test
    public void fit_perfectThreePoints_returnsCorrectIntercept() {
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        assertEquals(600.0, r.a, 1e-6);
    }

    @Test
    public void fit_perfectThreePoints_returnsCorrectSlope() {
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        assertEquals(20.0, r.b, 1e-6);
    }

    @Test
    public void fit_perfectThreePoints_returnsR2OfOne() {
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        assertEquals(1.0, r.r2, 1e-9);
    }

    // ── Degenerate input guards ───────────────────────────────────────────────

    @Test
    public void fit_twoPoints_throwsIllegalArgumentException() {
        List<DataPoint> two = Arrays.asList(new DataPoint(600, 0f), new DataPoint(500, 5f));
        try {
            FormulaFitter.fit(two, 600);
            fail("Expected IllegalArgumentException");
        } catch (IllegalArgumentException e) {
            // expected
        }
    }

    @Test
    public void fit_emptyList_throwsIllegalArgumentException() {
        try {
            FormulaFitter.fit(Collections.emptyList(), 600);
            fail("Expected IllegalArgumentException");
        } catch (IllegalArgumentException e) {
            // expected
        }
    }

    @Test
    public void fit_allGradesIdentical_throwsIllegalArgumentException() {
        // Zero variance in grade → degenerate denominator
        List<DataPoint> same = Arrays.asList(
                new DataPoint(600, 5f), new DataPoint(550, 5f), new DataPoint(500, 5f));
        try {
            FormulaFitter.fit(same, 600);
            fail("Expected IllegalArgumentException");
        } catch (IllegalArgumentException e) {
            // expected
        }
    }

    // ── targetThumbY() ─────────────────────────────────────────────────────────────

    @Test
    public void result_targetThumbY_computedFromFittedFormula() {
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        assertEquals(600, r.targetThumbY(0f));
        assertEquals(500, r.targetThumbY(5f));
        assertEquals(400, r.targetThumbY(10f));
    }

    @Test
    public void result_targetThumbY_interpolatesForNonDataGrade() {
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        // grade=7.5 → 600 - 20*7.5 = 450
        assertEquals(450, r.targetThumbY(7.5f));
    }

    // ── R² quality below 1.0 for imperfect data ───────────────────────────────

    @Test
    public void fit_noisyData_r2BelowOne() {
        // (Y=610,g=0), (Y=500,g=5), (Y=410,g=10): off-line by ±3–7 px → r2≈0.997
        List<DataPoint> noisy = Arrays.asList(
                new DataPoint(610, 0f), new DataPoint(500, 5f), new DataPoint(410, 10f));
        Result r = FormulaFitter.fit(noisy, 600);
        assertTrue("r2 < 1 for noisy data", r.r2 < 1.0);
        assertTrue("r2 > 0 for positive correlation", r.r2 > 0.99);
    }

    // ── Hysteresis: all long-travel points ───────────────────────────────────

    @Test
    public void fit_allLongTravelPoints_hystSmallIsDefaultSwapped() {
        // All 3 reference points have travel ≥ 40 px from neutralY=600.
        // Perfect fit → residuals=0, hystLarge=0; shortN=0 → hystSmall default=10.
        // 10 > 0 → swap: hystSmall=0, hystLarge=10.
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        assertEquals(40,  r.hystThresholdPx);
        assertEquals(0,   r.hystSmallPx);
        assertEquals(10,  r.hystLargePx);
    }

    // ── Hysteresis: no counted points (all at neutralY) ───────────────────────

    @Test
    public void fit_noTravelPoints_bothDefaultValues() {
        // All Y=600 → travel=0 for every point → not counted.
        // shortN=0, longN=0 → defaults: hystSmall=10, hystLarge=15 (no swap).
        List<DataPoint> atNeutral = Arrays.asList(
                new DataPoint(600, 0f), new DataPoint(600, 5f), new DataPoint(600, 10f));
        Result r = FormulaFitter.fit(atNeutral, 600);
        assertEquals(10, r.hystSmallPx);
        assertEquals(15, r.hystLargePx);
    }

    // ── Hysteresis: mixed short- and long-travel with non-zero residuals ──────

    @Test
    public void fit_mixedTravel_hystCalculatedFromResiduals() {
        // (Y=610,g=0): travel=10 <40 → short;  residual≈3.33 → hystSmall=round(3.33)=3
        // (Y=500,g=5): travel=100 ≥40 → long;  residual≈6.67
        // (Y=410,g=10): travel=190 ≥40 → long;  residual≈3.33 → hystLarge=round(10/2)=5
        List<DataPoint> mixed = Arrays.asList(
                new DataPoint(610, 0f), new DataPoint(500, 5f), new DataPoint(410, 10f));
        Result r = FormulaFitter.fit(mixed, 600);
        assertEquals(3, r.hystSmallPx);
        assertEquals(5, r.hystLargePx);
    }

    // ── Hysteresis inversion swap ─────────────────────────────────────────────

    @Test
    public void fit_invertedHysteresisFromNoise_isSwappedToMonotonic() {
        // Perfect-fit long-travel data → hystSmall gets default=10, hystLarge=0.
        // The code swaps them so hystSmall ≤ hystLarge always.
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        assertTrue("hystSmall must be ≤ hystLarge", r.hystSmallPx <= r.hystLargePx);
    }

    // ── Format strings ────────────────────────────────────────────────────────

    @Test
    public void result_formulaString_containsCoefficients() {
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        String s = r.formulaString();
        assertTrue("formula contains intercept 600.0", s.contains("600.0"));
        assertTrue("formula contains slope 20.00",     s.contains("20.00"));
    }

    @Test
    public void result_r2String_excellentForPerfectFit() {
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        assertTrue(r.r2String().contains("excellent"));
    }

    @Test
    public void result_r2String_containsR2Prefix() {
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        assertTrue(r.r2String().startsWith("R²"));
    }

    @Test
    public void result_hysteresisString_containsThresholdValue() {
        Result r = FormulaFitter.fit(PERFECT_3, 600);
        assertTrue(r.hysteresisString().contains("40"));
    }
}
