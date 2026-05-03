package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.command.QZCommandPacket;
import org.cagnulein.qzcompanionnordictracktreadmill.command.MyAccessibilityService;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MonoStdoutMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.SliderMetric;

import java.util.List;

public abstract class Device {
    /** The currently active device. Set by MainActivity when the user selects one. */
    public static volatile Device instance = null;

    /** Duration of each AccessibilityService swipe gesture, in ms. */
    public static final int SWIPE_DURATION_MS = 200;

    /**
     * Applies a parsed command to this device immediately.
     * Throttling is handled by CommandDispatcher; device subclasses apply device-specific
     * de-dup or safety-gate logic only.
     *
     * @param cmd parsed command snapshot (non-null fields = requested values)
     */
    public abstract void applyCommand(Command cmd);

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

    /** Interprets a parsed QZ UDP packet and returns one Command per actionable field. */
    public abstract List<Command> decodeCommands(QZCommandPacket pkt);

    public MetricReader defaultMetricReader() {
        return new MonoStdoutMetricReader();
    }

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
