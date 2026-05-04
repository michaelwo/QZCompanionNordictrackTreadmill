package org.cagnulein.qzcompanionnordictracktreadmill.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;

import java.util.ArrayDeque;
import java.util.List;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;

/**
 * Parses raw UDP messages, throttles delivery, and dispatches commands to the active device.
 *
 * Each incoming message is decoded into one Command per actionable field (e.g. a treadmill
 * message "8.0;3.0" yields [speedCmd, inclineCmd]).  All decoded Commands are enqueued, then
 * one is drained per open throttle window — oldest first.  Commands arriving when the queue
 * is full are silently dropped.
 *
 * <h3>Active drain</h3>
 * A background {@link ScheduledExecutorService} fires every {@code SWIPE_THROTTLE_MS} and
 * calls {@link #tryDrain}, independent of incoming packets.  {@link #dispatch} also calls
 * {@code tryDrain} immediately when the window is open.  Both paths synchronize on {@code this}
 * to prevent double-drain.  The test constructor takes an injectable {@link Clock} and starts
 * no background thread — tests remain fully deterministic.
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
    private final ScheduledExecutorService scheduler;

    private static final class Pending {
        final Command command;
        final Device  device;
        Pending(Command c, Device d) { command = c; device = d; }
    }

    private final ArrayDeque<Pending> queue = new ArrayDeque<>();
    private long lastExecutedMs = 0;

    /** Production constructor: wall clock + background drain thread. */
    public CommandDispatcher() {
        this.clock = System::currentTimeMillis;
        scheduler = Executors.newSingleThreadScheduledExecutor(r -> {
            Thread t = new Thread(r, "QZ:DrainThread");
            t.setDaemon(true);
            return t;
        });
        scheduler.scheduleAtFixedRate(
                () -> tryDrain(clock.now()),
                SWIPE_THROTTLE_MS, SWIPE_THROTTLE_MS, TimeUnit.MILLISECONDS);
    }

    /** Test constructor: injectable clock, no background thread. */
    public CommandDispatcher(Clock clock) {
        this.clock = clock;
        this.scheduler = null;
    }

    /** Stops the background drain thread. Call from CommandListenerService.onDestroy(). */
    public void shutdown() {
        if (scheduler != null) scheduler.shutdownNow();
    }

    /**
     * Decodes {@code message} into atomic Commands, enqueues all of them, then attempts
     * an immediate drain if the throttle window is open.
     *
     * @param message raw semicolon-delimited UDP string
     * @param device  the currently active device
     */
    public void dispatch(String message, Device device) {
        long now = clock.now();
        QZCommandPacket pkt = QZCommandPacket.parse(message);
        List<Command> incoming = device.decodeCommands(pkt);

        synchronized (this) {
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
        }
        tryDrain(now);
    }

    private void tryDrain(long now) {
        Pending next;
        int remaining;
        synchronized (this) {
            if (now < lastExecutedMs + SWIPE_THROTTLE_MS) return;
            next = queue.poll();
            if (next == null) return;
            remaining = queue.size();
            lastExecutedMs = now;
        }
        next.device.logger.log("QZ:Dispatcher",
                "drain: " + next.command + " depth=" + remaining + "/" + QUEUE_CAPACITY);
        next.device.applyCommand(next.command);
    }
}
