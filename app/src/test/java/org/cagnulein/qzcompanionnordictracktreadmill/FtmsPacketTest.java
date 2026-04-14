package org.cagnulein.qzcompanionnordictracktreadmill;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 * Unit tests for FTMS packet parsing and building.
 * Pure JVM — no Android SDK required.
 */
public class FtmsPacketTest {

    private static final float DELTA = 0.01f;

    // ── parseControlPoint ─────────────────────────────────────────────────────

    @Test
    public void parse_requestControl() {
        FtmsPacket.Command cmd = FtmsPacket.parseControlPoint(new byte[]{0x00});
        assertNotNull(cmd);
        assertEquals(FtmsPacket.OP_REQUEST_CONTROL, cmd.opCode);
        assertNull(cmd.inclinePct);
    }

    @Test
    public void parse_startResume() {
        FtmsPacket.Command cmd = FtmsPacket.parseControlPoint(new byte[]{0x07});
        assertNotNull(cmd);
        assertEquals(FtmsPacket.OP_START_RESUME, cmd.opCode);
    }

    @Test
    public void parse_stopPause() {
        FtmsPacket.Command cmd = FtmsPacket.parseControlPoint(new byte[]{0x08});
        assertNotNull(cmd);
        assertEquals(FtmsPacket.OP_STOP_PAUSE, cmd.opCode);
    }

    @Test
    public void parse_setInclination_positive() {
        // 8.5% = 85 = 0x55 0x00 little-endian
        FtmsPacket.Command cmd = FtmsPacket.parseControlPoint(
                new byte[]{0x04, 0x55, 0x00});
        assertNotNull(cmd);
        assertEquals(FtmsPacket.OP_SET_INCLINATION, cmd.opCode);
        assertEquals(8.5f, cmd.inclinePct, DELTA);
    }

    @Test
    public void parse_setInclination_zero() {
        FtmsPacket.Command cmd = FtmsPacket.parseControlPoint(
                new byte[]{0x04, 0x00, 0x00});
        assertNotNull(cmd);
        assertEquals(0.0f, cmd.inclinePct, DELTA);
    }

    @Test
    public void parse_setInclination_negative() {
        // -3.0% = -30 = 0xE2 0xFF little-endian (two's complement)
        short raw = -30;
        byte lo = (byte)(raw & 0xFF);
        byte hi = (byte)((raw >> 8) & 0xFF);
        FtmsPacket.Command cmd = FtmsPacket.parseControlPoint(new byte[]{0x04, lo, hi});
        assertNotNull(cmd);
        assertEquals(-3.0f, cmd.inclinePct, DELTA);
    }

    @Test
    public void parse_setInclination_tooShort_returnsNull() {
        assertNull(FtmsPacket.parseControlPoint(new byte[]{0x04, 0x55})); // missing 3rd byte
    }

    @Test
    public void parse_setResistance() {
        // 7.5 = 75 = 0x4B
        FtmsPacket.Command cmd = FtmsPacket.parseControlPoint(new byte[]{0x05, 75});
        assertNotNull(cmd);
        assertEquals(FtmsPacket.OP_SET_RESISTANCE, cmd.opCode);
        assertEquals(7.5f, cmd.inclinePct, DELTA);
    }

    @Test
    public void parse_null_returnsNull() {
        assertNull(FtmsPacket.parseControlPoint(null));
    }

    @Test
    public void parse_empty_returnsNull() {
        assertNull(FtmsPacket.parseControlPoint(new byte[]{}));
    }

    @Test
    public void parse_unknownOpCode_returnsCommandWithOpCode() {
        FtmsPacket.Command cmd = FtmsPacket.parseControlPoint(new byte[]{(byte) 0xFF});
        assertNotNull(cmd);
        assertEquals(0xFF, cmd.opCode);
        assertNull(cmd.inclinePct);
    }

    // ── response ──────────────────────────────────────────────────────────────

    @Test
    public void response_hasCorrectFormat() {
        byte[] r = FtmsPacket.response(FtmsPacket.OP_REQUEST_CONTROL, FtmsPacket.RESULT_SUCCESS);
        assertEquals(3, r.length);
        assertEquals((byte) FtmsPacket.OP_RESPONSE,         r[0]);
        assertEquals((byte) FtmsPacket.OP_REQUEST_CONTROL,  r[1]);
        assertEquals((byte) FtmsPacket.RESULT_SUCCESS,      r[2]);
    }

    @Test
    public void response_notSupported() {
        byte[] r = FtmsPacket.response(0x99, FtmsPacket.RESULT_NOT_SUPPORTED);
        assertEquals((byte) FtmsPacket.RESULT_NOT_SUPPORTED, r[2]);
    }

    // ── indoorBikeData ────────────────────────────────────────────────────────

    @Test
    public void indoorBikeData_hasCorrectLength() {
        byte[] pkt = FtmsPacket.indoorBikeData(30.0f, 90.0f, 200.0f);
        assertEquals(8, pkt.length);
    }

    @Test
    public void indoorBikeData_speedEncoding() {
        // 30.0 km/h = 3000 in 0.01 km/h units = 0x0BB8 little-endian
        byte[] pkt = FtmsPacket.indoorBikeData(30.0f, 0f, 0f);
        int speedRaw = (pkt[2] & 0xFF) | ((pkt[3] & 0xFF) << 8);
        assertEquals(3000, speedRaw);
    }

    @Test
    public void indoorBikeData_cadenceEncoding() {
        // 90 rpm = 180 in 0.5 rpm units = 0x00B4 little-endian
        byte[] pkt = FtmsPacket.indoorBikeData(0f, 90.0f, 0f);
        int cadenceRaw = (pkt[4] & 0xFF) | ((pkt[5] & 0xFF) << 8);
        assertEquals(180, cadenceRaw);
    }

    @Test
    public void indoorBikeData_powerEncoding() {
        // 200 W = 200 little-endian
        byte[] pkt = FtmsPacket.indoorBikeData(0f, 0f, 200.0f);
        int powerRaw = (pkt[6] & 0xFF) | ((pkt[7] & 0xFF) << 8);
        assertEquals(200, powerRaw);
    }

    @Test
    public void indoorBikeData_nullInputs_encodesZero() {
        byte[] pkt = FtmsPacket.indoorBikeData(null, null, null);
        assertEquals(8, pkt.length);
        // speed bytes should be 0
        assertEquals(0, pkt[2]);
        assertEquals(0, pkt[3]);
    }

    // ── feature flags ─────────────────────────────────────────────────────────

    @Test
    public void featureFlags_length() {
        assertEquals(6, FtmsPacket.FEATURE_FLAGS.length);
    }

    @Test
    public void featureFlags_inclinationBitSet() {
        // Bit 3 of byte 0 = inclination supported
        assertTrue((FtmsPacket.FEATURE_FLAGS[0] & 0x08) != 0);
        // Bit 3 of byte 4 = inclination target setting supported
        assertTrue((FtmsPacket.FEATURE_FLAGS[4] & 0x08) != 0);
    }
}
