package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.TailGrepMetricReader;

public abstract class Device {
    /** The currently active device. Set by MainActivity when the user selects one. */
    public static Device instance = null;

    /** Latest observed metrics from the fitness device. Written by MetricReaderBroadcastingService. */
    public MetricSnapshot lastSnapshot = new MetricSnapshot();

    /** Throttle window — commands within this window of the last apply are cached, not sent. */
    public static final int SWIPE_THROTTLE_MS = 500;

    /**
     * Applies a parsed command to this device, honouring the throttle window and
     * any device-specific de-dup or gating rules.
     *
     * @param cmd     parsed command snapshot (non-null fields = requested values)
     * @param now current timestamp in ms (injected by CommandDispatcher)
     */
    public abstract void applyCommand(Command cmd, long now);

    /** Merges non-null fields from {@code m} into {@link #lastSnapshot}. */
    public void updateSnapshot(MetricSnapshot m) {
        if (m.speedKmh      != null) lastSnapshot.speedKmh      = m.speedKmh;
        if (m.inclinePct    != null) lastSnapshot.inclinePct    = m.inclinePct;
        if (m.resistanceLvl != null) lastSnapshot.resistanceLvl = m.resistanceLvl;
        if (m.cadenceRpm    != null) lastSnapshot.cadenceRpm    = m.cadenceRpm;
        if (m.watts         != null) lastSnapshot.watts         = m.watts;
        if (m.gearLevel     != null) lastSnapshot.gearLevel     = m.gearLevel;
        if (m.heartRate     != null) lastSnapshot.heartRate     = m.heartRate;
    }

    /** Functional interface so the executor can be set without Android imports. */
    public interface CommandExecutor { void send(String command); }

    /** Executes shell commands on this device. No-op by default; set by MainActivity. */
    public CommandExecutor commandExecutor = command -> {};

    /** Functional interface for log output. */
    public interface Logger { void log(String tag, String msg); }

    /** Logger for this device. No-op by default; set by MainActivity. */
    public Logger logger = (tag, msg) -> {};

    public abstract String displayName();

    /** Returns true if this device sends commands via the ADB loopback connection. */
    public boolean requiresAdb() { return true; }

    /**
     * Interprets a raw UDP message (already split on ";") for this device type.
     * Returns a MetricSnapshot whose non-null fields represent the requested values.
     * Fields not relevant to this device type (or absent from the message) are null.
     */
    public abstract Command decodeCommand(String[] parts, char decimalSeparator);

    /** Rounds to one decimal place (e.g. 5.25 → 5.3). */
    public static float roundToOneDecimal(float value) {
        return Math.round(value * 10) / 10.0f;
    }

    /**
     * Parses one message part into a Float, handling locale decimal separators and
     * the common fallback of replacing ',' with '.'.  Returns null on parse failure.
     */
    public static Float parseField(String part, char decimalSeparator) {
        String s = part.trim();
        if (decimalSeparator != '.') s = s.replace('.', decimalSeparator);
        try {
            return Float.parseFloat(s);
        } catch (NumberFormatException e) {
            try {
                return Float.parseFloat(s.replace(',', '.'));
            } catch (NumberFormatException e2) {
                return null;
            }
        }
    }

    public MetricReader defaultMetricReader() {
        return new TailGrepMetricReader();
    }

    /**
     * Timestamp (ms) of the last command sent to this device.
     * Owned here so CommandDispatcher can throttle per-device without holding device state itself.
     */
    public long lastCommandMs = 0;

    protected void swipe(int x, int y1, int y2) {
        String cmd = "input swipe " + x + " " + y1 + " " + x + " " + y2 + " 200";
        logger.log("QZ:Device", "swipe -> " + cmd);
        commandExecutor.send(cmd);
    }
}
