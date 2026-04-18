package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import java.io.IOException;

/**
 * Metric reader for bike devices. Identical to TailGrepMetricReader except it
 * skips the KPH search — bikes don't emit "Changed KPH" to the iFit log.
 */
public class BikeMetricReader extends TailGrepMetricReader {

    @Override public MetricReader forIfitV2() { return this; }

    @Override
    public MetricSnapshot read(String file, Shell shell) throws IOException {
        MetricSnapshot m = new MetricSnapshot();

        findIncline(m, shell, file);
        findSingle(shell, "Changed Watts",       file, v -> m.watts         = lastFloat(v));
        findSingle(shell, "Changed RPM",         file, v -> m.cadenceRpm    = lastFloat(v));
        findSingle(shell, "Changed CurrentGear", file, v -> m.gearLevel     = lastFloat(v));
        findSingle(shell, "Changed Resistance",  file, v -> m.resistanceLvl = lastFloat(v));

        if (++truncateCounter > 1200) {
            truncateCounter = 0;
            shell.exec("truncate -s0 " + file);
        }

        return m;
    }
}
