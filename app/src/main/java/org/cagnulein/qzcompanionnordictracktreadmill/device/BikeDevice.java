package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public abstract class BikeDevice extends Device {

    private final Slider incline;
    private final Slider resistance;  // null if this device has no resistance control

    protected BikeDevice(Slider incline, Slider resistance) {
        this.incline    = incline;
        this.resistance = resistance;
    }

    public float lastAppliedIncline() {
        Float v = incline.lastApplied();
        return v != null ? v : Float.MAX_VALUE;
    }

    public Float lastAppliedResistance() {
        return resistance != null ? resistance.lastApplied() : null;
    }

    public final void applyIncline(double value) {
        incline.moveTo(value, this);
    }

    public final void applyResistance(double level) {
        if (resistance == null) return;
        resistance.moveTo(level, this);
    }

    @Override
    public final void applyCommand(MetricSnapshot cmd, long now) {
        // incline (2-part message)
        Float inclineVal = cmd.inclinePct != null ? cmd.inclinePct : cached.inclinePct;
        if (inclineVal != null) {
            float quantized = incline.quantize(inclineVal);
            Float last = incline.lastApplied();
            logger.log("QZ:Dispatch", "requestIncline(bike): " + inclineVal + " quantized=" + quantized + " last=" + lastAppliedIncline());
            if (lastCommandMs + SWIPE_THROTTLE_MS < now) {
                if (last == null || quantized != last) {
                    applyIncline(quantized);
                    logger.log("QZ:Dispatch", "applyIncline(bike): " + quantized);
                    lastCommandMs = now;
                    cached.inclinePct = null;
                } else {
                    logger.log("QZ:Dispatch", "de-dup: skipping incline " + inclineVal + " (quantized=" + quantized + " already at " + lastAppliedIncline() + ")");
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
            logger.log("QZ:Dispatch", "requestResistance(bike): " + resistanceVal + " last=" + lastAppliedResistance());
            if (lastCommandMs + SWIPE_THROTTLE_MS < now) {
                if (last == null || !resistanceVal.equals(last)) {
                    applyResistance(resistanceVal);
                    logger.log("QZ:Dispatch", "applyResistance(bike): " + resistanceVal);
                    lastCommandMs = now;
                    cached.resistanceLvl = null;
                } else {
                    logger.log("QZ:Dispatch", "de-dup: skipping resistance " + resistanceVal + " (already at " + lastAppliedResistance() + ")");
                }
            } else {
                logger.log("QZ:Dispatch", "throttle: cached resistance " + resistanceVal + " (window open in " + (lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
            }
        }
    }

    @Override
    public MetricSnapshot decodeCommand(String[] parts, char decimalSeparator) {
        MetricSnapshot.Builder b = new MetricSnapshot.Builder();
        if (parts.length == 2) {
            Float v = parseField(parts[0], decimalSeparator);
            if (v != null && v != -1 && v != -100) b.inclinePct(roundToOneDecimal(v));
        }
        if (parts.length == 1) {
            Float v = parseField(parts[0], decimalSeparator);
            if (v != null && v != -1 && v != -100) b.resistanceLvl(roundToOneDecimal(v));
        }
        return b.build();
    }
}
