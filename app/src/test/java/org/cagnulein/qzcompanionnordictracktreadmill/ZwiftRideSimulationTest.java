package org.cagnulein.qzcompanionnordictracktreadmill;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.List;

/**
 * End-to-end simulation of a Zwift ride session against an S22i bike.
 *
 * Tests exercise the full pipeline without UDP sockets:
 *   grade message → CommandDispatcher.dispatch() → S22iDevice.applyIncline()
 *   → Device.swipe() → Device.commandExecutor (captured)
 *
 * Time is injected so throttle behavior is controlled without sleeping.
 * All assertions verify both the swipe command format and the y1→y2 chain
 * (confirming that state tracking is correct across calls).
 *
 * S22i formula: x=75, y2 = (int)(616.18 - 17.223 * (grade > 3.0 ? grade + 0.5 : grade))
 * Grades ≤ 3% use the raw value; above 3% a +0.5 overshoot corrects iFit's 0.5% snap rounding.
 *   grade 0%  → y2=616   (initial y1=618)
 *   grade 3%  → y2=564
 *   grade 5%  → y2=521   (sent as 5.5)
 *   grade 8%  → y2=469   (sent as 8.5)
 *   grade 10% → y2=435   (sent as 10.5)
 *
 * Run via run-tests.sh (pure JVM, no Android SDK required).
 */
public class ZwiftRideSimulationTest {

    private final List<String> commands = new ArrayList<>();
    private final long[] time = {1_000L};

    private CommandDispatcher dispatcher() {
        return new CommandDispatcher(() -> time[0], msg -> {});
    }

    @Before
    public void setup() {
        commands.clear();
        Device.commandExecutor = cmd -> commands.add(cmd);
    }

    @After
    public void restore() {
        Device.commandExecutor = cmd -> {};
    }

    /** Advances time by ms and dispatches one Zwift grade message (2-part format). */
    private void send(CommandDispatcher d, S22iDevice bike, float grade, long advanceMs) {
        time[0] += advanceMs;
        d.dispatch(grade + ";0", '.', bike, new MetricSnapshot());
    }

    // ── helper: expected swipe string ────────────────────────────────────────

    private static String swipe(int y1, int y2) {
        return "input swipe 75 " + y1 + " 75 " + y2 + " 200";
    }

    /** S22i target y for a given grade percentage, matching the snap-corrected formula. */
    private static int targetY(float grade) {
        return (int) (616.18 - 17.223 * (grade > 3.0f ? grade + 0.5f : grade));
    }

    // ── test 1: full Zwift ride — correct swipe chain ─────────────────────────

    /**
     * Verifies that five grade changes produce five swipes with the correct
     * y1→y2 chain.  y1 of each swipe must equal y2 of the previous — confirming
     * that state tracking is working correctly.
     */
    @Test
    public void fullRide_fiveGradeChanges_correctSwipeChain() {
        CommandDispatcher d = dispatcher();
        S22iDevice bike = new S22iDevice();

        float[] grades = {0f, 5f, 10f, 5f, 0f};
        for (float g : grades) {
            send(d, bike, g, 600);  // 600ms > 500ms throttle
        }

        assertEquals("expected 5 swipes for 5 grade changes", 5, commands.size());

        // Verify each swipe's y1 matches the previous swipe's y2
        int y1 = 618;  // initial position
        for (int i = 0; i < grades.length; i++) {
            int y2 = targetY(grades[i]);
            assertEquals("swipe " + i + " (grade " + grades[i] + "%)", swipe(y1, y2), commands.get(i));
            y1 = y2;
        }
    }

    // ── test 2: throttle — rapid messages cache last value ────────────────────

