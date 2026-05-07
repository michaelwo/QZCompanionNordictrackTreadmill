# Architecture

## Overview

QZCompanion is an Android app that runs on the NordicTrack/ProForm iFit embedded tablet and acts as the bridge between the Zwift training ecosystem and the physical hardware. It has two concurrent jobs: **accepting control commands** (grade, resistance, speed) forwarded from the QZ app and translating them into touch gestures on the iFit screen, and **reading live metrics** (speed, incline, cadence, watts) from the iFit firmware and unicasting them back to the QZ app so Zwift stays in sync with what the machine is actually doing.

---

## Context

### Why can't Zwift connect directly to some NordicTrack devices?

Zwift requires **BLE hardware and a full FTMS (Fitness Machine Service) software implementation** on the fitness device — both to receive grade and resistance commands and to report metrics back. The NordicTrack and ProForm machines supported by this project have neither: the iFit 1/2 embedded tablet has no BLE radio dedicated to fitness machine control, and the iFit firmware does not implement the FTMS profile.

The **QZ app** satisfies Zwift's FTMS requirement by running on a separate device that *does* have BLE — a phone, laptop, or computer. Zwift pairs with QZ over BLE as if it were the fitness machine. QZ then forwards Zwift's grade and resistance commands over UDP (Wi-Fi) to QZCompanion, which runs on the iFit tablet itself and drives the hardware by injecting touch gestures on the iFit screen. Metrics travel the reverse path: QZCompanion reads them from the iFit firmware log and unicasts them back to QZ, which relays them to Zwift over BLE.

### Why swipe simulation?

**No programmable control surface exists** on NordicTrack/ProForm iFit 1/2 devices. Swipe simulation is the last resort after a systematic investigation ruled out every other approach.

| Surface | Verdict |
|---------|---------|
| FTMS Control Point (BLE) | Not implemented in iFit firmware — the device advertises BLE metrics but the Control Point write characteristic is absent |
| TCP socket (Sindarin engine) | The Xamarin DLL `Sindarin.FitPro1.Tcp.dll` connects *outbound* to iFit's cloud; it does not listen on any local port |
| Local IPC (ContentProvider / AIDL / Intent) | No exported ContentProvider, no AIDL interface, no broadcast receiver that accepts incline or resistance targets from third-party apps |
| USB HID | The motor controller communicates over USB, but Android restricts HID access to the process that opened the USB device — `com.ifit.standalone` holds that exclusive handle; no other app can send HID reports |
| ADB `input swipe` / Accessibility API | Works — the iFit app cannot distinguish injected touch events from real finger gestures |

The iFit application is a standard Android app (a Xamarin.Android / Wolf hybrid). It reads touch input through the normal Android `MotionEvent` pipeline. Both `adb shell input swipe` and `AccessibilityService.dispatchGesture()` inject events at the same level, so the iFit UI responds identically to an injected drag as it does to a physical finger.

The full investigation — methodology, decompilation output, and per-surface conclusions — is documented in [iFit Control Surface Investigation](ifit-control-surface-investigation.md).

---

## Data Flows

### Inbound: Zwift → Hardware

Zwift grade and resistance targets travel through the QZ app and arrive as UDP datagrams. QZCompanion translates them into swipe gestures on the iFit touchscreen.

```
Zwift (PC/console)
        │
        │  FTMS control point (BLE)
        ▼
QZ App (phone/tablet)
        │
        │  UDP datagram, port 8003
        │  format: "speedKmh;inclinePct"  (treadmill)
        │       or  "inclinePct;?"        (2-part bike)
        │       or  "resistanceLvl"       (1-part bike)
        ▼
QZCommandListenerService.listenAndWaitAndThrowIntent()
        │  records qzAddress from -100; heartbeat packets
        │  calls subscriber.onPacket(QZCommandPacket.parse(msg))
        ▼
DeviceController.onPacket(packet)
        │
        │  device.decodeCommands(pkt)
        │    → produces List<Command>, one per actionable field
        │      (e.g. "8.0;3.0" → [speedCmd(8.0), inclineCmd(3.0)])
        │
        │  dispatcher.enqueue(cmd) for each command
        │  sentinel packets (empty list) call dispatcher.drain()
        ▼
CommandDispatcher   [throttle + FIFO queue, 500ms window, capacity 5]
        │  drains one Command per open window, oldest first
        │  executor.accept(cmd) → DeviceController.executeCommand(cmd)
        ▼
device.applyCommand(cmd)  →  cmd.applyTo(device)
        │  cmd calls device.sliderOf(XxxSlider.class)
        ▼
XxxSlider.handle(value, device)   [de-dup / speed gate in SpeedSlider]
        │
        │  Slider.moveTo(value, device)
        │    quantize(value)        → snap to physical increments
        │    targetThumbY(value)    → compute logical pixel Y coordinate
        │    hysteresisPixels()     → directional overshoot in px (0 for most sliders)
        ▼
GestureService.performSwipe(x, fromY, x, swipeY, 200)   [swipeY may differ from targetThumbY]
```

