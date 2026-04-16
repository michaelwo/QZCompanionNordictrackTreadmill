package org.cagnulein.qzcompanionnordictracktreadmill.ocr;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

/**
 * Pure OCR text parsing logic extracted from QZService.getOCR().
 * Has no Android dependencies — uses no android.* imports.
 *
 * Input format produced by ScreenCaptureService:
 *   Blocks separated by "§§". Each block is either "text$$rect" or just "text".
 *   The VALUE for a metric is on the line IMMEDIATELY BEFORE the label line.
 *   Example: "12.5§§speed" → speed = 12.5
 */
public class Ocr {

    /** Minimum RPM value accepted as a valid cadence reading. */
    public static final int MIN_CADENCE_RPM = 20;

    /** Minimum watt value accepted as a valid power reading. */
    public static final int MIN_WATTS = 20;

    /**
     * Splits {@code textExtended} into its constituent blocks without parsing metric values.
     * Callers that need both blocks (for rect-based fallback) and parsed metrics can call
     * this once, pass the result to {@link #parse(OcrBlock[])}, and avoid re-splitting.
     */
    public static OcrBlock[] blocks(String textExtended) {
        if (textExtended == null || textExtended.isEmpty()) return new OcrBlock[0];
        String[] raw = textExtended.split("§§");
        OcrBlock[] result = new OcrBlock[raw.length];
        for (int i = 0; i < raw.length; i++) {
            String[] parts = raw[i].split("\\$\\$", 2);
            result[i] = new OcrBlock(parts[0], parts.length == 2 ? parts[1] : null);
        }
        return result;
    }

    /**
     * Parses pre-split blocks and returns all recognised metric values.
     * Use this when you already have the blocks (e.g. for the watt rect fallback)
     * so the raw string is only split once.
     *
     * @param blocks the result of {@link #blocks(String)}
     * @return a MetricSnapshot whose fields are null for any metric not found
     */
    public static MetricSnapshot extractMetrics(OcrBlock[] blocks) {
        MetricSnapshot.Builder b = new MetricSnapshot.Builder();
        for (int i = 1; i < blocks.length; i++) {
            String label     = blocks[i].text.toLowerCase();
            String valueLine = blocks[i - 1].text.trim();

            if (label.contains("speed")) {
                b.speedKmh(parseFloatOrNull(valueLine));
            }

            if (label.contains("500 split") || label.contains("/500m")) {
                try {
                    int seconds = Integer.parseInt(valueLine);
                    if (seconds > 0) b.speedKmh(1800.0f / seconds);
                } catch (Exception ignored) { }
            }

            if (label.contains("incline")) {
                b.inclinePct(parseFloatOrNull(valueLine.replace(',', '.')));
            }

            if (label.contains("resistance")) {
                b.resistanceLvl(parseFloatOrNull(valueLine));
            }

            if (label.contains("cadence") || label.contains("rpm")
                    || label.contains("strokes per min")) {
                try {
                    double rpm = Double.parseDouble(valueLine);
                    b.cadenceRpm(rpm > MIN_CADENCE_RPM ? (float) rpm : null);
                } catch (Exception e) {
                    // Value on block i-1 was not numeric; fall back to block i-2
                    if (i >= 2) {
                        try {
                            double rpm = Double.parseDouble(blocks[i - 2].text.trim());
                            b.cadenceRpm(rpm > MIN_CADENCE_RPM ? (float) rpm : null);
                        } catch (Exception ignored) {
                            b.cadenceRpm(null);
                        }
                    }
                }
            }

            if (label.contains("watt")) {
                try {
                    String digits = valueLine.replaceAll("[^0-9]", " ").trim();
                    String[] tokens = digits.split("\\s+");
                    if (tokens.length > 0 && !tokens[0].isEmpty()) {
                        int w = Integer.parseInt(tokens[tokens.length - 1]);
                        b.watts(w > MIN_WATTS ? (float) w : null);
                    }
                } catch (Exception ignored) { }
            }
        }
        return b.build();
    }

    /**
     * Parses raw OCR text and returns all recognised metric values.
     * Convenience overload — equivalent to {@code parse(blocks(textExtended))}.
     *
     * @param textExtended the raw string from ScreenCaptureService.getLastTextExtended()
     * @return a MetricSnapshot whose fields are null for any metric not found in the text
     */
    public static MetricSnapshot extractMetrics(String textExtended) {
        return extractMetrics(blocks(textExtended));
    }

    private static Float parseFloatOrNull(String s) {
        try {
            return Float.parseFloat(s);
        } catch (Exception e) {
            return null;
        }
    }
}
