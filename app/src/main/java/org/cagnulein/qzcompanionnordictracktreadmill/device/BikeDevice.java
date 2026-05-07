package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.SnapToOriginCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public abstract class BikeDevice extends Device {

    private final Slider incline;
    private final Slider resistance;  // null if this device has no resistance control

    protected BikeDevice(Slider incline, Slider resistance) {
        this.incline    = incline;
        this.resistance = resistance;
    }

    @Override
    public List<Slider> sliders() {
        if (incline != null && resistance != null) return Arrays.asList(incline, resistance);
        if (incline != null) return Collections.singletonList(incline);
        if (resistance != null) return Collections.singletonList(resistance);
        return Collections.emptyList();
    }

    @Override
    public List<Command> decodeCommands(QZCommandPacket pkt) {
        if (pkt.fieldCount() == 1 && QZCommandPacket.SNAP_ORIGIN.equals(pkt.rawField(0))) {
            List<Command> snaps = new ArrayList<>();
            for (Slider s : sliders()) snaps.add(new SnapToOriginCommand(s));
            return snaps;
        }
        if (pkt.fieldCount() == 2) {
            if (QZCommandPacket.END_OF_RIDE.equals(pkt.raw())) return Collections.emptyList();
            Float v = QZCommandPacket.parseField(pkt.rawField(0));
            if (v == null || v == QZCommandPacket.NO_COMMAND || incline == null)
                return Collections.emptyList();
            return Collections.singletonList(incline.commandFor(QZCommandPacket.roundToOneDecimal(v)));
        }
        if (pkt.fieldCount() == 1) {
            if (resistance == null) return Collections.emptyList();
            Float v = QZCommandPacket.parseField(pkt.rawField(0));
            if (v == null || v == QZCommandPacket.NO_RESISTANCE || v == QZCommandPacket.NO_COMMAND)
                return Collections.emptyList();
            return Collections.singletonList(resistance.commandFor(QZCommandPacket.roundToOneDecimal(v)));
        }
        return Collections.emptyList();
    }
}
