package org.cagnulein.qzcompanionnordictracktreadmill;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.S15iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.S22iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.X11iDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.dispatch.CommandDispatcher;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 * Integration tests for CommandDispatcher.
 *
 * Each test exercises the full pipeline from a raw UDP message string through
 * parseCommand, throttle/cache logic, and apply*, down to the final "input swipe"
 * shell command — using real device instances with a capturing CommandExecutor.
 *
 * Time is injected via a mutable long[] so throttle behaviour can be tested
 * without sleeping.
 */
public class CommandDispatcherTest {

    private String lastCommand;
    private final long[] time = {1_000L};

    private CommandDispatcher dispatcher() {
        return new CommandDispatcher(() -> time[0], msg -> {});
    }

    /** Running snapshot: device is in motion at 5 km/h. */
    private static MetricSnapshot moving() {
        return new MetricSnapshot.Builder().speedKmh(5.0f).build();
    }

    /** Running snapshot: device is stopped. */
    private static MetricSnapshot stopped() {
        return new MetricSnapshot();
    }

    @Before
    public void installCaptureExecutor() {
        lastCommand = null;
        Device.commandExecutor = cmd -> lastCommand = cmd;
    }

    @After
    public void restoreDefaultExecutor() {
        Device.commandExecutor = cmd -> {};
    }

    // ── Treadmill: basic dispatch ─────────────────────────────────────────────

    @Test
    public void treadmill_speedAndIncline_appliesSpeedSwipe() {
        // X11i: speedX=1207, initialSpeedY=600, targetSpeedY(8.0)=(int)(621.997-174.28)=447
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;3.0", '.', new X11iDevice(), moving());
        assertEquals("input swipe 1207 600 1207 447 200", lastCommand);
    }

    @Test
    public void treadmill_speedAndIncline_inclineThrottledInSameDispatch() {
        // Speed is applied first, updating lastSwipeMs=now, so the incline check
        // (lastSwipeMs + 500 < now) is false in the same dispatch — incline is cached.
        int[] count = {0};
        Device.commandExecutor = cmd -> { lastCommand = cmd; count[0]++; };

        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;3.0", '.', new X11iDevice(), moving());

        // Only one swipe (speed). Incline was cached.
        assertEquals(1, count[0]);
        assertTrue(lastCommand.contains("1207")); // speedX, not inclineX (75)
    }

    @Test
    public void treadmill_incline_appliedOnNextDispatchAfterThrottleWindow() {
        // Incline is cached on first dispatch (speed takes the throttle slot).
        // After the throttle window, a second dispatch applies the cached incline.
        // X11i: inclineX=75, initialInclineY=557, targetInclineY(3.0)=(int)(565.491-25.32)=540
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;3.0", '.', new X11iDevice(), moving()); // speed applied, incline cached

        time[0] += CommandDispatcher.SWIPE_THROTTLE_MS + 100;
        d.dispatch("-1;-100", '.', new X11iDevice(), moving()); // sentinels: flush cached incline
        assertEquals("input swipe 75 557 75 540 200", lastCommand);
    }

    @Test
    public void treadmill_speedGate_stopped_cachesSpeed() {
        // Speed must not be applied when current speed is 0 (device not yet running).
        // Use sentinel incline (-100) so that path also produces no command.
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;-100", '.', new X11iDevice(), stopped());
        assertNull(lastCommand);
    }

    @Test
    public void treadmill_cachedSpeed_appliedWhenDeviceMovesAndWindowOpen() {
        // Speed cached while stopped. Once moving and throttle window passes, applies.
        X11iDevice device = new X11iDevice();
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;-100", '.', device, stopped()); // cached, no command
        assertNull(lastCommand);

        time[0] += CommandDispatcher.SWIPE_THROTTLE_MS + 100;
        d.dispatch("-1;-100", '.', device, moving()); // flush cached 8.0
        assertEquals("input swipe 1207 600 1207 447 200", lastCommand);
    }

    @Test
    public void treadmill_throttle_secondMessageWithinWindowIsCached() {
        X11iDevice device = new X11iDevice();
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;3.0", '.', device, moving()); // applied at t=1000
        lastCommand = null;

        time[0] += 200; // still within 500 ms window
        d.dispatch("9.0;3.0", '.', device, moving()); // throttled — same device instance
        assertNull(lastCommand);
    }