Three mechanisms filter commands before a swipe is issued:

| Mechanism | Where | Behaviour |
|-----------|-------|-----------|
| **Throttle** | `CommandDispatcher` | Incoming Commands are enqueued in a FIFO queue (capacity 5). One Command drains per 500ms throttle window, oldest first — driven by a background `QZ:DrainThread` and by each `enqueue()` call. Sentinel packets (empty command list) call `drain()` directly so they still flush the queue. Excess Commands are dropped. |
| **De-dup** | `XxxSlider.handle()` | If the quantized value equals `lastApplied`, the swipe is skipped entirely. |
| **Speed gate** | `SpeedSlider` | Speed commands are held in a one-slot cache while `liveValueOrZero() <= 0` (belt stopped). The cache self-flushes when `applyIfMatch(KPH, >0, device)` fires. |

### Outbound: Hardware → Zwift

The iFit firmware writes speed, incline, cadence, and other metrics to a log file on the device. QZCompanion reads that file continuously, extracts changed values, and broadcasts them back to the QZ app.

```
iFit firmware
        │
        │  writes to log file every ~1 s
        │  e.g. /sdcard/android/data/com.ifit.glassos_service/
        │            files/.valinorlogs/log.latest.txt
        │
        ▼
QZMetricUnicastingService
        │
        │  reader.subscribe(packet →)          ← push path (MonoStdoutMetricReader)
        │    → delivers QZMetricPacket{metric, value} per changed field
        │
        │  toSliderMetric(packet.metric) → SliderMetric (or null if unmapped)
        │  subscriber.onMetric(sliderMetric, packet.value)
        ▼
DeviceController.onMetric(metric, value)
        │  device.applyMetric(metric, value)
        │    → iterates sliders(), calls s.applyIfMatch(metric, value, device)
        │    → SpeedSlider.applyIfMatch() flushes cached speed if KPH > 0 (belt started)
        │    → live-mode Sliders update their liveValue for currentThumbY tracking
        ▼
QZMetricUnicastingService (continued)
        │
        │  delta check: only changed fields are sent
        │  sendUnicast(): drops packet if no heartbeat in last 30 s
        ▼
UDP unicast → qzAddress:8002   (qzAddress = source IP of last -100; heartbeat)
        │  "Changed KPH <value>"
        │  "Changed Grade <value>"
        │  "Changed RPM <value>"
        │  "Changed Watts <value>"   etc.
        ▼
QZ App (phone/tablet)
        │
        │  FTMS measurement characteristic (BLE notify)
        ▼
Zwift (PC/console)
```

`MonoStdoutMetricReader` pushes metric updates the moment the iFit firmware emits them to logcat, typically within milliseconds of the change. Only fields that changed since the last unicast are sent — unchanged metrics produce no UDP traffic. Metric packets are addressed to the IP that QZ most recently advertised via its `-100;N` heartbeat; if no heartbeat has arrived in the last 30 s the packet is silently dropped. The `DeviceController.onMetric()` call closes the feedback loop for the inbound path: `SpeedSlider`'s speed gate blocks treadmill speed swipes while the belt is stopped, and when `KPH` first rises above zero any cached speed is applied immediately — the swipe fires the moment the belt starts, independent of incoming UDP packets. Sliders constructed with the `.live()` factory re-derive their starting position from live observed metrics rather than tracking internal state.

