# Device Reference

All coordinates are screen pixels on the iFit touch display, standardised to **iFit APK 2.6.90** (versionCode 4963, `com.ifit.standalone`). TrackX values are derived from the APK layout resources and expressed via the `ScreenProfile` enum in source — see `device/ScreenProfile.java`. If the iFit app is updated to a version with different slider geometry, re-derive the constants from the new APK before editing device classes. Swipe format:

```
input swipe <trackX> <fromY> <trackX> <targetY(v)> 200
```

Swipe duration is always 200 ms. `fromY` is the slider's current tracked position; `targetY(v)` is computed from the formula for the requested value `v`. When a device overrides `currentThumbY(snapshot)`, the starting position is re-derived from the live iFit-reported value before each swipe, correcting drift.

For the full dispatch pipeline see [architecture.md](architecture.md). For how to add a device and write formula tests see the steps at the bottom of this file and [testing-methodology.md](testing-methodology.md).

---

## All Devices at a Glance

| DeviceId | Display name | Mode | Metric reader |
|----------|-------------|------|---------------|
| `s15i` | S15i Bike | ADB | BikeMetricReader |
| `s22i` | S22i Bike | ADB | BikeMetricReader |
| `s22i_NTEX02121_5` | S22i Bike (NTEX02121.5) | ADB | BikeMetricReader |
| `s22i_NTEX02117_2` | S22i Bike (NTEX02117.2) | Shell | CatFileMetricReader |
| `s22i_noadb` | S22i Bike (No ADB) | Accessibility | MonoStdoutMetricReader |
| `s27i` | S27i Bike | ADB | BikeMetricReader |
| `NTEX71021` | NTEX71021 Bike | ADB | DirectLogcatMetricReader |
| `tdf10` | TDF10 Bike | ADB | BikeMetricReader |
| `tdf10_inclination` | TDF10 Bike (Inclination) | ADB | BikeMetricReader |
| `proform_studio_bike_pro22` | ProForm Studio Bike Pro 2.2 | ADB | BikeMetricReader |
| `proform_carbon_e7` | ProForm Carbon E7 Bike | ADB | BikeMetricReader |
| `proform_carbon_c10` | ProForm Carbon C10 Bike | ADB | DirectLogcatMetricReader |
| `custom_calibrated` | Custom (Calibrated) | ADB | BikeMetricReader |
| `x9i` | X9i Treadmill | Shell | TailGrepMetricReader |
| `x11i` | X11i Treadmill | ADB | TailGrepMetricReader |
| `x14i` | X14i Treadmill | Shell | CatFileMetricReader |
| `x22i` | X22i Treadmill | Shell | CatFileMetricReader |
| `x22i_v2` | X22i V2 Treadmill | ADB | TailGrepMetricReader |
| `x22i_noadb` | X22i Treadmill (No ADB) | Accessibility | TailGrepMetricReader |
| `x32i` | X32i Treadmill | ADB | TailGrepMetricReader |
| `x32i_NTL39019` | X32i Treadmill (NTL39019) | ADB | TailGrepMetricReader |
| `x32i_NTL39221` | X32i Treadmill (NTL39221) | ADB | TailGrepMetricReader |
| `c1750` | C1750 Treadmill | ADB | CatFileMetricReader |
| `c1750_2020` | C1750 Treadmill (2020) | ADB | CatFileMetricReader |
| `c1750_2020_kph` | C1750 Treadmill (2020 KPH) | ADB | CatFileMetricReader |
| `c1750_mph_minus3grade` | C1750 Treadmill (MPH -3% Grade) | ADB | TailGrepMetricReader |
| `c1750_NTL14122_2_MPH` | C1750 Treadmill (NTL14122.2 MPH) | ADB | TailGrepMetricReader |
| `c1750_2021` | C1750 Treadmill (2021) | ADB | CatFileMetricReader |
| `t65s` | T6.5s Treadmill | ADB | TailGrepMetricReader |
| `t75s` | T7.5s Treadmill | ADB | LogcatDumpMetricReader |
| `t85s` | T8.5s Treadmill | ADB | TailGrepMetricReader |
| `t95s` | T9.5s Treadmill | Accessibility | TailGrepMetricReader |
| `s40` | S40 Treadmill | ADB | TailGrepMetricReader |
| `nordictrack_2450` | NordicTrack 2450 Treadmill | ADB | TailGrepMetricReader |
| `nordictrack_2950` | NordicTrack 2950 Treadmill | ADB | TailGrepMetricReader |
| `nordictrack_2950_maxspeed22` | NordicTrack 2950 Treadmill (Max Speed 22) | ADB | TailGrepMetricReader |
| `proform_2000` | ProForm 2000 Treadmill | ADB | TailGrepMetricReader |
| `proform_carbon_t14` | ProForm Carbon T14 Treadmill | ADB | CatFileMetricReader |
| `proform_pro_9000` | ProForm Pro 9000 Treadmill | ADB | TailGrepMetricReader |
| `proform_pro_2000` | ProForm Pro 2000 Treadmill | ADB | TailGrepMetricReader |
| `grand_tour_pro` | Grand Tour Pro Treadmill | ADB | DirectLogcatMetricReader |
| `elite900` | Elite 900 Treadmill | ADB | TailGrepMetricReader |
| `elite1000` | Elite 1000 Treadmill | ADB | TailGrepMetricReader |
| `exp7i` | EXP 7i Treadmill | ADB | TailGrepMetricReader |
| `se9i_elliptical` | SE9i Elliptical | ADB | BikeMetricReader |
| `other` | Other Treadmill | ADB | TailGrepMetricReader |

