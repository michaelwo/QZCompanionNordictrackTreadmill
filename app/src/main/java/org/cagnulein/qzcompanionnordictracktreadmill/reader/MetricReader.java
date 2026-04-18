package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import java.io.IOException;

public interface MetricReader {
    MetricSnapshot read(String file, Shell shell) throws IOException;

    /** Returns the reader variant for iFit v2 logs. Most readers are format-agnostic; override in subclasses that differ. */
    default MetricReader forIfitV2() { return this; }
}
