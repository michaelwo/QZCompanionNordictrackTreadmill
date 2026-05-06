package org.cagnulein.qzcompanionnordictracktreadmill.calibration;

import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricPacket;
import org.junit.Test;

import static org.junit.Assert.*;

public class CalibrationMetricCollectorTest {

    private static final float DELTA = 0.0001f;

    @Test
    public void waitFreshGrade_returnsOnlyEventsAfterTimestamp() {
        ManualClock clock = new ManualClock(1000);
        CalibrationMetricCollector collector = new CalibrationMetricCollector(clock, clock::advance);
        collector.accept(new QZMetricPacket(QZMetricPacket.Metric.GRADE, 3.5f), 1000);

        assertNull(collector.waitFreshGrade(1000, 300));

        collector.accept(new QZMetricPacket(QZMetricPacket.Metric.GRADE, 4.0f), clock.nowMs());

        assertEquals(4.0f, collector.waitFreshGrade(1000, 300), DELTA);
    }

    @Test
    public void waitStableResistance_returnsLastValueAfterSettleWindow() {
        ManualClock clock = new ManualClock(1000);
        CalibrationMetricCollector collector = new CalibrationMetricCollector(clock, clock::advance);
        collector.accept(new QZMetricPacket(QZMetricPacket.Metric.RESISTANCE, 12.0f), 1100);
        clock.now = 1100;

        assertEquals(12.0f, collector.waitStableResistance(1000, 250, 1000), DELTA);
    }

    @Test
    public void resistance_zeroNoiseIsIgnored() {
        ManualClock clock = new ManualClock(1000);
        CalibrationMetricCollector collector = new CalibrationMetricCollector(clock, clock::advance);
        collector.accept(new QZMetricPacket(QZMetricPacket.Metric.RESISTANCE, 0.0f), 1100);

        assertNull(collector.waitFreshResistance(1000, 300));
        assertEquals(0L, collector.anyEventTimestampMs());
    }

    @Test
    public void currentGearFeedsResistanceCollector() {
        ManualClock clock = new ManualClock(1000);
        CalibrationMetricCollector collector = new CalibrationMetricCollector(clock, clock::advance);
        collector.accept(new QZMetricPacket(QZMetricPacket.Metric.CURRENT_GEAR, 7.0f), 1100);

        assertEquals(7.0f, collector.waitFreshResistance(1000, 300), DELTA);
    }

    @Test
    public void currentGearWinsWhenResistanceNoiseArrivesLater() {
        ManualClock clock = new ManualClock(1000);
        CalibrationMetricCollector collector = new CalibrationMetricCollector(clock, clock::advance);
        collector.accept(new QZMetricPacket(QZMetricPacket.Metric.CURRENT_GEAR, 24.0f), 1100);
        collector.accept(new QZMetricPacket(QZMetricPacket.Metric.RESISTANCE, 4.0f), 1200);

        assertEquals(24.0f, collector.waitFreshResistance(1000, 300), DELTA);
    }

    private static final class ManualClock implements CalibrationMetricCollector.Clock {
        long now;

        ManualClock(long now) {
            this.now = now;
        }

        @Override
        public long nowMs() {
            return now;
        }

        void advance(long ms) {
            now += ms;
        }
    }
}
