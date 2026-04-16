package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public abstract class TreadmillDevice extends Device {

    private final Slider speed;
    private final Slider incline;

    protected TreadmillDevice(Slider speed, Slider incline) {
        this.speed   = speed;
        this.incline = incline;
    }

    public final void applySpeed(double kmh) {
        speed.moveTo(kmh, this);
    }

    public final void applyIncline(double pct) {
        incline.moveTo(pct, this);
    }

    @Override
    public final void applyCommand(MetricSnapshot cmd, long now) {
        // speed (2-part message, first field)
        Float speedVal = cmd.speedKmh != null ? cmd.speedKmh : cached.speedKmh;
        if (speedVal != null) {
            logger.log("QZ:Dispatch", "requestSpeed: " + speedVal + " lastSpeed=" + lastSnapshot.speed() + " cachedSpeed=" + cached.speedKmh);
            if (lastCommandMs + SWIPE_THROTTLE_MS < now && lastSnapshot.speed() > 0) {
                applySpeed(speedVal);
                logger.log("QZ:Dispatch", "applySpeed: " + speedVal);
                lastCommandMs = now;
                cached.speedKmh = null;
            } else {
                if (lastSnapshot.speed() <= 0) {
                    logger.log("QZ:Dispatch", "speed gate: cached " + speedVal + " (treadmill stopped, speed=" + lastSnapshot.speed() + ")");
                } else {
                    logger.log("QZ:Dispatch", "throttle: cached speed " + speedVal + " (window open in " + (lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                }
                cached.speedKmh = speedVal;
            }
        }

        // incline (2-part message, second field)
        Float inclineVal = cmd.inclinePct != null ? cmd.inclinePct : cached.inclinePct;
        if (inclineVal != null) {
            logger.log("QZ:Dispatch", "requestInclination: " + inclineVal + " cached=" + cached.inclinePct);
            if (lastCommandMs + SWIPE_THROTTLE_MS < now) {
                applyIncline(inclineVal);
                logger.log("QZ:Dispatch", "applyIncline: " + inclineVal);
                lastCommandMs = now;
                cached.inclinePct = null;
            } else {
                logger.log("QZ:Dispatch", "throttle: cached incline " + inclineVal + " (window open in " + (lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                cached.inclinePct = inclineVal;
            }
        }
    }

    @Override
    public MetricSnapshot decodeCommand(String[] parts, char decimalSeparator) {
        MetricSnapshot.Builder b = new MetricSnapshot.Builder();
        if (parts.length == 2) {
            Float s = parseField(parts[0], decimalSeparator);
            Float i = parseField(parts[1], decimalSeparator);
            if (s != null && s != -1)   b.speedKmh(roundToOneDecimal(s));
            if (i != null && i != -100) b.inclinePct(roundToOneDecimal(i));
        }
        return b.build();
    }
}
