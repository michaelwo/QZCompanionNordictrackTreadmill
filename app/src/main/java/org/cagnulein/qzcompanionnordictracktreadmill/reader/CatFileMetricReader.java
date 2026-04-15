package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

/**
 * Reads the entire log file via {@code cat} and scans all lines for metric keywords.
 * Used by devices that lack {@code tail} and {@code grep} capabilities on-device.
 */
public class CatFileMetricReader implements MetricReader {

    @Override
    public MetricSnapshot read(String file, Shell shell) throws IOException {
        MetricSnapshot m = new MetricSnapshot();
        try (InputStream in = shell.execAndGetOutput("cat " + file);
             BufferedReader reader = new BufferedReader(new InputStreamReader(in))) {
            String line;
            while ((line = reader.readLine()) != null) {
                if (line.contains("Changed KPH") || line.contains("Kph changed")) {
                    m.speedKmh = lastFloat(line);
                } else if (line.contains("Changed Grade") || line.contains("Grade changed")) {
                    m.inclinePct = lastFloat(line);
                } else if (line.contains("Changed Watts") || line.contains("Watts changed")) {
                    m.watts = lastFloat(line);
                } else if (line.contains("Changed RPM")) {
                    m.cadenceRpm = lastFloat(line);
                } else if (line.contains("Changed CurrentGear")) {
                    m.gearLevel = lastFloat(line);
                } else if (line.contains("Changed Resistance")) {
                    m.resistanceLvl = lastFloat(line);
                } else if (line.contains("HeartRateDataUpdate")) {
                    m.heartRate = lastFloat(line);
                }
            }
        }
        return m;
    }

    private static Float lastFloat(String line) {
        try {
            String[] parts = line.trim().split("\\s+");
            return Float.parseFloat(parts[parts.length - 1]);
        } catch (Exception ignored) {
            return null;
        }
    }
}
