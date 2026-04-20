# Device Formula Reference

All coordinates are screen pixels on the iFit touch display. Swipe duration is always 200 ms.

Swipe format: `input swipe <trackX> <fromY> <trackX> <targetY> 200`

---

## Command Execution Mode

| Mode | How it works | Devices |
|------|-------------|---------|
| **ADB loopback** | `ShellService` sends via ADB to 127.0.0.1:5555 | Most devices (default) |
| **Direct shell** | `Runtime.getRuntime().exec()` — no ADB required | NTEX02117_2, X22i, X14i |
| **AccessibilityService** | Android a11y API — no ADB required; must be enabled in Settings | S22i NoADB, X22i NoADB, T95s |

---

## Bikes

Bike UDP message format: `"inclinePct;?"` (2 parts) or `"resistanceLvl"` (1 part).  
The sentinel values `-1` and `-100` are discarded (no-op).

### S22i Bike (`s22i`)
**Command mode:** ADB  
**Metric reader:** `BikeMetricReader`

| Slider | trackX | Initial thumbY | Formula | Quantize | currentThumbY | Hysteresis |
|--------|--------|---------------|---------|----------|---------------|------------|
| Incline | 75 | 622 | `v≤0: (int)(622 - 10*v)` / `v>0: (int)(622 - 18.57*v)` | 0.5% steps | `snapshot.inclinePct` when non-null | 15 px |
| Resistance | 1845 | 724 | `(int)(724 - 401.0/23 * (v-1))` | integer levels | `snapshot.resistanceLvl` when ≥1 | — |

**Calibration (2026-04-19, screen 1920×1080):**
- Incline (positive): 13-point ascending swipe sweep via `calibrate-device.sh --sweep-swipe` (Y=400→700 from neutral=622). 7 clean positive-grade points (4–12%), least-squares fit: Y = 622 − 18.57 × grade (R² ≈ 0.999). Updates slope from 14.8→18.57 px/%. Intercept fixed at 622 (iFit log confirmed device self-reports 0% at Y≈622; initial 619 estimate was 3 px low).
- Incline (negative): prior 3-point calibration slope (−10 px/%) retained — only 2 data points available from the 2026-04-19 sweep (insufficient for reliable refit). Intercept 622 consistent with iFit neutral reading.
- Resistance: two points measured — level=1→Y=724, level=24→Y=323. Slope = −401/23 ≈ −17.43 px/level. Resistance=0 readings from the log are noise and ignored in `currentThumbY`.

Both sliders read live observed values from the iFit log (`Changed Grade to:`, `Changed Resistance to:`) and use them as the starting position for each swipe, self-correcting for drift.

**Hysteresis correction (incline only):** Physical slider stiction causes ~0.5–1% undershoot in both directions. The swipe overshoots `targetY` in the direction of travel; `thumbY` still tracks the logical target so de-dup and state-tracking are unaffected. The `currentThumbY` override reads back the actual iFit-reported grade before the next swipe, correcting residual error one interval later.
- **Swipe travel ≥ 40 px:** 15 px overshoot — spring-back is ~15 px for longer swipes.
- **Swipe travel < 40 px:** 10 px — spring-back is ~8 px for short swipes; 15 px would overcorrect by ~0.5%.

---

### S22i Bike (NTEX02121.5) (`s22i_NTEX02121_5`)
**Command mode:** ADB  
**Metric reader:** `BikeMetricReader`

| Slider | trackX | Initial thumbY | Formula | currentThumbY |
|--------|--------|---------------|---------|---------------|
| Incline | 75 | 535 | `800 - (int)((v + 10) * 19)` | derived from `lastSnapshot.incline` |

This variant derives the slider start position from the observed incline each time (no state drift).

---

### S22i Bike (NTEX02117.2) (`s22i_NTEX02117_2`)
**Command mode:** Direct shell (`ShellRuntime`) — no ADB  
**Metric reader:** `CatFileMetricReader`

Inherits all slider geometry from `S22iDevice`. Only the command executor and metric reader differ from `s22i`.

---

### S22i Bike (No ADB) (`s22i_noadb`)
**Command mode:** AccessibilityService  
**Metric reader:** `BikeMetricReader`

