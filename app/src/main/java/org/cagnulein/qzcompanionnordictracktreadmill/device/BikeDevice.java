package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.command.QZCommandPacket;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.SliderMetric;

import java.util.Collections;
import java.util.List;

public abstract class BikeDevice extends Device {

    private final Slider incline;
    private final Slider resistance;  // null if this device has no resistance control
    protected BikeDevice(Slider incline, Slider resistance) {
        this.incline    = incline;
        this.resistance = resistance;
    }

    protected final void applyIncline(double value) {
        incline.moveTo(value, this);
    }

    protected final void applyResistance(double level) {
        if (resistance == null) return;
        resistance.moveTo(level, this);
    }

    @Override
    public void applyMetric(SliderMetric metric, float value) {
        incline.applyIfMatch(metric, value);
        if (resistance != null) resistance.applyIfMatch(metric, value);
    }

    @Override
    public final void applyCommand(Command cmd) {
        if (cmd.inclinePct != null) {
            float quantized = incline.quantize(cmd.inclinePct);
            Float last = incline.lastApplied();
            logger.log("QZ:Dispatch", "requestIncline(bike): " + cmd.inclinePct + " quantized=" + quantized + " last=" + last);
            if (last == null || quantized != last) {
                applyIncline(quantized);
                logger.log("QZ:Dispatch", "applyIncline(bike): " + quantized);
            } else {
                logger.log("QZ:Dispatch", "de-dup: skipping incline " + cmd.inclinePct + " (quantized=" + quantized + " already at " + last + ")");
            }
        }
        if (cmd.resistanceLvl != null && resistance != null) {
            Float last = resistance.lastApplied();
            logger.log("QZ:Dispatch", "requestResistance(bike): " + cmd.resistanceLvl + " last=" + last);
            if (last == null || !cmd.resistanceLvl.equals(last)) {
                applyResistance(cmd.resistanceLvl);
                logger.log("QZ:Dispatch", "applyResistance(bike): " + cmd.resistanceLvl);
            } else {
                logger.log("QZ:Dispatch", "de-dup: skipping resistance " + cmd.resistanceLvl + " (already at " + last + ")");
            }
        }
    }

    @Override
    public List<Command> decodeCommands(QZCommandPacket pkt) {
        if (pkt.fieldCount() == 2) {
            if (QZCommandPacket.END_OF_RIDE.equals(pkt.raw())) return Collections.emptyList();
            Float v = QZCommandPacket.parseField(pkt.rawField(0));
            if (v == null || v == QZCommandPacket.NO_COMMAND) return Collections.emptyList();
            Command cmd = new Command();
            cmd.inclinePct = QZCommandPacket.roundToOneDecimal(v);
            return Collections.singletonList(cmd);
        }
        if (pkt.fieldCount() == 1) {
            Float v = QZCommandPacket.parseField(pkt.rawField(0));
            if (v == null || v == QZCommandPacket.NO_RESISTANCE || v == QZCommandPacket.NO_COMMAND)
                return Collections.emptyList();
            Command cmd = new Command();
            cmd.resistanceLvl = QZCommandPacket.roundToOneDecimal(v);
            return Collections.singletonList(cmd);
        }
        return Collections.emptyList();
    }
}
