package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;
import org.cagnulein.qzcompanionnordictracktreadmill.device.gesture.GestureService;
import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;

import java.util.List;

public abstract class Device {
    /** Duration of each AccessibilityService swipe gesture, in ms. */
    public static final int SWIPE_DURATION_MS = 200;

    /** All sliders on this device, in declaration order. Used for metric routing and command dispatch. */
    public abstract List<Slider> sliders();

    /** Returns the first slider of the given type, or null if none. */
    public final <S extends Slider> S sliderOf(Class<S> type) {
        for (Slider s : sliders()) {
            if (type.isInstance(s)) return type.cast(s);
        }
        return null;
    }

    /** Routes a parsed command to the appropriate handler on this device. */
    public final void applyCommand(Command cmd) { cmd.applyTo(this); }

    /** Routes a live slider metric update to all matching sliders on this device. */
    public final void applyMetric(SliderMetric metric, float value) {
        for (Slider s : sliders()) s.applyIfMatch(metric, value, this);
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
    public boolean requiresAdb() { return false; }

    /** Returns true if this device sends commands via the Android AccessibilityService. */
    public boolean requiresAccessibility() { return true; }

    /** Interprets a parsed QZ UDP packet and returns one Command per actionable field. */
    public abstract List<Command> decodeCommands(QZCommandPacket pkt);

    protected void swipe(int x, int y1, int y2) {
        String cmd = "input swipe " + x + " " + y1 + " " + x + " " + y2 + " " + SWIPE_DURATION_MS;
        logger.log("QZ:Device", "swipe -> " + cmd);
        if (GestureService.isConnected()) {
            GestureService.performSwipe(x, y1, x, y2, SWIPE_DURATION_MS);
        } else {
            logger.log("QZ:Device", "swipe dropped: AccessibilityService not connected");
        }
        commandExecutor.send(cmd);
    }
}