---

## Command Execution Modes

| Mode | How it works | Devices |
|------|-------------|---------|
| **ADB** | `ShellService` sends via ADB loopback to 127.0.0.1:5555 | Default for all devices not listed below |
| **Shell** | `Runtime.getRuntime().exec()` — no ADB connection needed | S22i (NTEX02117.2), X9i, X14i, X22i |
| **Accessibility** | `MyAccessibilityService.dispatchGesture()` — no ADB needed; must be enabled in Android Settings | S22i (No ADB), X22i (No ADB), T9.5s |

---

## Bikes

Bike UDP message: `"inclinePct;?"` (2-part) or `"resistanceLvl"` (1-part). Sentinels `-1` and `-100` are discarded.

### S15i (`s15i`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Incline | 75 | 618 | `616 - (int)(v * 17.65)` | from `snapshot.incline()` |
| Resistance | 1845 | 790 | `790 - (int)(v * 23.16)` | from `snapshot.gear()` |

---

### S22i (`s22i`)

| Slider | trackX | Initial Y | Formula | Quantize | currentThumbY | Hysteresis |
|--------|--------|-----------|---------|----------|---------------|------------|
| Incline | 75 | 622 | `v≤0: (int)(622 - 10*v)` / `v>0: (int)(622 - 18.57*v)` | 0.5% steps | from `snapshot.inclinePct` | travel ≥40px → 15px; <40px → 10px |
| Resistance | 1845 | 724 | `(int)(724 - 401.0/23 * (v-1))` | integer levels | from `snapshot.resistanceLvl` (when ≥1) | — |

**Calibration (2026-04-19, 1920×1080):** 13-point ascending sweep; least-squares fit: `Y = 622 − 18.57 × grade` (R² ≈ 0.999). Negative slope retained at −10 px/% from earlier 3-point calibration (insufficient data to refit). Intercept 622 confirmed from iFit log at neutral. Resistance: two points (level 1 → Y=724, level 24 → Y=323), slope −401/23 ≈ −17.43 px/level.

Hysteresis compensates for physical slider stiction: swipe overshoots `targetY` in the direction of travel; `thumbY` tracks the logical target so de-dup is unaffected. `currentThumbY` reads back the iFit-reported grade before each swipe, correcting residual drift.

---

### S22i (NTEX02121.5) (`s22i_NTEX02121_5`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Incline | 75 | 535 | `800 - (int)((v + 10) * 19)` | from `snapshot.incline()` |

---

### S22i (NTEX02117.2) (`s22i_NTEX02117_2`) — Shell mode

Shares all slider geometry with `S22iDevice`. Only the command executor (`ShellRuntime`) and metric reader (`CatFileMetricReader`) differ.

---

### S22i (No ADB) (`s22i_noadb`) — Accessibility mode

Shares all slider geometry with `S22iDevice`. Swipe injected via `MyAccessibilityService.performSwipe()`. Uses `MonoStdoutMetricReader` (push-based streaming) instead of the poll loop.

