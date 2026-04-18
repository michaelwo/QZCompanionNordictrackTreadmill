package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.catalog.S22iDevice;
import org.junit.Test;
import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * End-to-end replay of the Zwift Hilly Route (Watopia) grade profile through S22iDevice.
 *
 * Source: bestbikesplit.com/zwift/229508 — 31 intervals, 9.12 km total.
 * Zwift scales route grades to 50% before sending to QZCompanion.
 *
 * Pipeline per interval:
 *   actualGrade × 0.5  →  roundToOneDecimal  →  quantize (0.5% steps)  →  targetY swipe
 *
 * Time is synthetic: each interval advances 'now' by 2000ms, well above
 * SWIPE_THROTTLE_MS (500ms), so no throttling fires and every dispatch
 * decision is driven purely by de-dup logic.
 *
 * Expected result: 30 dispatches — interval 30 is de-duped because
 *   -2.19% × 0.5 = -1.095 → -1.1% → quantize = -1.0  (same as interval 29).
 */
public class HillyRouteReplayTest {

    // Actual route grades from bestbikesplit.com/zwift/229508
    private static final float[] ACTUAL_GRADES = {
        +0.66f, +5.42f, +7.85f, +5.42f, +2.69f, -1.94f, +0.67f, -0.52f,
        -0.23f, -3.36f, +3.13f,  0.00f, -2.37f, -4.27f, -6.44f, -2.60f,
        -0.54f, +2.30f, -1.81f, -3.24f,  0.00f, +4.13f, -3.15f, -5.38f,
        +1.43f, -0.17f, -1.60f, +1.65f, -1.92f, -2.19f, -0.19f
    };

    // Expected swipe command per interval. null = de-duped (no dispatch expected).
    // Pipeline: actual × 0.5 → roundToOneDecimal → quantize(0.5 steps) → targetY
    // S22i formula: v≤0 → (int)(622-10*v); v>0 → (int)(622-14.8*v). Calibrated 2026-04-18.
    // trackX = 75, initial thumbY = 622
    private static final String[] EXPECTED = {
        "input swipe 75 622 75 614 200",  //  1: 0.66→0.33→0.3→q0.5     → y614
        "input swipe 75 614 75 585 200",  //  2: 5.42→2.71→2.7→q2.5     → y585
        "input swipe 75 585 75 562 200",  //  3: 7.85→3.93→3.9→q4.0     → y562
        "input swipe 75 562 75 585 200",  //  4: 5.42→2.71→2.7→q2.5     → y585
        "input swipe 75 585 75 599 200",  //  5: 2.69→1.35→1.3→q1.5     → y599
        "input swipe 75 599 75 632 200",  //  6: -1.94→-0.97→-1.0→q-1.0 → y632
        "input swipe 75 632 75 614 200",  //  7: 0.67→0.34→0.3→q0.5     → y614
        "input swipe 75 614 75 627 200",  //  8: -0.52→-0.26→-0.3→q-0.5 → y627
        "input swipe 75 627 75 622 200",  //  9: -0.23→-0.12→-0.1→q0.0  → y622
        "input swipe 75 622 75 637 200",  // 10: -3.36→-1.68→-1.7→q-1.5 → y637
        "input swipe 75 637 75 599 200",  // 11: 3.13→1.57→1.6→q1.5     → y599
        "input swipe 75 599 75 622 200",  // 12: 0.00→0.00→0.0→q0.0     → y622
        "input swipe 75 622 75 632 200",  // 13: -2.37→-1.19→-1.2→q-1.0 → y632
        "input swipe 75 632 75 642 200",  // 14: -4.27→-2.14→-2.1→q-2.0 → y642
        "input swipe 75 642 75 652 200",  // 15: -6.44→-3.22→-3.2→q-3.0 → y652
        "input swipe 75 652 75 637 200",  // 16: -2.60→-1.30→-1.3→q-1.5 → y637
        "input swipe 75 637 75 627 200",  // 17: -0.54→-0.27→-0.3→q-0.5 → y627
        "input swipe 75 627 75 607 200",  // 18: 2.30→1.15→1.2→q1.0     → y607
        "input swipe 75 607 75 632 200",  // 19: -1.81→-0.91→-0.9→q-1.0 → y632
        "input swipe 75 632 75 637 200",  // 20: -3.24→-1.62→-1.6→q-1.5 → y637
        "input swipe 75 637 75 622 200",  // 21: 0.00→0.00→0.0→q0.0     → y622
        "input swipe 75 622 75 592 200",  // 22: 4.13→2.07→2.1→q2.0     → y592
        "input swipe 75 592 75 637 200",  // 23: -3.15→-1.58→-1.6→q-1.5 → y637
        "input swipe 75 637 75 647 200",  // 24: -5.38→-2.69→-2.7→q-2.5 → y647
        "input swipe 75 647 75 614 200",  // 25: 1.43→0.72→0.7→q0.5     → y614
        "input swipe 75 614 75 622 200",  // 26: -0.17→-0.09→-0.1→q0.0  → y622
        "input swipe 75 622 75 632 200",  // 27: -1.60→-0.80→-0.8→q-1.0 → y632
        "input swipe 75 632 75 607 200",  // 28: 1.65→0.83→0.8→q1.0     → y607
        "input swipe 75 607 75 632 200",  // 29: -1.92→-0.96→-1.0→q-1.0 → y632
        null,                             // 30: -2.19→-1.10→-1.1→q-1.0 → DE-DUPED (same as #29)
        "input swipe 75 632 75 622 200",  // 31: -0.19→-0.10→-0.1→q0.0  → y622
    };

    @Test
    public void hillyRoute_replayAt50pctZwiftScaling_dispatchesCorrectSwipes() {
        List<String> dispatched = new ArrayList<>();
        S22iDevice dev = new S22iDevice();
        dev.commandExecutor = cmd -> dispatched.add(cmd);

        long now = 1000L;
        for (int i = 0; i < ACTUAL_GRADES.length; i++) {
            int sizeBefore = dispatched.size();
            Command cmd = new Command();
            cmd.inclinePct = Device.roundToOneDecimal(ACTUAL_GRADES[i] * 0.5f);
            dev.applyCommand(cmd, now);
            now += 2000L;

            if (EXPECTED[i] == null) {
                assertEquals("interval " + (i + 1) + " should be de-duped — no command expected",
                        sizeBefore, dispatched.size());
            } else {
                assertEquals("interval " + (i + 1) + " should produce exactly one command",
                        sizeBefore + 1, dispatched.size());
                assertEquals("interval " + (i + 1) + " wrong swipe target",
                        EXPECTED[i], dispatched.get(dispatched.size() - 1));
            }
        }

        long expectedDispatches = Arrays.stream(EXPECTED).filter(e -> e != null).count();
        assertEquals("total dispatched commands", expectedDispatches, dispatched.size());
    }
}
