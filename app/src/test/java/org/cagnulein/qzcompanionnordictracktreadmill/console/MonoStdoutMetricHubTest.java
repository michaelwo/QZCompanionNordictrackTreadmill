package org.cagnulein.qzcompanionnordictracktreadmill.console;

import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricPacket;
import org.junit.Test;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.function.Consumer;

import static org.junit.Assert.*;

public class MonoStdoutMetricHubTest {

    @Test
    public void subscribe_startsReaderOnceAndFansOutPackets() throws Exception {
        FakeReader reader = new FakeReader();
        MonoStdoutMetricHub hub = new MonoStdoutMetricHub(reader);
        List<QZMetricPacket> first = new ArrayList<>();
        List<QZMetricPacket> second = new ArrayList<>();

        MonoStdoutMetricHub.Subscription firstSub = hub.subscribe(first::add);
        hub.subscribe(second::add);
        reader.emit(new QZMetricPacket(QZMetricPacket.Metric.GRADE, 4.0f));

        assertEquals(1, reader.readCount);
        assertEquals(1, first.size());
        assertEquals(1, second.size());

        firstSub.close();
        reader.emit(new QZMetricPacket(QZMetricPacket.Metric.GRADE, 5.0f));

        assertEquals(1, first.size());
        assertEquals(2, second.size());
        assertEquals(1, hub.subscriberCount());
    }

    private static final class FakeReader implements MetricReader {
        int readCount = 0;
        Consumer<QZMetricPacket> listener;

        @Override
        public void read() throws IOException {
            readCount++;
        }

        @Override
        public boolean subscribe(Consumer<QZMetricPacket> listener) {
            this.listener = listener;
            return true;
        }

        void emit(QZMetricPacket packet) {
            listener.accept(packet);
        }
    }
}
