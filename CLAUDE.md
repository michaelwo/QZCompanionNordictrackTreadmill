# QZ Companion NordicTrack Treadmill - Claude Documentation

## Project Structure
Android app for controlling NordicTrack and ProForm fitness devices via AccessibilityService gesture injection.

### Main Files
- `app/src/main/java/.../qz/QZCommandListenerService.java` — UDP listener (port 8003); pure publisher — calls `QZCommandSubscriber.onPacket()` or `onCalibrationSwipe()` for each received datagram
- `app/src/main/java/.../qz/QZMetricUnicastingService.java` — streams iFit metrics via MonoStdout, unicasts changes over UDP (port 8002); pure publisher — calls `QZMetricSubscriber.onMetric()` for each reading
- `app/src/main/java/.../device/DeviceController.java` — owns `Device` + `CommandDispatcher`; implements both `QZMetricSubscriber` and `QZCommandSubscriber`; the single seam between the two services and the device layer
- `app/src/main/java/.../device/gesture/GestureService.java` — performs swipe gestures for all devices via the Android Accessibility API
- `app/src/main/java/.../ui/MainActivity.java` — main UI; sectioned device list, status chip, requirements card, overflow debug menu
- `app/src/main/java/.../device/DeviceRegistry.java` — `DeviceId` enum + `EnumMap` of all supported devices
- `app/src/main/java/.../device/Device.java` — abstract base class for all fitness devices
- `app/src/main/java/.../device/DeviceCalibration.java` — loads `qz-calibration.json` (written by `tools/discover-device.py`) at startup
- `app/src/main/res/layout/activity_main.xml` — sectioned RecyclerView UI (no radio buttons)
- `app/build.gradle` — Android build configuration
- `app/src/main/AndroidManifest.xml` — Android manifest
- `.github/workflows/main.yml` — GitHub Actions CI/CD

### Package Layout

```
org.cagnulein.qzcompanionnordictracktreadmill
├── qz/               QZCommandListenerService, QZMetricUnicastingService,
│                     QZCommandPacket, QZMetricPacket,
│                     QZCommandSubscriber, QZMetricSubscriber
├── console/          MetricReader, MonoStdoutMetricReader, SliderMetric,
│                     IfitConsoleSnapshot
├── device/           Device, BikeDevice, TreadmillDevice, Slider, DeviceController,
│                     DeviceRegistry (+ DeviceId enum), DeviceCalibration
│   ├── command/      CommandDispatcher, Command, SpeedCommand, InclineCommand,
│   │                 ResistanceCommand, CalibrationSwipeCommand
│   ├── gesture/      GestureService
│   ├── bike/         One class per bike device (S22iDevice, S15iDevice, …)
│   └── treadmill/    One class per treadmill device (X11iDevice, X32iDevice, …)
└── ui/               MainActivity, DeviceAdapter
```

---

## New Device Implementation Pattern

All devices are self-contained classes. There is no enum switch or coordinate lookup table.

### 1. Create the device class

Bike device (`device/bike/MyNewDevice.java`):
```java
package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;
import org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public class MyNewDevice extends BikeDevice {
    private static final int ORIGIN_INCLINE_THUMBY = /* formula intercept */;

    public MyNewDevice() {
        super(
            new Slider(ScreenProfile.W1920.leftTrackX, ORIGIN_INCLINE_THUMBY, MyNewDevice::offsetInclineThumbY),
            null  // null if no resistance slider
        );
    }
    @Override public String displayName() { return "My New Device"; }

    private static int offsetInclineThumbY(double v) { return ORIGIN_INCLINE_THUMBY - (int)(/* scale */ * v); }
}
```

Treadmill device: extend `TreadmillDevice` and pass two `Slider` instances `(incline, speed)`. All devices use `AccessibilityService` by default — no `requiresAdb()` or `requiresAccessibility()` overrides needed. When `currentThumbY`, `quantize`, or `hysteresisPixels` need overriding, use an anonymous `Slider` subclass combining the formula constructor with the override body.

### 2. Register the device

Add a `DeviceId` value to `DeviceRegistry.DeviceId`, then add an entry in `DeviceRegistry.DEVICES`:
```java
.put(DeviceId.my_new_device, new MyNewDevice())
```

### 3. Add to the UI

Add the `DeviceId` to the appropriate category in `ui/DeviceAdapter` (items are built from `DeviceRegistry.Category` automatically).

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

## Documentation

Most docs live in `docs/`. Two live adjacent to the code they describe:

- `app/src/main/java/.../device/device-reference.md` — per-device pixel formulas, ScreenProfile table, validator notes; edit alongside device classes
- `app/src/test/java/.../testing-methodology.md` — test file inventory, swipe assertion patterns, how to add tests for a new device; edit alongside test files

---

## Code Style Guidelines
- All comments must be in English
- Use descriptive variable names
- Follow existing indentation patterns
- No comments explaining what the code does — only why (non-obvious constraints, workarounds)
