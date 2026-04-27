# Testing Methodology

## Philosophy

Tests in this project are pure JVM unit tests — no mocking framework, no fakes, no stubs beyond simple capturing lambdas. The production code is structured to be testable without Android by:

- Keeping `CommandDispatcher`, `Ocr`, `FormulaFitter`, and all `Device` subclasses free of `android.*` imports.
- Injecting side effects via functional interfaces (`CommandExecutor`, `Clock`, `Logger`) rather than static calls or singletons.
- Keeping calibration logic (`Ocr`, `FormulaFitter`) in the `calibration/` package with no Android dependencies.

Robolectric is used only where the Android service lifecycle or real socket I/O is the subject under test.

Run all tests with:

```bash
./run-tests.sh                # delegates to ./gradlew testDebugUnitTest
./gradlew testDebugUnitTest   # equivalent; also accepts flags like --info
```

Results: `app/build/reports/tests/testDebugUnitTest/index.html`

---

## Test Files

| File | Tests | What it covers |
|------|------:|----------------|
| `OcrTest` | 44 | `Ocr.extractMetrics()`: all label variants, 500m-split conversion, thresholds, fallbacks, edge cases |
| `WattRectFallbackTest` | 19 | `OcrRect` (fromString, width, intersects) and `WattRectFallback` (update/cache/tryRecover) |
| `FormulaFitterTest` | 17 | `FormulaFitter.fit()`: least-squares coefficients, R², hysteresis classification, degenerate-input guards, Result format strings |
| `DeviceUtilsTest` | 15 | `Device.parseField()` and `Device.roundToOneDecimal()`: locale separators, fallback parsing, boundary rounding |
| `MetricReaderTest` | 24 | Log-line parsing for all field types across all polling readers; malformed lines; truncation boundary; `MonoStdoutMetricReader` stream parsing and push subscription |
| `BikeDeviceTest` | 67 | All bike device subclasses: `targetY()` formula at representative values, throttle/cache, de-dup, null resistance slider, negative incline, hysteresis overshoot |
| `TreadmillDeviceTest` | 144 | All treadmill device subclasses: `targetY()` formula at representative values, speed gate, throttle/cache, negative incline, cache overwrite |
| `CommandDispatcherTest` | 16 | Full pipeline from raw UDP string → `decodeCommand` → `applyCommand` → captured swipe; throttle, cache, locale mismatch |
| `UdpPipelineTest` | 5 | End-to-end with real UDP sockets: datagram received by `CommandListenerService` → `CommandDispatcher` → device swipe captured |
| `ZwiftRideSimulationTest` | 10 | Scenario replay against S22i: synthetic Zwift grade sequence through the full pipeline; time-injected throttle; verifies y1→y2 state chain across calls |
| `HillyRouteReplayTest` | 1 | Parameterised replay of a recorded Hilly Route (31 intervals) against S22i; verifies de-dup fires correctly on repeated grades |
| `ZwiftRideRobolectricTest` | 5 | Robolectric: real `CommandListenerService` started in an Android runtime, real UDP datagrams sent to port 8003, swipes captured via injectable executor |
| `CommandListenerServiceTest` | 7 | Robolectric: service lifecycle — onCreate/onDestroy, WakeLock acquire/release, socket rebind |
| `MetricReaderUnicastingServiceTest` | 5 | Robolectric: service lifecycle and binding contract |
| **Total** | **379** | |

---

## How Swipe Tests Work

Device formula tests follow a consistent three-step pattern:

```java
// 1. Construct the device and install a capturing executor
S22iDevice dev = new S22iDevice();
List<String> commands = new ArrayList<>();
dev.commandExecutor = commands::add;

// 2. Apply a command directly (or via CommandDispatcher for pipeline tests)
dev.applyIncline(5.0f, clock.now());

// 3. Assert the exact swipe string
assertEquals("input swipe 75 622 75 529 200", commands.get(0));
```

Expected Y values are derived analytically from the device's `targetY()` formula, adjusted for `hysteresisPixels()` overshoot and Java's integer truncation behaviour (`(int)` cast). The test comment documents the formula and the derivation so future calibration changes can be verified by inspection.

`CommandDispatcher` tests inject a `Clock` lambda (`() -> time[0]`) and advance `time[0]` directly — no `Thread.sleep()` anywhere in the test suite.

`MonoStdoutMetricReader` tests inject a fake `ProcessFactory` that returns a process backed by a `ByteArrayInputStream`, then call `reader.awaitCurrentStream()` to drain the daemon thread before asserting on the snapshot.

---

## Adding Tests for a New Device

When you add a device class, add at least three formula tests — a floor value, a mid-range value, and a ceiling value — in the appropriate test class:

**Bike device** → `BikeDeviceTest.java`

```java
@Test public void myNewBike_incline_midRange() {
    BikeDevice dev = dev(new MyNewDevice());
    applyIncline(dev, 5.0);
    assertSwipe("input swipe <trackX> <y1> <trackX> <targetY(5.0)> 200");
}
```

**Treadmill device** → `TreadmillDeviceTest.java` — same pattern; also add a speed test.

**Scenario test** — if your device has non-trivial quantization, hysteresis, or a `currentThumbY()` override, add a short sequence test in `ZwiftRideSimulationTest` that exercises those edge cases across multiple calls.

The helper methods `dev()`, `applyIncline()`, `applySpeed()`, and `assertSwipe()` are defined as package-private statics at the top of each test class.

---

## Known Gaps

| Area | Status | Notes |
|------|--------|-------|
| `FtmsPacket` | Not tested | Pure Java; `parseControlPoint()` and `response()` have no unit tests. Straightforward to add. |
| `BleCanaryService` | Not tested | Android BLE stack; would require Robolectric + shadow classes. Low priority while the canary is in pre-production. |
| `MetricReader` error paths | Partially tested | Malformed lines and truncation boundary covered; duplicate-field and extreme-value edge cases are not. |
| `FormulaFitter` — real-world calibration datasets | Not tested | Algorithm is verified for synthetic cases; representative sweep data from real devices is not in the test suite. |
| Accessibility swipe path | Not tested | `MyAccessibilityService.performSwipe()` requires an Android runtime; no Robolectric coverage yet. |