Inherits all slider geometry from `S22iDevice`. Swipe injected via `MyAccessibilityService.performSwipe()` instead of ADB.

---

### S15i Bike (`s15i`)
**Command mode:** ADB  
**Metric reader:** `BikeMetricReader` (inherited from `BikeDevice`)

| Slider | trackX | Initial thumbY | Formula | currentThumbY |
|--------|--------|---------------|---------|---------------|
| Incline | 75 | 618 | `616 - (int)(v * 17.65)` | derived from `lastSnapshot.incline` |
| Resistance | 1848 | 790 | `790 - (int)(v * 23.16)` | derived from `lastSnapshot.gear` |

---

### S27i Bike (`s27i`)
**Command mode:** ADB  
**Metric reader:** `BikeMetricReader` (inherited from `BikeDevice`)

Range assumptions: incline −10%..+20% mapped to Y 803..248; resistance levels 1..24 mapped to Y 803..248.

| Slider | trackX | Initial thumbY | Formula | currentThumbY |
|--------|--------|---------------|---------|---------------|
| Incline | 76 | 803 | `803 - (int)((v + 10) * (803-248) / 30.0)` | derived from `lastSnapshot.incline` |
| Resistance | 1847 | 803 | `803 - (int)((v - 1) * (803-248) / 23.0)` | derived from `lastSnapshot.resistance` |

---

## Treadmills

Treadmill UDP message format: `"speedKmh;inclinePct"` (2 parts).  
Speed commands are gated: no swipe is sent while `lastSnapshot.speed <= 0` (belt stopped).

### X22i Treadmill (`x22i`)
**Command mode:** Direct shell — no ADB  
**Metric reader:** `CatFileMetricReader`

| Slider | trackX | Initial thumbY | Formula |
|--------|--------|---------------|---------|
| Speed | 1845 | 785 | `(int)(785 - 23.636363636363636 * v)` |
| Incline | 75 | 785 | `(int)(785 - 11.304347826086957 * (v + 6))` |

---

### X32i Treadmill (`x32i`)
**Command mode:** ADB  
**Metric reader:** `TailGrepMetricReader` (default)

| Slider | trackX | Initial thumbY | Formula |
|--------|--------|---------------|---------|
| Speed | 1845 | 927 | `(int)(834.85 - 26.946 * v)` |
| Incline | 76 | 881 | `(int)(734.07 - 12.297 * v)` |

---

### C1750 Treadmill (`c1750`)
**Command mode:** ADB  
**Metric reader:** `CatFileMetricReader`

| Slider | trackX | Initial thumbY | Formula | currentThumbY |
|--------|--------|---------------|---------|---------------|
| Speed | 1845 | 793 | `785 - (int)((v - 1.0) * 31.42)` | derived from `lastSnapshot.speed` |
| Incline | 79 | 694 | `(int)(700 - 34.9 * v)` | — |

---

## Adding a New Device

1. Create a class in `device/catalog/` extending `BikeDevice` or `TreadmillDevice`
2. Supply one or two `Slider` anonymous subclasses with `trackX()`, `targetY()`, and optionally `quantize()` and `currentThumbY()`
3. Override `displayName()`
4. If the device uses direct shell: override `requiresAdb()` to return `false` and assign a `ShellRuntime` executor in the constructor
5. If the device uses AccessibilityService: override `requiresAdb()` and override `swipe()` to call `MyAccessibilityService.performSwipe()`
6. Add a `DeviceId` entry and `m.put(...)` line in `DeviceRegistry`
7. The `DeviceAdapter` in `MainActivity` will pick it up automatically once it's in `DeviceRegistry.DeviceId`

See `S22iDevice` + `BikeDevice` for the canonical bike example, and `X22iDevice` + `TreadmillDevice` for the canonical treadmill example.

---

## Deriving New Slider Formulas

The formula `targetY(v)` is a linear mapping: `Y = a - b * v`.

To calibrate from two known (value, Y) pairs:
```
b = (Y1 - Y2) / (v2 - v1)
a = Y1 + b * v1
```

To observe the current slider positions, use `adb shell screencap -p /sdcard/screen.png` and examine the result, or use the OCR calibration procedure in `calibration-runbook.md`.
