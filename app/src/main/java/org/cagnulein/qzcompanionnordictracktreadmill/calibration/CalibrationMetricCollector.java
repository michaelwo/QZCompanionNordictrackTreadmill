package org.cagnulein.qzcompanionnordictracktreadmill.calibration;

import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricPacket;

import java.util.function.Consumer;

/** Caches recent iFit metric packets and exposes fresh/stable waits for calibration sweeps. */
public final class CalibrationMetricCollector implements Consumer<QZMetricPacket> {

    public interface Clock { long nowMs(); }
    public interface Sleeper { void sleepMs(long ms) throws InterruptedException; }

    private static final long POLL_MS = 100L;

    private final Clock clock;
    private final Sleeper sleeper;
    private Sample grade;
    private Sample resistance;
    private Sample currentGear;

    public CalibrationMetricCollector() {
        this(System::currentTimeMillis, Thread::sleep);
    }

    public CalibrationMetricCollector(Clock clock, Sleeper sleeper) {
        this.clock = clock;
        this.sleeper = sleeper;
    }

    @Override
    public void accept(QZMetricPacket packet) {
        accept(packet, clock.nowMs());
    }

    public synchronized void accept(QZMetricPacket packet, long timestampMs) {
        if (packet.metric == QZMetricPacket.Metric.GRADE) {
            grade = new Sample(packet.value, timestampMs);
        } else if (packet.metric == QZMetricPacket.Metric.RESISTANCE) {
            if (packet.value >= 1.0f) resistance = new Sample(packet.value, timestampMs);
        } else if (packet.metric == QZMetricPacket.Metric.CURRENT_GEAR) {
            if (packet.value >= 1.0f) currentGear = new Sample(packet.value, timestampMs);
        }
        notifyAll();
    }

    public synchronized long anyEventTimestampMs() {
        return Math.max(grade != null ? grade.timestampMs : 0L,
                Math.max(resistance != null ? resistance.timestampMs : 0L,
                        currentGear != null ? currentGear.timestampMs : 0L));
    }

    public Float waitFreshGrade(long afterTimestampMs, long timeoutMs) {
        return waitFresh(QZMetricPacket.Metric.GRADE, afterTimestampMs, timeoutMs);
    }

    public Float waitFreshResistance(long afterTimestampMs, long timeoutMs) {
        return waitFresh(QZMetricPacket.Metric.RESISTANCE, afterTimestampMs, timeoutMs);
    }

    public Float waitStableGrade(long afterTimestampMs, long settleMs, long timeoutMs) {
        return waitStable(QZMetricPacket.Metric.GRADE, afterTimestampMs, settleMs, timeoutMs);
    }

    public Float waitStableResistance(long afterTimestampMs, long settleMs, long timeoutMs) {
        return waitStable(QZMetricPacket.Metric.RESISTANCE, afterTimestampMs, settleMs, timeoutMs);
    }

    private Float waitFresh(QZMetricPacket.Metric metric, long afterTimestampMs, long timeoutMs) {
        long deadline = clock.nowMs() + timeoutMs;
        while (clock.nowMs() < deadline) {
            Sample sample = sample(metric, afterTimestampMs);
            if (sample != null && sample.timestampMs > afterTimestampMs) return sample.value;
            sleep(POLL_MS);
        }
        Sample sample = sample(metric, afterTimestampMs);
        return sample != null && sample.timestampMs > afterTimestampMs ? sample.value : null;
    }

    private Float waitStable(QZMetricPacket.Metric metric, long afterTimestampMs,
                             long settleMs, long timeoutMs) {
        long deadline = clock.nowMs() + timeoutMs;
        Float lastValue = null;
        long lastChangeMs = 0L;
        while (clock.nowMs() < deadline) {
            Sample sample = sample(metric, afterTimestampMs);
            if (sample != null && sample.timestampMs > afterTimestampMs) {
                if (lastValue == null || Float.compare(sample.value, lastValue) != 0) {
                    lastValue = sample.value;
                    lastChangeMs = clock.nowMs();
                } else if (clock.nowMs() - lastChangeMs >= settleMs) {
                    return lastValue;
                }
            }
            sleep(POLL_MS);
        }
        return lastValue;
    }

    private synchronized Sample sample(QZMetricPacket.Metric metric) {
        if (metric == QZMetricPacket.Metric.GRADE) return grade;
        if (currentGear != null) return currentGear;
        return resistance;
    }

    private synchronized Sample sample(QZMetricPacket.Metric metric, long afterTimestampMs) {
        if (metric == QZMetricPacket.Metric.GRADE) return grade;
        if (currentGear != null && currentGear.timestampMs > afterTimestampMs) return currentGear;
        return resistance;
    }

    private void sleep(long ms) {
        try {
            sleeper.sleepMs(ms);
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        }
    }

    private static final class Sample {
        final float value;
        final long timestampMs;

        Sample(float value, long timestampMs) {
            this.value = value;
            this.timestampMs = timestampMs;
        }
    }
}
