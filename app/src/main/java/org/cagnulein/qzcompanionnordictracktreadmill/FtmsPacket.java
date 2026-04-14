package org.cagnulein.qzcompanionnordictracktreadmill;

/**
 * Parses and builds FTMS (Fitness Machine Service) BLE packets.
 * No Android imports — fully unit-testable on the JVM.
 *
 * Reference: Bluetooth SIG "Fitness Machine Service" specification,
 * assigned numbers at bluetooth.com/specifications/specs/fitness-machine-service-1-0/
 */
class FtmsPacket {

    // ── Control Point op-codes (FTMS spec §4.16.1) ───────────────────────────
    static final int OP_REQUEST_CONTROL     = 0x00;
    static final int OP_RESET               = 0x01;
    static final int OP_SET_INCLINATION     = 0x04;
    static final int OP_SET_RESISTANCE      = 0x05;
    static final int OP_START_RESUME        = 0x07;
    static final int OP_STOP_PAUSE          = 0x08;

    // ── Response op-code and result codes ────────────────────────────────────
    static final int OP_RESPONSE            = 0x80;
    static final int RESULT_SUCCESS         = 0x01;
    static final int RESULT_NOT_SUPPORTED   = 0x02;

    // ── Fitness Machine Feature flags (4+2 bytes, §4.3) ──────────────────────
    // Byte 0-3: feature flags
    // Bit 3 = Inclination Supported
    // Byte 4-5: target setting flags
    // Bit 3 = Inclination Target Setting Supported
    static final byte[] FEATURE_FLAGS = {
        0x08, 0x00, 0x00, 0x00,   // inclination supported
        0x08, 0x00                 // inclination target setting supported
    };

    // ── Parsed command ────────────────────────────────────────────────────────

    /** Result of {@link #parseControlPoint(byte[])}. */
    static class Command {
        final int opCode;
        /** Inclination in % (only set when opCode == OP_SET_INCLINATION). */
        final Float inclinePct;

        Command(int opCode, Float inclinePct) {
            this.opCode     = opCode;
            this.inclinePct = inclinePct;
        }

        @Override public String toString() {
            return "Command{op=0x" + Integer.toHexString(opCode)
                + (inclinePct != null ? ", incline=" + inclinePct + "%" : "") + "}";
        }
    }

    /**
     * Parses a raw FTMS Control Point write from Zwift.
     * Returns null if the payload is null, empty, or unrecognised.
     */
    static Command parseControlPoint(byte[] value) {
        if (value == null || value.length == 0) return null;
        int op = value[0] & 0xFF;
        switch (op) {
            case OP_REQUEST_CONTROL:
            case OP_RESET:
            case OP_START_RESUME:
            case OP_STOP_PAUSE:
                return new Command(op, null);

            case OP_SET_INCLINATION:
                if (value.length < 3) return null;
                // Int16 little-endian, unit = 0.1 %
                short raw = (short) ((value[2] & 0xFF) << 8 | (value[1] & 0xFF));
                return new Command(op, raw / 10.0f);

            case OP_SET_RESISTANCE:
                // Uint8, unit = 0.1 (unitless)
                if (value.length < 2) return null;
                return new Command(op, (float)(value[1] & 0xFF) / 10.0f);

            default:
                return new Command(op, null);
        }
    }

    /**
     * Builds the 3-byte Indicate response for a given request op-code.
     * Format: [0x80, requestOpCode, resultCode]
     */
    static byte[] response(int requestOpCode, int resultCode) {
        return new byte[]{ (byte) OP_RESPONSE, (byte) requestOpCode, (byte) resultCode };
    }

    /**
     * Builds an Indoor Bike Data notification packet (§4.9).
     * Only speed, cadence, and power are populated — the minimum Zwift reads.
     *
     * @param speedKmh  speed in km/h   (null → omit / send 0)
     * @param cadenceRpm cadence in RPM (null → omit / send 0)
     * @param watts     power in watts  (null → omit / send 0)
     */
    static byte[] indoorBikeData(Float speedKmh, Float cadenceRpm, Float watts) {
        // Flags (2 bytes): bit 0 = More Data (0 = speed present),
        //                  bit 2 = Instantaneous Cadence present,
        //                  bit 6 = Instantaneous Power present
        int flags = 0x00   // speed always present (More Data bit = 0 means speed IS included)
                  | 0x04   // cadence present
                  | 0x40;  // power present

        // Speed: uint16, 0.01 km/h units
        int speedRaw    = speedKmh   != null ? Math.round(speedKmh   * 100) : 0;
        // Cadence: uint16, 0.5 rpm units
        int cadenceRaw  = cadenceRpm != null ? Math.round(cadenceRpm * 2)   : 0;
        // Power: sint16, 1 W units
        int powerRaw    = watts      != null ? Math.round(watts)             : 0;

        return new byte[]{
            (byte)(flags       & 0xFF), (byte)((flags      >> 8) & 0xFF),
            (byte)(speedRaw    & 0xFF), (byte)((speedRaw   >> 8) & 0xFF),
            (byte)(cadenceRaw  & 0xFF), (byte)((cadenceRaw >> 8) & 0xFF),
            (byte)(powerRaw    & 0xFF), (byte)((powerRaw   >> 8) & 0xFF)
        };
    }
}
