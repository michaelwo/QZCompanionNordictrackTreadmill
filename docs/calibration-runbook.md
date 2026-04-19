# Incline Calibration Runbook

## Purpose

Bike devices use a linear formula to map an incline percentage to a pixel Y coordinate on the iFit touch screen. If the formula is wrong or has drifted from the device's actual layout, QZCompanion will swipe to the wrong position and the bike will stop at the wrong incline.

This runbook describes how to derive a device-specific formula using the in-app calibration tool (`CalibrationActivity`) or the shell-based sweep script (`calibrate-device.sh`).

---

## Prerequisites

- Device connected via ADB (`adb devices` shows it)
- QZCompanion installed and running on the fitness device
- Screen-capture permission granted on first launch (required for OCR feedback)
- ADB debugging enabled on the fitness device

---

## Approach

Drive a series of raw swipe Y coordinates, read back the observed incline from OCR after each swipe settles, then fit a linear formula `Y = a − b × incline%` to the resulting data.

---

## Option A — In-App Calibration (recommended)

### Step 1 — Start a slow ride

Incline commands may be gated while the belt or resistance is not engaged. Start a slow ride before calibrating.

### Step 2 — Open CalibrationActivity

Tap **Calibrate New Device** from the main screen. You will need to supply two values:

| Field | Meaning | How to find it |
|-------|---------|----------------|
| **Track X** | Horizontal pixel position of the incline slider | Screenshot the device screen; measure the X pixel of the slider track (commonly 75 for NordicTrack bikes) |
| **Neutral Y** | Pixel Y corresponding to 0% incline | Screenshot at 0% incline; measure the Y pixel of the slider thumb |

### Step 3 — Run the sweep

Tap **Start Sweep**. The app will:
1. Return the slider to neutral Y between each step
2. Swipe to a sequence of Y positions spanning ≈±11% of the neutral range
3. Wait for the OCR-observed incline to stabilise (3 consecutive reads within 0.3%, up to 6 s timeout)
4. Record the (Y commanded, incline observed) pair

The sweep takes approximately 60–90 seconds for 10 positions.

### Step 4 — Review and save

The results screen shows the fitted formula, R² value, and hysteresis estimates. A good fit has R² ≥ 0.97.

- **R² < 0.90** — poor fit; check that OCR is reading the incline label correctly and that the slider range is wide enough
- **Hysteresis** — the app automatically estimates two-zone hysteresis (travel < 40 px vs ≥ 40 px) from residual scatter

Tap **Save** to write the formula to SharedPreferences and activate the `custom_calibrated` device. The new formula is live immediately — no restart needed.

---

## Option B — Shell Sweep (`calibrate-device.sh`)

Use this when OCR is not available or you prefer offline formula derivation.

### Phase 1 — Log format discovery (developer task)

```bash
./calibrate-device.sh
```

Sweeps known grades via UDP, captures OCR logcat output, iFit log diffs, and screencaps for each step. Use the output to identify which log keyword carries the incline value on your device firmware.

### Phase 2 — Swipe formula derivation

```bash
./calibrate-device.sh --sweep-swipe
```

Drives raw swipe Y positions (neutral → target) via `adb shell input swipe`, reads OCR-observed incline after each swipe settles, fits `Y = a − b × grade` in awk, and reports spring-back (hysteresis) from residuals. Requires `adb` on PATH and OCR active (`adb logcat | grep QZ:OcrCalibration`).

---

## Verifying the Formula

After saving a calibration, command a range of inclines via the QZ app and confirm OCR-observed values match within ±0.5% (one quantize step):

```bash
adb logcat | grep "QZ:OcrCalibration"
```

If divergence is consistent (e.g. always 1% low), the intercept `a` needs adjustment. If divergence grows at higher inclines, the slope `b` is slightly off.

---

## Formula Structure

`CalibratedBikeDevice` reads `CalibrationResult.current` on every swipe:

```
targetY(incline%) = (int)(a − b × incline%)
```

Two-zone hysteresis is applied automatically:
- **Travel ≥ 40 px:** `hystLargePx` overshoot
- **Travel < 40 px:** `hystSmallPx` overshoot

The `currentThumbY()` override reads live incline from `MetricReaderBroadcastingService` (via `Device.instance.lastSnapshot`), so any drift is self-corrected on the next command.

---

## Notes

- The S22i slider snaps to 0.5% increments — differences smaller than 0.5% are expected
- OCR requires the incline value to be visible on screen. If the iFit firmware uses an unexpected label, check `Ocr.extractMetrics()` against a screenshot
- `SETTLE_MS = 300 ms`, `POLL_INTERVAL = 400 ms`, `TIMEOUT_MS = 6 s` are constants in `CalibrationActivity` — adjust for unusually slow or fast hardware
- Calibration data is stored in `SharedPreferences` under the key prefix `cal_` and survives app restarts
