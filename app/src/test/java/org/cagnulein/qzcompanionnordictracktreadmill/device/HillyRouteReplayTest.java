package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.S22iDevice;
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
    // Pipeline: actual × 0.5 → roundToOneDecimal → quantize(0.5 steps) → targetY → ±hysteresis
    // S22i formula: v≤0 → (int)(622-10*v); v>0 → (int)(622-14.8*v). Calibrated 2026-04-18.
    // S22i hysteresis: travel ≥ 40px → 15px overshoot; shorter → 10px.
    // trackX = 75, initial thumbY = 622
    // dispatchY = toY∓h (up) | toY±h (down); most intervals travel < 40px → h=10
    private static final String[] EXPECTED = {
        "input swipe 75 622 75 604 200",  //  1: q0.5  → y614 ↑ t8  h10 d604
        "input swipe 75 614 75 575 200",  //  2: q2.5  → y585 ↑ t29 h10 d575
        "input swipe 75 585 75 552 200",  //  3: q4.0  → y562 ↑ t23 h10 d552
        "input swipe 75 562 75 595 200",  //  4: q2.5  → y585 ↓ t23 h10 d595
        "input swipe 75 585 75 609 200",  //  5: q1.5  → y599 ↓ t14 h10 d609
        "input swipe 75 599 75 642 200",  //  6: q-1.0 → y632 ↓ t33 h10 d642
        "input swipe 75 632 75 604 200",  //  7: q0.5  → y614 ↑ t18 h10 d604
        "input swipe 75 614 75 637 200",  //  8: q-0.5 → y627 ↓ t13 h10 d637
        "input swipe 75 627 75 612 200",  //  9: q0.0  → y622 ↑ t5  h10 d612
        "input swipe 75 622 75 647 200",  // 10: q-1.5 → y637 ↓ t15 h10 d647
        "input swipe 75 637 75 589 200",  // 11: q1.5  → y599 ↑ t38 h10 d589
        "input swipe 75 599 75 632 200",  // 12: q0.0  → y622 ↓ t23 h10 d632
        "input swipe 75 622 75 642 200",  // 13: q-1.0 → y632 ↓ t10 h10 d642
        "input swipe 75 632 75 652 200",  // 14: q-2.0 → y642 ↓ t10 h10 d652
        "input swipe 75 642 75 662 200",  // 15: q-3.0 → y652 ↓ t10 h10 d662
        "input swipe 75 652 75 627 200",  // 16: q-1.5 → y637 ↑ t15 h10 d627
        "input swipe 75 637 75 617 200",  // 17: q-0.5 → y627 ↑ t10 h10 d617
        "input swipe 75 627 75 597 200",  // 18: q1.0  → y607 ↑ t20 h10 d597
        "input swipe 75 607 75 642 200",  // 19: q-1.0 → y632 ↓ t25 h10 d642
        "input swipe 75 632 75 647 200",  // 20: q-1.5 → y637 ↓ t5  h10 d647
        "input swipe 75 637 75 612 200",  // 21: q0.0  → y622 ↑ t15 h10 d612
        "input swipe 75 622 75 582 200",  // 22: q2.0  → y592 ↑ t30 h10 d582
        "input swipe 75 592 75 652 200",  // 23: q-1.5 → y637 ↓ t45 h15 d652  ← travel ≥ 40
        "input swipe 75 637 75 657 200",  // 24: q-2.5 → y647 ↓ t10 h10 d657
        "input swipe 75 647 75 604 200",  // 25: q0.5  → y614 ↑ t33 h10 d604
        "input swipe 75 614 75 632 200",  // 26: q0.0  → y622 ↓ t8  h10 d632
        "input swipe 75 622 75 642 200",  // 27: q-1.0 → y632 ↓ t10 h10 d642
        "input swipe 75 632 75 597 200",  // 28: q1.0  → y607 ↑ t25 h10 d597
        "input swipe 75 607 75 642 200",  // 29: q-1.0 → y632 ↓ t25 h10 d642
        null,                             // 30: q-1.0 → DE-DUPED (same as #29)
        "input swipe 75 632 75 612 200",  // 31: q0.0  → y622 ↑ t10 h10 d612
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
