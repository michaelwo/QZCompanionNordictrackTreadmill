package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

/**
 * Default log-file reader. Uses {@code tail | grep} pipelines with two levels of fallback.
 * Periodically truncates the log file to prevent unbounded growth.
 *
 * Subclasses override {@link #inclineKeyword()} and {@link #valueTokenIndex(String[])} to
 * adapt to different iFit log formats without any boolean flag arguments.
 */
public class TailGrepMetricReader implements MetricReader {

    public static int truncateCounter = 0;

    @Override
    public MetricReader forIfitV2() { return new TailGrepIfitV2MetricReader(); }

    /** The log keyword used to find incline lines. Override in subclasses for format variants. */
    protected String inclineKeyword() { return "Grade"; }

    /** The index of the value token in a split log line. Override in subclasses for format variants. */
    protected int valueTokenIndex(String[] tokens) { return tokens.length - 1; }

    @Override
    public MetricSnapshot read(String file, Shell shell) throws IOException {
        MetricSnapshot m = new MetricSnapshot();

        findSpeed(m, shell, file);
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

    protected void findSpeed(MetricSnapshot m, Shell shell, String file) throws IOException {
        if (trySpeed(m, shell, "tail -n500 " + file + " | grep -a \"Changed KPH\" | tail -n1")) return;
        if (trySpeed(m, shell, "grep -a \"Changed KPH\" " + file + "  | tail -n1")) return;
        trySpeed(m, shell, "cat " + file + " | grep -a \"Changed KPH\" | tail -n1");
    }

    private boolean trySpeed(MetricSnapshot m, Shell shell, String cmd) throws IOException {
        try (InputStream in = shell.execAndGetOutput(cmd);
             BufferedReader reader = new BufferedReader(new InputStreamReader(in))) {
            String line;
            boolean found = false;
            while ((line = reader.readLine()) != null) {
                try {
                    String[] b = line.replaceAll(",", ".").split(" ");
                    m.speedKmh = Float.parseFloat(b[valueTokenIndex(b)]);
                    found = true;
                } catch (Exception ignored) {}
            }
            return found;
        }
    }

    protected void findIncline(MetricSnapshot m, Shell shell, String file) throws IOException {
        String keyword = inclineKeyword();
        if (tryIncline(m, shell, "tail -n500 " + file + " | grep -a \"Changed " + keyword + "\" | tail -n1")) return;
        if (tryIncline(m, shell, "grep -a \"Changed " + keyword + "\" " + file + "  | tail -n1")) return;
        tryIncline(m, shell, "cat " + file + " | grep -a \"Changed " + keyword + "\" | tail -n1");
    }

    private boolean tryIncline(MetricSnapshot m, Shell shell, String cmd) throws IOException {
        try (InputStream in = shell.execAndGetOutput(cmd);
             BufferedReader reader = new BufferedReader(new InputStreamReader(in))) {
            String line;
            boolean found = false;
            while ((line = reader.readLine()) != null) {
                try {
                    String[] b = line.replaceAll(",", ".").split(" ");
                    m.inclinePct = Float.parseFloat(b[valueTokenIndex(b)]);
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