---

### S27i (`s27i`)

Range: incline −10%..+20% → Y 803..248; resistance levels 1..24 → Y 803..248.

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Incline | 75 | 803 | `803 - (int)((v + 10) * (803-248) / 30.0)` | from `snapshot.incline()` |
| Resistance | 1845 | 803 | `803 - (int)((v - 1) * (803-248) / 23.0)` | from `snapshot.resistance()` |

---

### NTEX71021 (`NTEX71021`)
**Reader:** DirectLogcatMetricReader

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Resistance | 950 | 480 | `(int)(493 - 13.57 * v)` |

---

### TDF10 (`tdf10`)

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Resistance | 1205 | 604 | `(int)(619.91 - 15.913 * v)` |

---

### TDF10 Inclination (`tdf10_inclination`)

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Incline | 75 | 482 | `(int)(-12.499 * v + 482.2)` |

---

### ProForm Studio Bike Pro 2.2 (`proform_studio_bike_pro22`)

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Resistance | 1845 | 805 | `(int)(826.25 - 21.25 * v)` |

---

### ProForm Carbon E7 (`proform_carbon_e7`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Incline | 74 | 440 | `440 - (int)(v * 11)` | from `snapshot.incline()` |
| Resistance | 950 | 440 | `440 - (int)(v * 9.16)` | from `snapshot.resistance()` |

---

### ProForm Carbon C10 (`proform_carbon_c10`)
**Reader:** DirectLogcatMetricReader

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Resistance | 1205 | 632 | `632 - (int)(v * 18.45)` | from `snapshot.resistance()` |

---

### Custom (Calibrated) (`custom_calibrated`)

`CalibratedBikeDevice` — formula and hysteresis derived at runtime from the last `CalibrationResult` written by `CalibrationActivity`. Falls back to a no-op swipe if no calibration data is present. See `calibration-runbook.md`.

---

## Treadmills

Treadmill UDP message: `"speedKmh;inclinePct"` (2 parts). Speed commands are gated: no swipe fires while `lastSnapshot.speed <= 0` (belt stopped).

### X9i (`x9i`) — Shell mode

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Speed | 725 | 332 | `(int)(345.6315 - 13.6315 * v)` |
| Incline | 73 | 332 | `(int)(311.91 - 3.3478 * v)` |

---

### X11i (`x11i`)

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Speed | 1205 | 600 | `(int)(621.997 - 21.785 * v)` |
| Incline | 75 | 557 | `(int)(565.491 - 8.44 * v)` |

---

### X14i (`x14i`) — Shell mode
**Reader:** CatFileMetricReader

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1845 | 785 | `807 - (int)((v - 1.0) * 31)` | from `snapshot.speed()` |
| Incline | 75 | 645 | lookup table (`INCLINE_TABLE`) | from `snapshot.incline()` |

---

### X22i (`x22i`) — Shell mode
**Reader:** CatFileMetricReader

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Speed | 1845 | 785 | `(int)(785 - 23.636 * v)` |
| Incline | 75 | 785 | `(int)(785 - 11.304 * (v + 6))` |

---

### X22i V2 (`x22i_v2`)

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Speed | 1845 | 785 | `(int)(838 - 26.136 * v)` |
| Incline | 75 | 785 | `(int)(742 - 11.9 * (v + 6))` |

---

### X22i (No ADB) (`x22i_noadb`) — Accessibility mode

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1845 | 785 | `(int)(785 - 23.636 * v)` | — |
| Incline | 75 | 785 | `658 - (int)(12 * v)` | from `snapshot.incline()` |

---

### X32i (`x32i`)

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Speed | 1845 | 927 | `(int)(834.85 - 26.946 * v)` |
| Incline | 75 | 881 | `(int)(734.07 - 12.297 * v)` |

---

### X32i (NTL39019) (`x32i_NTL39019`)

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Speed | 1845 | 779 | `(int)(817.5 - 42.5 * v * 0.621371)` *(mph input scaled to km/h)* |
| Incline | 75 | 740 | `(int)(749 - 11.8424 * v)` |

---

