package org.cagnulein.qzcompanionnordictracktreadmill.console;

import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricPacket;

import java.io.IOException;
import java.util.function.Consumer;

public interface MetricReader {
    void read() throws IOException;


    /**
     * Push hook for streaming readers. The reader calls {@code listener} immediately whenever a
     * new metric arrives, allowing the service to skip the poll loop entirely.
     * Returns {@code true} if accepted; {@code false} for pull-based readers (default).
     */
    default boolean subscribe(Consumer<QZMetricPacket> listener) { return false; }
}
