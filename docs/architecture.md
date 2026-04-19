# Architecture & Data Flow

## Overview

QZCompanion receives workout targets from the QZ fitness app over UDP and translates them into simulated touch-screen swipe gestures that physically move the sliders on NordicTrack/ProForm iFit devices. It is entirely open-loop: commands are sent and forgotten — there is no confirmation that the device reached the requested position.

---

## End-to-End Pipeline

```
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

---

## Key Classes

### `CommandListenerService`
Android `Service` that loops on a `DatagramSocket` (port 8003), holds a `WakeLock` per receive, and passes each packet to `CommandDispatcher`. Handles locale-aware decimal separators (`,` vs `.`).

### `CommandDispatcher`
Stateless parser/router. Splits the raw UDP string on `;`, calls `device.decodeCommand()` to get a `Command`, then `device.applyCommand(cmd, now)`. Has an injectable `Clock` interface so tests can drive time without sleeping.

### `Device` (abstract)
Base class for all fitness devices. Owns:
- `commandExecutor` — functional interface wired by `MainActivity`; the executor is the only Android-coupled piece
- `logger` — functional interface; no-op by default, wired to `Log.i` in production
- `lastCommandMs` — timestamp used for throttle window enforcement
- `swipe(x, y1, y2)` — builds the `input swipe` string and hands it to `commandExecutor`

### `BikeDevice` (abstract, extends `Device`)
Controls one or two `Slider` instances (incline + optional resistance). `applyCommand()` enforces a 500 ms throttle window and de-duplicates commands whose quantized value equals the last applied value. Caches the incoming value if throttled and re-applies it on the next call.

### `TreadmillDevice` (abstract, extends `Device`)
Controls speed and incline `Slider` instances. Also gates speed commands when `lastSnapshot.speed() <= 0` (treadmill stopped) to avoid swipes on a stationary belt.

### `Slider` (abstract)
Represents one physical slider on the iFit touch screen. Subclasses supply:
- `trackX()` — fixed horizontal pixel position
- `targetY(double v)` — converts a metric value to a logical pixel Y coordinate
- `quantize(float v)` — (optional) snaps to physically reachable increments
- `currentThumbY(MetricSnapshot)` — (optional) derive starting position from live metrics rather than tracking it as internal state; used when the slider can drift if commands are missed
- `hysteresisPixels()` — (optional) pixels of directional overshoot to compensate for physical stiction; the swipe goes `hysteresisPixels()` past `targetY`, while `thumbY` still tracks the logical target so de-dup is unaffected. Default: 0.

### `DeviceRegistry`
Singleton `EnumMap` mapping every `DeviceId` to a pre-constructed `Device` instance. Neither `CommandListenerService` nor `MainActivity` reference concrete device classes — all coupling goes through `DeviceId`.

---

## Throttle, Cache, and De-dup

Three mechanisms prevent redundant or too-frequent swipes:

| Mechanism | Where | Behaviour |
|-----------|-------|-----------|
| **Throttle** | `BikeDevice`, `TreadmillDevice` | If `now < lastCommandMs + 500ms`, the incoming value is cached; it is applied on the next call that falls outside the window. |
| **De-dup** | `BikeDevice` | If the quantized value equals `lastApplied`, the swipe is skipped entirely. |
| **Speed gate** | `TreadmillDevice` | Speed commands are held in cache while `lastSnapshot.speed <= 0` (belt stopped). |

---

## Metric Feedback (MetricReaderBroadcastingService → Device)

`MetricReaderBroadcastingService` runs a background poll loop that reads current device state (speed, incline, cadence, watts, etc.) and calls `Device.instance.updateSnapshot(m)`. The updated snapshot is used by:
- `currentThumbY()` overrides in `Slider` subclasses — devices that re-derive the slider's starting position from live observed metrics rather than tracking it as internal state
- The speed gate in `TreadmillDevice` — no speed swipe is sent while `lastSnapshot.speed <= 0`

### MetricReader Interface

```
MetricReader
│   read(String file, Shell shell) → MetricSnapshot
│   forIfitV2() → MetricReader          (default: returns this)
│
├── TailGrepMetricReader                (default for most treadmill devices)
│   │   forIfitV2() → TailGrepIfitV2MetricReader
│   ├── TailGrepIfitV2MetricReader      (iFit v2 log format variant)
│   └── BikeMetricReader               (skips KPH; forIfitV2() → this)
├── CatFileMetricReader
├── DirectLogcatMetricReader
└── LogcatDumpMetricReader
```

Each device returns its reader from `defaultMetricReader()`. iFit v2 adaptation is handled
orthogonally: `MetricReaderBroadcastingService` calls `reader.forIfitV2()` when the newer iFit log path is detected
(`/sdcard/android/data/com.ifit.glassos_service/...`). Readers that are format-agnostic
(CatFile, DirectLogcat, BikeMetric) return `this`; `TailGrepMetricReader` returns a
`TailGrepIfitV2MetricReader` instance, which overrides two template methods:
`inclineKeyword()` (`"Grade"` → `"INCLINE"`) and `valueTokenIndex()` (last token → second-to-last).
Device classes know nothing about iFit versions.

### `Shell` interface

`MetricReader.read()` receives a `Shell` rather than executing commands directly. `Shell` has two methods:

```java
InputStream execAndGetOutput(String command)  // run command, return stdout
Process      exec(String command)             // run command, fire and forget
```

This abstraction keeps readers free of Android dependencies and allows them to be exercised in pure JVM unit tests with a mock `Shell`.

### `MetricSnapshot`

Holds all observable metrics as nullable `Float` fields. `null` means "not observed this cycle" — `MetricReaderBroadcastingService` re-broadcasts the last known value rather than emitting zero. The `speed()`, `incline()`, `resistance()`, and `gear()` accessors return `0f` when the field is null, which is safe for arithmetic but should not be confused with a confirmed zero reading.

| Field | Unit | Source keyword |
|-------|------|----------------|
| `speedKmh` | km/h | `Changed KPH`, `Kph changed`, `Changed Actual KPH` |
| `inclinePct` | % | `Changed Grade`, `Grade changed`, `Changed INCLINE` (v2), `Changed Actual Grade` |
| `watts` | W | `Changed Watts`, `Watts changed` |
| `cadenceRpm` | RPM | `Changed RPM` |
| `gearLevel` | level | `Changed CurrentGear` |
| `resistanceLvl` | level | `Changed Resistance` |
| `heartRate` | BPM | `HeartRateDataUpdate` (CatFileMetricReader only) |

### Reader Implementations

**`TailGrepMetricReader`** (default for treadmills without a known file path)

Runs `tail -n500 <file> | grep -a "<keyword>" | tail -n1` with two fallback strategies (`grep` alone, then `cat | grep`) if the pipe returns nothing. After every 1200 read cycles (~20 minutes at a 1-second poll rate) it truncates the log file to zero to prevent unbounded growth. Subclasses override `inclineKeyword()` and `valueTokenIndex()` to adapt to format variants without any boolean flag arguments. `forIfitV2()` returns a `TailGrepIfitV2MetricReader`.

**`TailGrepIfitV2MetricReader`** (extends `TailGrepMetricReader`)

Overrides `inclineKeyword()` → `"INCLINE"` and `valueTokenIndex()` → second-to-last token. All other behaviour is inherited.

**`BikeMetricReader`** (extends `TailGrepMetricReader`)

Identical to `TailGrepMetricReader` except `findSpeed()` is not called. Bikes do not emit `"Changed KPH"` to the iFit log, so skipping that search avoids a wasted shell exec every cycle. `forIfitV2()` returns `this` — the V2 log format difference does not affect bike metric parsing.

**`CatFileMetricReader`**

Reads the entire file with `cat` and scans every line for metric keywords in a single pass. Used by devices whose firmware lacks reliable `tail`/`grep` support (X22i, C1750, NTEX02117_2). Also recognises the `"Kph changed"` and `"Watts changed"` variants and parses `HeartRateDataUpdate` for heart rate.

**`DirectLogcatMetricReader`**

Calls `Runtime.getRuntime().exec("logcat -b all -d -t 500")` directly — no ADB, no log file. The `-t 500` flag caps output to the last 500 log entries so memory use stays bounded. Filters out its own `QZ:Service` tag to avoid feedback loops. Used by Grand Tour Pro, NTEX71021, and ProForm Carbon C10.

**`LogcatDumpMetricReader`**

Sends `logcat -b all -d -t 500 > /sdcard/logcat.log` via ADB, then reads the resulting file with `cat`. Two-step because some devices cannot stream logcat output directly but can write it to a file. Used by the T7.5s treadmill.

### Reader Selection per Device

| Reader | Used by |
|--------|---------|
| `BikeMetricReader` | `BikeDevice` subclasses (S22i, S15i, S27i, …) |
| `TailGrepMetricReader` | `TreadmillDevice` subclasses that don't override `defaultMetricReader()` (X32i, Nordictrack 2950, …) |
| `CatFileMetricReader` | X22i, C1750, NTEX02117_2, Exp7i, and others |
| `DirectLogcatMetricReader` | Grand Tour Pro, NTEX71021, ProForm Carbon C10 |
| `LogcatDumpMetricReader` | T7.5s |

---

## Command Execution Paths

| Path | Classes | When used |
|------|---------|-----------|
| **ADB loopback** | `ShellService`, `DeviceConnection` | Default for all devices; requires ADB connection to 127.0.0.1:5555 |
| **Direct shell** | `ShellRuntime` → `Runtime.getRuntime()` | Devices with `requiresAdb() = false` and a `ShellRuntime` executor (NTEX02117_2, X22i, X14i) |
| **AccessibilityService** | `MyAccessibilityService` | `S22iNoAdbDevice`, `X22iNoAdbDevice`, `T95sDevice` — swipe injected via Android accessibility API |

The ADB connection is managed by `ShellService` (from the `android-remote-debugger` library). `MainActivity` reconnects automatically on stream failure with a 3-second delay, provided `Device.instance.requiresAdb()` is true.

---

## OCR Pipeline (calibration only)

`OcrCalibrationService` runs continuously in the background after the user grants screen-capture permission on first launch. It captures frames via `ScreenCaptureService`, passes them to `Ocr.extractMetrics()`, and logs each recognised metric (`QZ:OcrCalibration` tag). Recognised labels: `"speed"`, `"incline"`, `"cadence"`, `"resistance"`, `"watt"`, `"strokes per min"`, `"500 split"`.

OCR output is **not** broadcast to the QZ app — it is used exclusively by `CalibrationActivity`, which reads `OcrCalibrationService.latestReading` during a swipe sweep to build a commanded-Y → observed-incline table. `MetricReaderBroadcastingService` (the production metric path) reads from the iFit log file only; it has no OCR dependency.
