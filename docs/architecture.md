# Architecture

QZ Companion is an Android app that runs on a NordicTrack/ProForm iFit tablet. It bridges the QZ app to the physical machine:

- QZ receives Zwift FTMS control over BLE on a phone, tablet, or computer.
- QZ forwards control targets to QZ Companion over UDP.
- QZ Companion turns those targets into hardware commands — via gRPC on iFit2, or via touchscreen gesture injection on iFit1.
- QZ Companion reads live telemetry from the machine — via gRPC subscription on iFit2, or via `mono-stdout` logcat on iFit1.
- QZ Companion unicasts changed metrics back to QZ over UDP.
- QZ relays those metrics to Zwift over BLE.

This document is the contributor map: where code lives, which classes own each part of the system, and where to go next for deeper reference.

---

## iFit2 — GlassOS gRPC path

iFit2 is the Kotlin/gRPC rewrite of the iFit app (`com.ifit.rivendell` + `com.ifit.glassos_service`). It exposes a local gRPC server on `localhost:54321` that accepts direct control commands and streams live telemetry. This is the primary path for devices running iFit2.

### Control: Zwift to hardware (iFit2)

```text
Zwift
  -> BLE FTMS control
QZ app
  -> UDP 8003, e.g. "speedKmh;inclinePct" or "resistanceLvl"
QZCommandListenerService
  -> parses QZCommandPacket and publishes to QZCommandSubscriber
DeviceController
  -> asks GlassOsControlTransport to apply the command first
GlassOsControlTransport
  -> sends InclineRequest, ResistanceRequest, or SpeedRequest over mTLS gRPC
glassos_service (localhost:54321)
  -> moves the hardware axis
```

`GlassOsControlTransport.tryApply()` returns `true` on success. On any gRPC error it shuts the channel down and returns `false`. On a committed-iFit2 platform `gesturesEnabled=false`, so a `false` return means the command is not applied — there is no gesture fallback.

### Telemetry: hardware to Zwift (iFit2)

```text
glassos_service (localhost:54321)
  -> gRPC async subscription stream per axis (incline, resistance, speed, cadence, watts, HR)
GlassOsTelemetryReader
  -> wraps each stream observer, emits Telemetry domain objects
TelemetryHub
  -> fans Telemetry objects out to all subscribers
QZTelemetryUnicastingService
  -> encodes QZMetricPacket and unicasts UDP 8002 to QZ's last heartbeat IP
DeviceController
  -> forwards Telemetry to the selected Device so live sliders can correct drift
QZ app
  -> BLE FTMS measurements
Zwift
```

`iFitPlatform.detect()` commits to exactly one reader at startup. On iFit2, `TelemetryHub` is configured with `GlassOsTelemetryReader` only — `MonoStdoutTelemetryReader` is never installed. On iFit1, the reverse. There is no runtime fallback between readers.

### Credentials

The gRPC channel requires mutual TLS. The CA certificate, client certificate, and private key live inside the rivendell APK as raw resources with obfuscated file paths. `GlassOsCredentials` discovers them at runtime by scanning the installed APK's `resources.arsc` for `img_icon_*` key strings, reading each resource, stripping JPEG obfuscation markers, and identifying the correct cert by its CN field (`com.ifit.rivendell`). Discovered resource names are cached in `SharedPreferences("glassos_cred_v2")` keyed by the APK's `versionCode`.

Full details on the credential scheme and server security model are in [ifit2-control-surface-investigation.md](ifit2-control-surface-investigation.md).

---

## iFit1 — Gesture + mono-stdout path

iFit1 is the Xamarin/Mono app (`com.ifit.standalone`) used on older NordicTrack/ProForm hardware. It exposes no local control API, so QZ Companion injects touchscreen swipe gestures through Android Accessibility Services and reads telemetry from a logcat tag.

### Control: Zwift to hardware (iFit1)

```text
Zwift
  -> BLE FTMS control
QZ app
  -> UDP 8003, e.g. "speedKmh;inclinePct" or "resistanceLvl"
QZCommandListenerService
  -> parses QZCommandPacket and publishes to QZCommandSubscriber
DeviceController
  -> GlassOsControlTransport returns false (not iFit2); falls through to gesture path
Device / Slider
  -> quantizes, de-duplicates, applies speed gating, computes screen Y
GestureService
  -> injects AccessibilityService swipe gestures into iFit
```

The dispatch path has three important filters:

| Filter | Owner | Purpose |
|--------|-------|---------|
| Throttle and queue | `CommandDispatcher` | Sends one command per 500 ms window and drops excess queue entries. |
| De-duplication | Typed `Slider` classes | Skips a swipe when the quantized target is already applied. |
| Treadmill speed gate | `SpeedSlider` | Caches speed commands while the belt is stopped and releases the latest command when live speed becomes positive. |

### Telemetry: hardware to Zwift (iFit1)

```text
iFit / Xamarin runtime
  -> logcat tag mono-stdout
MonoStdoutTelemetryReader
  -> parses changed speed, grade, watts, cadence, resistance, gear, HR
TelemetryHub
  -> fans Telemetry objects out to all subscribers
QZTelemetryUnicastingService
  -> encodes QZMetricPacket and unicasts UDP 8002 to QZ's last heartbeat IP
DeviceController
  -> forwards Telemetry to the selected Device so live sliders can correct drift
QZ app
  -> BLE FTMS measurements
Zwift
```

