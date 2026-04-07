package org.cagnulein.qzcompanionnordictracktreadmill;

import java.io.IOException;

interface MetricReader {
    MetricSnapshot read(String file, Shell shell) throws IOException;
}
