package org.cagnulein.qzcompanionnordictracktreadmill.dispatch;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Command;

public class QzProtocol {

    public static Command decodeBike(QzPacket pkt, char decimalSep) {
        Command cmd = new Command();
        if (pkt.fieldCount() == 2) {
            // END_OF_RIDE is matched by raw string so a legitimate -1.0% grade ("-1.0;0") is not swallowed.
            if (QzPacket.END_OF_RIDE.equals(pkt.raw())) return cmd;
            Float v = parseField(pkt.rawField(0), decimalSep);
            // NO_COMMAND in the incline slot is QZ's heartbeat while paused ("-100;N").
            if (v != null && v != QzPacket.NO_COMMAND) cmd.inclinePct = roundToOneDecimal(v);
        }
        if (pkt.fieldCount() == 1) {
            Float v = parseField(pkt.rawField(0), decimalSep);
            if (v != null && v != QzPacket.NO_RESISTANCE && v != QzPacket.NO_COMMAND)
                cmd.resistanceLvl = roundToOneDecimal(v);
        }
        return cmd;
    }

    public static Command decodeTreadmill(QzPacket pkt, char decimalSep) {
        Command cmd = new Command();
        if (pkt.fieldCount() == 2) {
            Float s = parseField(pkt.rawField(0), decimalSep);
            Float i = parseField(pkt.rawField(1), decimalSep);
            // -1 is a no-op speed flush; -100 is the QZ heartbeat. Both mean "no speed command".
            if (s != null && s != QzPacket.NO_COMMAND && s != QzPacket.NO_RESISTANCE)
                cmd.speedKmh   = roundToOneDecimal(s);
            if (i != null && i != QzPacket.NO_COMMAND)
                cmd.inclinePct = roundToOneDecimal(i);
        }
        return cmd;
    }

    public static Float parseField(String part, char decimalSeparator) {
        String s = part.trim();
        if (decimalSeparator != '.') s = s.replace('.', decimalSeparator);
        try {
            return Float.parseFloat(s);
        } catch (NumberFormatException e) {
            try { return Float.parseFloat(s.replace(',', '.')); }
            catch (NumberFormatException e2) { return null; }
        }
    }

    public static float roundToOneDecimal(float value) {
        return Math.round(value * 10) / 10.0f;
    }
}
