---
description: Review this project against the 8-dimension QZCompanion maturity model
---
# Maturity Review Skill

Performs a structured maturity review of QZCompanion work against the project's
8-dimension maturity model defined in `docs/maturity-model.md`.

## When to invoke

- `/maturity-review` — full project review; scores all 8 dimensions against current codebase state
- `/maturity-review <device>` — focused review of one device (e.g. `s22i`, `x32i`); scores dimensions 1, 3, 4
- `/maturity-review <feature or file>` — review of a specific feature or recent change; scores affected dimensions only

## Instructions

1. **Read the model first.**
   Always read `docs/maturity-model.md` before scoring. Do not rely on memory of the model.

2. **Ground every score in evidence.**
   For each dimension, read the relevant source before assigning a score:
   - Test Coverage → `app/src/test/`
   - Observability → logcat tags in source (`QZ:Dispatch`, `QZ:UDP`), `monitor-ride.sh`, `analyze-ride.sh`
   - Device Portability → `device/catalog/`, `DeviceRegistry.java`, `DeviceAdapter.java`
   - Formula Auditability → the device's `Slider` anonymous subclass; inline comments; `docs/device-reference.md`
   - Build Reproducibility → `.github/workflows/main.yml`, `version.properties`, `app/build.gradle`
   - Failure Resilience → `MainActivity.java` reconnect logic, catch blocks in dispatch path
   - Calibration Capability → `docs/calibration-runbook.md`, `Ocr.java`, `QZService.java`
   - Documentation → `docs/` directory

3. **Score each dimension 0–3** using the criteria table in the model.
   If scope is limited (device or feature review), score only affected dimensions and say so.

4. **Output format:**

   ```
   ## Maturity Review — <scope>

   | Dimension              | Score | Evidence |
   |------------------------|-------|----------|
   | Test Coverage          |  N/3  | <one-line justification> |
   | Observability          |  N/3  | ... |
   | Device Portability     |  N/3  | ... |
   | Formula Auditability   |  N/3  | ... |
   | Build Reproducibility  |  N/3  | ... |
   | Failure Resilience     |  N/3  | ... |
   | Calibration Capability |  N/3  | ... |
   | Documentation          |  N/3  | ... |

   **Total: N / 24**

   ## Gaps (scores < 2)
   <list each gap with the specific next action to reach score+1>

   ## Regressions (scores lower than recorded in maturity-model.md)
   <list any dimension that scored lower than the baseline in the model, with reason>

   ## Recommended next action
   <single highest-leverage improvement — the one gap that, if closed, most improves overall posture>
   ```

5. **Update `docs/maturity-model.md`** if the review finds the current scores table is stale.
   Update only the "Current Scores" and "Next Step" sections — never change the dimension
   definitions or scoring criteria without explicit user instruction.

6. **Do not pad.** A score of 1 is not bad — it is honest. Flag gaps clearly and move on.
   The goal is an accurate picture, not a flattering one.