---

## Components

### Package Layout

```
org.cagnulein.qzcompanionnordictracktreadmill
├── qz/               QZCommandListenerService, QZMetricUnicastingService,
│                     QZCommandPacket, QZMetricPacket,
│                     QZCommandSubscriber, QZMetricSubscriber
├── console/          MetricReader hierarchy, MonoStdoutMetricReader,
│                     IfitConsoleSnapshot, GestureService
├── device/           Device, BikeDevice, TreadmillDevice, Slider, SliderMetric,
│                     DeviceController,
│                     DeviceRegistry (+ DeviceId enum), DeviceCalibration
│   ├── bike/         One class per bike device
│   ├── treadmill/    One class per treadmill device
│   ├── command/      Command, SpeedCommand, InclineCommand, ResistanceCommand,
│   │                 GearCommand, CommandDispatcher, RawSwipeCommand
│   └── slider/       InclineSlider, SpeedSlider, ResistanceSlider, GearSlider
└── ui/               MainActivity, DeviceAdapter
```

### Device Model

**`Device`** (abstract) — base class for all fitness devices. Owns:
- `logger` — functional interface; no-op by default, wired to `Log.i` in production
- `commandExecutor` — functional interface; no-op by default, set by `MainActivity` to route shell commands
- `decodeCommands(QZCommandPacket)` — abstract; returns one `Command` per actionable field in the packet (sentinels return an empty list)
- `applyCommand(Command)` — calls `cmd.applyTo(this)`; throttle is handled upstream by `CommandDispatcher` via `DeviceController`
- `sliders()` — abstract; returns the list of typed `Slider` instances owned by this device
- `sliderOf(Class<S>)` — final generic lookup; returns the first slider of the given subtype, or `null`
- `applyMetric(SliderMetric, float)` — final; iterates `sliders()` calling `s.applyIfMatch(metric, value, this)` on each

**`BikeDevice`** (abstract, extends `Device`) — controls one or two typed `Slider` instances (incline + optional resistance/gear). Implements `sliders()` returning the non-null sliders. `decodeCommands()` calls `incline.commandFor(v)` and `resistance.commandFor(v)` so each slider produces its own matching `Command` type. De-duplication is handled inside each slider's `handle()` method.

**`TreadmillDevice`** (abstract, extends `Device`) — controls `SpeedSlider` and `InclineSlider` instances. Implements `sliders()` returning both. Speed-gate logic lives in `SpeedSlider`: commands are held in a one-slot cache while the belt is stopped, and flushed the moment `KPH > 0` arrives via `applyIfMatch`.

**`Slider`** (abstract) — represents one physical slider on the iFit touchscreen. Four typed subclasses exist: `InclineSlider` (metric: `GRADE`), `SpeedSlider` (metric: `KPH`), `ResistanceSlider` (metric: `RESISTANCE`), and `GearSlider` (metric: `CURRENT_GEAR`). Each typed slider is constructed as `new InclineSlider(trackX, initialThumbY, formula)` etc., where `trackX` is a `ScreenProfile` constant, `initialThumbY` equals `formula(0)`, and `formula` is a `ThumbYFormula` method reference. When `quantize`, `currentThumbY`, or `hysteresisPixels` also need overriding, an anonymous typed-slider subclass is used. Each typed slider also provides a `.live()` static factory that overrides `currentThumbY()` to re-derive starting position from its live metric value. Overridable behaviours:
- `targetThumbY(double v)` — (supplied via `ThumbYFormula`) converts a metric value to a logical pixel Y coordinate
- `quantize(float v)` — (optional) snaps to physically reachable increments
- `currentThumbY()` — dead mode (default): returns `thumbY()` (tracked from last `moveTo`). Live mode (`.live()` factory): returns `targetThumbY(liveValue)`, correcting drift from missed commands.
- `hysteresisPixels(fromY, toY)` — (optional) pixels of directional overshoot to compensate for physical stiction; swipe overshoots `targetThumbY` in the direction of travel while `thumbY` tracks the logical target so de-dup is unaffected. Default: 0.

