package org.cagnulein.qzcompanionnordictracktreadmill.dispatch;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;

/**
 * Parses a raw UDP message and dispatches the resulting command to the active device.
 *
 * Throttle, cache, and de-dup logic lives on the Device subclasses (BikeDevice,
 * TreadmillDevice) via applyCommand() — this class only splits the message, reads
 * the clock, and routes.
 *
 * Extracted as a plain Java class so it can be tested without Android dependencies.
 * UDPListenerService creates one instance at startup and calls dispatch() per message.
 */
public class CommandDispatcher {

    /** Injectable clock — defaults to wall time; replaced with a fixed value in tests. */
    public interface Clock { long now(); }

    private final Clock clock;

    /** Production constructor: wall clock. */
    public CommandDispatcher() {
        this(System::currentTimeMillis);
    }

    /** Full constructor — used in tests to inject a controllable clock. */
    public CommandDispatcher(Clock clock) {
        this.clock = clock;
    }

    /**
     * Parses {@code message} and dispatches to {@code device.applyCommand()}.
     *
     * @param message          raw semicolon-delimited UDP string
     * @param decimalSeparator locale decimal separator for numeric parsing
     * @param device           the currently active device
     */
    public void dispatch(String message, char decimalSeparator, Device device) {
        String[] parts = message.split(";");
        long now = clock.now();
        Command cmd = device.decodeCommand(parts, decimalSeparator);
        device.applyCommand(cmd, now);
    }
}
