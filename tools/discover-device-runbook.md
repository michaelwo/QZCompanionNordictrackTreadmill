# Runbook: Calibrating a New iFit Device with `discover-device.py`

Run this once per physical device to generate the slider calibration file (`qz-calibration.json`) that QZCompanion loads at startup. No APK rebuild required.

---

## Prerequisites

| Requirement | Notes |
|---|---|
| `adb` in `PATH` | Android SDK Platform Tools; verify with `adb version` |
| Python 3.6+ | stdlib only — no pip installs |
| iFit tablet powered on, screen unlocked | |
| ADB over TCP enabled on tablet | See "Enable ADB over TCP" below |
| iFit app open in an **active manual workout** | Slider events are only emitted during an active session |

### Enable ADB over TCP (one-time per tablet)

The tablet must have Developer Options unlocked and ADB over Wi-Fi enabled.

1. **Settings → About tablet → Software information** — tap "Build number" 7 times to unlock Developer Options.
2. **Settings → Developer options** → enable "USB debugging" and "Wireless debugging".
3. Note the tablet's IP address: **Settings → About tablet → Status information → IP address**.
4. From your laptop:
   ```bash
   adb connect <tablet-ip>:5555
   adb devices   # confirm device appears as "device"
   ```

---

## Step-by-Step

### 1. Start an active manual workout in iFit

1. Open iFit on the tablet.
2. Tap **Workouts → Manual Workout → Manual Ride** (or Manual Run for treadmills).
3. Tap **GO** — the workout timer must be running.
4. Leave the workout screen visible; do not navigate away.

> The script aborts with an error if no metric events arrive within 15 seconds. This is the most common failure mode.

### 2. Run the calibration script (dry run first)

```bash
python3 tools/discover-device.py --device <tablet-ip>:5555
```

The script will:
1. Print the detected screen resolution and track X coordinates.
2. Wait up to 15s for iFit metric events to confirm the workout is active.
3. Sweep the **incline** slider (left track) coarse → fine.
4. Sweep the **resistance** slider (right track) coarse → fine.
5. Fit linear formulas and print R² values.
6. Write `qz-calibration.json` in the current directory.

**Do not use `--push` on first run.** Inspect the output and verify R² before applying.

### 3. Interpret the output

```
Screen: 1920×1200
Track X — incline: 75  resistance: 1845

── Incline sweep (trackX=75) ──
    coarse y= 200 → (no change)
    coarse y= 250 → grade=3.0
    coarse y= 300 → grade=5.0
    ...
    fine   y= 230 → grade=2.50
    ...
  Fit: origin=622.1  scale=18.5700  R²=0.9981

── Resistance sweep (trackX=1845) ──
    ...
  Fit: origin=724.3  scale=17.4300  minLevel=1  R²=0.9962

✓ Written: qz-calibration.json
```

| Field | Meaning | Acceptable range |
|---|---|---|
| `origin` | Y pixel where slider sits at grade=0 (or resistance=minLevel) | — |
| `scale` | Pixels per unit change | > 0 |
| `R²` | Goodness of linear fit | ≥ 0.97 — below this the script warns `⚠ poor fit` |

If resistance yields fewer than 3 readings it is skipped with a warning. The output JSON will contain only `"incline"` in that case; QZCompanion will function without resistance control.

### 4. Push to the tablet and restart QZCompanion

Once R² looks good:

```bash
python3 tools/discover-device.py --device <tablet-ip>:5555 --push
```

Then force-stop and restart QZCompanion:

```bash
PKG=org.cagnulein.qzcompanionnordictracktreadmill
adb -s <tablet-ip>:5555 shell am force-stop $PKG
adb -s <tablet-ip>:5555 shell am start -n $PKG/.MainActivity
```

On startup, `MainActivity` reads `/sdcard/qz-calibration.json` and automatically selects the **Custom (Calibrated)** device. Both incline and resistance sliders are active.

### 5. Verify in QZCompanion

1. Confirm the status chip shows **Custom (Calibrated)**.
2. Send a Zwift incline command via QZ; confirm the incline slider moves to the expected Y.
3. Send a resistance command; confirm the resistance slider responds.

---

## Optional Arguments

| Argument | Default | Description |
|---|---|---|
| `--device` | *(required)* | ADB device address, e.g. `192.168.1.213:5555` |
| `--push` | off | Push output JSON to `/sdcard/qz-calibration.json` after writing |
| `--out` | `qz-calibration.json` | Local output file path |

---

## Troubleshooting

### "ERROR: No iFit events received in 15s"

- The manual workout timer must be actively running. Open iFit → Manual Ride → GO.
- Verify ADB connectivity: `adb -s <ip>:5555 shell echo ok`
- Check logcat manually to confirm events are flowing:
  ```bash
  adb -s <ip>:5555 logcat -s mono-stdout | grep "Changed"
  ```

### "Only N coarse readings — need ≥ 3" (incline)

The incline slider is not responding to swipes. Possible causes:
- iFit UI is on a different screen (e.g. settings, not the active workout).
- Screen is locked or dimmed — keep the screen on during the sweep.
- `trackX` is wrong for this device's resolution. Check `screen_profile()` in the script against `ScreenProfile.java`.

### "WARNING: Only N coarse resistance readings — skipping"

Resistance is optional. The JSON will have `"incline"` only. QZCompanion will control incline but not resistance. To investigate:
- Confirm the device has a physical resistance slider (some treadmill models do not).
- Try swiping manually at `res_trackX` during an active workout and watch logcat.

### R² < 0.97 warning

The fit is non-linear — possibly the slider has a dead zone or the sweep range is too narrow. Try:
- Running the script again (sweep order matters; let iFit settle between runs).
- Checking for mechanical friction or resistance steps at certain levels.
- The calibration is still usable if R² is ≥ 0.95; the warning is advisory.

### QZCompanion still shows previous device after restart

`qz-calibration.json` must be at exactly `/sdcard/qz-calibration.json`. Verify:
```bash
adb -s <ip>:5555 shell ls -la /sdcard/qz-calibration.json
```
If missing, run with `--push` again or push manually:
```bash
adb -s <ip>:5555 push qz-calibration.json /sdcard/qz-calibration.json
```

---

## Output File Format

```json
{
  "incline": {
    "trackX": 75,
    "origin": 622.10,
    "scale": 18.5700
  },
  "resistance": {
    "trackX": 1845,
    "origin": 724.30,
    "scale": 17.4300,
    "minLevel": 1
  }
}
```

The `"resistance"` section is omitted if resistance calibration was skipped. `minLevel` is the lowest resistance level observed during the sweep (typically 1).

---

## Re-calibrating

Re-run the script any time slider accuracy degrades or after a screen resolution change. The new file overwrites the old one on push. Force-stop and restart QZCompanion to apply.
