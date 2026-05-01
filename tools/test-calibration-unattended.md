# Unattended Calibration Test Plan

**Executor:** Claude Code agent  
**Target:** S22i at `192.168.1.213:5555`  
**Package:** `org.cagnulein.qzcompanionnordictracktreadmill` (alias `$PKG`)  
**Goal:** Build → Install → Configure → Run `discover-device.py` → Verify sliders respond to UDP commands  
**Human intervention required:** None (all steps are automated including iFit navigation)

---

## How to Invoke

From a Claude Code session in this repo:

```
Run the unattended calibration test defined in tools/test-calibration-unattended.md
```

The agent reads this document and executes each phase in order, aborting on any `FAIL` checkpoint.

---

## Environment Variables (set once at start of run)

```bash
DEVICE=192.168.1.213:5555
PKG=org.cagnulein.qzcompanionnordictracktreadmill
A11Y_SVC="$PKG/org.cagnulein.qzcompanionnordictracktreadmill.service.MyAccessibilityService"
APK=app/build/outputs/apk/debug/app-debug.apk
```

---

## Phase 0 — Pre-flight

### 0.1 ADB connectivity
```bash
adb connect $DEVICE
adb -s $DEVICE shell echo "ok"
```
**PASS:** output is `ok`  
**FAIL:** abort — device not reachable; check Wi-Fi and ADB-over-TCP setting on tablet.

### 0.2 Build environment
```bash
java -version 2>&1 | grep "21\."
```
**PASS:** Java 21 confirmed  
**FAIL:** `gradle.properties` points to wrong JVM; edit `org.gradle.java.home`.

---

## Phase 1 — Build

```bash
./gradlew assembleDebug 2>&1 | tail -5
```
**PASS:** last line contains `BUILD SUCCESSFUL`  
**FAIL:** read full output, identify compilation error, fix, re-run before proceeding.

---

## Phase 2 — Install

```bash
adb -s $DEVICE install -r $APK
```
**PASS:** output contains `Success`  
**FAIL:** if `INSTALL_FAILED_VERSION_DOWNGRADE`, retry with `install -r -d`. If other error, examine message.

---

## Phase 3 — Permissions

Run all three; verify each succeeds silently (non-zero exit = failure).

```bash
# Lets MonoStdoutMetricReader stream iFit logcat from within the app
adb -s $DEVICE shell pm grant $PKG android.permission.READ_LOGS

# Lets MainActivity read/write /sdcard/qz-calibration.json on Android 11+
adb -s $DEVICE shell appops set $PKG MANAGE_EXTERNAL_STORAGE allow
```

**If `appops set` returns an error:** run instead:
```bash
adb -s $DEVICE shell pm grant $PKG android.permission.MANAGE_EXTERNAL_STORAGE
```
If that also fails, skip — `/sdcard/` is still writable via `adb push` and the app can read it if granted at the OS level.

---

## Phase 4 — Enable Accessibility Service

`adb shell` runs as the `shell` user which has `WRITE_SECURE_SETTINGS` — this bypasses the manual Settings UI.

```bash
adb -s $DEVICE shell settings put secure enabled_accessibility_services "$A11Y_SVC"
adb -s $DEVICE shell settings put secure accessibility_enabled 1
```

**Verify:**
```bash
adb -s $DEVICE shell settings get secure enabled_accessibility_services
```
**PASS:** output contains `qzcompanionnordictracktreadmill`  
**FAIL:** the OEM locks `secure` settings writes. Abort and ask user to enable manually at Settings → Accessibility.

---

## Phase 5 — Activate iFit Manual Workout

This phase navigates iFit to an active manual ride so that `Changed Grade to:` events flow into logcat. It uses `uiautomator dump` to inspect the live screen state and `input tap` to interact — no hardcoded coordinates.

### 5.1 Launch iFit
```bash
adb -s $DEVICE shell monkey -p com.ifit.standalone -c android.intent.category.LAUNCHER 1
sleep 5
```

### 5.2 Discover current screen and navigate to Manual Ride

Repeat the following loop up to 8 times (≈ 40 seconds total), advancing one step per iteration:

```bash
adb -s $DEVICE shell uiautomator dump /sdcard/ui.xml
adb -s $DEVICE pull /sdcard/ui.xml /tmp/ifit-ui.xml
```

Parse `/tmp/ifit-ui.xml` to find the first matching rule below and execute the corresponding tap:

| Priority | Match text (case-insensitive, in any `text=` or `content-desc=` attribute) | Action |
|---|---|---|
| 1 | `"let's go"` or `"lets go"` or `"get started"` | Tap it — dismiss welcome screen |
| 2 | `"workouts"` or `"explore"` or `"start"` (in nav/tab area) | Tap it — navigate to workout library |
| 3 | `"manual"` or `"manual ride"` or `"manual workout"` | Tap it — select manual workout |
| 4 | `"go"` or `"start ride"` or `"begin"` (large button, not nav) | Tap it — start the workout |
| 5 | `"resume"` | Tap it — resume a paused workout |

To tap an element found at bounds `[left,top][right,bottom]`:
```bash
# mid_x = (left + right) / 2,  mid_y = (top + bottom) / 2
adb -s $DEVICE shell input tap $mid_x $mid_y
sleep 5
```

**After each tap:** check logcat for metric events — if found, skip remaining iterations.

```bash
adb -s $DEVICE logcat -d -s mono-stdout | grep "Changed" | tail -5
```

### 5.3 Verify metric events are flowing
```bash
# Clear stale events, then wait 8 seconds for fresh ones
adb -s $DEVICE logcat -c
sleep 8
adb -s $DEVICE logcat -d -s mono-stdout | grep "Changed"
```
**PASS:** at least one `Changed Grade to:` or `Changed Resistance to:` line  
**FAIL:** navigate back to phase 5.2 and try again (up to 3 retries). If still failing after 3 retries, abort with message: "iFit workout not active — open iFit, start Manual Ride, press GO, then re-run."

