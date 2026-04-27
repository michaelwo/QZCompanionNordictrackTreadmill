package org.cagnulein.qzcompanionnordictracktreadmill.dispatch;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 * Unit tests for QzPacket: structural parse, field-level parsing, and rounding.
 *
 * Protocol-level decode (decodeBike, decodeTreadmill) is tested in
 * BikeDeviceTest and TreadmillDeviceTest via decodeCommand().
 */
public class QzPacketTest {

    // ── Constants ─────────────────────────────────────────────────────────────

    @Test
    public void qzPacket_delimiter_isSemicolon() {
        assertEquals(';', QzPacket.DELIMITER);
    }

    @Test
    public void qzPacket_endOfRide_isCorrectSentinel() {
        assertEquals("-1;-100", QzPacket.END_OF_RIDE);
    }

    @Test
    public void qzPacket_noCommand_isMinusOneHundred() {
        assertEquals(-100f, QzPacket.NO_COMMAND, 0.001f);
    }

    @Test
    public void qzPacket_noResistance_isMinusOne() {
        assertEquals(-1f, QzPacket.NO_RESISTANCE, 0.001f);
    }

    // ── QzPacket.parse ────────────────────────────────────────────────────────

    @Test
    public void parse_onePart_fieldCountIsOne() {
        assertEquals(1, QzPacket.parse("8.0").fieldCount());
    }

    @Test
    public void parse_twoParts_fieldCountIsTwo() {
        assertEquals(2, QzPacket.parse("8.0;5.0").fieldCount());
    }

    @Test
    public void parse_rawField_returnsCorrectPart() {
        QzPacket pkt = QzPacket.parse("8.0;5.0");
        assertEquals("8.0", pkt.rawField(0));
        assertEquals("5.0", pkt.rawField(1));
    }

    @Test
    public void parse_raw_reconstructsOriginal() {
        assertEquals("8.0;5.0", QzPacket.parse("8.0;5.0").raw());
    }

    @Test
    public void parse_endOfRide_rawMatchesSentinel() {
        assertEquals(QzPacket.END_OF_RIDE, QzPacket.parse("-1;-100").raw());
    }

    // ── QzPacket.parseField ───────────────────────────────────────────────────

    @Test
    public void parseField_dotDecimal_parsesCorrectly() {
        assertEquals(8.5f, QzPacket.parseField("8.5"), 0.001f);
    }

    @Test
    public void parseField_negativeValue_parsesCorrectly() {
        assertEquals(-3.0f, QzPacket.parseField("-3.0"), 0.001f);
    }

    @Test
    public void parseField_leadingTrailingWhitespace_trimmedAndParsed() {
        assertEquals(8.5f, QzPacket.parseField("  8.5  "), 0.001f);
    }

    @Test
    public void parseField_commaDecimal_fallbackReplacesCommaAndParses() {
        assertEquals(8.5f, QzPacket.parseField("8,5"), 0.001f);
    }

    @Test
    public void parseField_nonNumericInput_returnsNull() {
        assertNull(QzPacket.parseField("abc"));
    }

    @Test
    public void parseField_emptyString_returnsNull() {
        assertNull(QzPacket.parseField(""));
    }

    @Test
    public void parseField_whitespaceOnly_returnsNull() {
        assertNull(QzPacket.parseField("   "));
    }

    @Test
    public void parseField_sentinelMinusOne_parsesAsMinusOne() {
        assertEquals(-1.0f, QzPacket.parseField("-1"), 0.001f);
    }

    // ── QzPacket.roundToOneDecimal ────────────────────────────────────────────

    @Test
    public void roundToOneDecimal_roundsUpAtHalfway() {
        assertEquals(8.3f, QzPacket.roundToOneDecimal(8.25f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_roundsDownBelowHalfway() {
        assertEquals(8.2f, QzPacket.roundToOneDecimal(8.24f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_negativeValue_roundsTowardPositiveInfinity() {
        assertEquals(-8.2f, QzPacket.roundToOneDecimal(-8.25f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_zero_returnsZero() {
        assertEquals(0.0f, QzPacket.roundToOneDecimal(0.0f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_alreadyOneDecimalPlace_unchanged() {
        assertEquals(5.5f, QzPacket.roundToOneDecimal(5.5f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_halfBoundaryPositive_roundsUp() {
        assertEquals(5.4f, QzPacket.roundToOneDecimal(5.35f), 0.001f);
    }
}
