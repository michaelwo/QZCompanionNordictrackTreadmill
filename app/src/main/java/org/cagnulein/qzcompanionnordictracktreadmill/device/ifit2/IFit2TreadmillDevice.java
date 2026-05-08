package org.cagnulein.qzcompanionnordictracktreadmill.device.ifit2;

import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.InclineCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.SpeedCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.slider.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public final class IFit2TreadmillDevice extends TreadmillDevice {

    public IFit2TreadmillDevice() { super(null, null); }

    @Override public String displayName() { return "iFit2 Treadmill"; }

    @Override public List<Slider> sliders() { return Collections.emptyList(); }

    @Override
    public List<Command> decodeCommands(QZCommandPacket pkt) {
        if (pkt.fieldCount() != 2) return Collections.emptyList();
        if (QZCommandPacket.END_OF_RIDE.equals(pkt.raw())) return Collections.emptyList();
        List<Command> cmds = new ArrayList<>();
        Float s = QZCommandPacket.parseField(pkt.rawField(0));
        Float i = QZCommandPacket.parseField(pkt.rawField(1));
        if (s != null && s != QZCommandPacket.NO_COMMAND && s != QZCommandPacket.NO_RESISTANCE) {
            cmds.add(new SpeedCommand(QZCommandPacket.roundToOneDecimal(s)));
        }
        if (i != null && i != QZCommandPacket.NO_COMMAND) {
            cmds.add(new InclineCommand(QZCommandPacket.roundToOneDecimal(i)));
        }
        return cmds;
    }
}
