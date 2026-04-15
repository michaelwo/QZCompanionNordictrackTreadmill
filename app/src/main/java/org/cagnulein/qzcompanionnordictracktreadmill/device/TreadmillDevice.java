package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public abstract class TreadmillDevice extends Device {
    private int ySpeed;
    private int yIncline;

    protected TreadmillDevice(int initialSpeedY, int initialInclineY) {
        this.ySpeed = initialSpeedY;
        this.yIncline = initialInclineY;
    }

    protected abstract int speedX();
    protected abstract int targetSpeedY(double kmh);
    protected int currentSpeedY(MetricSnapshot current) { return ySpeed; }

    protected abstract int inclineX();
    protected abstract int targetInclineY(double pct);
    protected int currentInclineY(MetricSnapshot current) { return yIncline; }

    public final void applySpeed(double kmh, MetricSnapshot current) {
        int y2 = targetSpeedY(kmh);
        swipe(speedX(), currentSpeedY(current), y2);
        ySpeed = y2;
    }

    public final void applyIncline(double pct, MetricSnapshot current) {
        int y2 = targetInclineY(pct);
        swipe(inclineX(), currentInclineY(current), y2);
        yIncline = y2;
    }

    @Override
    public final void applyParsed(MetricSnapshot cmd, long now, MetricSnapshot current) {
        // speed (2-part message, first field)
        Float speed = cmd.speedKmh != null ? cmd.speedKmh : cached.speedKmh;
        if (speed != null) {
            logger.log("QZ:Dispatch", "requestSpeed: " + speed + " lastSpeed=" + current.speed() + " cachedSpeed=" + cached.speedKmh);
            if (lastCommandMs + SWIPE_THROTTLE_MS < now && current.speed() > 0) {
                applySpeed(speed, current);
                logger.log("QZ:Dispatch", "applySpeed: " + speed);
                lastCommandMs = now;
                cached.speedKmh = null;
            } else {
                if (current.speed() <= 0) {
                    logger.log("QZ:Dispatch", "speed gate: cached " + speed + " (treadmill stopped, speed=" + current.speed() + ")");
                } else {
                    logger.log("QZ:Dispatch", "throttle: cached speed " + speed + " (window open in " + (lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                }
                cached.speedKmh = speed;
            }
        }

        // incline (2-part message, second field)
        Float incline = cmd.inclinePct != null ? cmd.inclinePct : cached.inclinePct;
        if (incline != null) {
            logger.log("QZ:Dispatch", "requestInclination: " + incline + " cached=" + cached.inclinePct);
            if (lastCommandMs + SWIPE_THROTTLE_MS < now) {
                applyIncline(incline, current);
                logger.log("QZ:Dispatch", "applyIncline: " + incline);
                lastCommandMs = now;
                cached.inclinePct = null;
            } else {
                logger.log("QZ:Dispatch", "throttle: cached incline " + incline + " (window open in " + (lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                cached.inclinePct = incline;
            }
        }
    }

    @Override
    public MetricSnapshot parseCommand(String[] parts, char decimalSeparator) {
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
