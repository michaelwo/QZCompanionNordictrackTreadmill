package org.cagnulein.qzcompanionnordictracktreadmill.dispatch;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Command;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 * Unit tests for QzPacket (structural parse) and QzProtocol (semantic decode).
 *
 * No device instances required — the QZ protocol contract is isolated here.
 */
public class QzProtocolTest {

    // ── QzPacket constants ────────────────────────────────────────────────────

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
    public void qzPacket_parse_onePart_fieldCountIsOne() {
        assertEquals(1, QzPacket.parse("8.0").fieldCount());
    }

    @Test
    public void qzPacket_parse_twoParts_fieldCountIsTwo() {
        assertEquals(2, QzPacket.parse("8.0;5.0").fieldCount());
    }

    @Test
    public void qzPacket_parse_rawField_returnsCorrectPart() {
        QzPacket pkt = QzPacket.parse("8.0;5.0");
        assertEquals("8.0", pkt.rawField(0));
        assertEquals("5.0", pkt.rawField(1));
    }

    @Test
    public void qzPacket_parse_raw_reconstructsOriginal() {
        assertEquals("8.0;5.0", QzPacket.parse("8.0;5.0").raw());
    }

    @Test
    public void qzPacket_parse_endOfRide_rawMatchesSentinel() {
        assertEquals(QzPacket.END_OF_RIDE, QzPacket.parse("-1;-100").raw());
    }

    // ── QzProtocol.parseField ─────────────────────────────────────────────────

    @Test
    public void parseField_dotValue_dotSeparator_parsesCorrectly() {
        assertEquals(8.5f, QzProtocol.parseField("8.5", '.'), 0.001f);
    }

    @Test
    public void parseField_negativeValue_dotSeparator_parsesCorrectly() {
        assertEquals(-3.0f, QzProtocol.parseField("-3.0", '.'), 0.001f);
    }

    @Test
    public void parseField_leadingTrailingWhitespace_trimmedAndParsed() {
        assertEquals(8.5f, QzProtocol.parseField("  8.5  ", '.'), 0.001f);
    }

    @Test
    public void parseField_commaInValue_dotSeparator_fallbackReplacesCommaAndParses() {
        assertEquals(8.5f, QzProtocol.parseField("8,5", '.'), 0.001f);
    }

    @Test
    public void parseField_dotInValue_commaSeparator_replacedThenFallbackParses() {
        assertEquals(8.5f, QzProtocol.parseField("8.5", ','), 0.001f);
    }

    @Test
    public void parseField_nonNumericInput_returnsNull() {
        assertNull(QzProtocol.parseField("abc", '.'));
    }

    @Test
    public void parseField_emptyString_returnsNull() {
        assertNull(QzProtocol.parseField("", '.'));
    }

    @Test
    public void parseField_whitespaceOnly_returnsNull() {
        assertNull(QzProtocol.parseField("   ", '.'));
    }

    @Test
    public void parseField_sentinelMinusOne_parsesAsMinusOne() {
        assertEquals(-1.0f, QzProtocol.parseField("-1", '.'), 0.001f);
    }

    // ── QzProtocol.roundToOneDecimal ──────────────────────────────────────────

