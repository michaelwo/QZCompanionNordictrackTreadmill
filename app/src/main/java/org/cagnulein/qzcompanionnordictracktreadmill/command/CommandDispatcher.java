package org.cagnulein.qzcompanionnordictracktreadmill.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;

import java.util.ArrayDeque;
import java.util.List;

/**
 * Parses raw UDP messages, throttles delivery, and dispatches commands to the active device.
 *
 * Each incoming message is decoded into one Command per actionable field (e.g. a treadmill
 * message "8.0;3.0" yields [speedCmd, inclineCmd]).  All decoded Commands are enqueued, then
 * one is drained per open throttle window — oldest first.  Commands arriving when the queue
 * is full are silently dropped.
 *
 * When the window opens and the queue is empty (e.g. a sentinel message), applyCommand() is
 * still called with an all-null Command so TreadmillDevice's belt-gate flush fires if needed.
 *
 * <h3>Passive drain design</h3>
 * The queue drains only when dispatch() is called — there is no background timer or drain
 * thread.  This is intentional: Zwift sends UDP packets continuously during a ride (~1 per
 * second), so any burst-induced backlog clears itself within a few seconds as incoming packets
 * each trigger one drain tick.  At ride end, Zwift floods "-1;-100" sentinel packets; these
 * decode to an empty list (no new Commands enqueued) but still trigger the drain check, acting
 * as a free flush pulse — one queued Command per sentinel.  The queue cap of QUEUE_CAPACITY
 * bounds worst-case stale Commands to a small, finite number that survive until the next
 * incoming packet.
 *
 * Device subclasses via applyCommand() are pure executors — no throttle logic there.
 *
 * Extracted as a plain Java class so it can be tested without Android dependencies.
 * CommandListenerService creates one instance at startup and calls dispatch() per message.
 */
public class CommandDispatcher {

    /** Minimum gap between successive command executions, in ms. */
    public static final int SWIPE_THROTTLE_MS = 500;

    /** Maximum number of pending Commands held while the throttle window is closed. */
    static final int QUEUE_CAPACITY = 5;

    /** Injectable clock — defaults to wall time; replaced with a fixed value in tests. */
    public interface Clock { long now(); }

    private final Clock clock;

    private static final class Pending {
        final Command command;
        final Device  device;
        Pending(Command c, Device d) { command = c; device = d; }
    }

    private final ArrayDeque<Pending> queue = new ArrayDeque<>();
    private long lastExecutedMs = 0;

    /** Production constructor: wall clock. */
    public CommandDispatcher() {
        this(System::currentTimeMillis);
    }

    /** Full constructor — used in tests to inject a controllable clock. */
    public CommandDispatcher(Clock clock) {
        this.clock = clock;
    }

    /**
     * Decodes {@code message} into atomic Commands, enqueues all of them, then drains
     * and executes the oldest queued Command if the throttle window is open.
     *
     * @param message raw semicolon-delimited UDP string
     * @param device  the currently active device
     */
    public void dispatch(String message, Device device) {
        long now = clock.now();
        QZCommandPacket pkt = QZCommandPacket.parse(message);
        List<Command> incoming = device.decodeCommands(pkt);

        for (Command cmd : incoming) {
            if (queue.size() < QUEUE_CAPACITY) {
                queue.offer(new Pending(cmd, device));
                device.logger.log("QZ:Dispatcher",
                        "enqueue: " + cmd + " depth=" + queue.size() + "/" + QUEUE_CAPACITY);
            } else {
                device.logger.log("QZ:Dispatcher",
                        "drop: " + cmd + " (queue full at " + QUEUE_CAPACITY + ")");
            }
        }

        if (now >= lastExecutedMs + SWIPE_THROTTLE_MS) {
            Pending next = queue.poll();
            if (next != null) {
                next.device.logger.log("QZ:Dispatcher",
                        "drain: " + next.command + " depth=" + queue.size() + "/" + QUEUE_CAPACITY);
                execute(next.command, next.device, now);
            } else {
                // Empty queue — still call applyCommand so TreadmillDevice's belt-gate flush fires.
                device.logger.log("QZ:Dispatcher", "flush (empty)");
                device.applyCommand(new Command());
                lastExecutedMs = now;
            }
        }
    }

    private void execute(Command cmd, Device device, long now) {
        device.applyCommand(cmd);
        lastExecutedMs = now;
    }
}
