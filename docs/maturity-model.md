# QZCompanion App Maturity Model

Eight dimensions, each scored 0–3. The model is specific to this project's constraints:
an Android app that controls fitness devices via touch injection, with no server side,
no network API, and a hardware-in-the-loop feedback problem.

---

## Scoring Scale

| Score | Meaning |
|-------|---------|
| **0** | Missing or broken |
| **1** | Ad-hoc / works but fragile |
| **2** | Defined, documented, repeatable |
| **3** | Measured, automated, self-correcting |

---

## Dimensions

### 1. Test Coverage

Does the code have tests that catch regressions before hardware access is needed?

| Score | Criteria |
|-------|----------|
| 0 | No tests |
| 1 | Some unit tests for isolated helpers |
| 2 | Core dispatch pipeline covered: throttle, de-dup, quantize, swipe formula; edge cases (sentinel values, locale separators) covered |
| 3 | Full end-to-end route replay test (e.g. HillyRouteReplayTest); all device formula paths exercised; metric reader tested against real log samples |

### 2. Observability

Can you tell what the app is doing and why, during and after a ride?

| Score | Criteria |
|-------|----------|
| 0 | No logging |
| 1 | Ad-hoc `Log.i` calls, unstructured |
| 2 | Structured log tags (`QZ:Dispatch`, `QZ:UDP`); throttle, de-dup, and cache decisions logged with reasons; ride monitoring script captures metrics |
| 3 | Post-ride analysis script produces actionable report (commands dispatched, de-dup rate, memory/CPU trend, ADB failures); anomalies flagged automatically |

### 3. Device Portability

How much work is required to add a new device or variant?

| Score | Criteria |
|-------|----------|
| 0 | Device logic scattered across multiple unrelated files |
| 1 | Device class exists but adding one requires changes in 3+ files |
| 2 | Single `DeviceRegistry`; new device = one new class + one registry entry; no changes to dispatch or UI code |
| 3 | New device class is self-contained: formula, execution mode, metric reader, and display name in one file; covered by at least one unit test |

### 4. Formula Auditability

Can you understand, verify, and correct the coordinate math for a device?

| Score | Criteria |
|-------|----------|
| 0 | Magic numbers, no explanation |
| 1 | Constants named but derivation unknown |
| 2 | Formula documented with derivation method (two-point linear fit); correction factors (e.g. S22i `v > 3.0` overshoot offset) explained inline |
| 3 | Formula verified against the real device via calibration sweep; commanded vs. observed table exists; tolerance confirmed ≤ 0.5% (one quantize step) |

### 5. Build Reproducibility

Does every commit produce the same artifact, automatically?

| Score | Criteria |
|-------|----------|
| 0 | Manual builds, version bumped by hand in multiple files |
| 1 | Gradle builds locally; version managed but inconsistently |
| 2 | CI builds on every push; version sourced from single `version.properties`; `versionCode` from run number |
| 3 | Signed release APK published automatically on tag; build inputs fully declared (no external mutable dependencies) |

### 6. Failure Resilience

Does the app recover gracefully when things go wrong?

| Score | Criteria |
|-------|----------|
| 0 | ADB failure = silent hang or crash |
| 1 | Error logged but no recovery |
| 2 | ADB auto-reconnects with delay; throttle window prevents command storms on reconnect; all failure paths log at error level |
| 3 | Per-feature graceful degradation: app continues functioning (minus the failed feature) on any single failure; no uncaught exceptions reach the user |

### 7. Calibration Capability

Can you verify that the device is actually reaching the commanded state?

| Score | Criteria |
|-------|----------|
| 0 | No feedback channel; purely open-loop |
| 1 | Manual observation (watch the display) |
| 2 | OCR incline reading confirmed working; ADB sweep script exists; commanded vs. observed can be captured |
| 3 | Automated calibration sweep produces correction table; formula re-derivation documented; calibration result feeds a regression test |

### 8. Documentation

Can a new contributor understand and extend the app without reading every file?

| Score | Criteria |
|-------|----------|
| 0 | No docs |
| 1 | CLAUDE.md with basic add-device pattern |
| 2 | Architecture doc (data flow, class roles), device formula reference table, calibration runbook |
| 3 | Docs kept adjacent to the code they describe; formula reference generated or verified against source; runbooks tested (commands in runbooks actually work) |

---

## Current Scores (as of 2026-04-19)

| Dimension | Score | Notes |
|-----------|-------|-------|
| Test Coverage | 3 | HillyRouteReplayTest, TreadmillDeviceTest (139 tests across 27 devices), BikeDeviceTest (56 tests across 14 devices), MetricReaderTest (22); all 45 registry devices have ≥1 test; T95s and X22iNoAdb limited to isinstance/displayName (override swipe() → MyAccessibilityService) |
| Observability | 2 | Structured tags, monitor-ride.sh, analyze-ride.sh working; no rate-based de-dup/throttle thresholds |
| Device Portability | 3 | DeviceRegistry pattern solid; all 45 devices have ≥1 test; device classes know nothing about iFit log format versions (orthogonal to reader layer via `MetricReader.forIfitV2()`) |
| Formula Auditability | 1 | S22i incline and resistance calibrated on real device (3-point and 2-point fits, 2026-04-18); 39+ other devices have no derivation notes |
| Build Reproducibility | 2 | CI signs and publishes on every master push; unpinned/deprecated action refs; publish-on-push vs publish-on-tag |
| Failure Resilience | 2 | ADB auto-reconnect in place; uncaught exceptions = hard kill not graceful degradation; 4 devices swallow IOException silently |
| Calibration Capability | 2 | In-app CalibrationActivity: swipe sweep + OCR feedback + FormulaFitter least-squares fit → CalibratedBikeDevice; calibrate-device.sh for shell-based sweep; commanded vs. observed captured automatically |
| Documentation | 2 | architecture.md updated to reflect service renames; device-reference.md, calibration-runbook.md written; hand-maintained, not verified |

**Overall: 17 / 24**

### Code Quality Gate (not a scored dimension)

`/smells` project command runs a two-pass Clean Code review (Uncle Bob checklist) on changed
files. Integrated into `/ship` as a gate: critical smells (flag arguments, commented-out code,
base/derivative coupling, Law of Demeter violations) block the commit; advisory smells appear
in the preview.

---

## Next Step Per Dimension

| Dimension | Next action to reach 3 |
|-----------|----------------------|
| Test Coverage | ✓ Done — all devices covered |
| Observability | Add de-dup rate and throttle rate to analyze-ride.sh thresholds |
| Device Portability | ✓ Orthogonal reader design complete; add checklist assertion that every DeviceId in registry has ≥1 test |
| Formula Auditability | ✓ S22i calibrated; document two-point derivation for C1750 and X32i |
| Build Reproducibility | Add release signing via GitHub Actions on version tag |
| Failure Resilience | Audit all catch blocks; ensure no swallowed exceptions in the dispatch path |
| Calibration Capability | Run calibration on a second device; feed CalibrationResult into a regression test that verifies formula tolerance ≤ 0.5% |
| Documentation | Verify runbook commands actually execute correctly end-to-end |
