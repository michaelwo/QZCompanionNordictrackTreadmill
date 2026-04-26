#!/usr/bin/env python3
"""
Replace every remaining raw-int trackX literal in device Slider constructors with
the appropriate ScreenProfile constant, and update the "deviates from APK-expected"
constructor comments that are now obsolete.

All constants are anchored to iFit APK 2.6.90 (versionCode 4963).
Devices whose original hardware calibrations differed from APK-expected values get
updated to the APK-standard coordinates; the original values are preserved in the
constructor comment for future reference.
"""

import re, os, sys

REPO = os.path.abspath(os.path.join(os.path.dirname(__file__), ".."))
DEVICE_BASE = os.path.join(
    REPO,
    "app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill/device",
)
SLIDER_IMPORT = (
    "import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;"
)
SCREEN_PROFILE_IMPORT = (
    "import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;"
)

# Per-file list of (raw_int, replacement_expression) pairs.
REPLACEMENTS: dict[str, list[tuple[int, str]]] = {
    # ── Bike devices ─────────────────────────────────────────────────────────
    "bike/Se9iEllipticalDevice.java": [
        (57,   "ScreenProfile.W1920.leftTrackX"),
        (1857, "ScreenProfile.W1920.rightTrackX"),
    ],
    "bike/ProformCarbonE7Device.java": [
        (75,  "ScreenProfile.W1024.leftTrackX"),
    ],
    "bike/S15iDevice.java": [
        (75,   "ScreenProfile.W1920.leftTrackX"),
        (1848, "ScreenProfile.W1920.rightTrackX"),
    ],
    "bike/Tdf10InclinationDevice.java": [
        (74,  "ScreenProfile.W1280.leftTrackX"),
    ],
    "bike/S27iDevice.java": [
        (76,   "ScreenProfile.W1920.leftTrackX"),
        (1847, "ScreenProfile.W1920.rightTrackX"),
    ],
    "bike/S22iNtex02121Device.java": [
        (75,  "ScreenProfile.W1920.leftTrackX"),
    ],
    "bike/ProformStudioBikePro22Device.java": [
        (1828, "ScreenProfile.W1920.rightTrackX"),
    ],
    # ── Treadmill devices ────────────────────────────────────────────────────
    "treadmill/C1750Device.java": [
        (79,  "ScreenProfile.W1920.leftTrackX"),
    ],
    "treadmill/C1750MphMinus3GradeDevice.java": [
        (1206, "ScreenProfile.W1280.rightTrackX"),
        (75,   "ScreenProfile.W1280.leftTrackX"),
    ],
    "treadmill/C1750Ntl14122Device.java": [
        (70,   "ScreenProfile.W1920.leftTrackX"),
        (1850, "ScreenProfile.W1920.rightTrackX"),
    ],
    "treadmill/C1750_2021Device.java": [
        (79,  "ScreenProfile.W1280.leftTrackX"),
    ],
    "treadmill/Elite1000Device.java": [
        (76,   "ScreenProfile.W1280.leftTrackX"),
        (1209, "ScreenProfile.W1280.rightTrackX"),
    ],
    "treadmill/Elite900Device.java": [
        (76,  "ScreenProfile.W1024.leftTrackX"),
    ],
    "treadmill/Nordictrack2450Device.java": [
        (72,  "ScreenProfile.W1920.leftTrackX"),
    ],
    "treadmill/OtherDevice.java": [
        (79,  "ScreenProfile.W1280.leftTrackX"),
    ],
    "treadmill/Proform2000Device.java": [
        (79,  "ScreenProfile.W1280.leftTrackX"),
    ],
    "treadmill/ProformCarbonT14Device.java": [
        (76,  "ScreenProfile.W1920.leftTrackX"),
    ],
    "treadmill/ProformPro9000Device.java": [
        (90,   "ScreenProfile.W1920.leftTrackX"),
        (1825, "ScreenProfile.W1920.rightTrackX"),
    ],
    "treadmill/S40Device.java": [
        (75,  "ScreenProfile.W1024.leftTrackX"),
        (949, "ScreenProfile.W1024.rightTrackX"),
    ],
    "treadmill/T65sDevice.java": [
        (74,  "ScreenProfile.W1280.leftTrackX"),
    ],
    "treadmill/T85sDevice.java": [
        (1207, "ScreenProfile.W1280.rightTrackX"),
        (75,   "ScreenProfile.W1280.leftTrackX"),
    ],
    "treadmill/T95sDevice.java": [
        (76,  "ScreenProfile.W1920.leftTrackX"),
    ],
    "treadmill/X11iDevice.java": [
        (1207, "ScreenProfile.W1280.rightTrackX"),
        (75,   "ScreenProfile.W1280.leftTrackX"),
    ],
    "treadmill/X32iDevice.java": [
        (76,  "ScreenProfile.W1920.leftTrackX"),
    ],
    "treadmill/X32iNtl39019Device.java": [
        (74,  "ScreenProfile.W1920.leftTrackX"),
    ],
}

