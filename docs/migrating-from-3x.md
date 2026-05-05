# Migrating from 3.x to 4.x

This document is for contributors who know the 3.x codebase and want to get oriented in this refactored branch. It covers what changed, where things moved, and the new patterns for the tasks contributors do most — primarily adding devices and following the dispatch flow.

The [architecture.md](architecture.md) document covers the current design in full. This document covers the *delta*: what the 3.x codebase looked like, why it changed, and how to map your 3.x knowledge to the new structure.

---

## The Big Picture

The 3.x codebase had two large service files that did everything:

| File | Lines | What it did |
|------|-------|-------------|
| `UDPListenerService.java` | 1,072 | UDP receive loop, all device pixel constants (inline switch), all dispatch logic (inline if/else chains per device), throttle, cache, de-dup |
| `QZService.java` | 768 | Metric polling, all metric state (static floats), iFit v2 detection, delta broadcasting |

There were **zero tests**. De-duplication had a latent bug (using `!=` on boxed `Float` objects — reference equality, not value equality — so duplicate swipe commands were never suppressed).

The 4.x refactor broke both files apart along their natural seams:

- **Device knowledge** (pixel constants, quantization, hysteresis) moved into individual device classes — one file per device.
- **Dispatch policy** (throttle, FIFO queue) moved into `CommandDispatcher`; de-dup and the treadmill speed gate remain in the device classes.
- **Command routing** (`CommandDispatcher`) became a pure-Java, Android-free class that throttles, queues, and routes — testable without a device or emulator.
- **Metric state** moved out of static fields and into per-`Slider` live-metric values; `SliderMetric`-keyed `applyMetric()` calls on `Device` replace the old static float bag.
- **Service files** became thin Android glue — the business logic inside them is now independently testable.

The result is ~200 pure JVM tests, a much smaller diff when adding a new device, and dispatch bugs that are reproducible without hardware.

---

## Service Renames

The two main service files were renamed to say what they actually do:

| 3.x name | 4.x name |
|----------|----------|
| `UDPListenerService` | `QZCommandListenerService` |
| `QZService` | `QZMetricUnicastingService` |
| `MyAccessibilityService` | `GestureService` |

If you're searching the codebase for something that lived in `QZService` in 3.x, look in `QZMetricUnicastingService` first, then `Device` and its `Slider` instances (metric values live there now).

---

## Where Things Moved

| 3.x location | 4.x location |
|--------------|--------------|
| `UDPListenerService._device` enum | `DeviceRegistry.DeviceId` enum |
| `UDPListenerService.setDevice()` switch | `DeviceRegistry.DEVICES` EnumMap |
| Per-device pixel constants in `setDevice()` | Inside each device class (`device/bike/`, `device/treadmill/`) |
| Per-device dispatch `if/else` chains | `BikeDevice.applyCommand()` / `TreadmillDevice.applyCommand()` |
| `static long lastSwipeMs` | `CommandDispatcher.lastExecutedMs` (private, injectable-clock) |
| `static float lastSpeedFloat` etc. | Per-`Slider` live-metric values; `Device.applyMetric(SliderMetric, float)` updates them |
| `static boolean ifit_v2` | `MetricReader.forIfitV2()` — no flag; format adaptation is on the reader |
| OCR-based calibration in `QZService` + `CalibrationActivity` | Removed — calibration is now done by `tools/discover-device.py` (ADB sweep); `DeviceCalibration` loads the resulting `qz-calibration.json` at startup |
| Device selection in `MainActivity` (RadioGroup) | `DeviceAdapter` (RecyclerView, sectioned by type) |

---

## Adding a Device

This is the most common contributor task. The before/after difference is significant.

### 3.x — touch four places in one file

```java
// 1. Add to the _device enum in UDPListenerService.java
public enum _device {
    x11i,
    my_new_device,   // ← add here
    ...
}

// 2. Add pixel constants to the setDevice() switch
case my_new_device:
    y1Speed = 785;
    y1Inclination = 644;
    break;

// 3. Add an if-branch in the treadmill incline dispatch block (~line 490)
} else if (device == _device.my_new_device) {
    x1 = 47;
    y2 = (int)(644 - (30.7 * reqInclination));

// 4. Add an if-branch in the speed dispatch block (~line 640)
} else if (device == _device.my_new_device) {
    x1 = 47;
    y2 = (int)(785 - (37.2 * (reqSpeed - 2.0)));
```

