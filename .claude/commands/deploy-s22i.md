# /deploy-s22i — Build and install on S22i at 192.168.1.213

## Step 1 — ADB connectivity

```bash
adb connect 192.168.1.213:5555
adb -s 192.168.1.213:5555 shell echo "ok"
```

**PASS:** output is `ok`. If not, abort — check Wi-Fi and ADB-over-TCP on the tablet.

## Step 2 — Build

```bash
./gradlew assembleDebug 2>&1 | tail -5
```

**PASS:** last line contains `BUILD SUCCESSFUL`. If not, read the full error, fix it, and re-run before continuing.

## Step 3 — Install

```bash
adb -s 192.168.1.213:5555 install -r app/build/outputs/apk/debug/app-debug.apk
```

**PASS:** output contains `Success`. If `INSTALL_FAILED_VERSION_DOWNGRADE`, retry with `-r -d`.

## Step 3b — Verify Installed Version

```bash
PKG=org.cagnulein.qzcompanionnordictracktreadmill
DEVICE=192.168.1.213:5555
BUILT=$(grep "^versionName" version.properties | cut -d= -f2 | tr -d '[:space:]')
INSTALLED=$(adb -s $DEVICE shell dumpsys package $PKG | grep versionName | cut -d= -f2 | tr -d '[:space:]')
LOCAL_HASH=$(git rev-parse --short HEAD)
echo "Built: $BUILT  |  Installed: $INSTALLED"
echo "Commit: $LOCAL_HASH"
git diff --quiet && echo "Working tree: clean" || echo "WARN: working tree dirty — installed APK may not match HEAD"
[ "$BUILT" = "$INSTALLED" ] && echo "PASS (version)" || echo "FAIL: version mismatch"
```

`BuildConfig.GIT_HASH` comparison against the device happens in Step 7 once the app is running (the hash is shown in the action bar subtitle).

**PASS:** `Built` and `Installed` match and working tree is clean.  
**WARN:** dirty working tree — local changes were not included in the build hash; consider stashing and rebuilding.  
**FAIL:** version mismatch — previous APK is still installed; re-run Step 3 with `-r -d`, or force-stop the app and retry.

## Step 4 — Enable Verbose Logging

Write the `debugLog` SharedPreference before the app launches so it takes effect on first open:

```bash
PKG=org.cagnulein.qzcompanionnordictracktreadmill
DEVICE=192.168.1.213:5555
PREFS="/data/data/$PKG/shared_prefs/QZ.xml"
adb -s $DEVICE shell run-as $PKG sh -c "
  if [ -f '$PREFS' ] && grep -q debugLog '$PREFS'; then
    sed -i 's/name=\"debugLog\" value=\"[^\"]*\"/name=\"debugLog\" value=\"true\"/' '$PREFS'
  elif [ -f '$PREFS' ]; then
    sed -i 's|</map>|<boolean name=\"debugLog\" value=\"true\" /></map>|' '$PREFS'
  else
    printf '<map>\n<boolean name=\"debugLog\" value=\"true\" />\n</map>' > '$PREFS'
  fi
"
```

**PASS:** command returns silently (no error output). Open the app — the overflow menu should show **Verbose Logging** checked.

## Step 5 — Permissions

```bash
PKG=org.cagnulein.qzcompanionnordictracktreadmill
DEVICE=192.168.1.213:5555
adb -s $DEVICE shell pm grant $PKG android.permission.READ_LOGS
adb -s $DEVICE shell pm grant $PKG android.permission.WRITE_SECURE_SETTINGS
adb -s $DEVICE shell appops set $PKG MANAGE_EXTERNAL_STORAGE allow
```

All three should return silently. Non-zero exit on the last one is fine — skip it if it errors.

## Step 6 — Activate iFit Manual Workout

Launch iFit and navigate to an active manual ride so that gestures complete against real slider UI.

