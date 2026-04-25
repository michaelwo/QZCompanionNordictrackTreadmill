# Architecture

## Overview

QZCompanion is an Android app that runs on the NordicTrack/ProForm iFit embedded tablet and acts as the bridge between the Zwift training ecosystem and the physical hardware. It has two concurrent jobs: **accepting control commands** (grade, resistance, speed) forwarded from the QZ app and translating them into touch gestures on the iFit screen, and **reading live metrics** (speed, incline, cadence, watts) from the iFit firmware and broadcasting them back to the QZ app so Zwift stays in sync with what the machine is actually doing.

---

## Context

### Why can't Zwift connect directly to some NordicTrack devices?

Zwift requires **BLE hardware and a full FTMS (Fitness Machine Service) software implementation** on the fitness device — both to receive grade and resistance commands and to report metrics back. The NordicTrack and ProForm machines supported by this project have neither: the iFit 1/2 embedded tablet has no BLE radio dedicated to fitness machine control, and the iFit firmware does not implement the FTMS profile.

The **QZ app** satisfies Zwift's FTMS requirement by running on a separate device that *does* have BLE — a phone, laptop, or computer. Zwift pairs with QZ over BLE as if it were the fitness machine. QZ then forwards Zwift's grade and resistance commands over UDP (Wi-Fi) to QZCompanion, which runs on the iFit tablet itself and drives the hardware by injecting touch gestures on the iFit screen. Metrics travel the reverse path: QZCompanion reads them from the iFit firmware log and broadcasts them back to QZ, which relays them to Zwift over BLE.

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
CommandListenerService.listenAndWaitAndThrowIntent()
        │
        │  splits on ";"
        ▼
CommandDispatcher.dispatch()
        │
        │  device.decodeCommand(parts, decimalSeparator)
        │    → produces Command{speedKmh, inclinePct, resistanceLvl}
        │
        │  device.applyCommand(cmd, now)
        ▼
BikeDevice / TreadmillDevice   [throttle, cache, de-dup]
        │
        │  Slider.moveTo(value, device)
        │    quantize(value)        → snap to physical increments
        │    targetY(value)         → compute logical pixel Y coordinate
        │    hysteresisPixels()     → directional overshoot in px (0 for most sliders)
        │    device.swipe(x, fromY, swipeY)   [swipeY may differ from targetY]
        ▼
CommandExecutor  [set by MainActivity]
        │
        ├── ADB path (default): MainActivity.sendCommand()
        │     → ShellService.queueCommand()
        │     → ADB loopback 127.0.0.1:5555
        │     → "input swipe x y1 x y2 200"
        │
        ├── Shell path (NTEX02117_2, X22i, X14i):
        │     ShellRuntime.exec()  → Runtime.getRuntime().exec()
        │
        └── AccessibilityService path (NoADB variants, T95s):
              MyAccessibilityService.performSwipe()
```

Three mechanisms filter commands before a swipe is issued:

| Mechanism | Where | Behaviour |
|-----------|-------|-----------|
| **Throttle** | `BikeDevice`, `TreadmillDevice` | If `now < lastCommandMs + 500ms`, the incoming value is cached and applied on the next call that falls outside the window. |
| **De-dup** | `BikeDevice` | If the quantized value equals `lastApplied`, the swipe is skipped entirely. |
| **Speed gate** | `TreadmillDevice` | Speed commands are held in cache while `lastSnapshot.speed <= 0` (belt stopped). |

### Outbound: Hardware → Zwift

The iFit firmware writes speed, incline, cadence, and other metrics to a log file on the device. QZCompanion reads that file continuously, extracts changed values, and broadcasts them back to the QZ app.

```
iFit firmware
        │
        │  writes to log file every ~1 s
        │  e.g. /sdcard/android/data/com.ifit.glassos_service/
        │            files/.valinorlogs/log.latest.txt
        │
        │  (S22i NoADB: also emits logcat tag "mono-stdout" per metric change)
        ▼
MetricReaderBroadcastingService
        │
        │  MetricReader.read(file, shell)      ← polling path (250 ms)
        │    or reader.subscribe(snapshot →)   ← push path (MonoStdoutMetricReader)
        │    → returns MetricSnapshot{speedKmh, inclinePct,
        │               cadenceRpm, watts, resistanceLvl, heartRate}
        │
        │  Device.instance.updateSnapshot(snapshot)
        │    → feeds speed gate and currentThumbY tracking
        │    → emits QZ:Snapshot log line when incline changes
        │
        │  delta check: only changed fields are broadcast
        ▼