Each typed slider implements two abstract methods:
- `handle(double value, Device device)` — de-duplicates against `lastApplied()` and calls `moveTo()`; `SpeedSlider` additionally gates on `liveValueOrZero()`
- `commandFor(double value)` — creates the matching `Command` subclass (e.g. `InclineSlider.commandFor()` returns `new InclineCommand(...)`)

`Slider.moveTo()` owns gesture dispatch: it calls `GestureService.performSwipe()` when connected and `device.commandExecutor.send()` unconditionally. `GestureService.SWIPE_DURATION_MS` (200 ms) governs gesture duration for both `moveTo()` and the calibration swipe path in `DeviceController`.

**`ScreenProfile`** (enum) — encodes the horizontal pixel coordinates of the left and right slider tracks for each iFit screen width (W1920, W1280, W1024, W800). Constants are derived from iFit APK 2.6.90 (versionCode 4963, `com.ifit.standalone`): `workout_slider_margin=12 dp`, `workout_slider_width=125 dp` → track centre at `12 + 62.5 = 74.5 dp`. Left and right values are stored independently because dp→px rounding can be asymmetric at the pixel boundary. If the iFit app is updated, re-derive these constants from the new APK's `res/values/dimens.xml` before touching any device class.

**`DeviceController`** — the seam between the two services and the device layer. Implements both `QZMetricSubscriber` and `QZCommandSubscriber`. Owns the selected `Device`, an internal `CalibrationDevice`, and a `CommandDispatcher`. `onPacket()` first asks `CalibrationDevice.decodeCommands()` to translate `CALSWIPE:x:fromY:toY` packets into `RawSwipeCommand`; if no calibration command is produced, it falls back to `device.decodeCommands()`. It enqueues each resulting `Command` and calls `dispatcher.drain()` for empty (sentinel) packets. `onMetric()` forwards directly to `device.applyMetric()`. `MainActivity` creates a new `DeviceController` on device selection and registers it with both services via `QZCommandListenerService.setSubscriber()` and `QZMetricUnicastingService.setSubscriber()`.

**`DeviceRegistry`** — singleton `EnumMap` mapping every `DeviceId` to a pre-constructed `Device` instance. Neither `QZCommandListenerService` nor `MainActivity` reference concrete device classes — all coupling goes through `DeviceId`.

For per-device pixel formulas, command execution modes, and metric reader assignments, see [device-reference.md](../app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill/device/device-reference.md).

### Coordinate Validation

All trackX constants are standardised to **iFit APK 2.6.90** (versionCode 4963) and expressed via the `ScreenProfile` enum — the single source of truth for slider track positions. `tools/validate_swipe_targets.py` reads the decoded APK (`ifit_decoded/res/`) and all device Java files, then checks that each slider's trackX matches the position implied by the APK's `workout_slider_margin` (12 dp) and `workout_slider_width` (125 dp) dimension resources. At the iFit tablet's mdpi density (1 dp = 1 px), this yields an expected left-slider trackX of 74.5 px and a right-slider trackX of `screen_width − 74.5` px. The script also checks formula monotonicity, initial-thumb plausibility, and formula bounds against Sindarin's protocol limits.

Run it before and after editing any device class:

```bash
python3 tools/validate_swipe_targets.py   # exits 0 if clean
```

Full methodology, per-screen-width tables, and documentation of known anomalies are in [device-reference.md](../app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill/device/device-reference.md).

### Command Dispatch

**`QZCommandListenerService`** — pure publisher. Android `Service` that loops on a `DatagramSocket` (port 8003), holds a `WakeLock` per receive, and calls `subscriber.onPacket()` for each datagram. Records `qzAddress` and `lastQzHeartbeatMs` from normal QZ command/heartbeat packets so `QZMetricUnicastingService` knows where to send metric updates; `CALSWIPE` packets are routed to the subscriber without updating heartbeat state. `CALSWIPE_PREFIX` is defined in `QZCommandPacket` (wire-format knowledge belongs there). Subscriber is set via `QZCommandListenerService.setSubscriber(QZCommandSubscriber)` after the service starts.

