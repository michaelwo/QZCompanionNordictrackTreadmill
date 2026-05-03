package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.command.QZCommandPacket;
import org.cagnulein.qzcompanionnordictracktreadmill.command.MyAccessibilityService;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MonoStdoutMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.SliderMetric;

public abstract class Device {
    /** The currently active device. Set by MainActivity when the user selects one. */
    public static volatile Device instance = null;

    /** Throttle window — commands within this window of the last apply are cached, not sent. */
    public static final int SWIPE_THROTTLE_MS = 500;

    /** Duration of each AccessibilityService swipe gesture, in ms. */
    public static final int SWIPE_DURATION_MS = 200;

    /**
     * Applies a parsed command to this device, honouring the throttle window and
     * any device-specific de-dup or gating rules.
     *
     * @param cmd     parsed command snapshot (non-null fields = requested values)
     * @param now current timestamp in ms (injected by CommandDispatcher)
     */
    public abstract void applyCommand(Command cmd, long now);

    /** Routes a live slider metric update to the matching Slider(s) on this device. */
    public abstract void applyMetric(SliderMetric metric, float value);

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
    public boolean requiresAdb() { return false; }

    /** Returns true if this device sends commands via the Android AccessibilityService. */
    public boolean requiresAccessibility() { return true; }

    /** Interprets a parsed QZ UDP packet for this device type. */
    public abstract Command decodeCommand(QZCommandPacket pkt);

    public MetricReader defaultMetricReader() {
        return new MonoStdoutMetricReader();
    }

    /**
     * Timestamp (ms) of the last command sent to this device.
     * Owned here so CommandDispatcher can throttle per-device without holding device state itself.
     */
    public long lastCommandMs = 0;

    protected void swipe(int x, int y1, int y2) {
        String cmd = "input swipe " + x + " " + y1 + " " + x + " " + y2 + " " + SWIPE_DURATION_MS;
        logger.log("QZ:Device", "swipe -> " + cmd);
        if (MyAccessibilityService.isConnected()) {
            MyAccessibilityService.performSwipe(x, y1, x, y2, SWIPE_DURATION_MS);
        } else {
            logger.log("QZ:Device", "swipe dropped: AccessibilityService not connected");
        }
        commandExecutor.send(cmd);
    }
}
