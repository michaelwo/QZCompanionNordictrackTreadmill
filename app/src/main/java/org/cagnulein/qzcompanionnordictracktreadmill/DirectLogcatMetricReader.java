package org.cagnulein.qzcompanionnordictracktreadmill;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * Runs {@code logcat -b all -d} directly via {@link Runtime} and scans its output.
 * Filters out lines from this app's own log tag to avoid feedback loops.
 * The "Actual" prefix and "Grade changed" variant do not affect the last numeric token,
 * so values are parsed directly from the raw line.
 * Used by Grand Tour Pro, NTEX71021, and ProForm Carbon C10.
 */
class DirectLogcatMetricReader implements MetricReader {

    private static final String OWN_LOG_TAG = "QZ:Service";

    @FunctionalInterface
    interface ProcessFactory { Process launch() throws IOException; }

    static ProcessFactory factory = () -> Runtime.getRuntime().exec("logcat -b all -d");

    @Override
    public MetricSnapshot read(String file, Shell shell) throws IOException {
        MetricSnapshot m = new MetricSnapshot();
        Process process = factory.launch();
        BufferedReader reader = new BufferedReader(new InputStreamReader(process.getInputStream()));
        String line;
        while ((line = reader.readLine()) != null) {
            if (line.contains(OWN_LOG_TAG)) continue;
            if (line.contains("Changed KPH") || line.contains("Changed Actual KPH")) {
                m.speedKmh = lastFloat(line);
            } else if (line.contains("Changed Grade") || line.contains("Changed Actual Grade")
                    || line.contains("Grade changed")) {
                m.inclinePct = lastFloat(line);
            } else if (line.contains("Changed Watts")) {
                m.watts = lastFloat(line);
            } else if (line.contains("Changed RPM")) {
                m.cadenceRpm = lastFloat(line);
            } else if (line.contains("Changed CurrentGear")) {
                m.gearLevel = lastFloat(line);
            } else if (line.contains("Changed Resistance")) {
                m.resistanceLvl = lastFloat(line);
            }
        }
        try { process.waitFor(); } catch (InterruptedException e) { Thread.currentThread().interrupt(); }
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
