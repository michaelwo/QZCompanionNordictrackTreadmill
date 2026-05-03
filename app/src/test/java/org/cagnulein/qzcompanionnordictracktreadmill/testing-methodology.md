# Testing Methodology

## Philosophy

Tests in this project are pure JVM unit tests — no mocking framework, no fakes, no stubs beyond simple capturing lambdas. The production code is structured to be testable without Android by:

- Keeping `CommandDispatcher` and all `Device` subclasses free of `android.*` imports.
- Injecting side effects via functional interfaces (`CommandExecutor`, `Clock`, `Logger`) rather than static calls or singletons.
- Keeping `DeviceCalibration` in the `device/` package with no Android dependencies.

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
| `MetricReaderTest` | 4 | `MonoStdoutMetricReader` stream parsing and push subscription; malformed lines |
| `BikeDeviceTest` | 64 | All bike device subclasses: `targetY()` formula at representative values, FIFO queue, de-dup, null resistance slider, negative incline, hysteresis overshoot, `decodeCommands` sentinel/boundary cases |
| `TreadmillDeviceTest` | 142 | All treadmill device subclasses: `targetY()` formula at representative values, speed gate, FIFO queue, negative incline, `decodeCommands` sentinel/boundary cases |
| `QZCommandPacketTest` | 23 | `QZCommandPacket` parsing: all command types, malformed input, locale separators, boundary values |
| `QZMetricPacketTest` | 29 | `QZMetricPacket`: serialize, parse, round-trip, wire-format identity |
| `CommandDispatcherTest` | 17 | Full pipeline from raw UDP string → `decodeCommands` → `applyCommand` → captured swipe; throttle, FIFO queue, passive drain, sentinel flush, locale mismatch |
| `DeviceCalibrationRegressionTest` | 13 | `DeviceCalibration` JSON loading, formula application, and regression against known-good calibration values |
| `UdpPipelineTest` | 5 | End-to-end with real UDP sockets: datagram received by `CommandListenerService` → `CommandDispatcher` → device swipe captured |
| `ZwiftRideSimulationTest` | 10 | Scenario replay against S22i: synthetic Zwift grade sequence through the full pipeline; time-injected throttle; verifies y1→y2 state chain across calls |
| `HillyRouteReplayTest` | 1 | Parameterised replay of a recorded Hilly Route (31 intervals) against S22i; verifies de-dup fires correctly on repeated grades |
| `ZwiftRideRobolectricTest` | 5 | Robolectric: real `CommandListenerService` started in an Android runtime, real UDP datagrams sent to port 8003, swipes captured via injectable executor |
| `CommandListenerServiceTest` | 7 | Robolectric: service lifecycle — onCreate/onDestroy, WakeLock acquire/release, socket rebind |
| `MetricReaderUnicastingServiceTest` | 5 | Robolectric: service lifecycle and binding contract |
| **Total** | **325** | |

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

## CommandDispatcher Queue and Sentinel Pattern

`CommandDispatcher` drains its queue **passively** — only when `dispatch()` is called, and only one Command per call when the throttle window is open. There is no background timer. This is by design: Zwift's continuous UDP stream drives draining naturally during a ride, and the sentinel flood at ride end (`"-1;-100"` packets) provides a free flush mechanism.

**Sentinels as flush pulses:** A sentinel message decodes to an empty `List<Command>` (no new Commands enqueued), but the drain check still runs. So each sentinel call removes exactly one item from the queue — making it the standard tool for flushing queued state in tests:

```java
// Queue a Command during the throttle window:
time[0] += 100;
d.dispatch("12.0", device);   // throttled → queued

// Flush it with a sentinel once the window re-opens:
time[0] += CommandDispatcher.SWIPE_THROTTLE_MS;
d.dispatch("-1", device);     // empty decode → drains "12.0" from queue
```

When writing dispatcher tests that need to drain multiple queued Commands, dispatch one sentinel per Command:

```java
d.dispatch("-1", device);  // drains queued Command 1
time[0] += CommandDispatcher.SWIPE_THROTTLE_MS;
d.dispatch("-1", device);  // drains queued Command 2
```

The test `sentinel_drainsOneCommandPerCall` in `CommandDispatcherTest` explicitly documents and verifies this behaviour.

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
| `discover-device.py` sweep output | Not tested | The calibration script is validated via the unattended test plan (`tools/test-calibration-unattended.md`), not a unit test. |
| Accessibility swipe path | Not tested | `MyAccessibilityService.performSwipe()` requires an Android runtime; no Robolectric coverage yet. |
