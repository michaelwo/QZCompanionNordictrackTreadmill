package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.command.QZCommandPacket;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.SliderMetric;

import java.util.ArrayList;
import java.util.List;

public abstract class TreadmillDevice extends Device {

    protected static final double KMH_TO_MPH = 0.621371;

    private final Slider speed;
    private final Slider incline;
    private final Command cached = new Command();
    private volatile float lastKnownKph = 0f;

    protected TreadmillDevice(Slider incline, Slider speed) {
        this.incline = incline;
        this.speed   = speed;
    }

    protected final void applySpeed(double kmh) {
        speed.moveTo(kmh, this);
    }

    protected final void applyIncline(double pct) {
        incline.moveTo(pct, this);
    }

    @Override
    public void applyMetric(SliderMetric metric, float value) {
        incline.applyIfMatch(metric, value);
        speed.applyIfMatch(metric, value);
        if (metric == SliderMetric.KPH) {
            lastKnownKph = value;
            if (value > 0) flushCachedSpeed();
        }
    }

    // Called from applyMetric (MetricReader thread) — synchronized to prevent TOCTOU race
    // with applyCommand (CommandListener thread) on cached.speedKmh.
    private synchronized void flushCachedSpeed() {
        if (cached.speedKmh != null) {
            float v = cached.speedKmh;
            cached.speedKmh = null;
            logger.log("QZ:Dispatch", "belt-gate flush: applySpeed " + v);
            applySpeed(v);
        }
    }

    @Override
    public final void applyCommand(Command cmd) {
        Float speedToApply = null;
        synchronized (this) {
            // speed: belt-gate cache provides fallback if this message has no speed field
            Float speedVal = cmd.speedKmh != null ? cmd.speedKmh : cached.speedKmh;
            if (speedVal != null) {
                logger.log("QZ:Dispatch", "requestSpeed: " + speedVal + " lastSpeed=" + lastKnownKph + " cachedSpeed=" + cached.speedKmh);
                if (lastKnownKph <= 0) {
                    logger.log("QZ:Dispatch", "speed gate: held " + speedVal + " (belt stopped)");
                    cached.speedKmh = speedVal;
                } else {
                    cached.speedKmh = null;
                    speedToApply = speedVal;
                }
            }
        }
        if (speedToApply != null) {
            applySpeed(speedToApply);
            logger.log("QZ:Dispatch", "applySpeed: " + speedToApply);
        }

        if (cmd.inclinePct != null) {
            logger.log("QZ:Dispatch", "requestInclination: " + cmd.inclinePct);
            applyIncline(cmd.inclinePct);
            logger.log("QZ:Dispatch", "applyIncline: " + cmd.inclinePct);
        }
    }

    @Override
    public List<Command> decodeCommands(QZCommandPacket pkt) {
        List<Command> cmds = new ArrayList<>();
        if (pkt.fieldCount() == 2) {
            Float s = QZCommandPacket.parseField(pkt.rawField(0));
            Float i = QZCommandPacket.parseField(pkt.rawField(1));
            if (s != null && s != QZCommandPacket.NO_COMMAND && s != QZCommandPacket.NO_RESISTANCE) {
                Command c = new Command();
                c.speedKmh = QZCommandPacket.roundToOneDecimal(s);
                cmds.add(c);
            }
            if (i != null && i != QZCommandPacket.NO_COMMAND) {
                Command c = new Command();
                c.inclinePct = QZCommandPacket.roundToOneDecimal(i);
                cmds.add(c);
            }
        }
        return cmds;
    }
}