```bash
DEVICE=192.168.1.213:5555
adb -s $DEVICE shell monkey -p com.ifit.standalone -c android.intent.category.LAUNCHER 1
sleep 5
```

Repeat the following loop up to 8 times (≈ 40 s), advancing one step per iteration:

```bash
adb -s $DEVICE shell uiautomator dump /sdcard/ui.xml
adb -s $DEVICE pull /sdcard/ui.xml /tmp/ifit-ui.xml
```

Parse `/tmp/ifit-ui.xml` and tap the first matching rule:

| Priority | Match (case-insensitive, `text=` or `content-desc=`) | Action |
|---|---|---|
| 0 | `"manual start"` | Tap — starts manual workout from dashboard |
| 1 | `"end warmup"` | Tap — skip warmup countdown |
| 2 | `"let's go"` / `"lets go"` / `"get started"` | Tap — dismiss welcome |
| 3 | `"workouts"` / `"explore"` / `"start"` (nav area) | Tap — go to workout library |
| 4 | `"manual"` / `"manual ride"` / `"manual workout"` | Tap — select manual workout |
| 5 | `"go"` / `"start ride"` (large button) | Tap — start the workout |
| 6 | `"resume"` | Tap — resume paused workout |

Do **not** match `"begin"` as a substring — `"Workout begins in"` is a countdown label, not a button.

Tap via:
```bash
# mid_x = (left + right) / 2,  mid_y = (top + bottom) / 2
adb -s $DEVICE shell input tap $mid_x $mid_y
sleep 5
```

After each tap check for metric events; exit loop early if found:
```bash
adb -s $DEVICE logcat -d -s mono-stdout | grep "Changed" | tail -5
```

Verify workout is active:
```bash
adb -s $DEVICE logcat -c
sleep 8
adb -s $DEVICE logcat -d -s mono-stdout | grep "Changed"
```

**PASS:** at least one `Changed Grade to:` or `Changed Resistance to:` line  
**FAIL:** no metrics after 3 retries — abort; manually start iFit Manual Ride, then re-run from this step.

## Step 7 — Launch QZCompanion

```bash
PKG=org.cagnulein.qzcompanionnordictracktreadmill
DEVICE=192.168.1.213:5555
adb -s $DEVICE shell am force-stop $PKG
sleep 1
adb -s $DEVICE logcat -c
adb -s $DEVICE shell am start -n $PKG/.ui.MainActivity
sleep 5
adb -s $DEVICE logcat -d | grep "QZ:" | grep "Listening on UDP port"
```

**PASS:** line contains `Listening on UDP port 8003`  
**FAIL:** no output — app may have crashed; check full logcat.

**Verify device selection:** The device picker card (below the requirements card) shows the previously saved device. Confirm it reads the correct S22i variant. The device list is collapsed by default — if the wrong device is shown or this is a fresh install, tap the picker card to expand, select the correct S22i variant, then tap **Save**. The card label and status chip both update immediately.

Verify the installed commit matches local HEAD via the action bar subtitle (`v<version>  ·  dev-<hash>` for local builds):

```bash
DEVICE=192.168.1.213:5555
adb -s $DEVICE shell uiautomator dump /sdcard/qz-ui.xml 2>/dev/null
adb -s $DEVICE pull /sdcard/qz-ui.xml /tmp/qz-ui.xml 2>/dev/null
python3 - << 'EOF'
import xml.etree.ElementTree as ET, subprocess, sys
local = subprocess.check_output(['git', 'rev-parse', '--short', 'HEAD']).decode().strip()
try:
    root = ET.parse('/tmp/qz-ui.xml').getroot()
    for node in root.iter('node'):
        t = node.get('text', '') or ''
        if 'dev-' in t:
            device = t[t.index('dev-') + 4:].strip()
            ok = device == local
            print(f"Hash: local={local}  device={device}  {'PASS' if ok else 'FAIL: mismatch'}")
            sys.exit(0 if ok else 1)
    print(f"WARN: subtitle not found (CI build shows version instead of hash); local={local}")
except Exception as e:
    print(f"WARN: could not check hash: {e}")
EOF
```