UDP datagram, port 8002
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

The 250 ms poll interval is intentionally faster than the firmware's ~1 Hz write rate so that every firmware update is caught within a quarter second. Only fields that changed since the last broadcast are sent — unchanged metrics produce no UDP traffic. The `updateSnapshot()` call also closes the feedback loop for the inbound path: the speed gate blocks treadmill speed swipes while `lastSnapshot.speed <= 0`, and slider subclasses that implement `currentThumbY()` re-derive their starting position from live observed metrics rather than tracking it as internal state.

---

## Components

### Package Layout

```
org.cagnulein.qzcompanionnordictracktreadmill
├── service/          CommandListenerService, MetricReaderBroadcastingService,
│                     MyAccessibilityService, OcrCalibrationService, ScreenCaptureService
├── device/           Device, BikeDevice, TreadmillDevice, Slider, DeviceRegistry (+ DeviceId enum)
│   ├── bike/         One class per bike device
│   └── treadmill/    One class per treadmill device
├── calibration/      Ocr, OcrBlock, FormulaFitter, CalibrationResult
├── dispatch/         CommandDispatcher, Command
└── reader/           MetricReader hierarchy, MetricSnapshot, ShellRuntime
```

### Device Model

**`Device`** (abstract) — base class for all fitness devices. Owns:
- `commandExecutor` — functional interface wired by `MainActivity`; the only Android-coupled piece
- `logger` — functional interface; no-op by default, wired to `Log.i` in production
- `lastCommandMs` — timestamp for throttle window enforcement
- `swipe(x, y1, y2)` — builds the `input swipe` string and hands it to `commandExecutor`

**`BikeDevice`** (abstract, extends `Device`) — controls one or two `Slider` instances (incline + optional resistance). `applyCommand()` enforces a 500 ms throttle window and de-duplicates commands whose quantized value equals the last applied value. Caches the incoming value if throttled and re-applies it on the next call.

**`TreadmillDevice`** (abstract, extends `Device`) — controls speed and incline `Slider` instances. Gates speed commands when `lastSnapshot.speed() <= 0` (treadmill stopped) to avoid swipes on a stationary belt.

**`Slider`** (abstract) — represents one physical slider on the iFit touchscreen. Subclasses supply:
- `trackX()` — fixed horizontal pixel position of the slider track
- `targetY(double v)` — converts a metric value to a logical pixel Y coordinate
- `quantize(float v)` — (optional) snaps to physically reachable increments
- `currentThumbY(MetricSnapshot)` — (optional) derives starting position from live metrics rather than tracking it as internal state; used when the slider can drift if commands are missed
- `hysteresisPixels()` — (optional) pixels of directional overshoot to compensate for physical stiction; the swipe overshoots `targetY` by this amount while `thumbY` still tracks the logical target so de-dup is unaffected. Default: 0.

**`DeviceRegistry`** — singleton `EnumMap` mapping every `DeviceId` to a pre-constructed `Device` instance. Neither `CommandListenerService` nor `MainActivity` reference concrete device classes — all coupling goes through `DeviceId`.

For per-device pixel formulas, command execution modes, and metric reader assignments, see [device-reference.md](device-reference.md).

### Command Dispatch

**`CommandListenerService`** — Android `Service` that loops on a `DatagramSocket` (port 8003), holds a `WakeLock` per receive, and passes each packet to `CommandDispatcher`. Handles locale-aware decimal separators (`,` vs `.`).

**`CommandDispatcher`** — stateless parser/router. Splits the raw UDP string on `;`, calls `device.decodeCommand()` to get a `Command`, then `device.applyCommand(cmd, now)`. Has an injectable `Clock` interface so tests can drive time without sleeping.

### Metric Reading

**`MetricReaderBroadcastingService`** — background service that drives either a 250 ms poll loop (polling readers) or a push subscription (streaming readers). Calls `Device.instance.updateSnapshot()` on every new reading and broadcasts changed metrics over UDP on port 8002.

