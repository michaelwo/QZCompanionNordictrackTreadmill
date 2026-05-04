package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.command.InclineCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.command.SpeedCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.command.QZCommandPacket;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.SliderMetric;

import java.util.ArrayList;
import java.util.List;

public abstract class TreadmillDevice extends Device {

    protected static final double KMH_TO_MPH = 0.621371;

    private final Slider speed;
    private final Slider incline;
    private Double cachedSpeedKmh = null;
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
    public final void handleSpeed(double kmh) {
        Double speedToApply = null;
        synchronized (this) {
            logger.log("QZ:Dispatch", "requestSpeed: " + kmh + " lastSpeed=" + lastKnownKph + " cachedSpeed=" + cachedSpeedKmh);
            if (lastKnownKph <= 0) {
                logger.log("QZ:Dispatch", "speed gate: held " + kmh + " (belt stopped)");
                cachedSpeedKmh = kmh;
            } else {
                cachedSpeedKmh = null;
                speedToApply = kmh;
            }
        }
        if (speedToApply != null) {
            applySpeed(speedToApply);
            logger.log("QZ:Dispatch", "applySpeed: " + speedToApply);
        }
    }

    @Override
    public final void handleIncline(double pct) {
        logger.log("QZ:Dispatch", "requestInclination: " + pct);
        applyIncline(pct);
        logger.log("QZ:Dispatch", "applyIncline: " + pct);
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

    // MetricReader and CommandListener threads both access cachedSpeedKmh.
    private void flushCachedSpeed() {
        double v;
        synchronized (this) {
            if (cachedSpeedKmh == null) return;
            v = cachedSpeedKmh;
            cachedSpeedKmh = null;
        }
        logger.log("QZ:Dispatch", "belt-gate flush: applySpeed " + v);
        applySpeed(v);
    }

    @Override
    public List<Command> decodeCommands(QZCommandPacket pkt) {
        List<Command> cmds = new ArrayList<>();
        if (pkt.fieldCount() == 2) {
            Float s = QZCommandPacket.parseField(pkt.rawField(0));
            Float i = QZCommandPacket.parseField(pkt.rawField(1));
            if (s != null && s != QZCommandPacket.NO_COMMAND && s != QZCommandPacket.NO_RESISTANCE) {
                cmds.add(new SpeedCommand(QZCommandPacket.roundToOneDecimal(s)));
            }
            if (i != null && i != QZCommandPacket.NO_COMMAND) {
                cmds.add(new InclineCommand(QZCommandPacket.roundToOneDecimal(i)));
            }
        }
        return cmds;
    }
}
