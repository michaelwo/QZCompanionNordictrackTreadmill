package org.cagnulein.qzcompanionnordictracktreadmill;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.S15iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.S22iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill.X11iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.dispatch.CommandDispatcher;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 * Integration tests for CommandDispatcher.
 *
 * Each test exercises the full pipeline from a raw UDP message string through
 * decodeCommand, throttle/cache logic, and apply*, down to the final "input swipe"
 * shell command — using real device instances with a capturing CommandExecutor.
 *
 * Time is injected via a mutable long[] so throttle behaviour can be tested
 * without sleeping.
 */
public class CommandDispatcherTest {

    private String lastCommand;
    private final long[] time = {1_000L};

    private CommandDispatcher dispatcher() {
        return new CommandDispatcher(() -> time[0]);
    }

    /** Pre-populate a device's lastSnapshot so the treadmill speed gate passes. */
    private static void setMoving(Device device) {
        device.updateSnapshot(new MetricSnapshot.Builder().speedKmh(5.0f).build());
    }

    @Before
    public void reset() { lastCommand = null; }

    /** Wraps a device to capture its swipe commands into lastCommand. */
    private <T extends Device> T dev(T d) {
        d.commandExecutor = cmd -> lastCommand = cmd;
        return d;
    }


    // ── Treadmill: basic dispatch ─────────────────────────────────────────────

    @Test
    public void treadmill_speedAndIncline_appliesSpeedSwipe() {
        // X11i: speedX=1207, initialSpeedY=600, targetSpeedY(8.0)=(int)(621.997-174.28)=447
        X11iDevice device = dev(new X11iDevice());
        setMoving(device);
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;3.0", '.', device);
        assertEquals("input swipe 1207 600 1207 447 200", lastCommand);
    }

    @Test
    public void treadmill_speedAndIncline_inclineThrottledInSameDispatch() {
        // Speed is applied first, updating lastSwipeMs=now, so the incline check
        // (lastSwipeMs + 500 < now) is false in the same dispatch — incline is cached.
        int[] count = {0};
        X11iDevice device = new X11iDevice();
        device.commandExecutor = cmd -> { lastCommand = cmd; count[0]++; };
        setMoving(device);
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;3.0", '.', device);

        // Only one swipe (speed). Incline was cached.
        assertEquals(1, count[0]);
        assertTrue(lastCommand.contains("1207")); // speedX, not inclineX (75)
    }

    @Test
    public void treadmill_incline_appliedOnNextDispatchAfterThrottleWindow() {
        // Incline is cached on first dispatch (speed takes the throttle slot).
        // After the throttle window, a second dispatch applies the cached incline.
        // X11i: inclineX=75, initialInclineY=557, targetInclineY(3.0)=(int)(565.491-25.32)=540
        X11iDevice device = dev(new X11iDevice());
        setMoving(device);
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;3.0", '.', device); // speed applied, incline cached

        time[0] += Device.SWIPE_THROTTLE_MS + 100;
        d.dispatch("-1;-100", '.', device); // sentinels: flush cached incline
        assertEquals("input swipe 75 557 75 540 200", lastCommand);
    }

    @Test
    public void treadmill_speedGate_stopped_cachesSpeed() {
        // Speed must not be applied when current speed is 0 (device not yet running).
        // Use sentinel incline (-100) so that path also produces no command.
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;-100", '.', dev(new X11iDevice()));
        assertNull(lastCommand);
    }

    @Test
    public void treadmill_cachedSpeed_appliedWhenDeviceMovesAndWindowOpen() {
        // Speed cached while stopped. Once moving and throttle window passes, applies.
        X11iDevice device = dev(new X11iDevice());
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;-100", '.', device); // cached, no command (device stopped)
        assertNull(lastCommand);

        setMoving(device); // device now reports speed > 0
        time[0] += Device.SWIPE_THROTTLE_MS + 100;
        d.dispatch("-1;-100", '.', device); // flush cached 8.0
        assertEquals("input swipe 1207 600 1207 447 200", lastCommand);
    }

    @Test
    public void treadmill_throttle_secondMessageWithinWindowIsCached() {
        X11iDevice device = dev(new X11iDevice());
        setMoving(device);
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;3.0", '.', device); // applied at t=1000
        lastCommand = null;

        time[0] += 200; // still within 500 ms window
        d.dispatch("9.0;3.0", '.', device); // throttled — same device instance
        assertNull(lastCommand);
    }

