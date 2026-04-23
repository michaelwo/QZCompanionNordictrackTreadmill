package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import java.io.IOException;
import java.util.function.Consumer;

public interface MetricReader {
    MetricSnapshot read(String file, Shell shell) throws IOException;

    /** Returns the reader variant for iFit v2 logs. Most readers are format-agnostic; override in subclasses that differ. */
    default MetricReader forIfitV2() { return this; }

    /**
     * Push hook for streaming readers. The reader calls {@code listener} immediately whenever a
     * new metric arrives, allowing the service to skip the poll loop entirely.
     * Returns {@code true} if accepted; {@code false} for pull-based readers (default).
     */
    default boolean subscribe(Consumer<MetricSnapshot> listener) { return false; }
}
