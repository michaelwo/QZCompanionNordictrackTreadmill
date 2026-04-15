package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public abstract class BikeDevice extends Device {
    private int yIncline;
    private int yResistance;

    private float lastAppliedIncline    = Float.MAX_VALUE;
    private Float lastAppliedResistance = null;

    public float lastAppliedIncline()    { return lastAppliedIncline; }
    public Float lastAppliedResistance() { return lastAppliedResistance; }

    protected BikeDevice(int initialInclineY, int initialResistanceY) {
        this.yIncline = initialInclineY;
        this.yResistance = initialResistanceY;
    }

    protected abstract int inclineX();
    protected abstract int targetInclineY(double value);
    protected int currentInclineY(MetricSnapshot current) { return yIncline; }

    /**
     * Quantizes an incoming grade to the nearest value this device can physically reach.
     * Default: identity (no quantization). Override for devices whose slider snaps to
     * a fixed grid (e.g. S22i snaps to 0.5% increments).
     */
    public float quantizeIncline(float grade) { return grade; }

    protected int resistanceX()               { return -1; }
    protected int targetResistanceY(double v) { return -1; }
    protected int currentResistanceY(MetricSnapshot current) { return yResistance; }

    public final void applyIncline(double value, MetricSnapshot current) {
        int y2 = targetInclineY(value);
        swipe(inclineX(), currentInclineY(current), y2);
        yIncline = y2;
        lastAppliedIncline = (float) value;
    }

    public final void applyResistance(double level, MetricSnapshot current) {
        if (resistanceX() == -1) return;
        int y2 = targetResistanceY(level);
        swipe(resistanceX(), currentResistanceY(current), y2);
        yResistance = y2;
        lastAppliedResistance = (float) level;
    }

    @Override
    public final void applyParsed(MetricSnapshot cmd, long now, MetricSnapshot current) {
        // incline (2-part message)
        Float incline = cmd.inclinePct != null ? cmd.inclinePct : cached.inclinePct;
        if (incline != null) {
            float quantized = quantizeIncline(incline);
            logger.log("QZ:Dispatch", "requestIncline(bike): " + incline + " quantized=" + quantized + " last=" + lastAppliedIncline());
            if (lastCommandMs + SWIPE_THROTTLE_MS < now) {
                if (quantized != lastAppliedIncline()) {
                    applyIncline(quantized, current);
                    logger.log("QZ:Dispatch", "applyIncline(bike): " + quantized);
                    lastCommandMs = now;
                    cached.inclinePct = null;
                } else {
                    logger.log("QZ:Dispatch", "de-dup: skipping incline " + incline + " (quantized=" + quantized + " already at " + lastAppliedIncline() + ")");
                }
            } else {
                logger.log("QZ:Dispatch", "throttle: cached incline " + incline + " (window open in " + (lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                cached.inclinePct = incline;
            }
        }

        // resistance (1-part message)
        Float resistance = cmd.resistanceLvl != null ? cmd.resistanceLvl : cached.resistanceLvl;
        if (resistance != null) {
            logger.log("QZ:Dispatch", "requestResistance(bike): " + resistance + " last=" + lastAppliedResistance());
            if (lastCommandMs + SWIPE_THROTTLE_MS < now) {
                if (!resistance.equals(lastAppliedResistance())) {
                    applyResistance(resistance, current);
                    logger.log("QZ:Dispatch", "applyResistance(bike): " + resistance);
                    lastCommandMs = now;
                    cached.resistanceLvl = null;
                } else {
                    logger.log("QZ:Dispatch", "de-dup: skipping resistance " + resistance + " (already at " + lastAppliedResistance() + ")");
                }
            } else {
                logger.log("QZ:Dispatch", "throttle: cached resistance " + resistance + " (window open in " + (lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
            }
        }
    }

    @Override
    public MetricSnapshot parseCommand(String[] parts, char decimalSeparator) {
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
