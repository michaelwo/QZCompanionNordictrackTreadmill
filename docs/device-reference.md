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

| Slider | trackX | Initial thumbY | Formula | Quantize |
|--------|--------|---------------|---------|----------|
| Incline | 75 | 618 | `(int)(616.18 - 17.223 * (v > 3.0 ? v + 0.5 : v))` | 0.5% steps |

The `v + 0.5` correction at grades above 3% compensates for the formula landing just short of the snap point, ensuring the swipe lands in the correct zone.

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
**Metric reader:** `TailGrepMetricReader` (default)

| Slider | trackX | Initial thumbY | Formula | currentThumbY |
|--------|--------|---------------|---------|---------------|
| Incline | 75 | 618 | `616 - (int)(v * 17.65)` | derived from `lastSnapshot.incline` |
| Resistance | 1848 | 790 | `790 - (int)(v * 23.16)` | derived from `lastSnapshot.gear` |

---

### S27i Bike (`s27i`)
**Command mode:** ADB  
**Metric reader:** `TailGrepMetricReader` (default)

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
