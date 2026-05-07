# Architecture

QZ Companion is an Android app that runs on a NordicTrack/ProForm iFit tablet. It
bridges the QZ app to the physical machine:

- QZ receives Zwift FTMS control over BLE on a phone, tablet, or computer.
- QZ forwards control targets to QZ Companion over UDP.
- QZ Companion turns those targets into Android accessibility swipe gestures on
  the iFit screen.
- QZ Companion reads live iFit telemetry from `mono-stdout` logcat output and
  unicasts changed metrics back to QZ.
- QZ relays those metrics to Zwift over BLE.

This document is the contributor map: where code lives, which classes own each
part of the system, and where to go next for deeper reference.

---

## System Flow

### Control: Zwift to hardware

```text
Zwift
  -> BLE FTMS control
QZ app
  -> UDP 8003, for example "speedKmh;inclinePct" or "resistanceLvl"
QZCommandListenerService
  -> parses QZCommandPacket and publishes to QZCommandSubscriber
DeviceController
  -> asks the selected Device to decode Commands
CommandDispatcher
  -> throttles and drains a small FIFO queue
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

### Telemetry: hardware to Zwift

```text
iFit / Xamarin runtime
  -> logcat tag mono-stdout
MonoStdoutTelemetryReader
  -> parses changed speed, grade, watts, cadence, resistance, gear, HR
MonoStdoutTelemetryHub
  -> fans Telemetry objects out to subscribers
QZTelemetryUnicastingService
  -> encodes QZMetricPacket and unicasts UDP 8002 to QZ's last heartbeat IP
DeviceController
  -> forwards Telemetry to the selected Device so live sliders can correct drift
QZ app
  -> BLE FTMS measurements
Zwift
```

`MonoStdoutTelemetryHub` owns the single process-wide reader. Consumers subscribe
to the hub so command feedback, QZ metric output, and calibration all observe the
same telemetry stream.

---

## Package Layout

Main Java package:

```text
org.cagnulein.qzcompanionnordictracktreadmill
|-- qz/             UDP input/output adapters and QZ wire packet types
|-- console/        Android console surfaces: logcat telemetry and gestures
|-- telemetry/      Domain telemetry value objects
|-- device/         Device model, registry, calibration, commands, sliders
|   |-- bike/       One class per supported bike or bike-like device
|   |-- treadmill/  One class per supported treadmill
|   |-- command/    Command types plus CommandDispatcher
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

`QZCommandListenerService` is the UDP input service. It listens on port 8003,
tracks the source IP of QZ heartbeat packets, parses datagrams into
`QZCommandPacket`, and forwards packets to the active `QZCommandSubscriber`.

`QZTelemetryUnicastingService` is the UDP output service. It subscribes to
`MonoStdoutTelemetryHub`, converts domain `Telemetry` objects through
`QZTelemetryEncoder`, and unicasts serialized `QZMetricPacket` values to
`qzAddress:8002`. It drops sends until a recent QZ heartbeat is known.

`QZCommandPacket` and `QZMetricPacket` own the UDP wire details. Device code
should consume commands and telemetry objects, not split raw strings itself.

### Device model

`Device` is the abstract base for every supported machine. It decodes QZ command
packets into typed `Command` objects, exposes its sliders, and applies telemetry
to each slider.

`BikeDevice` and `TreadmillDevice` define the common command decoding shape for
the two main device families. Individual devices live in `device/bike/` or
`device/treadmill/` and contain their own pixel formulas, screen profile, and
any special slider behavior.

`DeviceRegistry` is the single registry of selectable devices. UI and services
look up devices by `DeviceId`; they should not reference concrete device classes
directly.

### Sliders and gestures

A `Slider` represents one physical iFit control axis. The typed subclasses are:

| Slider | Telemetry | Command |
|--------|-----------|---------|
| `InclineSlider` | grade percent | `InclineCommand` |
| `SpeedSlider` | km/h | `SpeedCommand` |
| `ResistanceSlider` | resistance level | `ResistanceCommand` |
| `GearSlider` | current gear | `GearCommand` |

Each slider knows its track X coordinate, current thumb Y, target formula,
quantization rules, and optional hysteresis. `Slider.moveTo()` sends the final
gesture through `GestureService.performSwipe()`. All supported devices use the
accessibility gesture path.

`ScreenProfile` stores the standard left/right slider track positions for iFit
screen widths. Use it instead of hardcoding track X values in new device classes.

### Command dispatch