There was no enforced structure — pixel constants, formulas, and dispatch logic were interspersed across hundreds of lines of a 1,000-line file. The additions had to be made carefully to avoid breaking other devices' logic.

### 4.x — one self-contained file, plus two registrations

Before writing Step 1, you need the ORIGIN constants and scale factors for the device. If you own the hardware, derive them empirically. If you don't, this is where `tools/discover-device.py` comes in: ask the user who reported the device to run the calibration sweep on their machine. The script fits a linear formula for each slider axis and prints the ORIGIN and scale values directly — those numbers become the constants in your device class, and the user can ride with Zwift immediately via `custom_calibrated` while the PR is in review.

**Step 1 — create the device class:**

```java
// app/src/main/java/.../device/treadmill/MyNewDevice.java
package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;

import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.InclineSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.SpeedSlider;

public class MyNewDevice extends TreadmillDevice {
    private static final int ORIGIN_INCLINE_THUMBY = 644;
    private static final int ORIGIN_SPEED_THUMBY   = 785;

    public MyNewDevice() {
        super(
            new InclineSlider(ScreenProfile.W1280.leftTrackX,  ORIGIN_INCLINE_THUMBY, MyNewDevice::offsetInclineThumbY),
            new SpeedSlider(ScreenProfile.W1280.rightTrackX, ORIGIN_SPEED_THUMBY,   MyNewDevice::offsetSpeedThumbY)
        );
    }
    @Override public String displayName() { return "My New Treadmill (MODEL)"; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int)(30.7 * v); }
    private static int offsetSpeedThumbY(double v)   { return ORIGIN_SPEED_THUMBY   - (int)(37.2 * (v - 2.0)); }
}
```

**Step 2 — register in `DeviceRegistry`:**

```java
// Add DeviceId value
public enum DeviceId { ..., my_new_device }

// Add entry to DEVICES map
.put(DeviceId.my_new_device, new MyNewDevice())
```

**Step 3 — add to the UI list in `DeviceAdapter`:**

```java
static final List<DeviceId> TREADMILL_DEVICES = Arrays.asList(
    ...,
    DeviceId.my_new_device
);
```

**Step 4 — validate the coordinates:**

```bash
python3 tools/validate_swipe_targets.py
```

This cross-checks your `trackX` values against the iFit APK layout XML and flags formula monotonicity and bounds issues. Exit code 0 means all checks pass. See the validator section in [device-reference.md](../app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill/device/device-reference.md) for what each check means.

The CLAUDE.md has the full pattern including bike devices, naming conventions, and the `ThumbYFormula` constructor. For a complete listing of all 44 supported devices with their pixel formulas, see [device-reference.md](../app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill/device/device-reference.md).

---

## The `Slider` Abstraction (new in 4.x)

In 3.x, pixel constants (`y1Speed`, `y1Inclination`, `y1Resistance`) were module-level static variables, and the formulas for computing target Y coordinates were repeated inline in each dispatch branch. If a device needed special behaviour (metric-derived starting position, directional overshoot), it added more inline conditionals.

In 4.x, a `Slider` encapsulates everything about one physical axis. `Slider` is abstract; four typed subclasses cover each axis kind:

| Subclass | `SliderMetric` | `commandFor()` returns |
|----------|---------------|----------------------|
| `InclineSlider` | `GRADE` | `InclineCommand` |
| `SpeedSlider` | `KPH` | `SpeedCommand` |
| `ResistanceSlider` | `RESISTANCE` | `ResistanceCommand` |
| `GearSlider` | `CURRENT_GEAR` | `GearCommand` |

Each device class constructs typed slider instances — `new InclineSlider(trackX, initialThumbY, Device::offsetInclineThumbY)`, `new SpeedSlider(...)` — where `offsetXxxThumbY` is a `private static` method in the device class. Sliders that must re-derive their current position from the live metric feed are constructed with the typed `.live()` static factory instead of `new`. Anonymous typed-slider subclasses are used only when `quantize`, `currentThumbY`, or `hysteresisPixels` also need overriding.

