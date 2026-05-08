package org.cagnulein.qzcompanionnordictracktreadmill.device.ifit2;

import org.cagnulein.qzcompanionnordictracktreadmill.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.command.InclineCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.command.ResistanceCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.console.ifit2.GrpcCommandTransport;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;

import java.util.Collections;
import java.util.List;

public final class GrpcBikeDevice extends GrpcDevice {

    public GrpcBikeDevice(GrpcCommandTransport transport) { super(transport); }

    @Override public String displayName() { return "iFit2 Bike"; }

    @Override
    public List<Command> decodeCommands(QZCommandPacket pkt) {
        if (pkt.fieldCount() == 2) {
            if (QZCommandPacket.END_OF_RIDE.equals(pkt.raw())) return Collections.emptyList();
            Float v = QZCommandPacket.parseField(pkt.rawField(0));
            if (v == null || v == QZCommandPacket.NO_COMMAND) return Collections.emptyList();
            return Collections.singletonList(
                    new InclineCommand(QZCommandPacket.roundToOneDecimal(v)));
        }
        if (pkt.fieldCount() == 1) {
            Float v = QZCommandPacket.parseField(pkt.rawField(0));
            if (v == null || v == QZCommandPacket.NO_RESISTANCE || v == QZCommandPacket.NO_COMMAND)
                return Collections.emptyList();
            return Collections.singletonList(
                    new ResistanceCommand(QZCommandPacket.roundToOneDecimal(v)));
        }
        return Collections.emptyList();
    }
}