`DeviceController` connects packet input, the selected device, command
dispatching, and telemetry feedback. `MainActivity` creates a new controller when
the selected device changes and registers it with `QZCommandListenerService`.

`CommandDispatcher` is Android-free policy code. It owns the throttle window and
FIFO queue, accepts a `Command` executor, and has an injectable clock for tests.

Calibration-only UDP packets are decoded by `CalibrationDevice` into
`RawSwipeCommand` so external discovery tools can use the same dispatch path as
normal device commands.

### Telemetry

`MonoStdoutTelemetryReader` starts a persistent `logcat -s mono-stdout` process
and parses iFit metric-change lines. The iFit app is Xamarin/Mono-based, so this
tag is the common source of live metrics across supported NordicTrack/ProForm
devices.

`Telemetry` subclasses are domain objects: speed, incline, resistance, gear,
cadence, watts, and heart rate. The QZ wire format is handled later by
`QZTelemetryEncoder`.

### Calibration

The in-app calibration flow lives in `ui/CalibrationActivity` and
`calibration/`. It uses accessibility gestures to sweep a physical slider,
collects live telemetry from `MonoStdoutTelemetryHub`, fits a linear
`Y = origin - scale * value` formula, writes `/sdcard/qz-calibration.json`, and
selects the `custom_calibrated` device.

`DeviceCalibration` is the compatibility boundary for saved calibration data.
`tools/discover-device.py` can still produce compatible `qz-calibration.json`
files when a contributor needs an ADB-driven or repeatable discovery run.

---

## Contributor Workflows

### Adding a supported device

1. Get fitted origin and scale constants from the in-app calibration flow, or
   from `tools/discover-device.py` when an ADB workflow is needed.
2. Add one self-contained class under `device/bike/` or `device/treadmill/`.
3. Put the device's origin constants, scale formulas, screen profile, and any
   quantization or hysteresis overrides in that class.
4. Register the `DeviceId` and instance in `DeviceRegistry`.
5. Make sure the device appears in the correct `DeviceRegistry.Category` so
   `DeviceAdapter` can place it in the UI list.
6. Add focused unit coverage for command decoding, swipe output, quantization,
   hysteresis, or live telemetry behavior that differs from the base classes.
7. Run `python3 tools/discover-device/validate_swipe_targets.py` after changing
   screen coordinates or formulas.

See [device-reference.md](device-reference.md) for current device formulas,
screen profiles, and validator notes. See
[testing-methodology.md](../app/src/test/java/org/cagnulein/qzcompanionnordictracktreadmill/testing-methodology.md)
for test patterns.

### Changing command behavior

Start at `DeviceController` to understand routing, then keep policy in the
lowest class that owns it:

- Queueing and time-based throttling belong in `CommandDispatcher`.
- Device-family packet decoding belongs in `BikeDevice` or `TreadmillDevice`.
- Per-axis behavior belongs in the relevant `Slider` subclass or anonymous
  slider override.
- Raw UDP parsing belongs in `QZCommandPacket`.

### Changing telemetry behavior

Keep metric parsing in `MonoStdoutTelemetryReader`, domain representation in
`telemetry/`, and QZ UDP serialization in `QZTelemetryEncoder` or
`QZMetricPacket`. Device and slider code should react to `Telemetry`, not QZ
wire strings.

### Changing UI behavior

`MainActivity` owns app startup, selected-device lifecycle, service startup,
status display, and menu actions. `DeviceAdapter` owns the sectioned device list.
`CalibrationActivity` owns the guided calibration screen.

---

## Design Notes

### Why swipe simulation?

NordicTrack/ProForm iFit 1/2 devices do not expose a supported local control API
for grade, resistance, or speed. BLE FTMS control, local sockets, Android IPC,
and direct USB HID control were investigated and ruled out. Accessibility
gestures work because iFit receives them through the normal Android touch event
pipeline.

The full investigation is in
[ifit-control-surface-investigation.md](ifit-control-surface-investigation.md).

### Why mono-stdout?

The iFit app runs fitness logic inside a Xamarin/Mono runtime. Metric changes are
emitted to Android logcat under `mono-stdout`, which avoids per-device log-file
polling, iFit version flags, and repeated shell process startup.

### What should stay stable?

- The QZ UDP command and metric wire formats are compatibility boundaries.
- `DeviceRegistry` is the public selection map for supported devices.
- `ScreenProfile` is the source of truth for standard slider track X positions.
- `DeviceCalibration` is the boundary for saved calibration JSON compatibility.