    @Test
    public void treadmill_cachedSpeed_appliedAfterThrottleWindow() {
        // X11i targetSpeedY(9.0) = (int)(621.997 - 21.785*9.0) = (int)(425.932) = 425
        // Reuse the same device so initialSpeedY carries over correctly: 600→447 after first dispatch.
        X11iDevice device = dev(new X11iDevice());
        setMoving(device);
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;-100", '.', device); // speed 8.0 applied, y 600→447

        time[0] += 200;
        d.dispatch("9.0;-100", '.', device); // throttled → cached

        time[0] = 1000 + Device.SWIPE_THROTTLE_MS + 100;
        d.dispatch("-1;-100", '.', device); // flush cached 9.0, y 447→425
        assertEquals("input swipe 1207 447 1207 425 200", lastCommand);
    }

    @Test
    public void treadmill_sentinelMessage_noCommandGenerated() {
        CommandDispatcher d = dispatcher();
        d.dispatch("-1;-100", '.', dev(new X11iDevice()));
        assertNull(lastCommand);
    }

    @Test
    public void treadmill_commaLocale_parsesCorrectly() {
        X11iDevice device = dev(new X11iDevice());
        setMoving(device);
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;3.0", ',', device);
        assertEquals("input swipe 1207 600 1207 447 200", lastCommand);
    }

    // ── Bike: basic dispatch ──────────────────────────────────────────────────

    @Test
    public void bike_resistance_appliesResistanceSwipe() {
        // S15i: resistanceX=1848, initialResistanceY=790
        // targetResistanceY(10.0) = 790 - (int)(23.16*10) = 790 - 231 = 559
        CommandDispatcher d = dispatcher();
        d.dispatch("10.0", '.', dev(new S15iDevice()));
        assertEquals("input swipe 1848 790 1848 559 200", lastCommand);
    }

    @Test
    public void bike_incline_appliesInclineSwipe() {
        // S22i v>0: targetInclineY(5.0)=(int)(622-14.8*5.0)=548; initialY=622
        // Going up (toY<fromY): hysteresis overshoot = 548-15 = 533
        CommandDispatcher d = dispatcher();
        d.dispatch("5.0;0", '.', dev(new S22iDevice()));
        assertEquals("input swipe 75 622 75 533 200", lastCommand);
    }

    @Test
    public void bike_duplicateResistance_notReapplied() {
        S15iDevice device = dev(new S15iDevice());
        CommandDispatcher d = dispatcher();
        d.dispatch("10.0", '.', device); // applied
        lastCommand = null;

        time[0] += Device.SWIPE_THROTTLE_MS + 100;
        d.dispatch("10.0", '.', device); // same value — skipped
        assertNull(lastCommand);
    }

    @Test
    public void bike_throttle_cachesResistance() {
        S15iDevice device = dev(new S15iDevice());
        CommandDispatcher d = dispatcher();
        d.dispatch("10.0", '.', device); // applied at t=1000
        lastCommand = null;

        time[0] += 200; // within throttle window
        d.dispatch("12.0", '.', device); // cached
        assertNull(lastCommand);
    }

    @Test
    public void bike_throttledResistance_cachedAndAppliedAfterWindow() {
        // S15i targetResistanceY(12.0) = 790 - (int)(23.16*12) = 790 - 277 = 513
        S15iDevice device = dev(new S15iDevice());
        CommandDispatcher d = dispatcher();
        d.dispatch("10.0", '.', device); // applied at t=1000

        time[0] += 200;
        lastCommand = null;
        d.dispatch("12.0", '.', device); // throttled → cached
        assertNull(lastCommand);

        time[0] = 1000 + Device.SWIPE_THROTTLE_MS + 100;
        d.dispatch("-1", '.', device); // sentinel: flush cached 12.0
        assertEquals("input swipe 1848 790 1848 513 200", lastCommand);
    }

    @Test
    public void bike_sentinelResistance_noCommandGenerated() {
        CommandDispatcher d = dispatcher();
        d.dispatch("-1", '.', dev(new S15iDevice()));
        assertNull(lastCommand);
    }
}
