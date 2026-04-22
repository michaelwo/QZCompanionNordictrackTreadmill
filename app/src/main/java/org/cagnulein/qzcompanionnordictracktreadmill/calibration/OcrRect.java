package org.cagnulein.qzcompanionnordictracktreadmill.calibration;

/**
 * Pure-Java screen rectangle, equivalent to android.graphics.Rect but with
 * no Android dependency so calibration code remains unit-testable on the JVM.
 *
 * Coordinate convention: (left, top) is the top-left corner, (right, bottom)
 * is the bottom-right corner.  Width = right − left.
 *
 * Immutable value type.
 */
public final class OcrRect {

    public final int left, top, right, bottom;

    public OcrRect(int left, int top, int right, int bottom) {
        this.left   = left;
        this.top    = top;
        this.right  = right;
        this.bottom = bottom;
    }

    public int width() { return right - left; }

    /**
     * Returns true when this rect and {@code other} have a non-empty intersection.
     * Identical semantics to {@code android.graphics.Rect.intersects(a, b)}.
     */
    public boolean intersects(OcrRect other) {
        return left < other.right  && other.left < right
            && top  < other.bottom && other.top  < bottom;
    }

    /**
     * Parses a rect string produced by ScreenCaptureService — format: {@code "Rect(l,t-r,b)"}.
     *
     * @return the parsed rect, or {@code null} if the string is null, blank, or malformed
     */
    public static OcrRect fromString(String str) {
        if (str == null) return null;
        String s = str.replace("Rect(", "").replace(")", "");
        String[] halves = s.split("-");
        if (halves.length != 2) return null;
        String[] lt = halves[0].split(",");
        String[] rb = halves[1].split(",");
        if (lt.length != 2 || rb.length != 2) return null;
        try {
            return new OcrRect(
                Integer.parseInt(lt[0].trim()), Integer.parseInt(lt[1].trim()),
                Integer.parseInt(rb[0].trim()), Integer.parseInt(rb[1].trim()));
        } catch (NumberFormatException e) {
            return null;
        }
    }
}
