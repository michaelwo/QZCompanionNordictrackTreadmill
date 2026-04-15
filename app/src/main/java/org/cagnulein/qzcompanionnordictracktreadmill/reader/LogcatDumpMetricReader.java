package org.cagnulein.qzcompanionnordictracktreadmill.reader;

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
public class LogcatDumpMetricReader implements MetricReader {

    /** Sends an ADB command. Matches the signature of Device.CommandExecutor. */
    public interface AdbSender { void send(String command); }

    public static AdbSender adbSender = org.cagnulein.qzcompanionnordictracktreadmill.MainActivity::sendCommand;

    @Override
    public MetricSnapshot read(String file, Shell shell) throws IOException {
        // -t 500: limit to last 500 entries so the file stays bounded in size
        // regardless of how long the session has been running.
        adbSender.send("logcat -b all -d -t 500 > /sdcard/logcat.log");

        MetricSnapshot m = new MetricSnapshot();
        try (InputStream in = shell.execAndGetOutput("cat /sdcard/logcat.log");
             BufferedReader reader = new BufferedReader(new InputStreamReader(in))) {
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
