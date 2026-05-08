package org.cagnulein.qzcompanionnordictracktreadmill.device.ifit2;

import org.cagnulein.qzcompanionnordictracktreadmill.console.ifit2.GrpcCommandTransport;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceLogTags;
import org.cagnulein.qzcompanionnordictracktreadmill.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.command.InclineCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.command.ResistanceCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;

import java.util.Collections;
import java.util.List;

public final class IFit2BikeDevice extends Device {

    private static final String LOG_TAG = DeviceLogTags.DISPATCH;

    private final GrpcCommandTransport transport;

    public IFit2BikeDevice(GrpcCommandTransport transport) {
        this.transport = transport;
    }

    @Override public String displayName() { return "iFit2 Bike"; }

    @Override
    public void applyCommand(Command cmd) {
        if (!transport.apply(cmd, logger)) logger.log(Logger.WARN, LOG_TAG, "command rejected: " + cmd);
    }

    @Override
    public void shutdown() { transport.shutdown(); }

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