**PASS:** `Hash: local=<hash>  device=<hash>  PASS`  
**FAIL:** hash mismatch — a stale APK is installed; re-run from Step 2.  
**WARN:** subtitle not found — CI build or UI dump timing; verify manually or proceed if version check passed.

## Step 7.5 — Bring iFit to Foreground and Reset Sliders to Origin

QZCompanion launched in Step 7 is in the foreground; gestures target whichever window is focused. Bring iFit back to front, then reset both sliders to their origin positions using direct swipes computed from the live MonoStdout reading. Direct swipes bypass the QZ pipeline so de-dup state is not touched — after this step iFit's physical position matches what QZ's de-dup tracker already believes.

```bash
DEVICE=192.168.1.213:5555
adb -s $DEVICE shell monkey -p com.ifit.standalone -c android.intent.category.LAUNCHER 1
sleep 3
adb -s $DEVICE shell dumpsys activity | grep mFocusedActivity
```

**PASS:** output contains `com.ifit.standalone`.  
**FAIL:** QZ or another app is focused — repeat the monkey command.

**Reset incline to 0%:** read the current grade from MonoStdout, compute the slider's actual Y, and swipe directly to the origin Y (622):

```bash
DEVICE=192.168.1.213:5555
GRADE=$(adb -s $DEVICE logcat -d | grep "mono-stdout" | grep "Changed Grade" | tail -1 \
  | grep -oP '(?<=Changed Grade to: )-?[0-9]+')
[ -z "$GRADE" ] && GRADE=0
echo "Current grade: ${GRADE}%"
FROM_Y=$(python3 -c "print(int(622 - 18.57 * $GRADE))")
echo "Direct swipe: y=$FROM_Y → y=622"
adb -s $DEVICE shell input swipe 75 $FROM_Y 75 622 400
sleep 4
adb -s $DEVICE logcat -d | grep "mono-stdout" | grep "Changed Grade" | tail -3
```

**PASS:** `Changed Grade to: 0`

**Reset resistance to level 1:** same approach — read current gear, swipe to origin Y (802):

```bash
GEAR=$(adb -s $DEVICE logcat -d | grep "mono-stdout" | grep "Changed CurrentGear" | tail -1 \
  | grep -oP '(?<=Changed CurrentGear to: )[0-9]+')
[ -z "$GEAR" ] && GEAR=1
echo "Current gear: $GEAR"
FROM_Y=$(python3 -c "print(int(802 - 26.25 * ($GEAR - 1)))")
echo "Direct swipe: y=$FROM_Y → y=802"
adb -s $DEVICE shell input swipe 1845 $FROM_Y 1845 802 400
sleep 4
adb -s $DEVICE logcat -d | grep "mono-stdout" | grep "Changed CurrentGear" | tail -3
```

**PASS:** `Changed CurrentGear to: 1`

After this step iFit's sliders are physically at origin. QZ de-dup (`last=0.0` incline, `last=1.0` resistance) and `thumbY` already reflect origin — the direct swipes leave QZ's state unchanged. Steps 8 and 9 start from a clean, fully-aligned baseline.

**FAIL (either axis):** MonoStdout line absent — iFit must be in foreground and in an active workout; re-run Step 6.

## Step 8 — Smoke Test: Incline

Three consecutive commands cover positive → negative → origin, guaranteeing the de-dup guard never skips a gesture.

