package org.cagnulein.qzcompanionnordictracktreadmill.dispatch;

import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

/**
 * Parses a raw UDP message and dispatches the resulting command to the active device.
 * Encapsulates the throttle, caching, and de-duplication logic that was previously
 * inline in UDPListenerService.
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

    private final MetricSnapshot cached        = new MetricSnapshot();
    private final MetricSnapshot lastRequested = new MetricSnapshot();
    private float lastAppliedIncline = Float.MAX_VALUE;  // last quantized incline sent to bike
    private long lastSwipeMs = 0;

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
                // Ask the device to quantize to its physical snap grid (e.g. 0.5% for S22i).
                // Other devices return the value unchanged.
                float quantized = bike.quantizeIncline(incline);
                log.write("requestIncline(bike): " + incline + " quantized=" + quantized + " last=" + lastAppliedIncline);
                if (lastSwipeMs + SWIPE_THROTTLE_MS < now) {
                    if (quantized != lastAppliedIncline) {
                        bike.applyIncline(quantized, current);
                        log.write("applyIncline(bike): " + quantized);
                        lastAppliedIncline = quantized;
                        lastSwipeMs = now;
                        cached.inclinePct = null;
                    } else {
                        log.write("de-dup: skipping incline " + incline + " (quantized=" + quantized + " already at " + lastAppliedIncline + ")");
                    }
                } else {
                    log.write("throttle: cached incline " + incline + " (window open in " + (lastSwipeMs + SWIPE_THROTTLE_MS - now) + "ms)");
                    cached.inclinePct = incline;
                }
            }

            // resistance (1-part message)
            Float resistance = cmd.resistanceLvl != null ? cmd.resistanceLvl : cached.resistanceLvl;
            if (resistance != null) {
                log.write("requestResistance(bike): " + resistance + " last=" + lastRequested.resistanceLvl);
                if (lastSwipeMs + SWIPE_THROTTLE_MS < now) {
                    if (!resistance.equals(lastRequested.resistanceLvl)) {
                        bike.applyResistance(resistance, current);
                        log.write("applyResistance(bike): " + resistance);
                        lastRequested.resistanceLvl = resistance;
                        lastSwipeMs = now;
                        cached.resistanceLvl = null;
                    } else {
                        log.write("de-dup: skipping resistance " + resistance + " (already at " + lastRequested.resistanceLvl + ")");
                    }
                } else {
                    log.write("throttle: cached resistance " + resistance + " (window open in " + (lastSwipeMs + SWIPE_THROTTLE_MS - now) + "ms)");
                }
            }

        } else if (device instanceof TreadmillDevice) {
            TreadmillDevice treadmill = (TreadmillDevice) device;

            // speed (2-part message, first field)
            Float speed = cmd.speedKmh != null ? cmd.speedKmh : cached.speedKmh;
            if (speed != null) {
                log.write("requestSpeed: " + speed + " lastSpeed=" + current.speed() + " cachedSpeed=" + cached.speedKmh);
                if (lastSwipeMs + SWIPE_THROTTLE_MS < now && current.speed() > 0) {
                    treadmill.applySpeed(speed, current);
                    log.write("applySpeed: " + speed);
                    lastSwipeMs = now;
                    cached.speedKmh = null;
                } else {
                    if (current.speed() <= 0) {
                        log.write("speed gate: cached " + speed + " (treadmill stopped, speed=" + current.speed() + ")");
                    } else {
                        log.write("throttle: cached speed " + speed + " (window open in " + (lastSwipeMs + SWIPE_THROTTLE_MS - now) + "ms)");
                    }
                    cached.speedKmh = speed;
                }
            }

            // incline (2-part message, second field)
            Float incline = cmd.inclinePct != null ? cmd.inclinePct : cached.inclinePct;
            if (incline != null) {
                log.write("requestInclination: " + incline + " cached=" + cached.inclinePct);
                if (lastSwipeMs + SWIPE_THROTTLE_MS < now) {
                    treadmill.applyIncline(incline, current);
                    log.write("applyIncline: " + incline);
                    lastSwipeMs = now;
                    cached.inclinePct = null;
                } else {
                    log.write("throttle: cached incline " + incline + " (window open in " + (lastSwipeMs + SWIPE_THROTTLE_MS - now) + "ms)");
                    cached.inclinePct = incline;
                }
            }
        }
    }
}