# Constructor comments that need updating once the calibration mismatch is resolved.
# Each entry: list of (old_text, new_text) string pairs (exact match).
COMMENT_UPDATES: dict[str, list[tuple[str, str]]] = {
    "bike/Se9iEllipticalDevice.java": [(
        "        // Screen: assumed 1920px, but both trackX values deviate from APK-expected:\n"
        "        //   incline trackX=57 (expected≤75, −18px), resistance trackX=1857 (+11.5px).\n"
        "        // Asymmetric offsets suggest non-standard slider margins on this model.",
        "        // Screen: 1920px wide — updated to iFit APK 2.6.90 standard\n"
        "        //   (original hardware calibration: left=57, right=1857).",
    )],
    "bike/ProformStudioBikePro22Device.java": [(
        "        // Screen width unconfirmed: right trackX=1828 implies ~1903px — not a standard iFit screen width.\n"
        "        // Calibrated from hardware; may use non-standard slider margins.",
        "        // Screen: 1920px wide — updated to iFit APK 2.6.90 standard\n"
        "        //   (original hardware calibration: right=1828).",
    )],
    "treadmill/ProformPro9000Device.java": [(
        "        // Screen width unconfirmed: right trackX=1825 implies ~1900px — not a standard iFit screen width.\n"
        "        // Incline trackX=90 is 15.5px off APK-expected 74.5. Calibrated from hardware; may use non-standard slider margins.",
        "        // Screen: 1920px wide — updated to iFit APK 2.6.90 standard\n"
        "        //   (original hardware calibration: left=90, right=1825).",
    )],
    "treadmill/C1750Ntl14122Device.java": [(
        "        // Speed trackX=1850 (+4.5px) and incline trackX=70 (−4.5px) both deviate from APK-expected; matches hardware calibration.\n",
        "",
    )],
    "treadmill/Nordictrack2450Device.java": [(
        "        // Incline trackX=72 is 2.5px off APK-expected 74.5; matches hardware calibration.\n",
        "",
    )],
    "treadmill/Elite1000Device.java": [(
        "        // Speed trackX=1209 is 3.5px off APK-expected 1205.5; matches hardware calibration.\n",
        "",
    )],
}


def apply_replacements(source: str, reps: list[tuple[int, str]]) -> str:
    for raw_int, expr in reps:
        # Match exactly: new Slider(<digits>, <raw_int>) — the raw_int as the second arg.
        pattern = re.compile(
            r'(new\s+Slider\s*\(\s*\d+\s*,\s*)' + str(raw_int) + r'(\s*\))',
        )
        source = pattern.sub(r'\g<1>' + expr + r'\2', source)
    return source


def ensure_import(source: str) -> str:
    if SCREEN_PROFILE_IMPORT in source:
        return source
    if SLIDER_IMPORT in source:
        return source.replace(
            SLIDER_IMPORT,
            SCREEN_PROFILE_IMPORT + "\n" + SLIDER_IMPORT,
        )
    # Fallback: after last import
    last = max(
        (m.end() for m in re.finditer(r"^import .*;", source, re.MULTILINE)),
        default=0,
    )
    if last:
        return source[:last] + "\n" + SCREEN_PROFILE_IMPORT + source[last:]
    return source


def apply_comment_updates(source: str, updates: list[tuple[str, str]]) -> str:
    for old, new in updates:
        source = source.replace(old, new)
    return source


def migrate_file(rel_path: str) -> bool:
    path = os.path.join(DEVICE_BASE, rel_path)
    with open(path) as f:
        original = f.read()
    source = original

    reps = REPLACEMENTS.get(rel_path, [])
    source = apply_replacements(source, reps)

    comment_upds = COMMENT_UPDATES.get(rel_path, [])
    source = apply_comment_updates(source, comment_upds)

    if "ScreenProfile." in source and SCREEN_PROFILE_IMPORT not in source:
        source = ensure_import(source)

    if source != original:
        with open(path, "w") as f:
            f.write(source)
        return True
    return False


def main() -> int:
    changed, unchanged = [], []
    all_keys = sorted(set(list(REPLACEMENTS) + list(COMMENT_UPDATES)))
    for rel_path in all_keys:
        if migrate_file(rel_path):
            changed.append(rel_path)
            print(f"  CHANGED : {rel_path}")
        else:
            unchanged.append(rel_path)
            print(f"  no-op   : {rel_path}")
    print(f"\nChanged: {len(changed)}, No-op: {len(unchanged)}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
