package org.cagnulein.qzcompanionnordictracktreadmill.dispatch;

import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

/**
 * Parses a raw UDP message and dispatches the resulting command to the active device.
 * Encapsulates the throttle and caching logic that was previously inline in UDPListenerService.
 *
 * De-duplication state (lastAppliedIncline, lastAppliedResistance) lives on the Device
 * subclasses where it belongs — this class is a thin routing and throttle layer.
 *
 * Extracted as a plain Java class so it can be tested without Android dependencies.
 * UDPListenerService creates one instance at startup and calls dispatch() per message.
 */
public class CommandDispatcher {

    public static final int SWIPE_THROTTLE_MS = 500;

    /** Injectable clock — defaults to wall time; replaced with a fixed value in tests. */
    public interface Clock { long now(); }

    /** Injectable logger — defaults to no-op; replaced with writeLog in production. */
    public interface Log { void write(String message); }

    private final Clock clock;
    private final Log   log;

    /** Holds values that arrived during a throttle window — flushed on the next dispatch. */
    private final MetricSnapshot cached = new MetricSnapshot();

    /** Production constructor: wall clock, silent logger. */
    public CommandDispatcher() {
        this(System::currentTimeMillis, msg -> {});
    }

    /** Production constructor with logging: wall clock, caller-supplied logger. */
    public CommandDispatcher(Log log) {
        this(System::currentTimeMillis, log);
    }

    /** Full constructor — used in tests to inject a controllable clock. */
    public CommandDispatcher(Clock clock, Log log) {
        this.clock = clock;
        this.log   = log;
    }

    /**
     * Parses {@code message}, applies the resulting command to {@code device},
     * honouring the 500 ms swipe-throttle and the inter-dispatch cache.
     *
     * @param message          raw semicolon-delimited UDP string
     * @param decimalSeparator locale decimal separator for numeric parsing
     * @param device           the currently active device
     * @param current          latest observed metrics snapshot (for swipe-origin calculation)
     */
    public void dispatch(String message, char decimalSeparator, Device device, MetricSnapshot current) {
        String[] parts = message.split(";");
        long now = clock.now();
        MetricSnapshot cmd = device.parseCommand(parts, decimalSeparator);

        if (device instanceof BikeDevice) {
            BikeDevice bike = (BikeDevice) device;

            // incline (2-part message)
            Float incline = cmd.inclinePct != null ? cmd.inclinePct : cached.inclinePct;
            if (incline != null) {
                float quantized = bike.quantizeIncline(incline);
                log.write("requestIncline(bike): " + incline + " quantized=" + quantized + " last=" + bike.lastAppliedIncline());
                if (bike.lastCommandMs + SWIPE_THROTTLE_MS < now) {
                    if (quantized != bike.lastAppliedIncline()) {
                        bike.applyIncline(quantized, current);
                        log.write("applyIncline(bike): " + quantized);
                        bike.lastCommandMs = now;
                        cached.inclinePct = null;
                    } else {
                        log.write("de-dup: skipping incline " + incline + " (quantized=" + quantized + " already at " + bike.lastAppliedIncline() + ")");
                    }
                } else {
                    log.write("throttle: cached incline " + incline + " (window open in " + (bike.lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                    cached.inclinePct = incline;
                }
            }

            // resistance (1-part message)
            Float resistance = cmd.resistanceLvl != null ? cmd.resistanceLvl : cached.resistanceLvl;
            if (resistance != null) {
                log.write("requestResistance(bike): " + resistance + " last=" + bike.lastAppliedResistance());
                if (bike.lastCommandMs + SWIPE_THROTTLE_MS < now) {
                    if (!resistance.equals(bike.lastAppliedResistance())) {
                        bike.applyResistance(resistance, current);
                        log.write("applyResistance(bike): " + resistance);
                        bike.lastCommandMs = now;
                        cached.resistanceLvl = null;
                    } else {
                        log.write("de-dup: skipping resistance " + resistance + " (already at " + bike.lastAppliedResistance() + ")");
                    }
                } else {
                    log.write("throttle: cached resistance " + resistance + " (window open in " + (bike.lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                }
            }

        } else if (device instanceof TreadmillDevice) {
            TreadmillDevice treadmill = (TreadmillDevice) device;

            // speed (2-part message, first field)
            Float speed = cmd.speedKmh != null ? cmd.speedKmh : cached.speedKmh;
            if (speed != null) {
                log.write("requestSpeed: " + speed + " lastSpeed=" + current.speed() + " cachedSpeed=" + cached.speedKmh);
                if (treadmill.lastCommandMs + SWIPE_THROTTLE_MS < now && current.speed() > 0) {
                    treadmill.applySpeed(speed, current);
                    log.write("applySpeed: " + speed);
                    treadmill.lastCommandMs = now;
                    cached.speedKmh = null;
                } else {
                    if (current.speed() <= 0) {
                        log.write("speed gate: cached " + speed + " (treadmill stopped, speed=" + current.speed() + ")");
                    } else {
                        log.write("throttle: cached speed " + speed + " (window open in " + (treadmill.lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                    }
                    cached.speedKmh = speed;
                }
            }

            // incline (2-part message, second field)
            Float incline = cmd.inclinePct != null ? cmd.inclinePct : cached.inclinePct;
            if (incline != null) {
                log.write("requestInclination: " + incline + " cached=" + cached.inclinePct);
                if (treadmill.lastCommandMs + SWIPE_THROTTLE_MS < now) {
                    treadmill.applyIncline(incline, current);
                    log.write("applyIncline: " + incline);
                    treadmill.lastCommandMs = now;
                    cached.inclinePct = null;
                } else {
                    log.write("throttle: cached incline " + incline + " (window open in " + (treadmill.lastCommandMs + SWIPE_THROTTLE_MS - now) + "ms)");
                    cached.inclinePct = incline;
                }
            }
        }
    }
}
