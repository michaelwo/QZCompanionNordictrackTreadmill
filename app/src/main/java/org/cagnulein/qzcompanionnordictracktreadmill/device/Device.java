package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.slider.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.telemetry.Telemetry;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;

import java.util.List;

public abstract class Device {
    /** All sliders on this device, in declaration order. Used for metric routing and command dispatch. */
    public abstract List<Slider> sliders();

    /** Returns the first slider of the given type, or null if none. */
    public final <S extends Slider> S sliderOf(Class<S> type) {
        for (Slider s : sliders()) {
            if (type.isInstance(s)) return type.cast(s);
        }
        return null;
    }

    /** Routes a live telemetry update to all matching sliders on this device. */
    public final void applyTelemetry(Telemetry telemetry) {
        for (Slider s : sliders()) s.applyTelemetry(telemetry, this);
    }

    /** Functional interface so the executor can be set without Android imports. */
    public interface CommandExecutor { void send(String command); }

    /** Executes shell commands on this device. No-op by default; set by MainActivity. */
    public CommandExecutor commandExecutor = command -> {};

    /** Functional interface for log output. Level constants match android.util.Log values. */
    public interface Logger {
        int VERBOSE = 2;
        int DEBUG   = 3;
        int INFO    = 4;
        int WARN    = 5;
        int ERROR   = 6;
        void log(int level, String tag, String msg);
    }

    /** Logger for this device. No-op by default; set by MainActivity. */
    public Logger logger = (level, tag, msg) -> {};

    public abstract String displayName();

    /** Interprets a parsed QZ UDP packet and returns one Command per actionable field. */
    public abstract List<Command> decodeCommands(QZCommandPacket pkt);

    /** Returns a log label for confirmed telemetry this device handles, or null to suppress logging. */
    public String telemetryLabel(Telemetry t) { return null; }
}
