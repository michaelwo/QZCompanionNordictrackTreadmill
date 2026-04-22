# Testing Methodology

## Philosophy

Tests in this project are pure JVM unit tests — no mocking, no fakes, no stubs.
The production code is designed to be testable without Android by:

- Keeping `CommandDispatcher`, `Ocr`, `FormulaFitter`, and `Device` subclasses free of `android.*` imports.
- Injecting side effects via functional interfaces (`CommandExecutor`, `Clock`, `Logger`) rather than static calls.
- Keeping calibration logic (`Ocr`, `FormulaFitter`) in the `calibration/` package with no Android dependencies.

Robolectric is used only where the Android lifecycle is the subject under test (e.g., `MetricReaderBroadcastingServiceTest`).

---

## Test Files

| File | What it covers |
|------|----------------|
| `OcrTest` | `Ocr.extractMetrics()`: all label variants, 500m-split conversion, thresholds, fallbacks, edge cases |
| `WattRectFallbackTest` | `OcrRect` (fromString, width, intersects) and `WattRectFallback` (update/cache/tryRecover) |
| `FormulaFitterTest` | `FormulaFitter.fit()`: least-squares coefficients, R², hysteresis classification, degenerate-input guards, Result format strings |
| `DeviceUtilsTest` | `Device.parseField()` and `Device.roundToOneDecimal()`: locale separators, fallback parsing, boundary rounding |
| `BikeDeviceTest` | BikeDevice subclasses: formula swipe generation, throttle/cache, de-dup, null resistance slider, negative incline |
| `TreadmillDeviceTest` | TreadmillDevice subclasses: formula swipe generation, speed gate, throttle/cache, negative incline, cache overwrite |
| `CommandDispatcherTest` | Full pipeline from raw UDP string through decodeCommand → applyCommand → swipe; throttle, cache, locale mismatch |
| `MetricReaderTest` | Log-line parsing for all field types; malformed lines; truncation boundary |
| `CommandListenerServiceTest` | Robolectric: service lifecycle only |
| `MetricReaderBroadcastingServiceTest` | Robolectric: service lifecycle + binding contract; exercises real source compilation |
| `UdpPipelineTest` | End-to-end: UDP socket → CommandDispatcher → device swipe, with injected clock |
| `ZwiftRideSimulationTest` | Scenario replay: simulates a full Zwift ride against an X11i with time-controlled throttle |
| `HillyRouteReplayTest` | Parameterised replay: runs a pre-recorded hilly route against multiple treadmill devices |

---

## How Swipe Tests Work

Each `BikeDeviceTest` and `TreadmillDeviceTest` case:

1. Calls `dev(new XDevice())` to install a capturing `CommandExecutor` that stores the last command string.
2. Calls `applyIncline(v)` or `applySpeed(v)` directly (or `CommandDispatcher.dispatch()` for pipeline tests).
3. Asserts the exact `"input swipe X Y1 X Y2 200"` string.

The expected Y values are derived analytically from the device's `targetY()` formula plus the `hysteresisPixels()` overshoot, matching the Java integer truncation (`(int)` cast) in the source.

---

## Known Gaps

| Area | Status | Notes |
|------|--------|-------|
| `MetricReader` error paths | Partially tested | Malformed lines and truncation boundary covered; duplicate-field and extreme-value cases are not. |
| `FormulaFitter` — large real-world datasets | Not tested | The algorithm is correct for the synthetic cases; representative device calibration data is not included in the test suite. |

---

## Running Tests

```bash
./gradlew test                # all unit tests
./gradlew testDebugUnitTest   # debug variant only
```

Test results: `app/build/reports/tests/testDebugUnitTest/index.html`