**`CommandDispatcher`** — pure throttle and queue. Accepts a `Consumer<Command> executor` at construction; has no device knowledge. Commands are enqueued via `enqueue(Command)` and drained one per 500 ms throttle window via `executor.accept(cmd)`. Drain happens on two paths: `enqueue()` attempts an immediate drain when the window is open, and a background `ScheduledExecutorService` (`QZ:DrainThread`) fires every 500 ms. `drain()` is called directly by `DeviceController` for sentinel packets (empty command list). Both paths synchronize on `this` to prevent double-drain. `shutdown()` stops the background thread. Has an injectable `Clock` interface so tests can drive time without sleeping — the test constructor starts no background thread.

**`QZCommandSubscriber`** — single-method interface: `onPacket(QZCommandPacket)`. Calibration and normal QZ datagrams share the same subscriber boundary.

**`CalibrationDevice`** — internal decoder for calibration-only UDP packets. It is not registered in `DeviceRegistry` and is never user-selectable; it exists so `discover-device.py --a11y` can use the same decode/dispatch path regardless of the selected fitness device.

**`RawSwipeCommand`** — `Command` subclass carrying `x, fromY, toY` pixel coordinates for a calibration swipe. It dispatches directly through `GestureService.performSwipe()` and emits the equivalent `input swipe` string through `device.commandExecutor` for tests/debug capture.

**`QZCommandPacket`** — structural wrapper for a single QZ UDP datagram. Owns the `;` delimiter, field access by index, named sentinel constants (`NO_COMMAND = -100`, `NO_RESISTANCE = -1`, `END_OF_RIDE`), and `CALSWIPE_PREFIX`. The `;` split is not exposed outside this class.

**`QZMetricPacket`** — typed wrapper for an outbound UDP metric message. The `Metric` enum encodes both the wire-format prefix string and whether the value serialises as an integer or float. `serialize()` produces the raw string sent over UDP; `parse()` reconstructs the object from a raw string (used in tests). `QZMetricUnicastingService` constructs one instance per changed metric and calls `serialize()` before passing the result to `sendUnicast()`.

### Metric Reading

**`QZMetricUnicastingService`** — pure publisher. Background service that starts `MonoStdoutMetricReader` once unconditionally in `onCreate()`. On each reading it calls `toSliderMetric(packet.metric)` to map the wire-format metric to a domain type, then `subscriber.onMetric(sliderMetric, value)` if the metric is mapped and a subscriber is set. Unicasts changed metrics to `qzAddress:8002`. Silently drops sends until `QZCommandListenerService` has seen a QZ heartbeat within the last 30 s. Subscriber is set via `QZMetricUnicastingService.setSubscriber(QZMetricSubscriber)`.

**`QZMetricSubscriber`** — single-method interface: `onMetric(SliderMetric metric, float value)`. Implemented by `DeviceController`.