    @Test
    public void treadmill_cachedSpeed_appliedAfterThrottleWindow() {
        // X11i targetSpeedY(9.0) = (int)(621.997 - 21.785*9.0) = (int)(425.932) = 425
        // Reuse the same device so initialSpeedY carries over correctly: 600→447 after first dispatch.
        X11iDevice device = new X11iDevice();
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;-100", '.', device, moving()); // speed 8.0 applied, y 600→447

        time[0] += 200;
        d.dispatch("9.0;-100", '.', device, moving()); // throttled → cached

        time[0] = 1000 + CommandDispatcher.SWIPE_THROTTLE_MS + 100;
        d.dispatch("-1;-100", '.', device, moving()); // flush cached 9.0, y 447→425
        assertEquals("input swipe 1207 447 1207 425 200", lastCommand);
    }

    @Test
    public void treadmill_sentinelMessage_noCommandGenerated() {
        CommandDispatcher d = dispatcher();
        d.dispatch("-1;-100", '.', new X11iDevice(), moving());
        assertNull(lastCommand);
    }

    @Test
    public void treadmill_commaLocale_parsesCorrectly() {
        CommandDispatcher d = dispatcher();
        d.dispatch("8.0;3.0", ',', new X11iDevice(), moving());
        assertEquals("input swipe 1207 600 1207 447 200", lastCommand);
    }

    // ── Bike: basic dispatch ──────────────────────────────────────────────────

    @Test
    public void bike_resistance_appliesResistanceSwipe() {
        // S15i: resistanceX=1848, initialResistanceY=790
        // targetResistanceY(10.0) = 790 - (int)(23.16*10) = 790 - 231 = 559
        CommandDispatcher d = dispatcher();
        d.dispatch("10.0", '.', new S15iDevice(), stopped());
        assertEquals("input swipe 1848 790 1848 559 200", lastCommand);
    }

    @Test
    public void bike_incline_appliesInclineSwipe() {
        // S22i grade>3: overshoot+0.5 → targetInclineY(5.0)=(int)(616.18-17.223*5.5)=521
        CommandDispatcher d = dispatcher();
        d.dispatch("5.0;0", '.', new S22iDevice(), stopped());
        assertEquals("input swipe 75 618 75 521 200", lastCommand);
    }

    @Test
    public void bike_duplicateResistance_notReapplied() {
        S15iDevice device = new S15iDevice();
        CommandDispatcher d = dispatcher();
        d.dispatch("10.0", '.', device, stopped()); // applied
        lastCommand = null;

        time[0] += CommandDispatcher.SWIPE_THROTTLE_MS + 100;
        d.dispatch("10.0", '.', device, stopped()); // same value — skipped
        assertNull(lastCommand);
    }

    @Test
    public void bike_throttle_cachesResistance() {
        S15iDevice device = new S15iDevice();
        CommandDispatcher d = dispatcher();
        d.dispatch("10.0", '.', device, stopped()); // applied at t=1000
        lastCommand = null;

        time[0] += 200; // within throttle window
        d.dispatch("12.0", '.', device, stopped()); // cached
        assertNull(lastCommand);
    }

    @Test
    public void bike_resistance_appliedDirectlyAfterThrottleWindow() {
        // Resistance has no cache-flush path: a throttled value is dropped.
        // A new value sent after the window opens IS applied directly.
        // S15i targetResistanceY(12.0) = 790 - (int)(23.16*12) = 790 - 277 = 513
        S15iDevice device = new S15iDevice();
        CommandDispatcher d = dispatcher();
        d.dispatch("10.0", '.', device, stopped()); // applied at t=1000

        time[0] += 200;
        lastCommand = null;
        d.dispatch("12.0", '.', device, stopped()); // throttled — dropped
        assertNull(lastCommand);  // nothing was applied

        time[0] = 1000 + CommandDispatcher.SWIPE_THROTTLE_MS + 100;
        d.dispatch("12.0", '.', device, stopped()); // sent again after window — applied
        assertEquals("input swipe 1848 790 1848 513 200", lastCommand);
    }

    @Test
    public void bike_sentinelResistance_noCommandGenerated() {
        CommandDispatcher d = dispatcher();
        d.dispatch("-1", '.', new S15iDevice(), stopped());
        assertNull(lastCommand);
    }
}
