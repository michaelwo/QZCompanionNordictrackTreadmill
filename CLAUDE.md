# QZ Companion NordicTrack Treadmill - Claude Documentation

## Project Structure
Android app for controlling NordicTrack and ProForm fitness devices via ADB/shell commands.

### Main Files
- `app/src/main/java/.../service/CommandListenerService.java` — UDP listener (port 8003); dispatches packets to `CommandDispatcher`
- `app/src/main/java/.../service/MetricReaderBroadcastingService.java` — polls iFit log file and broadcasts metric changes over UDP (port 8002)
- `app/src/main/java/.../service/MyAccessibilityService.java` — performs swipe gestures for NoADB devices via the Android Accessibility API
- `app/src/main/java/.../service/OcrCalibrationService.java` — calibration-only OCR polling loop
- `app/src/main/java/.../service/ScreenCaptureService.java` — captures screen frames for OCR during calibration
- `app/src/main/java/.../MainActivity.java` — main UI; sectioned device list, status chip, requirements card, overflow debug menu
- `app/src/main/java/.../device/DeviceRegistry.java` — `DeviceId` enum + `EnumMap` of all supported devices
- `app/src/main/java/.../device/Device.java` — abstract base class for all fitness devices
- `app/src/main/java/.../calibration/` — `Ocr.java`, `OcrBlock.java`, `FormulaFitter.java`, `CalibrationResult.java`
- `app/src/main/res/layout/activity_main.xml` — sectioned RecyclerView UI (no radio buttons)
- `app/build.gradle` — Android build configuration
- `app/src/main/AndroidManifest.xml` — Android manifest
- `.github/workflows/main.yml` — GitHub Actions CI/CD

### Package Layout

```
org.cagnulein.qzcompanionnordictracktreadmill
├── service/          CommandListenerService, MetricReaderBroadcastingService,
│                     MyAccessibilityService, OcrCalibrationService, ScreenCaptureService
├── device/           Device, BikeDevice, TreadmillDevice, Slider, DeviceRegistry (+ DeviceId enum)
│   ├── bike/         One class per bike device (S22iDevice, S15iDevice, …)
│   └── treadmill/    One class per treadmill device (X11iDevice, X32iDevice, …)
├── calibration/      Ocr, OcrBlock, FormulaFitter, CalibrationResult
├── dispatch/         CommandDispatcher, Command
└── reader/           MetricReader hierarchy, MetricSnapshot, ShellRuntime
```

---

## New Device Implementation Pattern

All devices are self-contained classes. There is no enum switch or coordinate lookup table.

### 1. Create the device class

Bike device (`device/bike/MyNewDevice.java`):
```java
package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class MyNewDevice extends BikeDevice {
    public MyNewDevice() {
        super(
            new Slider(/* maxValue */) {
                public int trackX()          { return /* px */; }
                public int targetY(double v) { return /* base */ - (int)(/* scale */ * v); }
            }
        );
    }
    @Override public String displayName() { return "My New Device"; }
    @Override public boolean requiresAdb() { return true; }  // or false for shell/accessibility
}
```

Treadmill device: extend `TreadmillDevice` and pass two `Slider` instances (speed + incline).

### 2. AccessibilityService devices (NoADB variants)

Override `swipe()` to call `MyAccessibilityService.performSwipe()` and add:
```java
@Override public boolean requiresAdb()          { return false; }
@Override public boolean requiresAccessibility() { return true; }
@Override protected void swipe(int x, int y1, int y2) {
    MyAccessibilityService.performSwipe(x, y1, x, y2, 200);
}
```
Import: `org.cagnulein.qzcompanionnordictracktreadmill.service.MyAccessibilityService`

### 3. Register the device

Add a `DeviceId` value to `DeviceRegistry.DeviceId`, then add an entry in `DeviceRegistry.DEVICES`:
```java
.put(DeviceId.my_new_device, new MyNewDevice())
```

### 4. Add to the UI

Add the `DeviceId` to the appropriate list in `DeviceAdapter` (`BIKE_DEVICES`, `TREADMILL_DEVICES`, or `OTHER_DEVICES`).

---

## Version Management

### Files to Update for Each Release
**Update ONE value only:**

1. **version.properties** (root of repo)
   - `versionName` (semantic versioning): `3.6.29 → 3.6.30`

`versionCode` is set automatically from the GitHub Actions run number — never edit it manually. `build.gradle` reads `versionName` from `version.properties`. `AndroidManifest.xml` no longer carries version fields — AGP injects them at build time. CI publishes the release as `3.6.30 (build 214)` automatically.

Local debug builds show `dev-<git-hash>` in the action bar subtitle instead of a build number.

### Version Bump Process
```bash
# 1. Patch release (bug fix)
3.6.19 → 3.6.20

# 2. Minor release (new feature)
3.6.19 → 3.7.0

# 3. Major release (breaking change)
3.6.19 → 4.0.0
```

---

## Device Naming Convention
- `DeviceId` enum value: `{series}{model}_{variant}` (e.g. `s22i_NTEX02117_2`)
- `displayName()`: `"{Series} {Type} ({Model})"` (e.g. `"S22i Bike (NTEX02117.2)"`)
- Class name: `{Series}{Model}Device.java` (e.g. `S22iNtex02117Device.java`)
- No strings.xml — display names are hardcoded in `displayName()`

---

## OCR / Calibration

OCR parsing lives in `calibration/Ocr.java`. It has no Android dependencies and is fully unit-tested.

### Recognised metric labels (case-insensitive)
| Metric | Labels |
|--------|--------|
| Speed (km/h) | `"speed"` |
| Speed from 500m split | `"500 split"`, `"/500m"` → `km/h = 1800 / seconds` |
| Incline | `"incline"` |
| Resistance | `"resistance"` |
| Cadence | `"cadence"`, `"rpm"`, `"strokes per min"` |
| Watts | `"watt"` |

---

## Code Style Guidelines
- All comments must be in English
- Use descriptive variable names
- Follow existing indentation patterns
- No comments explaining what the code does — only why (non-obvious constraints, workarounds)