Each typed slider implements two abstract methods from `Slider`:
- `handle(double value, Device device)` — called by `cmd.applyTo(device)` via `device.sliderOf()`. De-duplicates against `lastApplied()` and calls `moveTo()`. `SpeedSlider` additionally gates on `liveValueOrZero()`: if the belt is stopped, the speed is cached and released when `KPH > 0` arrives.
- `commandFor(double value)` — creates the matching `Command` subclass. Called by `BikeDevice`/`TreadmillDevice` in `decodeCommands()`.

---

## Dispatch Flow (3.x vs 4.x)

**3.x:** One method in `UDPListenerService` receives a UDP packet and contains all the logic — parsing, throttle check, device-specific if/else chain, swipe command construction — inline.

**4.x:** Each step is a separate class with a single responsibility:

```
QZCommandListenerService   receive UDP packet, hold WakeLock
        ↓
CommandDispatcher          throttle, call device.applyCommand(cmd)
        ↓
cmd.applyTo(device)        calls device.sliderOf(XxxSlider.class)
        ↓
XxxSlider.handle()         de-dup; SpeedSlider also gates on belt speed
        ↓
Slider.moveTo()            quantize → targetThumbY → hysteresis → swipe
        ↓
GestureService.performSwipe()   all 44 devices
```

`CommandDispatcher` is pure Java with no Android imports. The `Clock` it uses for throttle timing is injectable, so tests control time directly. `Device` has an injectable `logger` functional interface, so tests capture swipe strings without Android.

---

## Metric State (3.x vs 4.x)

**3.x:** Metric values were static fields on `QZService`:

```java
static float lastSpeedFloat = 0;
static float lastInclinationFloat = 0;
static float lastResistanceFloat = 0;
// etc.
```

Any class that needed current speed or incline imported `QZService` and read these directly. This made the coupling invisible and the state globally mutable.

**4.x:** Metric values are tracked inside each `Slider` as a live float, updated via `Device.applyMetric(SliderMetric, float)` which iterates `sliders()` and calls `s.applyIfMatch()`. Live-mode sliders (`.live()` factory) read back this value before each swipe via `currentThumbY()` to correct drift. The speed gate in `SpeedSlider` uses the same live value — when `KPH > 0` arrives, `applyIfMatch()` flushes any cached speed immediately — no cross-service import needed.

---

## Metric Reading Strategy (3.x vs 4.x)

**3.x:** Each device was configured with one of several reading strategies that described how `QZService` extracted metric values from the iFit log. Strategies ranged from reading the log file directly, to shelling out and tailing it, to grepping a snapshot of it on each poll cycle. On top of that, the reader had to branch on which iFit version was installed, because v1 and v2 wrote metrics to different file paths with different keyword formats. A `static boolean ifit_v2` flag in `QZService` tracked this:

```java
if (ifit_v2) {
    // grep for "INCLINE" with second-to-last token
} else {
    // grep for "Grade" with last token
}
```

The combination of per-device reading strategy × iFit version produced a matrix of configurations. Adding a new device meant deciding which strategy it needed, and any change to iFit's log format could break devices that weren't on the updated code path.

**4.x:** All of that is replaced by a single approach: `logcat -s mono-stdout`. This works because iFit's fitness logic runs inside a **Xamarin/.NET (Mono) runtime** — it's a .NET application hosted by the Android APK. The Mono runtime unconditionally routes all `.NET stdout` output to the Android logcat tag `mono-stdout`, regardless of iFit version or the device model running it. There is no file path to discover, no version to detect, and no per-device strategy to configure.

`MonoStdoutMetricReader` opens a `logcat -s mono-stdout` process, streams its output line by line, and parses keyword patterns (`"Changed KPH"`, `"Changed Grade"`, `"Changed Resistance"`, etc.) to emit a `QZMetricPacket` for each changed value. `QZMetricUnicastingService` creates one `MonoStdoutMetricReader` directly — no factory, no variants, no flag. Device classes are completely unaware of iFit versions or log formats.

---

## Tests

There were no tests in 3.x. The 4.x codebase has 310 tests across 12 test classes that run without a device, emulator, or Android SDK:

```bash
./run-tests.sh
```

Full details — test file inventory, how swipe assertions work, the `MonoStdoutMetricReader` test pattern, and a step-by-step guide for adding tests when you add a new device — are in [testing-methodology.md](../app/src/test/java/org/cagnulein/qzcompanionnordictracktreadmill/testing-methodology.md).

---

## Version and Build Numbers

**3.x — three files, one of them hardcoded in CI:**