The `MetricReader` interface and its implementations are described in the [Design Decisions](#design-decisions) and [Reference](#reference) sections below.

### Swipe Execution Paths

| Path | Classes | When used |
|------|---------|-----------|
| **ADB loopback** | `ShellService`, `DeviceConnection` | Default for all devices; requires ADB connection to 127.0.0.1:5555 |
| **Direct shell** | `ShellRuntime` → `Runtime.getRuntime()` | Devices with `requiresAdb() = false` and a `ShellRuntime` executor (NTEX02117_2, X22i, X14i) |
| **AccessibilityService** | `MyAccessibilityService` | `S22iNoAdbDevice`, `X22iNoAdbDevice`, `T95sDevice` — swipe injected via Android accessibility API |

The ADB connection is managed by `ShellService` (from the `android-remote-debugger` library). `MainActivity` reconnects automatically on stream failure with a 3-second delay, provided `Device.instance.requiresAdb()` is true.

### Calibration (OCR)

`OcrCalibrationService` runs in the background after the user grants screen-capture permission. It captures frames via `ScreenCaptureService`, passes them to `Ocr.extractMetrics()`, and logs each recognised metric under the `QZ:OcrCalibration` tag. Recognised labels: `"speed"`, `"incline"`, `"cadence"`, `"resistance"`, `"watt"`, `"strokes per min"`, `"500 split"`.

OCR output is **not** broadcast to the QZ app — it is used exclusively by `CalibrationActivity`, which reads `OcrCalibrationService.latestReading` during a swipe sweep to build a commanded-Y → observed-incline mapping table. The production metric path (`MetricReaderBroadcastingService`) reads from the iFit log file only; it has no OCR dependency.

---

## Design Decisions

### What's with all these Metric Readers?

The variety of readers exists because there is no single reliable way to extract metrics from every iFit device — each reader was added organically to the original QZ codebase when a device owner reported that the default approach did not work on their machine. The working assumption is that each choice reflects a real constraint on that specific model: a device where `tail` is unavailable or unreliable, one where metrics appear only in logcat rather than a log file, another where even streaming logcat requires a file-write detour. The device-specific assignments were carried forward as-is; there was no opportunity to verify all of them from scratch.

**Polling vs. streaming.** Every reader except `MonoStdoutMetricReader` works by polling: `MetricReaderBroadcastingService` calls `reader.read()` on a 250 ms timer, the reader shells out to `tail`/`grep`/`logcat`, parses the output, and returns a snapshot. This works but has overhead: a shell process is spawned and torn down every 250 ms regardless of whether anything changed on the machine.

The preferred approach is **push-based streaming**. `MonoStdoutMetricReader` was identified and tested on the S22i NoADB bike. The iFit app (`com.ifit.standalone`) is a Xamarin.Android (Wolf platform) application — it emits every FitPro metric change as a log line under the logcat tag `mono-stdout`. Rather than polling, `MonoStdoutMetricReader` opens a single persistent `logcat -s mono-stdout` process in a daemon thread and updates a cached snapshot the moment each line arrives. `MetricReaderBroadcastingService.read()` then returns that cached value with zero I/O — latency drops to milliseconds and CPU overhead between changes is essentially zero.

Because iFit's Xamarin runtime is consistent across NordicTrack and ProForm hardware generations, `mono-stdout` likely works on any device running the same Wolf/Xamarin stack — which is most of them. Confirming this on each model and migrating the corresponding reader to `MonoStdoutMetricReader` is left as a future exercise for developers who own those machines.

---

## Reference

### MetricReader Interface

```
MetricReader
│   read(String file, Shell shell) → MetricSnapshot
│   subscribe(Consumer<MetricSnapshot>) → boolean   (push path; default returns false)
│   forIfitV2() → MetricReader                      (default: returns this)
│
├── TailGrepMetricReader                (default for most treadmill devices)
│   │   forIfitV2() → TailGrepIfitV2MetricReader
│   ├── TailGrepIfitV2MetricReader      (iFit v2 log format variant)
│   └── BikeMetricReader               (skips KPH; forIfitV2() → this)
├── CatFileMetricReader
├── DirectLogcatMetricReader
├── LogcatDumpMetricReader
└── MonoStdoutMetricReader              (push-based; subscribe() returns true)
```

Each device returns its reader from `defaultMetricReader()`. iFit v2 adaptation is handled orthogonally: `MetricReaderBroadcastingService` calls `reader.forIfitV2()` when the newer iFit log path is detected (`/sdcard/android/data/com.ifit.glassos_service/...`). Readers that are format-agnostic (CatFile, DirectLogcat, BikeMetric, MonoStdout) return `this`; `TailGrepMetricReader` returns a `TailGrepIfitV2MetricReader` that overrides `inclineKeyword()` (`"Grade"` → `"INCLINE"`) and `valueTokenIndex()` (last token → second-to-last). Device classes know nothing about iFit versions.

### Reader Implementations

**`TailGrepMetricReader`** — runs `tail -n500 <file> | grep -a "<keyword>" | tail -n1` with two fallback strategies (`grep` alone, then `cat | grep`) if the pipe returns nothing. After every 1200 read cycles (~20 minutes at a 1-second poll rate) it truncates the log file to zero to prevent unbounded growth.

**`TailGrepIfitV2MetricReader`** (extends `TailGrepMetricReader`) — overrides `inclineKeyword()` → `"INCLINE"` and `valueTokenIndex()` → second-to-last token. All other behaviour is inherited.

**`BikeMetricReader`** (extends `TailGrepMetricReader`) — identical except `findSpeed()` is not called. Bikes do not emit `"Changed KPH"` to the iFit log, so skipping that search avoids a wasted shell exec every cycle.

**`CatFileMetricReader`** — reads the entire file with `cat` and scans every line for metric keywords in a single pass. Used by devices whose firmware lacks reliable `tail`/`grep` support (X22i, C1750, NTEX02117_2). Also recognises the `"Kph changed"` and `"Watts changed"` variants and parses `HeartRateDataUpdate` for heart rate.

**`DirectLogcatMetricReader`** — calls `Runtime.getRuntime().exec("logcat -b all -d -t 500")` directly — no ADB, no log file. The `-t 500` flag caps output to the last 500 log entries so memory use stays bounded. Filters out its own `QZ:Service` tag to avoid feedback loops. Used by Grand Tour Pro, NTEX71021, and ProForm Carbon C10.

**`LogcatDumpMetricReader`** — sends `logcat -b all -d -t 500 > /sdcard/logcat.log` via ADB, then reads the resulting file with `cat`. Two-step because some devices cannot stream logcat output directly but can write it to a file. Used by the T7.5s treadmill.

**`MonoStdoutMetricReader`** — streams `logcat -s mono-stdout` in a daemon thread. `read()` returns the cached snapshot with zero I/O; the thread updates it as each line arrives. Restarts automatically if the logcat process exits. Used by S22i NoADB.

### Reader Selection per Device

| Reader | Used by |
|--------|---------|
| `MonoStdoutMetricReader` | S22i NoADB |
| `BikeMetricReader` | All other `BikeDevice` subclasses (S22i, S15i, S27i, …) |
| `TailGrepMetricReader` | `TreadmillDevice` subclasses that don't override `defaultMetricReader()` (X32i, Nordictrack 2950, …) |
| `CatFileMetricReader` | X22i, C1750, NTEX02117_2, Exp7i, and others |
| `DirectLogcatMetricReader` | Grand Tour Pro, NTEX71021, ProForm Carbon C10 |
| `LogcatDumpMetricReader` | T7.5s |

### MetricSnapshot Fields

`MetricSnapshot` holds all observable metrics as nullable `Float` fields. `null` means "not observed this cycle" — `MetricReaderBroadcastingService` re-broadcasts the last known value rather than emitting zero. The `speed()`, `incline()`, `resistance()`, and `gear()` accessors return `0f` when the field is null, which is safe for arithmetic but should not be confused with a confirmed zero reading.

| Field | Unit | Source keyword |
|-------|------|----------------|
| `speedKmh` | km/h | `Changed KPH`, `Kph changed`, `Changed Actual KPH` |
| `inclinePct` | % | `Changed Grade`, `Grade changed`, `Changed INCLINE` (v2), `Changed Actual Grade` |
| `watts` | W | `Changed Watts`, `Watts changed` |
| `cadenceRpm` | RPM | `Changed RPM` |
| `gearLevel` | level | `Changed CurrentGear` |
| `resistanceLvl` | level | `Changed Resistance` |
| `heartRate` | BPM | `HeartRateDataUpdate` (CatFileMetricReader only) |

### Shell Interface

`MetricReader.read()` receives a `Shell` rather than executing commands directly:

```java
InputStream execAndGetOutput(String command)  // run command, return stdout
Process      exec(String command)             // run command, fire and forget
```

This abstraction keeps readers free of Android dependencies and allows them to be exercised in pure JVM unit tests with a mock `Shell`.
