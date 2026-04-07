package org.cagnulein.qzcompanionnordictracktreadmill;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

/**
 * Dumps logcat to a file via ADB, then reads that file via shell {@code cat}.
 * Handles "Changed Actual KPH / Grade" variants — "Actual" does not affect the
 * last token, so the value is parsed directly from the raw line.
 * Used by the T7.5s treadmill.
 */
class LogcatDumpMetricReader implements MetricReader {

    static Device.CommandExecutor adbSender = MainActivity::sendCommand;

    @Override
    public MetricSnapshot read(String file, Shell shell) throws IOException {
        adbSender.send("logcat -b all -d > /sdcard/logcat.log");

        MetricSnapshot m = new MetricSnapshot();
        InputStream in = shell.execAndGetOutput("cat /sdcard/logcat.log");
        BufferedReader reader = new BufferedReader(new InputStreamReader(in));
        String line;
        while ((line = reader.readLine()) != null) {
            if (line.contains("Changed KPH") || line.contains("Changed Actual KPH")) {
                m.speedKmh = lastFloat(line);
            } else if (line.contains("Changed Grade") || line.contains("Changed Actual Grade")) {
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
        in.close();
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