On iFit1 (committed by `iFitPlatform.detect()`), `MonoStdoutTelemetryReader` is the only configured reader.

---

## Package Layout

Main Java package:

```text
org.cagnulein.qzcompanionnordictracktreadmill
|-- qz/             UDP input/output adapters and QZ wire packet types
|-- console/        TelemetryHub, TelemetryReader, MonoStdoutTelemetryReader, GestureService
|-- glassos/        GlassOS gRPC transport: credentials, telemetry reader, control transport
|-- telemetry/      Domain telemetry value objects
|-- device/         Device model, registry, calibration, commands, sliders
|   |-- bike/       One class per supported bike or bike-like device
|   |-- treadmill/  One class per supported treadmill
|   |-- command/    Command types plus CommandDispatcher
|   |-- control/    ControlTransport interface (gRPC or no-op)
|   `-- slider/     Typed slider abstractions for speed, incline, resistance, gear
|-- calibration/    In-app calibration runner, fitting, telemetry collection
|-- platform/       Boot/restart receivers and crash handling
`-- ui/             MainActivity, CalibrationActivity, DeviceAdapter
```

Important non-code areas:

| Path | Purpose |
|------|---------|
| `docs/` | Contributor and investigation docs. |
| `tools/discover-device/` | ADB-based discovery, calibration, and coordinate validation tools. |
| `app/src/test/java/...` | JVM and Robolectric tests, plus `testing-methodology.md`. |
| `InstallPackage/` | End-user install scripts and packaged APK assets. |
| `version.properties` | Single source for release `versionName`. |

---

## Core Components

### QZ adapters

`QZCommandListenerService` is the UDP input service. It listens on port 8003, tracks the source IP of QZ heartbeat packets, parses datagrams into `QZCommandPacket`, and forwards packets to the active `QZCommandSubscriber`.

`QZTelemetryUnicastingService` is the UDP output service. It subscribes to `TelemetryHub`, converts domain `Telemetry` objects through `QZTelemetryEncoder`, and unicasts serialized `QZMetricPacket` values to `qzAddress:8002`. It drops sends until a recent QZ heartbeat is known.

`QZCommandPacket` and `QZMetricPacket` own the UDP wire details. Device code should consume commands and telemetry objects, not split raw strings itself.

### TelemetryHub

`TelemetryHub` is the process-wide telemetry fanout. It holds a prioritized list of `TelemetryReader` implementations and starts the first one that succeeds. All subscribers — QZ metric output, device drift correction, calibration — observe the same stream regardless of which reader is active.

`configure(TelemetryReader)` installs the single platform-committed reader. On iFit2 it receives a `GlassOsTelemetryReader`; on iFit1 a `MonoStdoutTelemetryReader`. Both `MainActivity` and `QZTelemetryUnicastingService` call `configure()` before subscribing; the configuration is idempotent once a reader has started.

### GlassOS transport (iFit2)

`GlassOsTelemetryReader` opens the gRPC channel, subscribes to `WorkoutService.WorkoutStateChanged`, and activates per-axis metric subscriptions (incline, resistance, speed, cadence, watts, HR) when the workout state transitions to `WORKOUT_STATE_RUNNING`. If the workout is already running at startup, `GetWorkoutState()` triggers immediate activation. `read()` only throws `IOException` for hard failures (credential load, channel open); a missing or not-yet-started workout is handled transparently.

`GlassOsControlTransport` implements `ControlTransport`. `DeviceController` calls `tryApply(command, device)` before the gesture path; the transport handles `InclineCommand`, `ResistanceCommand`, and `SpeedCommand` via their respective gRPC services, and returns `true` on success. On any gRPC error it shuts the channel down and returns `false`.

`GlassOsCredentials` loads the mTLS credentials from the installed rivendell APK and builds the `SSLContext` used by both transports.

### Device model

`Device` is the abstract base for every supported machine. It decodes QZ command packets into typed `Command` objects, exposes its sliders, and applies telemetry to each slider.

`BikeDevice` and `TreadmillDevice` define the common command decoding shape for the two main device families. Individual devices live in `device/bike/` or `device/treadmill/` and contain their own pixel formulas, screen profile, and any special slider behavior.

`DeviceRegistry` is the single registry of selectable devices. UI and services look up devices by `DeviceId`; they should not reference concrete device classes directly.

### Sliders and gestures (iFit1)

A `Slider` represents one physical iFit control axis. The typed subclasses are:

| Slider | Telemetry | Command |
|--------|-----------|---------|
| `InclineSlider` | grade percent | `InclineCommand` |
| `SpeedSlider` | km/h | `SpeedCommand` |
| `ResistanceSlider` | resistance level | `ResistanceCommand` |
| `GearSlider` | current gear | `GearCommand` |

