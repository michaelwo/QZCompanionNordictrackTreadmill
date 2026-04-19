package org.cagnulein.qzcompanionnordictracktreadmill.calibration;

import java.util.List;

/**
 * Least-squares fit of the swipe-Y → grade relationship for a new device.
 *
 * Model: Y = a − b × grade  (b > 0 means Y decreases as grade increases)
 *
 * Also derives hysteresis compensation from residuals: after fitting, the
 * difference between Y_commanded and Y_implied_by_fit(OCR_grade) is the
 * spring-back the physical slider applied. Residuals are split at 40 px
 * travel to characterise short vs. long-swipe spring-back separately.
 *
 * No Android dependencies — pure JVM, fully unit-testable.
 */
public class FormulaFitter {

    public static class DataPoint {
        public final int   yCommanded;
        public final float ocrGrade;
        public DataPoint(int yCommanded, float ocrGrade) {
            this.yCommanded = yCommanded;
            this.ocrGrade   = ocrGrade;
        }
    }

    public static class Result {
        /** Y = a − b × grade */
        public final double a, b;
        /** Coefficient of determination (0–1; ≥ 0.97 is a good fit). */
        public final double r2;
        /** Travel threshold separating small- from large-spring-back swipes (px). */
        public final int hystThresholdPx;
        /** Overshoot for swipes with travel < hystThresholdPx. */
        public final int hystSmallPx;
        /** Overshoot for swipes with travel ≥ hystThresholdPx. */
        public final int hystLargePx;

        Result(double a, double b, double r2,
               int hystThresholdPx, int hystSmallPx, int hystLargePx) {
            this.a = a; this.b = b; this.r2 = r2;
            this.hystThresholdPx = hystThresholdPx;
            this.hystSmallPx     = hystSmallPx;
            this.hystLargePx     = hystLargePx;
        }

        public int targetY(float grade) { return (int) (a - b * grade); }

        public String formulaString() {
            return String.format("Y = %.1f − %.2f × grade", a, b);
        }

        public String r2String() {
            String quality = r2 >= 0.99 ? "excellent" : r2 >= 0.97 ? "good" : r2 >= 0.90 ? "fair" : "poor";
            return String.format("R² = %.4f (%s)", r2, quality);
        }

        public String hysteresisString() {
            return String.format(
                "Hysteresis: %dpx (travel < %dpx) / %dpx (travel ≥ %dpx)",
                hystSmallPx, hystThresholdPx, hystLargePx, hystThresholdPx);
        }
    }

    /**
     * Fits the formula and derives hysteresis from the collected data points.
     *
     * @param points   (Y_commanded, OCR_grade) pairs — at least 3 required
     * @param neutralY starting Y used as the reference for travel distance
     * @throws IllegalArgumentException if there are fewer than 3 points or all grades are identical
     */
    public static Result fit(List<DataPoint> points, int neutralY) {
        int n = points.size();
        if (n < 3) throw new IllegalArgumentException("Need at least 3 data points (got " + n + ")");

        double sg = 0, sy = 0, sgg = 0, sgy = 0, syy = 0;
        for (DataPoint p : points) {
            sg  += p.ocrGrade;
            sy  += p.yCommanded;
            sgg += (double) p.ocrGrade  * p.ocrGrade;
            sgy += (double) p.ocrGrade  * p.yCommanded;
            syy += (double) p.yCommanded * p.yCommanded;
        }
        double denom = n * sgg - sg * sg;
        if (Math.abs(denom) < 1e-9)
            throw new IllegalArgumentException("Degenerate fit — grade values must vary across data points");

        // Y = a + c*grade, where c = -b (expect c < 0 for typical incline slider)
        double c = (n * sgy - sg * sy) / denom;
        double a = (sy - c * sg) / n;
        double b = -c;

        // R²
        double ssTot = syy - sy * sy / n;
        double ssRes = 0;
        for (DataPoint p : points) {
            double err = p.yCommanded - (a - b * p.ocrGrade);
            ssRes += err * err;
        }
        double r2 = ssTot > 1e-9 ? 1.0 - ssRes / ssTot : 1.0;

        // Hysteresis: split residuals by travel distance from neutral
        final int HYST_THRESHOLD = 40;
        double shortSum = 0; int shortN = 0;
        double longSum  = 0; int longN  = 0;
        for (DataPoint p : points) {
            int travel   = Math.abs(p.yCommanded - neutralY);
            double residual = Math.abs(p.yCommanded - (a - b * p.ocrGrade));
            if (travel >= HYST_THRESHOLD) { longSum  += residual; longN++;  }
            else if (travel > 0)          { shortSum += residual; shortN++; }
        }
        int hystSmall = shortN > 0 ? (int) Math.round(shortSum / shortN) : 10;
        int hystLarge = longN  > 0 ? (int) Math.round(longSum  / longN)  : 15;

        // Ensure small ≤ large (occasionally noisy data can invert them)
        if (hystSmall > hystLarge) { int tmp = hystSmall; hystSmall = hystLarge; hystLarge = tmp; }

        return new Result(a, b, r2, HYST_THRESHOLD, hystSmall, hystLarge);
    }
}