### X32i (NTL39221) (`x32i_NTL39221`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1845 | 579 | `(int)(900.26 - 46.63 * v * 0.621371)` *(mph scaled)* | from `snapshot.speed()` |
| Incline | 75 | 635 | `750 - (int)(v * 12.05)` | from `snapshot.incline()` |

---

### C1750 (`c1750`)
**Reader:** CatFileMetricReader

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1845 | 793 | `785 - (int)((v - 1.0) * 31.42)` | from `snapshot.speed()` |
| Incline | 75 | 694 | `(int)(700 - 34.9 * v)` | — |

---

### C1750 (2020) (`c1750_2020`)
**Reader:** CatFileMetricReader

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1205 | 575 | `575 - (int)((v * 0.621371 - 1.0) * 28.91)` *(mph scaled)* | from `snapshot.speed()` |
| Incline | 75 | 525 | `520 - (int)(v * 20)` | from `snapshot.incline()` |

---

### C1750 (2020 KPH) (`c1750_2020_kph`)
**Reader:** CatFileMetricReader

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1205 | 598 | lookup table | from `snapshot.speed()` |
| Incline | 75 | 525 | lookup table (`INCLINE_TABLE`) | from `snapshot.incline()` |

---

### C1750 (MPH -3% Grade) (`c1750_mph_minus3grade`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1205 | 603 | `603 - (int)((v * 0.621371 - 0.5) * 21.722)` *(mph scaled)* | from `snapshot.speed()` |
| Incline | 75 | 603 | `603 - (int)((v + 3.0) * 21.722)` | from `snapshot.incline()` |

---

### C1750 (NTL14122.2 MPH) (`c1750_NTL14122_2_MPH`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1845 | 787 | `787 - (int)(v * 43.5)` | from `snapshot.speed()` |
| Incline | 75 | 787 | `787 - (int)((v + 3) * 29)` | from `snapshot.incline()` |

---

### C1750 (2021) (`c1750_2021`)
**Reader:** CatFileMetricReader

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1205 | 592 | `620 - (int)((v - 1.0) * 20.73)` | from `snapshot.speed()` |
| Incline | 75 | 547 | `(int)(553 - 22 * v)` | — |

---

### T6.5s, T7.5s, Grand Tour Pro

These three devices share the `T65sDevice` geometry — only the display name and metric reader differ.

| DeviceId | Display name | Reader |
|----------|-------------|--------|
| `t65s` | T6.5s Treadmill | TailGrepMetricReader (default) |
| `t75s` | T7.5s Treadmill | LogcatDumpMetricReader |
| `grand_tour_pro` | Grand Tour Pro Treadmill | DirectLogcatMetricReader |

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Speed | 1205 | 495 | `(int)(578.36 - 35.866 * v * 0.621371)` *(mph scaled)* |
| Incline | 75 | 585 | `(int)(576.91 - 34.182 * v)` |

---

### T8.5s (`t85s`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1205 | 609 | `(int)(629.81 - 20.81 * v)` | from `snapshot.speed()` |
| Incline | 75 | 609 | `(int)(609 - 36.417 * v)` | from `snapshot.incline()` |

---

### T9.5s (`t95s`) — Accessibility mode

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1845 | 817 | `847 - (int)(30.0 * v)` | from `snapshot.speed()` |
| Incline | 75 | 817 | `846 - (int)(46.0 * v)` | from `snapshot.incline()` |

---

### S40 (`s40`)

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Speed | 950 | 482 | `(int)(507 - 12.5 * v)` |
| Incline | 74 | 490 | `(int)(490 - 21.4 * v)` |

---

### NordicTrack 2450 (`nordictrack_2450`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1845 | 807 | `(int)(-26.33 * (v * 0.621371) + 831.39)` *(mph scaled)* | from `snapshot.speed()` |
| Incline | 75 | 717 | `715 - (int)((v + 3) * 29.26)` | from `snapshot.incline()` |

---

### NordicTrack 2950 (`nordictrack_2950`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1845 | 807 | `807 - (int)((v - 1.0) * 31)` | from `snapshot.speed()` |
| Incline | 75 | 717 | `807 - (int)((v + 3) * 31.1)` | from `snapshot.incline()` |

---

### NordicTrack 2950 (Max Speed 22) (`nordictrack_2950_maxspeed22`)

