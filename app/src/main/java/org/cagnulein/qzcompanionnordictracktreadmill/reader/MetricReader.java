package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import java.io.IOException;

public interface MetricReader {
    MetricSnapshot read(String file, Shell shell) throws IOException;
}
