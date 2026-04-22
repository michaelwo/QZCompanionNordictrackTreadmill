package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 * Unit tests for Device.parseField() and Device.roundToOneDecimal().
 *
 * These are pure static utilities — no device instance, no Android dependencies.
 */
public class DeviceUtilsTest {

    // ── parseField ────────────────────────────────────────────────────────────

    @Test
    public void parseField_dotValue_dotSeparator_parsesCorrectly() {
        assertEquals(8.5f, Device.parseField("8.5", '.'), 0.001f);
    }

    @Test
    public void parseField_negativeValue_dotSeparator_parsesCorrectly() {
        assertEquals(-3.0f, Device.parseField("-3.0", '.'), 0.001f);
    }

    @Test
    public void parseField_leadingTrailingWhitespace_trimmedAndParsed() {
        assertEquals(8.5f, Device.parseField("  8.5  ", '.'), 0.001f);
    }

    @Test
    public void parseField_commaInValue_dotSeparator_fallbackReplacesCommaAndParses() {
        // Comma-locale OCR output: fallback replaces ',' with '.'
        assertEquals(8.5f, Device.parseField("8,5", '.'), 0.001f);
    }

    @Test
    public void parseField_dotInValue_commaSeparator_replacedThenFallbackParses() {
        // separator=',': "8.5" → "8,5" (dot→comma); Float.parseFloat fails;
        // fallback "8,5".replace(',','.') = "8.5" → parses correctly.
        assertEquals(8.5f, Device.parseField("8.5", ','), 0.001f);
    }

    @Test
    public void parseField_nonNumericInput_returnsNull() {
        assertNull(Device.parseField("abc", '.'));
    }

    @Test
    public void parseField_emptyString_returnsNull() {
        assertNull(Device.parseField("", '.'));
    }

    @Test
    public void parseField_whitespaceOnly_returnsNull() {
        assertNull(Device.parseField("   ", '.'));
    }

    @Test
    public void parseField_sentinelMinusOne_parsesAsMinusOne() {
        assertEquals(-1.0f, Device.parseField("-1", '.'), 0.001f);
    }

    // ── roundToOneDecimal ─────────────────────────────────────────────────────

    @Test
    public void roundToOneDecimal_roundsUpAtHalfway() {
        // 8.25 * 10 = 82.5 → Math.round = 83 → 8.3
        assertEquals(8.3f, Device.roundToOneDecimal(8.25f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_roundsDownBelowHalfway() {
        // 8.24 * 10 = 82.4 → Math.round = 82 → 8.2
        assertEquals(8.2f, Device.roundToOneDecimal(8.24f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_negativeValue_roundsTowardPositiveInfinity() {
        // Math.round(-8.25 * 10) = Math.round(-82.5) = -82 (Java rounds toward +∞)
        assertEquals(-8.2f, Device.roundToOneDecimal(-8.25f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_zero_returnsZero() {
        assertEquals(0.0f, Device.roundToOneDecimal(0.0f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_alreadyOneDecimalPlace_unchanged() {
        assertEquals(5.5f, Device.roundToOneDecimal(5.5f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_halfBoundaryPositive_roundsUp() {
        // 5.35 * 10 = 53.5 → Math.round = 54 → 5.4
        assertEquals(5.4f, Device.roundToOneDecimal(5.35f), 0.001f);
    }
}
