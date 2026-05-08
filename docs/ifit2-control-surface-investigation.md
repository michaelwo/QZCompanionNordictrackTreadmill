# iFit2 Control Surface Investigation

**Goal:** find programmable interfaces on NordicTrack/ProForm devices running iFit2 (the Kotlin/gRPC rewrite, APK `com.ifit.rivendell` + `com.ifit.glassos_service`) that allow QZCompanion to set incline, resistance, and speed without simulating touchscreen input.

**Verdict (partial — investigation ongoing):**
- **gRPC works for commands.** `glassos_service` exposes a local gRPC server; `InclineRequest`, `ResistanceRequest`, `SpeedRequest`, and `GearRequest` are confirmed callable.
- **glassos works for telemetry.** Live metrics stream from glassos_service.
- **BLE FTMS control was not added.** The iFit2 GATT server contains no FTMS service or Control Point — see below.

---

## Background

iFit2 is a ground-up rewrite of the iFit Android app. Where iFit 1 was a Xamarin.Android application backed by the Sindarin C# engine (see `docs/ifit-control-surface-investigation.md`), iFit2 is a Kotlin app with two APKs:

| APK | Package | Role |
|-----|---------|------|
| Rivendell | `com.ifit.rivendell` | Main UI and workout app |
| GlassOS Service | `com.ifit.glassos_service` | Platform service — gRPC server, BLE, telemetry |

The decompiled sources were extracted under `/tmp/ifit2-rivendell-decompile/` and `/tmp/ifit2-glassos-service-decompile/` using jadx + apktool.

---

## Surface 1 — gRPC (GlassOS service)

### Findings

The `glassos_service` APK bundles a full gRPC server (io.grpc library confirmed in both APKs). The `com.ifit.glassos.workout` package contains unobfuscated protobuf message classes for every controllable axis:

| Class | Purpose |
|-------|---------|
| `InclineRequest` | Set target incline (%) |
| `ResistanceRequest` | Set target resistance |
| `SpeedRequest` | Set target speed (kph) |
| `GearRequest` | Set target gear |

**Status: confirmed working by prior Codex investigation.** This is the primary control surface for ifit2.

---

## Surface 2 — BLE FTMS Control Point

### What was tested

The iFit 1 investigation (see `docs/ifit-control-surface-investigation.md`, Surface 1) found that iFit 1 exposed BLE read/notify characteristics but no FTMS Control Point (`0x2AD9`). The question here was whether iFit2 added FTMS control as part of the rewrite.

### Methodology

1. Located the live GATT server implementation in `glassos_service` smali: `zd/d.smali` calls `BluetoothManager.openGattServer()`, creates `BluetoothGattService` instances, adds characteristics via `addCharacteristic()`, and registers them via `addService()`.
2. Traced all UUID construction to the enum class `wd/i` (decompiled to `wd/i.java`), which is the single source of truth for every UUID the GATT server uses.
3. Searched both APKs exhaustively for the FTMS service UUID (`0x1826`) and all FTMS characteristic UUIDs (`0x2ACC`, `0x2ACD`, `0x2ACE`, `0x2AD2`, `0x2AD6`, `0x2AD8`, `0x2AD9`, `0x2ADA`) — in jadx Java output, apktool smali, and raw string search.

### Findings

The complete UUID registry for the iFit2 GATT server (`wd/i.java`):

| Name | UUID | Standard |
|------|------|----------|
| `DeviceTx` | `00001535-1412-efde-1523-785feabcd123` | Nordic UART (TX) |
| `DeviceRx` | `00001534-1412-efde-1523-785feabcd123` | Nordic UART (RX) |
| `HeartRateMeasurement` | `00002a37-0000-1000-8000-00805f9b34fb` | BT SIG 0x2A37 |
| `BatteryLevel` | `00002A19-0000-1000-8000-00805f9B34fb` | BT SIG 0x2A19 |
| `BodySensorLocation` | `00002A38-0000-1000-8000-00805f9B34fb` | BT SIG 0x2A38 |
| `GlassOSWatchService` | `40E7419B-8EAA-4937-A944-D2816145F074` | iFit proprietary |
| `GlassOSHR` | `DF196F21-349C-41D1-A04F-36F2863241D0` | iFit proprietary |
| `GlassOSWorkoutState` | `0E788C89-C676-4A1C-80E2-34EFBB453201` | iFit proprietary |
| `GlassOSHRZones` | `12CBCBFB-8BD1-4A76-A4E8-F7780C0C2BB2` | iFit proprietary |
| `ConnectedWatchName` | `6BEFE8ED-8BAE-4381-9052-3D25E186C309` | iFit proprietary |
| `ConnectionPing` | `6e400001-b5a3-f393-e0a9-e50e24dcca9e` | Nordic UART service |
| `ArcXClientCharacteristicConfigDescriptor` | `00002902-0000-1000-8000-00805f9b34fb` | BT SIG CCCD |
| `ArcXKeyEventCharacteristic` | `00001667-1212-efde-1523-785feabcd124` | iFit ArcX remote |
| `ArcXExtendedKeyEventCharacteristic` | `00001669-1212-EFDE-1523-785FEABCD124` | iFit ArcX remote |

**No FTMS UUID appears anywhere in this list or anywhere else in either APK.** The BLE layer in iFit2 is entirely dedicated to their proprietary watch/accessory ecosystem (iFit Watch via GlassOS characteristics, ArcX remote, Nordic UART) and standard HR/battery read-only notify characteristics.

### Conclusion

BLE FTMS control was not added in iFit2. The absence is complete — no service UUID, no Control Point characteristic, no Feature characteristic, no machine data characteristics. The gRPC path remains the only known programmable control surface.

---

## Summary

| Surface | Status | Notes |
|---------|--------|-------|
| gRPC (`InclineRequest`, `ResistanceRequest`, `SpeedRequest`, `GearRequest`) | **Working** | Confirmed by Codex investigation |
| glassos telemetry | **Working** | Live metric stream from glassos_service |
| BLE FTMS Control Point (`0x2AD9`) | **Absent** | UUID not present in any form in either APK |
| BLE FTMS Service (`0x1826`) | **Absent** | UUID not present in any form in either APK |
| Other BLE | Read/notify only | HR, battery, proprietary watch/ArcX characteristics |

---

## Artifacts

| Path | Contents |
|------|---------|
| `/tmp/ifit2-rivendell-decompile/` | jadx + apktool output for `com.ifit.rivendell` |
| `/tmp/ifit2-glassos-service-decompile/` | jadx + apktool output for `com.ifit.glassos_service` |
| `wd/i.java` (in glassos jadx output) | Complete UUID enum for the iFit2 GATT server |
| `zd/d.smali` (in glassos apktool output) | GATT server implementation (`openGattServer`, `addService`) |
| `com/ifit/glassos/workout/` (in rivendell jadx output) | Unobfuscated gRPC message classes |
