package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public abstract class TreadmillDevice extends Device {

    protected static final double KMH_TO_MPH = 0.621371;

    private final Slider incline;
    private final Slider speed;

    protected TreadmillDevice(Slider incline, Slider speed) {
        this.incline = incline;
        this.speed   = speed;
    }

    @Override
    public List<Slider> sliders() { return Arrays.asList(incline, speed); }

    @Override
    public List<Command> decodeCommands(QZCommandPacket pkt) {
        List<Command> cmds = new ArrayList<>();
        if (pkt.fieldCount() == 2) {
            Float s = QZCommandPacket.parseField(pkt.rawField(0));
            Float i = QZCommandPacket.parseField(pkt.rawField(1));
            if (s != null && s != QZCommandPacket.NO_COMMAND && s != QZCommandPacket.NO_RESISTANCE) {
                cmds.add(speed.commandFor(QZCommandPacket.roundToOneDecimal(s)));
            }
            if (i != null && i != QZCommandPacket.NO_COMMAND) {
                cmds.add(incline.commandFor(QZCommandPacket.roundToOneDecimal(i)));
            }
        }
        return cmds;
    }
}