Same incline geometry as `nordictrack_2950`. Speed formula adjusted for lower maximum:

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1845 | 807 | `682 - (int)((v - 1.0) * 26.5)` | from `snapshot.speed()` |
| Incline | 75 | 717 | `807 - (int)((v + 3) * 31.1)` | from `snapshot.incline()` |

---

### ProForm 2000 (`proform_2000`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1205 | 598 | `(int)(631.03 - 19.921 * v)` | — |
| Incline | 75 | 522 | `520 - (int)((v + 3) * 21.804)` | from `snapshot.incline()` |

---

### ProForm Carbon T14 (`proform_carbon_t14`)
**Reader:** CatFileMetricReader

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Speed | 1845 | 807 | `(int)(810 - 52.8 * v * 0.621371)` *(mph scaled)* |
| Incline | 75 | 844 | `(int)(844 - 46.833 * v)` |

---

### ProForm Pro 9000 (`proform_pro_9000`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1845 | 800 | `800 - (int)((v * 0.621371 - 1.0) * 41.667)` *(mph scaled)* | from `snapshot.speed()` |
| Incline | 75 | 715 | `720 - (int)(v * 34.583)` | from `snapshot.incline()` |

---

### Elite 1000 and ProForm Pro 2000

Both share `Elite1000Device` geometry — only the display name differs.

| DeviceId | Display name |
|----------|-------------|
| `elite1000` | Elite 1000 Treadmill |
| `proform_pro_2000` | ProForm Pro 2000 Treadmill |

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 1205 | 600 | `600 - (int)(v * 0.621371 * 31.33)` *(mph scaled)* | from `snapshot.speed()` |
| Incline | 75 | 600 | `589 - (int)(v * 32.8)` | from `snapshot.incline()` |

---

### Elite 900 (`elite900`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 950 | 450 | `450 - (int)(v * 14.705)` | from `snapshot.speed()` |
| Incline | 74 | 450 | `450 - (int)(v * 20.83)` | from `snapshot.incline()` |

---

### EXP 7i (`exp7i`)

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Speed | 950 | 430 | `453 - (int)((v * 0.621371 - 1.0) * 22.702)` *(mph scaled)* | from `snapshot.speed()` |
| Incline | 74 | 442 | `442 - (int)(v * 21.802)` | from `snapshot.incline()` |

---

## Other

### SE9i Elliptical (`se9i_elliptical`)

Physically an elliptical but treated as a bike (extends `BikeDevice`). Incline range 0–20 levels → Y 858..208; resistance levels 1–24 → Y 858..208.

| Slider | trackX | Initial Y | Formula | currentThumbY |
|--------|--------|-----------|---------|---------------|
| Incline | 75 | 858 | `858 - (int)(v * (858-208) / 20.0)` | from `snapshot.incline()` |
| Resistance | 1845 | 858 | `858 - (int)((v-1) * (858-208) / 23.0)` | from `snapshot.resistance()` |

---

### Other Treadmill (`other`)

Fallback device. Uses ProForm 2000 geometry without `currentThumbY`. Useful for initial testing on unknown hardware.

| Slider | trackX | Initial Y | Formula |
|--------|--------|-----------|---------|
| Speed | 1205 | 0 | `(int)(631.03 - 19.921 * v)` |
| Incline | 75 | 0 | `(int)(520.11 - 21.804 * v)` |

---

## Adding a New Device

1. Create a class in `device/bike/` (extends `BikeDevice`) or `device/treadmill/` (extends `TreadmillDevice`).
2. Pass one or two anonymous `Slider` subclasses to `super()`. Construct each as `new Slider(initialThumbY, ScreenProfile.Wxxx.leftTrackX)` or `new Slider(initialThumbY, ScreenProfile.Wxxx.rightTrackX)` — choose the profile that matches the device's screen width (W1920=1920px, W1280=1280px, W1024=1024px, W800=800px). Each subclass must supply `targetY()`; optionally override `quantize()`, `currentThumbY()`, and `hysteresisPixels()`.
3. Override `displayName()`.
4. **Shell mode:** override `requiresAdb()` to return `false`; add a `ShellRuntime` field and wire `commandExecutor = shellRuntime::exec` in the constructor.
5. **Accessibility mode:** override `requiresAdb()` to return `false`, `requiresAccessibility()` to return `true`, and `swipe()` to call `MyAccessibilityService.performSwipe(x, y1, x, y2, 200)`.
6. Add a `DeviceId` enum value to `DeviceRegistry.DeviceId` and a `m.put(DeviceId.my_device, new MyDevice())` line in `DeviceRegistry.DEVICES`.
7. Add the `DeviceId` to the appropriate list in `DeviceAdapter` — `BIKE_DEVICES`, `TREADMILL_DEVICES`, or `OTHER_DEVICES`. The UI is not automatic; if you skip this step the device will not appear in the app.
8. Add formula tests in `BikeDeviceTest` or `TreadmillDeviceTest`. See [testing-methodology.md](testing-methodology.md) for the pattern.