Each slider knows its track X coordinate, current thumb Y, target formula, quantization rules, and optional hysteresis. `Slider.moveTo()` sends the final gesture through `GestureService.performSwipe()`. On iFit2 the slider path is bypassed by `GlassOsControlTransport`, so sliders are only exercised as the fallback.

`ScreenProfile` stores the standard left/right slider track positions for iFit screen widths. Use it instead of hardcoding track X values in new device classes.

### Command dispatch

`DeviceController` connects packet input, the selected device, a `ControlTransport`, and telemetry feedback. `MainActivity` creates a new controller when the selected device changes and registers it with `QZCommandListenerService`.

`CommandDispatcher` is Android-free policy code. It owns the throttle window and FIFO queue, accepts a `Command` executor, and has an injectable clock for tests.

Calibration-only UDP packets are decoded by `CalibrationDevice` into `RawSwipeCommand` so external discovery tools can use the same dispatch path as normal device commands.

### Calibration

The in-app calibration flow lives in `ui/CalibrationActivity` and `calibration/`. It uses accessibility gestures to sweep a physical slider, collects live telemetry from `TelemetryHub`, fits a linear `Y = origin - scale * value` formula, writes `/sdcard/qz-calibration.json`, and selects the `custom_calibrated` device.

`DeviceCalibration` is the compatibility boundary for saved calibration data. `tools/discover-device.py` can still produce compatible `qz-calibration.json` files when a contributor needs an ADB-driven or repeatable discovery run.

---

## Contributor Workflows

### Adding a supported device

1. Get fitted origin and scale constants from the in-app calibration flow, or from `tools/discover-device.py` when an ADB workflow is needed.
2. Add one self-contained class under `device/bike/` or `device/treadmill/`.
3. Put the device's origin constants, scale formulas, screen profile, and any quantization or hysteresis overrides in that class.
4. Register the `DeviceId` and instance in `DeviceRegistry`.
5. Make sure the device appears in the correct `DeviceRegistry.Category` so `DeviceAdapter` can place it in the UI list.
6. Add focused unit coverage for command decoding, swipe output, quantization, hysteresis, or live telemetry behavior that differs from the base classes.
7. Run `python3 tools/discover-device/validate_swipe_targets.py` after changing screen coordinates or formulas.

See [device-reference.md](device-reference.md) for current device formulas, screen profiles, and validator notes. See [testing-methodology.md](../app/src/test/java/org/cagnulein/qzcompanionnordictracktreadmill/testing-methodology.md) for test patterns.

### Changing command behavior

Start at `DeviceController` to understand routing. There are now two execution paths:

- **iFit2:** `GlassOsControlTransport.tryApply()` is the first stop. Changes to how gRPC commands are constructed or retried belong there.
- **iFit1 / fallback:** if `tryApply()` returns `false`, control reaches `device.applyCommand()` and the slider path. Keep policy in the lowest class that owns it: queueing in `CommandDispatcher`, device-family decoding in `BikeDevice`/`TreadmillDevice`, per-axis behavior in the `Slider` subclass, raw UDP parsing in `QZCommandPacket`.

### Changing telemetry behavior

Keep metric parsing in the appropriate `TelemetryReader` (`GlassOsTelemetryReader` for iFit2, `MonoStdoutTelemetryReader` for iFit1), domain representation in `telemetry/`, and QZ UDP serialization in `QZTelemetryEncoder` or `QZMetricPacket`. Device and slider code should react to `Telemetry`, not reader-specific wire formats.

### Changing UI behavior

`MainActivity` owns app startup, selected-device lifecycle, service startup, status display, and menu actions. `DeviceAdapter` owns the sectioned device list. `CalibrationActivity` owns the guided calibration screen.

---

## Design Notes

### Why gRPC on iFit2?

`glassos_service` exposes a fully-featured local gRPC server with clean request/response semantics for every controllable axis, plus async subscription streams for live telemetry. Using it avoids touchscreen simulation entirely, eliminates pixel-formula drift, and provides sub-250 ms round-trip command application. The full security model (mTLS, client-id header, loopback-only) is documented in [ifit2-control-surface-investigation.md](ifit2-control-surface-investigation.md).

### Why swipe simulation on iFit1?

iFit1 (`com.ifit.standalone`) exposes no programmable local control surface for incline, resistance, or speed. BLE FTMS control, local sockets, Android IPC, and direct USB HID were investigated and ruled out. Accessibility gestures work because iFit receives them through the normal Android touch event pipeline. The full investigation is in [ifit-control-surface-investigation.md](ifit-control-surface-investigation.md).

### Why mono-stdout on iFit1?

The iFit1 app runs fitness logic inside a Xamarin/Mono runtime. Metric changes are emitted to Android logcat under `mono-stdout`, which avoids per-device log-file polling, iFit version flags, and repeated shell process startup.

### What should stay stable?

- The QZ UDP command and metric wire formats are compatibility boundaries.
- `DeviceRegistry` is the public selection map for supported devices.
- `ScreenProfile` is the source of truth for standard slider track X positions.
- `DeviceCalibration` is the boundary for saved calibration JSON compatibility.
- `TelemetryHub.shared()` is the single process-wide telemetry fanout; all consumers should subscribe to it rather than constructing their own readers.
