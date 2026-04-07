package org.cagnulein.qzcompanionnordictracktreadmill;

/**
 * Pure OCR text parsing logic extracted from QZService.getOCR().
 * Has no Android dependencies — uses no android.* imports.
 *
 * Input format produced by ScreenCaptureService:
 *   Blocks separated by "§§". Each block is either "text$$rect" or just "text".
 *   The VALUE for a metric is on the line IMMEDIATELY BEFORE the label line.
 *   Example: "12.5§§speed" → speed = 12.5
 *
 * The watt rect-cache fallback from QZService is intentionally excluded here
 * because it depends on android.graphics.Rect. It remains in QZService.
 */
public class OcrParser {

    /** Minimum RPM value accepted as a valid cadence reading. */
    static final int MIN_CADENCE_RPM = 20;

    /** Minimum watt value accepted as a valid power reading. */
    static final int MIN_WATTS = 20;

    /**
     * Parses the combined OCR text and returns all recognised metric values.
     *
     * @param textExtended the raw string from ScreenCaptureService.getLastTextExtended()
     * @return a MetricSnapshot whose fields are null for any metric not found in the text
     */
    public static MetricSnapshot parse(String textExtended) {
        MetricSnapshot.Builder b = new MetricSnapshot.Builder();
        if (textExtended == null || textExtended.isEmpty()) return b.build();

        String[] ocrBlocks = textExtended.split("§§");
        String[] lines = new String[ocrBlocks.length];
        for (int i = 0; i < ocrBlocks.length; i++) {
            // Strip optional "$$rect" suffix — we only need the text portion
            String[] parts = ocrBlocks[i].split("\\$\\$");
            lines[i] = parts[0];
        }

        for (int i = 1; i < lines.length; i++) {
            String label     = lines[i].toLowerCase();
            String valueLine = lines[i - 1].trim();

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
                    // Value on line i-1 was not numeric; fall back to line i-2
                    if (i >= 2) {
                        try {
                            double rpm = Double.parseDouble(lines[i - 2].trim());
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

    private static Float parseFloatOrNull(String s) {
        try {
            return Float.parseFloat(s);
        } catch (Exception e) {
            return null;
        }
    }
}