```bash
DEVICE=192.168.1.213:5555
PORT=8003

# 8a: Positive incline (3%)
adb -s $DEVICE logcat -c
echo -n "3.0;0" | nc -uN -w1 192.168.1.213 $PORT
sleep 5
adb -s $DEVICE logcat -d | grep -E "QZ:CmdListener|QZ:Dispatch|QZ:IFit"
adb -s $DEVICE logcat -d | grep "mono-stdout" | grep "Changed Grade" | tail -3
```
**PASS:** QZ log has `rx: 3.0;0`, `drain: incline=3.0`, `gesture completed`; mono-stdout has `Changed Grade to: 3` (or near value).

```bash
# 8b: Negative incline (-2% decline)
adb -s $DEVICE logcat -c
echo -n "-2.0;0" | nc -uN -w1 192.168.1.213 $PORT
sleep 5
adb -s $DEVICE logcat -d | grep -E "QZ:CmdListener|QZ:Dispatch|QZ:IFit"
adb -s $DEVICE logcat -d | grep "mono-stdout" | grep "Changed Grade" | tail -3
```
**PASS:** `drain: incline=-2.0`, `gesture completed`; mono-stdout has `Changed Grade to: -2` (or near value).

```bash
# 8c: Return to origin (0%)
adb -s $DEVICE logcat -c
echo -n "0.0;0" | nc -uN -w1 192.168.1.213 $PORT
sleep 5
adb -s $DEVICE logcat -d | grep -E "QZ:CmdListener|QZ:Dispatch|QZ:IFit"
adb -s $DEVICE logcat -d | grep "mono-stdout" | grep "Changed Grade" | tail -3
```
**PASS:** `drain: incline=0.0`, `gesture completed`; mono-stdout has `Changed Grade to: 0` (or near value).

**FAIL (any sub-step):**
- No `rx:` → UDP not reaching app; check same-subnet routing or try `python3 -c "import socket; s=socket.socket(socket.AF_INET,socket.SOCK_DGRAM); s.sendto(b'3.0;0', ('192.168.1.213', 8003)); s.close()"` as fallback.
- `rx:` present but no `drain:` → command decode failure; unexpected (re-check packet format).
- `drain:` present but `gesture CANCELLED` → iFit not in active workout; re-run Step 6.
- `drain:` present but no `QZ:IFit` lines → AccessibilityService not connected; re-run Step 5 and relaunch app.
- `gesture completed` but no `Changed Grade` → hardware lag; increase sleep to 8 s and retry the mono-stdout check.

## Step 9 — Smoke Test: Resistance

Two commands: positive level → origin (level 1). Uses the 1-field packet format (resistance only).

```bash
DEVICE=192.168.1.213:5555
PORT=8003

# 9a: Positive resistance (level 5)
adb -s $DEVICE logcat -c
echo -n "5" | nc -uN -w1 192.168.1.213 $PORT
sleep 5
adb -s $DEVICE logcat -d | grep -E "QZ:CmdListener|QZ:Dispatch|QZ:IFit"
adb -s $DEVICE logcat -d | grep "mono-stdout" | grep -E "Changed Resistance|Changed CurrentGear" | tail -3
```
**PASS:** `rx: 5`, `drain: resistance=5.0`, `gesture completed`; mono-stdout has `Changed CurrentGear to: 5` (S22i) or `Changed Resistance to: 5` (near value).

```bash
# 9b: Return to origin (level 1)
adb -s $DEVICE logcat -c
echo -n "1" | nc -uN -w1 192.168.1.213 $PORT
sleep 5
adb -s $DEVICE logcat -d | grep -E "QZ:CmdListener|QZ:Dispatch|QZ:IFit"
adb -s $DEVICE logcat -d | grep "mono-stdout" | grep -E "Changed Resistance|Changed CurrentGear" | tail -3
```
**PASS:** `rx: 1`, `drain: resistance=1.0`, `gesture completed`; mono-stdout has `Changed CurrentGear to: 1` (S22i) or `Changed Resistance to: 1` (near value).

**WARN:** if `QZ:Dispatch` shows `drop:` — queue is full; wait 10 s and retry.  
**FAIL:** same failure tree as Step 8.