    /**
     * Three grade changes fired within the 500ms throttle window:
     * only the first should fire immediately; the last cached value fires
     * when the next message arrives after the window opens.
     */
    @Test
    public void throttle_rapidMessages_onlyFirstAndCachedFire() {
        CommandDispatcher d = dispatcher();
        S22iDevice bike = new S22iDevice();

        // All three within the 500ms window: t=1100, t=1200, t=1300
        send(d, bike, 5f,  100);  // fires (window fresh)
        send(d, bike, 8f,  100);  // throttled, cached
        send(d, bike, 10f, 100);  // throttled, overwrites cache

        // First message fires immediately
        assertEquals(1, commands.size());
        assertEquals(swipe(618, targetY(5f)), commands.get(0));

        // Advance past throttle window and send another message
        send(d, bike, 10f, 600);  // t=1900, window open — fires (10f != 5f)

        assertEquals(2, commands.size());
        assertEquals(swipe(targetY(5f), targetY(10f)), commands.get(1));
    }

    // ── test 3: de-dup — same grade twice produces only one swipe ─────────────

    @Test
    public void dedup_sameGradeTwice_onlyFirstSwipeFires() {
        CommandDispatcher d = dispatcher();
        S22iDevice bike = new S22iDevice();

        send(d, bike, 7f, 600);  // fires
        send(d, bike, 7f, 600);  // de-dup: same as last, skipped

        assertEquals(1, commands.size());
        assertEquals(swipe(618, targetY(7f)), commands.get(0));
    }

    // ── test 4: sentinel flood — no swipes ────────────────────────────────────

    /**
     * Zwift sends "-1;-100" as a sentinel when the connection drops or no
     * grade data is available.  These must never trigger a swipe.
     */
    @Test
    public void sentinelFlood_noSwipesFire() {
        CommandDispatcher d = dispatcher();
        S22iDevice bike = new S22iDevice();

        for (int i = 0; i < 20; i++) {
            time[0] += 600;
            d.dispatch("-1;-100", '.', bike, new MetricSnapshot());
        }

        assertTrue("no swipes expected for 20 sentinel messages", commands.isEmpty());
    }

    // ── test 5: decimal separator variants produce identical swipes ───────────

    @Test
    public void decimalSeparator_commaAndDot_identicalSwipes() {
        CommandDispatcher dotDispatcher   = new CommandDispatcher(() -> time[0], msg -> {});
        CommandDispatcher commaDispatcher = new CommandDispatcher(() -> time[0] + 1, msg -> {});

        S22iDevice bikeDot   = new S22iDevice();
        S22iDevice bikeComma = new S22iDevice();

        List<String> dotCmds   = new ArrayList<>();
        List<String> commaCmds = new ArrayList<>();

        Device.commandExecutor = cmd -> dotCmds.add(cmd);
        time[0] += 600;
        dotDispatcher.dispatch("5.0;0", '.', bikeDot, new MetricSnapshot());

        Device.commandExecutor = cmd -> commaCmds.add(cmd);
        commaDispatcher.dispatch("5,0;0", ',', bikeComma, new MetricSnapshot());

        assertEquals(1, dotCmds.size());
        assertEquals(1, commaCmds.size());
        assertEquals("comma and dot separators must produce the same swipe",
                dotCmds.get(0), commaCmds.get(0));
    }

    // ── test 6: alpe du zwift profile — realistic climb ───────────────────────

    /**
     * Simulates the Alpe du Zwift climb profile (simplified): rising grades,
     * a plateau, then a descent.  Verifies that each swipe in the sequence
     * chains correctly and that the final flat position is reached.
     */
    @Test
    public void alpeProfile_climbAndDescent_correctSequence() {
        CommandDispatcher d = dispatcher();
        S22iDevice bike = new S22iDevice();

        float[] profile = {2f, 5f, 8f, 10f, 8f, 5f, 2f, 0f};
        for (float g : profile) {
            send(d, bike, g, 600);
        }

        assertEquals(profile.length, commands.size());

        int y1 = 618;
        for (int i = 0; i < profile.length; i++) {
            int y2 = targetY(profile[i]);
            assertEquals("step " + i + " (grade " + profile[i] + "%)",
                    swipe(y1, y2), commands.get(i));
            y1 = y2;
        }

        // After the descent, we should be near flat (y ≈ 616)
        int finalY = targetY(0f);
        assertEquals("final position should be flat", 616, finalY);
        assertEquals(swipe(targetY(2f), finalY), commands.get(commands.size() - 1));
    }
}