See `S22iDevice` + `BikeDevice` for the canonical bike example, `X22iDevice` + `TreadmillDevice` for treadmill, and `S22iNoAdbDevice` for accessibility mode.

---

## Deriving Slider Formulas

The formula `targetY(v)` is a linear mapping: `Y = a - b * v`.

From two known (value, Y) pairs:
```
b = (Y1 - Y2) / (v2 - v1)
a = Y1 + b * v1
```

For more than two points, use `FormulaFitter.fit()` (least-squares; also reports R² and hysteresis classification). The interactive calibration flow in `calibrate-device.sh` automates the sweep and calls the fitter — see `calibration-runbook.md`.

To observe current slider positions: `adb shell screencap -p /sdcard/screen.png` or use the OCR calibration UI in `CalibrationActivity`.

---

## Validating Slider Coordinates Against the APK Layout

All `trackX()` and `targetY()` values can be cross-checked against the iFit APK's Android layout resources without hardware. Run:

```bash
python3 tools/validate_swipe_targets.py
```

Exit code 0 means all checks pass. The script reads the decoded APK (`ifit_decoded/res/`) and all device Java files.

### How the validator derives expected trackX values

Constants are anchored to **iFit APK 2.6.90** (versionCode 4963). The iFit workout HUD (`inworkouttablet.xml`) positions slider containers using two dimensions from the APK:

```
workout_slider_margin =  12.0 dp   (gap between screen edge and slider container)
workout_slider_width  = 125.0 dp   (container width; track is centred at 50%)
```

At the iFit tablet's density (1 dp = 1 px on all tested models), the expected track centres are:

| Slider side | Expected trackX | Derivation |
|-------------|----------------|------------|
| Left (incline / speed) | ≈ 75 px | `12 + 125 / 2 = 74.5 dp` |
| Right (resistance / speed) | screen\_width − 75 px | e.g. `1920 − 74.5 = 1845.5 → 1845 px` |

The right-slider trackX also implies the device's screen width:

| right trackX | Inferred screen width | Devices |
|---|---|---|
| ~725  | 800 px  | X9i |
| ~950  | 1024 px | Elite 900, EXP 7i, NTEX71021, ProForm Carbon E7, S40 |
| ~1205 | 1280 px | C1750 (2020/2021), ProForm 2000, T6.5s family, X11i, TDF10, ProForm Carbon C10 |
| ~1845 | 1920 px | S22i, S27i, X22i/X32i family, C1750, NordicTrack 2450/2950, ProForm Carbon T14, T9.5s, X14i |

### Checks the validator runs

| Check | What it verifies |
|-------|-----------------|
| **A — Horizontal position** | `trackX ≈ 74.5` for left sliders; right `trackX + 74.5` lands on a recognised screen width (±15 px) |
| **B — Initial thumb vs. formula** | `new Slider(initialThumbY)` should equal `targetY(0)` for incline/speed sliders |
| **C — Monotonicity** | Higher metric values produce lower Y (slider moves up); inverted slopes are flagged |
| **D — Sindarin global bounds** | `targetY()` at `MaxIncline=40°`, `MinIncline=−20°`, and practical max speed 22 km/h must land within `[0, screen_height]` |

### Known anomalies

All trackX values are now standardised to iFit APK 2.6.90 (`ScreenProfile` constants). Devices that previously had hardware-calibrated trackX values deviating from the APK layout (ProForm Pro 9000, ProForm Studio Bike Pro 2.2, SE9i Elliptical, and others) have been updated. The original calibrated values are preserved in constructor comments in the Java source for reference.