---

## Phase 6 — Launch QZCompanion

```bash
adb -s $DEVICE shell settings put system screen_off_timeout 600000
adb -s $DEVICE shell am start -n $PKG/.MainActivity
sleep 3
```

Grant the runtime storage permission dialog if present:
```bash
adb -s $DEVICE shell uiautomator dump /sdcard/ui.xml
adb -s $DEVICE pull /sdcard/ui.xml /tmp/qz-ui.xml
# If "Allow" button is visible in the XML, tap it
```

---

## Phase 7 — Run `discover-device.py`

```bash
python3 tools/discover-device.py --device $DEVICE --push 2>&1 | tee /tmp/calibration-run.log
```

This step takes approximately **8–12 minutes** (coarse + fine sweeps for both sliders).

**PASS criteria** — all must be true:
1. Output contains `BUILD SUCCESSFUL` — not needed, script exits 0
2. Output contains `✓ Written: qz-calibration.json`
3. Output contains `✓ Pushed to /sdcard/qz-calibration.json`
4. Incline R² ≥ 0.97 (grep: `Fit: origin=.* R²=0\.[0-9][0-9]` where value ≥ 0.97)
5. No `⚠ poor fit` warning for incline

**WARN (non-blocking):**
- Resistance R² < 0.97 — note but continue; resistance is optional
- Resistance sweep skipped (< 3 readings) — note but continue

**FAIL (abort):**
- Script exits non-zero
- Incline has fewer than 3 fine points
- `ERROR:` line in output

---

## Phase 8 — Restart QZCompanion and Verify Calibration Loaded

```bash
adb -s $DEVICE shell am force-stop $PKG
sleep 2
adb -s $DEVICE logcat -c
adb -s $DEVICE shell am start -n $PKG/.MainActivity
sleep 5
```

Check logcat for calibration load confirmation:
```bash
adb -s $DEVICE logcat -d | grep "QZ:Main"
```
**PASS:** contains `Loaded calibration from qz-calibration.json`  
**FAIL:** contains `qz-calibration.json load failed` — print the error line; likely a JSON parse error.

Check UI shows correct device:
```bash
adb -s $DEVICE shell uiautomator dump /sdcard/ui.xml
adb -s $DEVICE pull /sdcard/ui.xml /tmp/qz-post.xml
# Verify "Custom (Calibrated)" appears in XML
```
**PASS:** `Custom (Calibrated)` found in XML  
**FAIL:** wrong device selected — check SharedPreferences deviceId key; may need to select manually.

---

## Phase 9 — Smoke Test: Incline Command

Send an incline command over UDP. Packet format: `"<grade>;-100"` (2 fields, `;` delimited).

```bash
adb -s $DEVICE logcat -c
# Send incline 3% command to QZCompanion on the tablet
# nc (netcat) must be available on the host; -u = UDP, -w1 = 1s timeout
echo -n "3.0;-100" | nc -u -w1 192.168.1.213 8003
sleep 6
```

Check logcat for dispatch and gesture:
```bash
adb -s $DEVICE logcat -d | grep -E "QZ:Dispatch|GestureResult|requestIncline"
```
**PASS:** log contains `requestIncline(bike): 3.0` and either `applyIncline` or a `GestureResultCallback` completion line  
**WARN:** log contains `de-dup: skipping incline` — slider already at 3%; send a different value (e.g., 6%) and recheck.  
**FAIL:** no dispatch log at all — QZCompanion may not be receiving UDP; check firewall/network.

---

## Phase 10 — Smoke Test: Resistance Command

Send a resistance command. Packet format: `"<level>"` (1 field).

```bash
adb -s $DEVICE logcat -c
echo -n "5" | nc -u -w1 192.168.1.213 8003
sleep 6
adb -s $DEVICE logcat -d | grep -E "QZ:Dispatch|requestResistance|applyResistance"
```
**PASS:** log contains `requestResistance(bike): 5.0` and `applyResistance(bike): 5.0`  
**SKIP (not FAIL):** if resistance sweep was skipped in Phase 7, resistance slider is null — skip this phase.

---

## Phase 11 — Cleanup and Report

Restore screen timeout:
```bash
adb -s $DEVICE shell settings put system screen_off_timeout 60000
```

Print summary:
```bash
echo "=== Calibration Values ==="
cat qz-calibration.json

echo ""
echo "=== Sweep R² ==="
grep "Fit:" /tmp/calibration-run.log

echo ""
echo "=== Verdict ==="
# PASS if Phase 7 R² ≥ 0.97, Phase 9 gesture confirmed, Phase 10 gesture confirmed (or skipped)
```

---

## Abort / Error Handling Summary

| Phase | Abort condition | Recovery hint |
|---|---|---|
| 0 | ADB not reachable | Check Wi-Fi, re-enable ADB over TCP |
| 1 | Build fails | Fix compilation error, re-run |
| 4 | `settings put secure` denied | User must enable Accessibility manually |
| 5 | No iFit metric events after 3 retries | User must start Manual Ride |
| 7 | Incline R² < 0.97 | Re-run sweep; check slider responsiveness |
| 8 | JSON load failed | Check `/sdcard/qz-calibration.json` content |
| 9 | No UDP dispatch | Check same-subnet routing; try from tablet itself |

---

## Estimated Total Runtime

| Phase | Duration |
|---|---|
| Build | ~3 min |
| Install + permissions | < 1 min |
| iFit navigation | 1–2 min |
| discover-device.py sweep | 8–12 min |
| Smoke tests | 2 min |
| **Total** | **~15–20 min** |
