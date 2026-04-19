package org.cagnulein.qzcompanionnordictracktreadmill;

import org.cagnulein.qzcompanionnordictracktreadmill.ocr.Ocr;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 * Verifies OCR text parsing: label recognition, value extraction,
 * threshold guards, 500m split conversion, and edge cases.
 *
 * OCR text format: blocks separated by "§§".
 * Each block is "text" or "text$$rect".
 * The VALUE for a metric is the block immediately BEFORE the label block.
 *
 * The ocr() helper below builds well-formed test strings from value/label pairs.
 */
public class OcrTest {

    /**
     * Builds an OCR string from pairs of (value, label).
     * Produces: "HEADER§§value1§§label1§§value2§§label2..."
     * Index 0 is a dummy header so all real values start at index 1.
     */
    private String ocr(String... valueLabelPairs) {
        StringBuilder sb = new StringBuilder("HEADER");
        for (int i = 0; i < valueLabelPairs.length; i += 2) {
            sb.append("§§").append(valueLabelPairs[i]);       // value
            sb.append("§§").append(valueLabelPairs[i + 1]);   // label
        }
        return sb.toString();
    }

    // ── Speed ─────────────────────────────────────────────────────────────────

    @Test
    public void parse_speedLabel_extractsSpeedValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("15.2", "speed"));
        assertNotNull(r.speedKmh);
        assertEquals(15.2f, r.speedKmh, 0.01f);
    }

    @Test
    public void parse_speedLabelUpperCase_extractsSpeedValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("12.0", "SPEED"));
        assertNotNull(r.speedKmh);
        assertEquals(12.0f, r.speedKmh, 0.01f);
    }

    @Test
    public void parse_speedLabelMixedCase_extractsSpeedValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("10.5", "Speed"));
        assertNotNull(r.speedKmh);
        assertEquals(10.5f, r.speedKmh, 0.01f);
    }

    @Test
    public void parse_nonNumericSpeedValue_setsNullSpeed() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("--", "speed"));
        assertNull(r.speedKmh);
    }

    @Test
    public void parse_emptySpeedValue_setsNullSpeed() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("", "speed"));
        assertNull(r.speedKmh);
    }

    // ── 500m split ────────────────────────────────────────────────────────────
    // Formula: 1800 / seconds

    @Test
    public void parse_500splitLabel_convertsSplitTimeToKmh() {
        // 90 seconds → 1800 / 90 = 20.0 km/h
        MetricSnapshot r = Ocr.extractMetrics(ocr("90", "500 split"));
        assertNotNull(r.speedKmh);
        assertEquals(20.0f, r.speedKmh, 0.001f);
    }

    @Test
    public void parse_500mSlashLabel_convertsSplitTimeToKmh() {
        // 180 seconds → 1800 / 180 = 10.0 km/h
        MetricSnapshot r = Ocr.extractMetrics(ocr("180", "/500m"));
        assertNotNull(r.speedKmh);
        assertEquals(10.0f, r.speedKmh, 0.001f);
    }

    @Test
    public void parse_500splitAt41Seconds_returnsApprox43point9KmH() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("41", "500 split"));
        assertNotNull(r.speedKmh);
        assertEquals(43.9f, r.speedKmh, 0.1f);
    }

    @Test
    public void parse_500splitAt60Seconds_returns30KmH() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("60", "500 split"));
        assertNotNull(r.speedKmh);
        assertEquals(30.0f, r.speedKmh, 0.001f);
    }

    @Test
    public void parse_500splitAtZeroSeconds_doesNotUpdateSpeed() {
        // Division by zero guard: seconds must be > 0
        MetricSnapshot r = Ocr.extractMetrics(ocr("0", "500 split"));
        assertNull(r.speedKmh);
    }

    @Test
    public void parse_500splitNonNumericSeconds_doesNotUpdateSpeed() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("--", "/500m"));
        assertNull(r.speedKmh);
    }

    // ── Incline ───────────────────────────────────────────────────────────────

    @Test
    public void parse_inclineLabel_extractsInclineValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("5.5", "incline"));
        assertNotNull(r.inclinePct);
        assertEquals(5.5f, r.inclinePct, 0.01f);
    }

    @Test
    public void parse_gradeLabel_extractsInclineValue() {
        // S22i and other bikes display "GRADE" rather than "INCLINE" on screen
        MetricSnapshot r = Ocr.extractMetrics(ocr("4.5", "grade"));
        assertNotNull(r.inclinePct);
        assertEquals(4.5f, r.inclinePct, 0.01f);
    }

    @Test
    public void parse_gradeLabel_negative_extractsInclineValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("-2.0", "grade"));
        assertNotNull(r.inclinePct);
        assertEquals(-2.0f, r.inclinePct, 0.01f);
    }

    @Test
    public void parse_inclineWithCommaDecimal_normalizedAndExtracted() {
        // OCR on comma-locale devices may produce "5,5" — comma is replaced with dot
        MetricSnapshot r = Ocr.extractMetrics(ocr("5,5", "incline"));
        assertNotNull(r.inclinePct);
        assertEquals(5.5f, r.inclinePct, 0.01f);
    }

    @Test
    public void parse_negativeIncline_extractedCorrectly() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("-3.0", "incline"));
        assertNotNull(r.inclinePct);
        assertEquals(-3.0f, r.inclinePct, 0.01f);
    }

    @Test
    public void parse_zeroIncline_extractedCorrectly() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("0.0", "incline"));
        assertNotNull(r.inclinePct);
        assertEquals(0.0f, r.inclinePct, 0.01f);
    }

    @Test
    public void parse_nonNumericInclineValue_setsNullInclination() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("--", "incline"));
        assertNull(r.inclinePct);
    }

    // ── Resistance ────────────────────────────────────────────────────────────

    @Test
    public void parse_resistanceLabel_extractsResistanceValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("8", "resistance"));
        assertNotNull(r.resistanceLvl);
        assertEquals(8.0f, r.resistanceLvl, 0.01f);
    }

    @Test
    public void parse_resistanceLabelUpperCase_extractsResistanceValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("12", "RESISTANCE"));
        assertNotNull(r.resistanceLvl);
        assertEquals(12.0f, r.resistanceLvl, 0.01f);
    }

    @Test
    public void parse_nonNumericResistanceValue_setsNullResistance() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("--", "resistance"));
        assertNull(r.resistanceLvl);
    }

    // ── Cadence ───────────────────────────────────────────────────────────────

    @Test
    public void parse_cadenceLabel_extractsCadenceValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("92", "cadence"));
        assertNotNull(r.cadenceRpm);
        assertEquals(92.0f, r.cadenceRpm, 0.01f);
    }

    @Test
    public void parse_rpmLabel_extractsCadenceValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("85", "rpm"));
        assertNotNull(r.cadenceRpm);
        assertEquals(85.0f, r.cadenceRpm, 0.01f);
    }

    @Test
    public void parse_strokesPerMinLabel_extractsCadenceValue() {
        // Rowing machine cadence pattern
        MetricSnapshot r = Ocr.extractMetrics(ocr("28", "strokes per min"));
        assertNotNull(r.cadenceRpm);
        assertEquals(28.0f, r.cadenceRpm, 0.01f);
    }

    @Test
    public void parse_cadenceBelowThreshold_returnsNullCadence() {
        // Values <= 20 RPM are rejected as noise
        MetricSnapshot r = Ocr.extractMetrics(ocr("15", "cadence"));
        assertNull(r.cadenceRpm);
    }

    @Test
    public void parse_cadenceExactlyAtThreshold_returnsNullCadence() {
        // Guard is strictly > 20, so exactly 20 is rejected
        MetricSnapshot r = Ocr.extractMetrics(ocr("20", "cadence"));
        assertNull(r.cadenceRpm);
    }

    @Test
    public void parse_cadenceOneAboveThreshold_extractedCorrectly() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("21", "cadence"));
        assertNotNull(r.cadenceRpm);
        assertEquals(21.0f, r.cadenceRpm, 0.01f);
    }

    @Test
    public void parse_cadenceValueOnLineTwoBeforeLabel_usesFallback() {
        // When lines[i-1] is non-numeric the parser falls back to lines[i-2]
        // Format: HEADER § 92 § non_number § cadence
        String text = "HEADER§§92§§non_number§§cadence";
        MetricSnapshot r = Ocr.extractMetrics(text);
        assertNotNull(r.cadenceRpm);
        assertEquals(92.0f, r.cadenceRpm, 0.01f);
    }

    @Test
    public void parse_cadenceFallbackValueBelowThreshold_returnsNullCadence() {
        // Fallback value is also below the > 20 threshold
        String text = "HEADER§§15§§non_number§§cadence";
        MetricSnapshot r = Ocr.extractMetrics(text);
        assertNull(r.cadenceRpm);
    }

    @Test
    public void parse_cadenceNonNumericOnBothFallbackLines_returnsNullCadence() {
        String text = "HEADER§§non_number_a§§non_number_b§§cadence";
        MetricSnapshot r = Ocr.extractMetrics(text);
        assertNull(r.cadenceRpm);
    }

    // ── Watts ─────────────────────────────────────────────────────────────────

    @Test
    public void parse_wattLabel_extractsWattValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("215", "watt"));
        assertNotNull(r.watts);
        assertEquals(215.0f, r.watts, 0.01f);
    }

    @Test
    public void parse_wattsLabelUpperCase_extractsWattValue() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("150", "WATT"));
        assertNotNull(r.watts);
        assertEquals(150.0f, r.watts, 0.01f);
    }

    @Test
    public void parse_wattsWithUnitSuffix_stripsNonDigitsAndExtracts() {
        // OCR may read "215W" — non-digit characters are stripped
        MetricSnapshot r = Ocr.extractMetrics(ocr("215W", "watt"));
        assertNotNull(r.watts);
        assertEquals(215.0f, r.watts, 0.01f);
    }

    @Test
    public void parse_wattsBelowThreshold_returnsNullWatts() {
        // Values <= 20 W are rejected as noise (same guard as cadence)
        MetricSnapshot r = Ocr.extractMetrics(ocr("15", "watt"));
        assertNull(r.watts);
    }

    @Test
    public void parse_wattsExactlyAtThreshold_returnsNullWatts() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("20", "watt"));
        assertNull(r.watts);
    }

    @Test
    public void parse_wattsOneAboveThreshold_extractedCorrectly() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("21", "watt"));
        assertNotNull(r.watts);
        assertEquals(21.0f, r.watts, 0.01f);
    }

    // ── Multiple metrics in a single OCR string ───────────────────────────────

    @Test
    public void parse_speedAndIncline_extractsBoth() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("15.2", "speed", "5.5", "incline"));
        assertEquals(15.2f, r.speedKmh,    0.01f);
        assertEquals(5.5f,  r.inclinePct, 0.01f);
    }

    @Test
    public void parse_allFiveMetrics_extractsAll() {
        MetricSnapshot r = Ocr.extractMetrics(
                ocr("12.0", "speed", "3.0", "incline", "8", "resistance", "88", "cadence", "200", "watt"));
        assertEquals(12.0f, r.speedKmh,    0.01f);
        assertEquals(3.0f,  r.inclinePct, 0.01f);
        assertEquals(8.0f,  r.resistanceLvl,  0.01f);
        assertEquals(88.0f, r.cadenceRpm,  0.01f);
        assertEquals(200.0f, r.watts,      0.01f);
    }

    @Test
    public void parse_500splitAndCadence_extractsBoth() {
        // 90 seconds → 20.0 km/h
        MetricSnapshot r = Ocr.extractMetrics(ocr("90", "500 split", "32", "strokes per min"));
        assertEquals(20.0f, r.speedKmh,   0.001f);
        assertEquals(32.0f, r.cadenceRpm, 0.01f);
    }

    // ── Edge cases ────────────────────────────────────────────────────────────

    @Test
    public void parse_nullInput_returnsEmptyResult() {
        MetricSnapshot r = Ocr.extractMetrics((String) null);
        assertNull(r.speedKmh);
        assertNull(r.inclinePct);
        assertNull(r.resistanceLvl);
        assertNull(r.cadenceRpm);
        assertNull(r.watts);
    }

    @Test
    public void parse_emptyString_returnsEmptyResult() {
        MetricSnapshot r = Ocr.extractMetrics("");
        assertNull(r.speedKmh);
        assertNull(r.inclinePct);
    }

    @Test
    public void parse_noKnownLabels_returnsEmptyResult() {
        MetricSnapshot r = Ocr.extractMetrics(ocr("42", "unknown_metric"));
        assertNull(r.speedKmh);
        assertNull(r.inclinePct);
        assertNull(r.resistanceLvl);
        assertNull(r.cadenceRpm);
        assertNull(r.watts);
    }

    @Test
    public void parse_singleBlockNoSeparator_returnsEmptyResult() {
        // If there is no §§ separator, there's only one block (index 0)
        // and the loop starting at i=1 never executes
        MetricSnapshot r = Ocr.extractMetrics("15.2");
        assertNull(r.speedKmh);
    }

    @Test
    public void parse_blockWithRectSuffix_stillExtractsValue() {
        // ScreenCaptureService appends "$$Rect(l,t-r,b)" — parser must strip it
        String text = "HEADER§§15.2$$Rect(10,20-100,40)§§speed$$Rect(10,40-100,60)";
        MetricSnapshot r = Ocr.extractMetrics(text);
        assertNotNull(r.speedKmh);
        assertEquals(15.2f, r.speedKmh, 0.01f);
    }
}
