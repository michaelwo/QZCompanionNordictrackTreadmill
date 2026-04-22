package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.BikeMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public abstract class BikeDevice extends Device {

    private final Slider incline;
    private final Slider resistance;  // null if this device has no resistance control
    private final Command cached = new Command();

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
    public final void applyCommand(Command cmd, long now) {
        // incline (2-part message)
        Float inclineVal = cmd.inclinePct != null ? cmd.inclinePct : cached.inclinePct;
        if (inclineVal != null) {
            float quantized = incline.quantize(inclineVal);
            Float last = incline.lastApplied();
            logger.log("QZ:Dispatch", "requestIncline(bike): " + inclineVal + " quantized=" + quantized + " last=" + last);
            if (lastCommandMs + SWIPE_THROTTLE_MS < now) {
                if (last == null || quantized != last) {
                    applyIncline(quantized);
                    logger.log("QZ:Dispatch", "applyIncline(bike): " + quantized);
                    lastCommandMs = now;
                    cached.inclinePct = null;
                } else {
                    logger.log("QZ:Dispatch", "de-dup: skipping incline " + inclineVal + " (quantized=" + quantized + " already at " + last + ")");
                }
            } else {
                logger.log("QZ:Dispatch", "throttle: cached incline " + inclineVal + " (window open in " + (lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                cached.inclinePct = inclineVal;
            }
        }

        // resistance (1-part message)
        Float resistanceVal = cmd.resistanceLvl != null ? cmd.resistanceLvl : cached.resistanceLvl;
        if (resistanceVal != null && resistance != null) {
            Float last = resistance.lastApplied();
            logger.log("QZ:Dispatch", "requestResistance(bike): " + resistanceVal + " last=" + last);
            if (lastCommandMs + SWIPE_THROTTLE_MS < now) {
                if (last == null || !resistanceVal.equals(last)) {
                    applyResistance(resistanceVal);
                    logger.log("QZ:Dispatch", "applyResistance(bike): " + resistanceVal);
                    lastCommandMs = now;
                    cached.resistanceLvl = null;
                } else {
                    logger.log("QZ:Dispatch", "de-dup: skipping resistance " + resistanceVal + " (already at " + last + ")");
                }
            } else {
                logger.log("QZ:Dispatch", "throttle: cached resistance " + resistanceVal + " (window open in " + (lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                cached.resistanceLvl = resistanceVal;
            }
        }
    }

    @Override
    public MetricReader defaultMetricReader() {
        return new BikeMetricReader();
    }

    @Override
    public Command decodeCommand(String[] parts, char decimalSeparator) {
        Command cmd = new Command();
        if (parts.length == 2) {
            // "-1;-100" is the QZ end-of-ride sentinel; skip it by raw string so that a
            // legitimate Zwift grade of -1.0% (sent as "-1.0;0") is not swallowed.
            if ("-1".equals(parts[0]) && "-100".equals(parts[1])) return cmd;
            Float v = parseField(parts[0], decimalSeparator);
            // -100 in the incline slot is QZ's "no grade" heartbeat ("-100;N" while paused).
            // A real Zwift grade of -1% arrives as "-1.0", so this check is safe.
            if (v != null && v != -100) cmd.inclinePct = roundToOneDecimal(v);
        }
        if (parts.length == 1) {
            Float v = parseField(parts[0], decimalSeparator);
            if (v != null && v != -1 && v != -100) cmd.resistanceLvl = roundToOneDecimal(v);
        }
        return cmd;
    }
}
