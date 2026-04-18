# Incline Calibration Runbook

## Purpose

The S22i (and other bikes) use a linear formula to map an incline percentage to a pixel Y coordinate on the iFit touch screen. If the formula is wrong or has drifted from the device's actual layout, QZCompanion will swipe to the wrong position and the bike will stop at the wrong incline.

This runbook describes how to verify the current formula is accurate and how to re-derive it if not.

---

## Prerequisites

- Device connected via ADB (`adb devices` shows it)
- QZCompanion installed and the correct device selected
- OCR enabled in QZCompanion settings
- ADB debugging enabled on the fitness device

**Verify OCR incline is active before starting:**
```bash
adb logcat | grep "OCRlines incline"
```
If you see log lines during a ride with incline changes, the OCR feedback channel is live. If nothing appears, OCR may not be reading the incline label on your device's firmware — stop here and investigate `Ocr.extractMetrics()` against a screenshot.

---

## Approach

Command a specific incline via ADB, wait for the slider to settle, read back the actual incline from OCR, compare commanded vs observed.

The result is a table of (commanded, observed) pairs. If they diverge consistently, a new formula can be derived from two well-separated data points.

---

## Step 1 — Warm up the belt

Incline changes may be gated while the belt is stopped. Start a slow ride first.

---

## Step 2 — Run the sweep

```bash
#!/usr/bin/env bash
# calibrate-incline.sh — sweep incline and log commanded vs OCR-observed values
#
# Usage: ./calibrate-incline.sh
# Requires: adb on PATH, QZCompanion running with OCR enabled

set -euo pipefail

PKG="org.cagnulein.qzcompanionnordictracktreadmill"
SETTLE_S=8       # seconds to wait for slider to settle at each step
OUT="calibration-$(date +%Y%m%d-%H%M%S).csv"

echo "commanded_pct,observed_pct" | tee "${OUT}"

# Sweep from -10% to +20% in 2.5% steps (adjust for your device's range)
for pct in -10 -7.5 -5 -2.5 0 2.5 5 7.5 10 12.5 15 17.5 20; do
    echo "Commanding ${pct}%..."

    # Send via UDP on loopback — QZCompanion expects "inclinePct;" for bikes
    echo -n "${pct};" | socat - UDP-DATAGRAM:127.0.0.1:8002,sp=8002

    sleep "${SETTLE_S}"

    # Read observed incline from logcat (last OCR incline line in the past 3s)
    observed=$(adb logcat -d -t 3 2>/dev/null \
        | grep "OCRlines incline\|inclinePct" \
        | tail -1 \
        | grep -oE '[-]?[0-9]+(\.[0-9]+)?' \
        | tail -1 \
        || echo "?")

    echo "${pct},${observed}" | tee -a "${OUT}"
done

echo ""
echo "Calibration data saved to: ${OUT}"
```

If `socat` is not available, send the UDP command from the QZ app instead and trigger each incline change manually.

---

## Step 3 — Interpret the results

Open `calibration-*.csv`. Look for:

| Pattern | Meaning |
|---------|---------|
| `commanded == observed` at all points | Formula is correct |
| Constant offset (e.g. always 1% low) | Formula intercept needs adjustment |
| Growing divergence at high inclines | Slope (`b` in `a - b*v`) is slightly off |
| Correct at 0%, wrong everywhere else | `currentThumbY()` is missing — slider start position is drifting |

---

## Step 4 — Derive a corrected formula (if needed)

Pick two well-separated data points where the commanded values are known and the observed values are trusted (e.g. 0% and 15%). Then:

```
b = (Y_at_0 - Y_at_15) / (15 - 0)
a = Y_at_0
```

But you may not have the raw Y coordinates — you have commanded vs observed percentages. In that case:

1. Use `adb shell screencap -p /sdcard/screen.png && adb pull /sdcard/screen.png` at each commanded level to capture screenshots
2. Measure the pixel Y of the slider thumb in each screenshot
3. Fit the two-point linear formula:
   ```
   b = (Y1 - Y2) / (v2 - v1)
   a = Y1 + b * v1
   ```
4. Update `targetY()` in the device's `Slider` anonymous subclass in `device/catalog/`

For the S22i specifically, the formula is in `S22iDevice.java`:
```java
public int targetY(double v) {
    return (int) (616.18 - 17.223 * (v > 3.0 ? v + 0.5 : v));
}
```

The `v > 3.0 ? v + 0.5 : v` term is a correction for the snap zone. If you find the formula is consistently off only above 3%, adjust the `0.5` constant rather than the slope.

---

## Step 5 — Validate

Re-run `calibrate-incline.sh` with the new formula. Commanded and observed values should match within ±0.5% (one quantize step).

---

## Notes

- The S22i slider snaps to 0.5% increments — differences smaller than 0.5% are expected and normal
- OCR reading requires the incline value to be visible on screen and labelled with a string containing `"incline"`. If the iFit firmware uses a different label, update `Ocr.extractMetrics()` in `ocr/Ocr.java`
- The `SETTLE_S` wait needs to be long enough for the swipe animation to complete and the OCR to update — 8 seconds is conservative; 5 may be sufficient
- The `currentThumbY()` override is critical for devices where the slider can be moved by the user or by another source (e.g. a physical resistance knob). Without it, the `fromY` in the swipe will be wrong if the slider has drifted, causing the next command to land at the wrong position
