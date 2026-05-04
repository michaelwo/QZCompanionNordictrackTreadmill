package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.InclineCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.ResistanceCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;

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
    public final void handleIncline(double pct) {
        float quantized = incline.quantize((float) pct);
        Float last = incline.lastApplied();
        logger.log("QZ:Dispatch", "requestIncline(bike): " + pct + " quantized=" + quantized + " last=" + last);
        if (last == null || quantized != last) {
            applyIncline(quantized);
            logger.log("QZ:Dispatch", "applyIncline(bike): " + quantized);
        } else {
            logger.log("QZ:Dispatch", "de-dup: skipping incline " + pct + " (quantized=" + quantized + " already at " + last + ")");
        }
    }

    @Override
    public final void handleResistance(double lvl) {
        if (resistance == null) return;
        Float last = resistance.lastApplied();
        logger.log("QZ:Dispatch", "requestResistance(bike): " + lvl + " last=" + last);
        if (last == null || !Float.valueOf((float) lvl).equals(last)) {
            applyResistance(lvl);
            logger.log("QZ:Dispatch", "applyResistance(bike): " + lvl);
        } else {
            logger.log("QZ:Dispatch", "de-dup: skipping resistance " + lvl + " (already at " + last + ")");
        }
    }

    @Override
    public void applyMetric(SliderMetric metric, float value) {
        incline.applyIfMatch(metric, value);
        if (resistance != null) resistance.applyIfMatch(metric, value);
    }

    @Override
    public List<Command> decodeCommands(QZCommandPacket pkt) {
        if (pkt.fieldCount() == 2) {
            if (QZCommandPacket.END_OF_RIDE.equals(pkt.raw())) return Collections.emptyList();
            Float v = QZCommandPacket.parseField(pkt.rawField(0));
            if (v == null || v == QZCommandPacket.NO_COMMAND) return Collections.emptyList();
            return Collections.singletonList(new InclineCommand(QZCommandPacket.roundToOneDecimal(v)));
        }
        if (pkt.fieldCount() == 1) {
            Float v = QZCommandPacket.parseField(pkt.rawField(0));
            if (v == null || v == QZCommandPacket.NO_RESISTANCE || v == QZCommandPacket.NO_COMMAND)
                return Collections.emptyList();
            return Collections.singletonList(new ResistanceCommand(QZCommandPacket.roundToOneDecimal(v)));
        }
        return Collections.emptyList();
    }
}