The `MetricReader` interface and its implementations are described in the [Design Decisions](#design-decisions) and [Reference](#reference) sections below.

### Swipe Execution Paths

All 44 devices use `GestureService.performSwipe()` via `Slider.moveTo()`. There is no per-device capability flag — all devices use `AccessibilityService` exclusively. `MainActivity` shows the "Enable Accessibility Service" prompt for all devices and does not establish an ADB connection.

### Calibration

Device-specific slider calibration is performed once per physical device from inside QZCompanion. The guided calibration screen runs on the iFit tablet, uses `GestureService` gestures to sweep incline and resistance, subscribes to the shared `MonoStdoutMetricHub`, fits `Y = origin − scale × value`, writes `/sdcard/qz-calibration.json`, updates `DeviceCalibration.current`, and selects `custom_calibrated` without an app restart.

`DeviceCalibration` remains the compatibility boundary. It holds the fitted origin, scale, and trackX for each slider axis, plus hysteresis defaults, and exposes `targetThumbY(float grade)` for use by `CalibratedBikeDevice`. If `qz-calibration.json` is absent, `DeviceCalibration.load(SharedPreferences)` provides a legacy fallback.

`tools/discover-device.py` is retained as an external fallback for contributors, recovery, unattended validation, and comparison runs. Its `qz-calibration.json` output remains compatible with the in-app loader.

#### discover-device.py as a device onboarding tool

Most contributors don't own every NordicTrack/ProForm variant they want to support. The in-app calibration flow is the primary mechanism for closing that gap: a user with the physical device runs the sweep, obtains working ORIGIN and scale constants for their machine, and can immediately ride with Zwift via the `custom_calibrated` device — no code changes required. `discover-device.py` remains useful when a contributor needs an ADB-run reproducible sweep.

The fitted constants from `qz-calibration.json` are also the exact values a contributor needs to write a proper hardcoded device class (the `ORIGIN_INCLINE_THUMBY`, `ORIGIN_SPEED_THUMBY`, and scale factors in the `offsetXxxThumbY` formulas). The typical onboarding workflow for a new device is:

1. User runs in-app calibration on their hardware, which writes `/sdcard/qz-calibration.json`, selects `custom_calibrated`, and confirms Zwift control works.
2. User submits the resulting `qz-calibration.json` (or pastes the displayed constants) in a GitHub issue or PR.
3. A contributor uses those constants to write the device class and register it — the user's calibration data becomes the hardcoded formula for everyone.

---

## Design Decisions

### Why mono-stdout?

The iFit app (`com.ifit.standalone`) is a Xamarin.Android (Wolf platform) application. The Xamarin/Mono runtime emits every `FitPro` metric change as a logcat line under the tag `mono-stdout`. This is consistent across every NordicTrack and ProForm device running the same Xamarin stack, which covers all hardware supported by this project.

Subscribing to `mono-stdout` via a persistent `logcat -s mono-stdout` process is strictly better than the per-device polling strategies used by the legacy codebase (`tail`/`grep` on a log file, `cat`, full logcat dumps): no repeated shell process spawning, no 250 ms poll lag, and no device-specific reader selection to maintain. `MonoStdoutMetricReader` is now the universal default for all 44 devices.

---

## Reference

### MetricReader Interface

All 44 devices use `MonoStdoutMetricReader`. The `MetricReader` interface has a `subscribe(Consumer<QZMetricPacket>)` method that `MonoStdoutMetricReader` implements by starting a background thread; `QZMetricUnicastingService` calls `subscribe()` once on startup rather than polling. Each `QZMetricPacket` carries a single wire-format metric field and its float value.

### MonoStdoutMetricReader

The iFit application (`com.ifit.standalone`) is a Xamarin.Android (Wolf platform) app. The Xamarin/Mono runtime emits every `FitPro` metric change as a logcat line under the tag `mono-stdout`, one value per line. `MonoStdoutMetricReader` opens `logcat -s mono-stdout` as a persistent child process in a daemon thread and parses each line as it arrives. Latency from firmware change to cached snapshot update is under 10 ms. The thread restarts automatically if the logcat process exits.

`read()` starts the logcat background thread; it returns immediately. There are no file or shell arguments.

`QZMetricUnicastingService` calls `subscribe(snapshot →)` once when a device is selected. `MonoStdoutMetricReader` stores the listener and invokes it on every parsed update; the service then unicasts only the changed fields to `qzAddress:8002`.

**Parsed line keywords** (last whitespace-delimited token on each line is the value):

| Field | Keywords |
|-------|----------|
| `speedKmh` | `Changed KPH`, `Changed Actual KPH` |
| `inclinePct` | `Changed Grade`, `Changed Actual Grade`, `Grade changed` |
| `watts` | `Changed Watts` |
| `cadenceRpm` | `Changed RPM` |
| `gearLevel` | `Changed CurrentGear` |
| `resistanceLvl` | `Changed Resistance` |
| `heartRate` | `HeartRateDataUpdate` |

### QZMetricPacket Fields

`QZMetricPacket` carries a single metric enum value and its float reading. `QZMetricUnicastingService` receives one packet per changed field, re-unicasts the last known value for unchanged fields, and maps the wire-format metric to the device-domain `SliderMetric`; `DeviceController.onMetric()` forwards it to `device.applyMetric(SliderMetric, float)`, which routes the value to the matching `Slider` via `applyIfMatch()` and updates its live state.

| `QZMetricPacket.Metric` | Unit |
|----------------|------|
| `KPH` | km/h |
| `GRADE` | % |
| `WATTS` | W |
| `RPM` | RPM |
| `CURRENT_GEAR` | level |
| `RESISTANCE` | level |
| `HEART_RATE` | BPM |
