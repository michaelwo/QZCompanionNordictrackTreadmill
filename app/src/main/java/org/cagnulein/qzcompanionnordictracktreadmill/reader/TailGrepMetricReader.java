package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

/**
 * Default log-file reader. Uses {@code tail | grep} pipelines with two levels of fallback.
 * The {@code ifitV2} flag changes the incline keyword and the token position used for
 * speed/incline values. Pass {@code true} when the iFit v2 log path is detected by QZService.
 * Periodically truncates the log file to prevent unbounded growth.
 */
public class TailGrepMetricReader implements MetricReader {

    private final boolean ifitV2;

    public TailGrepMetricReader()              { this(false); }
    public TailGrepMetricReader(boolean ifitV2) { this.ifitV2 = ifitV2; }

    public static int truncateCounter = 0;

    @Override
    public MetricSnapshot read(String file, Shell shell) throws IOException {
        MetricSnapshot m = new MetricSnapshot();

        findSpeed(m, shell, file, ifitV2);
        findIncline(m, shell, file, ifitV2);
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

    protected void findSpeed(MetricSnapshot m, Shell shell, String file, boolean v2)
            throws IOException {
        if (trySpeed(m, shell, "tail -n500 " + file + " | grep -a \"Changed KPH\" | tail -n1", v2)) return;
        if (trySpeed(m, shell, "grep -a \"Changed KPH\" " + file + "  | tail -n1", v2)) return;
        trySpeed(m, shell, "cat " + file + " | grep -a \"Changed KPH\"", v2);
    }

    private boolean trySpeed(MetricSnapshot m, Shell shell, String cmd, boolean v2)
            throws IOException {
        try (InputStream in = shell.execAndGetOutput(cmd);
             BufferedReader reader = new BufferedReader(new InputStreamReader(in))) {
            String line;
            boolean found = false;
            while ((line = reader.readLine()) != null) {
                try {
                    String[] b = line.replaceAll(",", ".").split(" ");
                    m.speedKmh = Float.parseFloat(v2 ? b[b.length - 2] : b[b.length - 1]);
                    found = true;
                } catch (Exception ignored) {}
            }
            return found;
        }
    }

    protected void findIncline(MetricSnapshot m, Shell shell, String file, boolean v2)
            throws IOException {
        String keyword = v2 ? "INCLINE" : "Grade";
        if (tryIncline(m, shell, "tail -n500 " + file + " | grep -a \"Changed " + keyword + "\" | tail -n1", v2)) return;
        if (tryIncline(m, shell, "grep -a \"Changed " + keyword + "\" " + file + "  | tail -n1", v2)) return;
        tryIncline(m, shell, "cat " + file + " | grep -a \"Changed " + keyword + "\"", v2);
    }

    private boolean tryIncline(MetricSnapshot m, Shell shell, String cmd, boolean v2)
            throws IOException {
        try (InputStream in = shell.execAndGetOutput(cmd);
             BufferedReader reader = new BufferedReader(new InputStreamReader(in))) {
            String line;
            boolean found = false;
            while ((line = reader.readLine()) != null) {
                try {
                    String[] b = line.replaceAll(",", ".").split(" ");
                    m.inclinePct = Float.parseFloat(v2 ? b[b.length - 2] : b[b.length - 1]);
                    found = true;
                } catch (Exception ignored) {}
            }
            return found;
        }
    }

    @FunctionalInterface
    protected interface Setter { void set(String value); }

    protected void findSingle(Shell shell, String keyword, String file, Setter setter)
            throws IOException {
        if (trySingle(shell, "tail -n500 " + file + " | grep -a \"" + keyword + "\" | tail -n1", setter)) return;
        trySingle(shell, "grep -a \"" + keyword + "\" " + file + "  | tail -n1", setter);
    }

    private boolean trySingle(Shell shell, String cmd, Setter setter) throws IOException {
        try (InputStream in = shell.execAndGetOutput(cmd);
             BufferedReader reader = new BufferedReader(new InputStreamReader(in))) {
            String line = reader.readLine();
            if (line != null) {
                setter.set(line);
                return true;
            }
            return false;
        }
    }

    protected static Float lastFloat(String line) {
        try {
            String[] parts = line.trim().split("\\s+");
            return Float.parseFloat(parts[parts.length - 1]);
        } catch (Exception ignored) {
            return null;
        }
    }
}