    @Test
    public void roundToOneDecimal_roundsUpAtHalfway() {
        assertEquals(8.3f, QzProtocol.roundToOneDecimal(8.25f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_roundsDownBelowHalfway() {
        assertEquals(8.2f, QzProtocol.roundToOneDecimal(8.24f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_negativeValue_roundsTowardPositiveInfinity() {
        assertEquals(-8.2f, QzProtocol.roundToOneDecimal(-8.25f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_zero_returnsZero() {
        assertEquals(0.0f, QzProtocol.roundToOneDecimal(0.0f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_alreadyOneDecimalPlace_unchanged() {
        assertEquals(5.5f, QzProtocol.roundToOneDecimal(5.5f), 0.001f);
    }

    @Test
    public void roundToOneDecimal_halfBoundaryPositive_roundsUp() {
        assertEquals(5.4f, QzProtocol.roundToOneDecimal(5.35f), 0.001f);
    }

    // ── QzProtocol.decodeBike ─────────────────────────────────────────────────

    @Test
    public void decodeBike_onePart_setsResistanceLvl() {
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("8.0"), '.');
        assertEquals(8.0f, cmd.resistanceLvl, 0.001f);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeBike_twoParts_setsInclinePct() {
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("5.0;unused"), '.');
        assertEquals(5.0f, cmd.inclinePct, 0.001f);
        assertNull(cmd.resistanceLvl);
    }

    @Test
    public void decodeBike_roundsToOneDecimal() {
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("8.25"), '.');
        assertEquals(8.3f, cmd.resistanceLvl, 0.001f);
    }

    @Test
    public void decodeBike_sentinelMinusOne_resistance_returnsNull() {
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("-1"), '.');
        assertNull(cmd.resistanceLvl);
    }

    @Test
    public void decodeBike_sentinelMinusOneHundred_resistance_returnsNull() {
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("-100"), '.');
        assertNull(cmd.resistanceLvl);
    }

    @Test
    public void decodeBike_endOfRideSentinel_returnsAllNull() {
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("-1;-100"), '.');
        assertNull(cmd.inclinePct);
        assertNull(cmd.resistanceLvl);
    }

    @Test
    public void decodeBike_negativeOnePercent_incline_parsesCorrectly() {
        // "-1.0;0" is a legitimate Zwift grade, not the sentinel; must not be swallowed.
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("-1.0;0"), '.');
        assertEquals(-1.0f, cmd.inclinePct, 0.001f);
    }

    @Test
    public void decodeBike_heartbeat_incline_returnsNull() {
        // "-100;N" is QZ's "no grade" heartbeat (Zwift paused/loading).
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("-100;16"), '.');
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeBike_commaDecimalSeparator_parsesCorrectly() {
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("8.5"), ',');
        assertEquals(8.5f, cmd.resistanceLvl, 0.001f);
    }

    @Test
    public void decodeBike_unparseable_returnsAllNull() {
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("abc"), '.');
        assertNull(cmd.resistanceLvl);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeBike_zeroParts_returnsAllNull() {
        // split("") returns [""] which has fieldCount=1, but parseField("") is null
        Command cmd = QzProtocol.decodeBike(QzPacket.parse(""), '.');
        assertNull(cmd.resistanceLvl);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeBike_threeParts_returnsAllNull() {
        Command cmd = QzProtocol.decodeBike(QzPacket.parse("1.0;2.0;3.0"), '.');
        assertNull(cmd.resistanceLvl);
        assertNull(cmd.inclinePct);
    }

    // ── QzProtocol.decodeTreadmill ────────────────────────────────────────────

    @Test
    public void decodeTreadmill_twoParts_setsBothFields() {
        Command cmd = QzProtocol.decodeTreadmill(QzPacket.parse("8.0;5.0"), '.');
        assertEquals(8.0f, cmd.speedKmh,   0.001f);
        assertEquals(5.0f, cmd.inclinePct, 0.001f);
    }

    @Test
    public void decodeTreadmill_roundsToOneDecimal() {
        Command cmd = QzProtocol.decodeTreadmill(QzPacket.parse("8.25;5.14"), '.');
        assertEquals(8.3f, cmd.speedKmh,   0.001f);
        assertEquals(5.1f, cmd.inclinePct, 0.001f);
    }

    @Test
    public void decodeTreadmill_sentinelMinusOneHundred_speed_returnsNull() {
        Command cmd = QzProtocol.decodeTreadmill(QzPacket.parse("-100;5.0"), '.');
        assertNull(cmd.speedKmh);
        assertEquals(5.0f, cmd.inclinePct, 0.001f);
    }

    @Test
    public void decodeTreadmill_sentinelMinusOneHundred_incline_returnsNull() {
        Command cmd = QzProtocol.decodeTreadmill(QzPacket.parse("8.0;-100"), '.');
        assertEquals(8.0f, cmd.speedKmh, 0.001f);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeTreadmill_bothSentinels_returnsAllNull() {
        Command cmd = QzProtocol.decodeTreadmill(QzPacket.parse("-100;-100"), '.');
        assertNull(cmd.speedKmh);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeTreadmill_sentinelMinusOne_speed_returnsNull() {
        // -1 is the QZ no-op speed flush sentinel; it must not produce a speed command.
        Command cmd = QzProtocol.decodeTreadmill(QzPacket.parse("-1;-100"), '.');
        assertNull(cmd.speedKmh);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeTreadmill_commaDecimalSeparator_parsesCorrectly() {
        Command cmd = QzProtocol.decodeTreadmill(QzPacket.parse("8.5;3.0"), ',');
        assertEquals(8.5f, cmd.speedKmh,   0.001f);
        assertEquals(3.0f, cmd.inclinePct, 0.001f);
    }

    @Test
    public void decodeTreadmill_onePart_returnsAllNull() {
        Command cmd = QzProtocol.decodeTreadmill(QzPacket.parse("8.0"), '.');
        assertNull(cmd.speedKmh);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeTreadmill_zeroParts_returnsAllNull() {
        Command cmd = QzProtocol.decodeTreadmill(QzPacket.parse(""), '.');
        assertNull(cmd.speedKmh);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void decodeTreadmill_threeParts_returnsAllNull() {
        Command cmd = QzProtocol.decodeTreadmill(QzPacket.parse("1.0;2.0;3.0"), '.');
        assertNull(cmd.speedKmh);
        assertNull(cmd.inclinePct);
    }
}