```
app/build.gradle          versionCode 181 / versionName "3.6.29"
AndroidManifest.xml       android:versionCode="181" android:versionName="3.6.29"
.github/workflows/main.yml  tag_name: 3.6.29   ← hardcoded string, not read from anywhere
```

Every release required editing all three files. Forgetting any one of them produced a release with a mismatched tag, manifest, or APK metadata. The CI tag was famously left as `3.6.29` with a commented-out `${{ steps.get_version.outputs.VERSION }}` beside it.

**4.x — one file, everything else is automatic:**

```
version.properties        versionName=4.0.1   ← the only file you touch
```

| What | How it's set |
|------|-------------|
| `versionName` | Read from `version.properties` by `build.gradle` at compile time |
| `versionCode` | `github.run_number` in CI; falls back to `1` locally (AGP rejects 0) |
| Release tag | CI reads `version.properties` and publishes `"4.0.1 (build 214)"` automatically |
| `AndroidManifest.xml` | No version fields — AGP injects them from `build.gradle` at build time |
| Action bar subtitle | CI builds show `build 214`; local/debug builds show `dev-a3f1c2b` (git hash) |

To cut a release, bump `versionName` in `version.properties` and push. The CI run number becomes the build number automatically.

---

## MainActivity UI

**3.x — a RadioGroup of 45 buttons:**

The device list was a single `RadioGroup` containing 45 `RadioButton` views inside a `ScrollView`. All 45 buttons were inflated and held in memory at once, and every scroll frame triggered a full layout re-measure pass across the entire group. Selection was persisted as a `SharedPreferences` integer keyed to the view's resource ID (`putInt("device", R.id.x11i)`). The `onCheckedChanged` handler was another large if/else chain — one branch per device — that called `selectDevice()` and contained scattered special-case logic (e.g. checking accessibility service state only for specific device IDs).

Debug controls (Verbose Logging, Live Logcat, Dump Log) were `CheckBox` and `Button` views inline in the main layout.

**4.x — RecyclerView with sections, a status chip, and a requirements card:**

The device list is a `RecyclerView` backed by `DeviceAdapter`. Only the visible items (~6–8) are in memory at any time. Devices are grouped into **Bikes / Treadmills / Other** with section headers; `DeviceAdapter.SECTION_MAP` provides O(1) category lookup per `DeviceId`. Tapping any item calls `selectDevice(DeviceRegistry.DEVICES.get(id))` — no if/else chain.

Device selection is now persisted as a string: `putString("device", deviceId.name())`. The enum name is stable across builds; the old view-ID integer was not. **Practical note:** existing user preferences from a 3.x install will not migrate — the saved integer won't resolve to a `DeviceId` name and the selection will silently reset to the default.

Debug tools (Verbose Logging, Live Logcat, Dump Log) moved to the **overflow menu (⋮)** in the action bar, freeing the main screen for operational information.

The action bar subtitle shows the version and build identifier (`build 214` for CI releases, `dev-a3f1c2b` for local builds).

Two UI elements appear above the device list:

**Status chip** — a single line showing `UDP 8003 · <selected device> · <local IP>`. Updates whenever the device selection changes.

**Requirements card** — shows the prerequisite status for the selected device, colour-coded green/grey:

| Device type | Card shows |
|-------------|-----------|
| All devices | "Tap control — Enabled / Not enabled" (tapping opens Android Accessibility Settings) |
| All devices | "QZ App — Broadcasting heartbeat / No heartbeat received yet" (refreshes every 5 s) |
| All devices | "Zwift via Bluetooth — Advertising / Not advertising / Not supported" (BLE FTMS canary status) |

The card refreshes automatically on `onResume()` so enabling Accessibility in Settings and returning to the app immediately shows the updated state. All devices use `AccessibilityService` — the card always shows the accessibility prompt. `MainActivity` has no hardcoded `DeviceId` list.

---

## What Didn't Change

- The **UDP wire format** (`"speedKmh;inclinePct"`, `"resistanceLvl"`, etc.) is identical — the QZ app doesn't need updating.
- The **iFit log file paths** and metric keyword strings are the same.
- All devices use `AccessibilityService` gesture injection via `GestureService.performSwipe()`.
- The **CI pipeline** (`.github/workflows/main.yml`) runs the same steps; tests now run before the release build.
