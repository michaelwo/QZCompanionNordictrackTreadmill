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
    // S22i formula: v≤0 → (int)(619-10*v); v>0 → (int)(619-18.57*v). Calibrated 2026-04-19.
    // S22i hysteresis: travel ≥ 40px → 15px overshoot; shorter → 10px.
    // trackX = 75, initial thumbY = 619
    // dispatchY = toY∓h (up) | toY±h (down); most intervals travel < 40px → h=10
    private static final String[] EXPECTED = {
        "input swipe 75 619 75 599 200",  //  1: q0.5  → y609 ↑ t10 h10 d599
        "input swipe 75 609 75 562 200",  //  2: q2.5  → y572 ↑ t37 h10 d562
        "input swipe 75 572 75 534 200",  //  3: q4.0  → y544 ↑ t28 h10 d534
        "input swipe 75 544 75 582 200",  //  4: q2.5  → y572 ↓ t28 h10 d582
        "input swipe 75 572 75 601 200",  //  5: q1.5  → y591 ↓ t19 h10 d601
        "input swipe 75 591 75 639 200",  //  6: q-1.0 → y629 ↓ t38 h10 d639
        "input swipe 75 629 75 599 200",  //  7: q0.5  → y609 ↑ t20 h10 d599
        "input swipe 75 609 75 634 200",  //  8: q-0.5 → y624 ↓ t15 h10 d634
        "input swipe 75 624 75 609 200",  //  9: q0.0  → y619 ↑ t5  h10 d609
        "input swipe 75 619 75 644 200",  // 10: q-1.5 → y634 ↓ t15 h10 d644
        "input swipe 75 634 75 576 200",  // 11: q1.5  → y591 ↑ t43 h15 d576  ← travel ≥ 40
        "input swipe 75 591 75 629 200",  // 12: q0.0  → y619 ↓ t28 h10 d629
        "input swipe 75 619 75 639 200",  // 13: q-1.0 → y629 ↓ t10 h10 d639
        "input swipe 75 629 75 649 200",  // 14: q-2.0 → y639 ↓ t10 h10 d649
        "input swipe 75 639 75 659 200",  // 15: q-3.0 → y649 ↓ t10 h10 d659
        "input swipe 75 649 75 624 200",  // 16: q-1.5 → y634 ↑ t15 h10 d624
        "input swipe 75 634 75 614 200",  // 17: q-0.5 → y624 ↑ t10 h10 d614
        "input swipe 75 624 75 590 200",  // 18: q1.0  → y600 ↑ t24 h10 d590
        "input swipe 75 600 75 639 200",  // 19: q-1.0 → y629 ↓ t29 h10 d639
        "input swipe 75 629 75 644 200",  // 20: q-1.5 → y634 ↓ t5  h10 d644
        "input swipe 75 634 75 609 200",  // 21: q0.0  → y619 ↑ t15 h10 d609
        "input swipe 75 619 75 571 200",  // 22: q2.0  → y581 ↑ t38 h10 d571
        "input swipe 75 581 75 649 200",  // 23: q-1.5 → y634 ↓ t53 h15 d649  ← travel ≥ 40
        "input swipe 75 634 75 654 200",  // 24: q-2.5 → y644 ↓ t10 h10 d654
        "input swipe 75 644 75 599 200",  // 25: q0.5  → y609 ↑ t35 h10 d599
        "input swipe 75 609 75 629 200",  // 26: q0.0  → y619 ↓ t10 h10 d629
        "input swipe 75 619 75 639 200",  // 27: q-1.0 → y629 ↓ t10 h10 d639
        "input swipe 75 629 75 590 200",  // 28: q1.0  → y600 ↑ t29 h10 d590
        "input swipe 75 600 75 639 200",  // 29: q-1.0 → y629 ↓ t29 h10 d639
        null,                             // 30: q-1.0 → DE-DUPED (same as #29)
        "input swipe 75 629 75 609 200",  // 31: q0.0  → y619 ↑ t10 h10 d609
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
