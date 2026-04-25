#!/usr/bin/env python3
"""
Migrate device Slider classes from the abstract trackX() override pattern to
the constructor-parameter pattern introduced with ScreenProfile.

Before:
    new Slider(Y) {
        public int trackX() { return N; }
        public int targetY(double v) { ... }
    }

After:
    new Slider(Y, EXPR) {
        public int targetY(double v) { ... }
    }

EXPR is a ScreenProfile constant when N is a standard APK-derived value; otherwise
a raw integer literal is kept.

Files that gain a ScreenProfile reference also receive the corresponding import.

CalibratedBikeDevice is skipped because its trackX() is computed dynamically at
runtime from CalibrationResult, not a fixed pixel constant.
"""

import re
import os
import sys

REPO = os.path.abspath(os.path.join(os.path.dirname(__file__), ".."))
DEVICE_DIRS = [
    os.path.join(REPO, "app/src/main/java/org/cagnulein/"
                       "qzcompanionnordictracktreadmill/device/bike"),
    os.path.join(REPO, "app/src/main/java/org/cagnulein/"
                       "qzcompanionnordictracktreadmill/device/treadmill"),
]

SKIP_FILES = {"CalibratedBikeDevice.java"}

SCREEN_PROFILE_IMPORT = (
    "import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;"
)
SLIDER_IMPORT = (
    "import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;"
)

# Unambiguous right-side trackX values (unique to one screen width).
RIGHT_MAP = {
    1845: "ScreenProfile.W1920.rightTrackX",
    1205: "ScreenProfile.W1280.rightTrackX",
    950:  "ScreenProfile.W1024.rightTrackX",
    725:  "ScreenProfile.W800.rightTrackX",
}

# Left-side trackX values that are unambiguous across all screen widths.
UNAMBIGUOUS_LEFT_MAP = {
    73: "ScreenProfile.W800.leftTrackX",
}

# Left-side trackX values that need a sibling (right) trackX to resolve.
CONTEXT_LEFT_MAP = {
    74: {950:  "ScreenProfile.W1024.leftTrackX"},
    75: {1845: "ScreenProfile.W1920.leftTrackX",
         1205: "ScreenProfile.W1280.leftTrackX"},
}


def all_trackx_values(source: str) -> set:
    return set(
        int(m)
        for m in re.findall(
            r'public\s+int\s+trackX\s*\(\s*\)\s*\{\s*return\s+(\d+)\s*;\s*\}',
            source,
        )
    )


def resolve_expr(val: int, all_vals: set) -> str:
    """Return the ScreenProfile expression for val, or the raw literal."""
    if val in RIGHT_MAP:
        return RIGHT_MAP[val]
    if val in UNAMBIGUOUS_LEFT_MAP:
        return UNAMBIGUOUS_LEFT_MAP[val]
    if val in CONTEXT_LEFT_MAP:
        for sibling, expr in CONTEXT_LEFT_MAP[val].items():
            if sibling in all_vals:
                return expr
    return str(val)


# Matches:  new Slider(Y) {
#             (optional blank line)
#               public int trackX() { return N; }
#
# Captures: group(1)=Y, group(2)=whitespace between { and trackX line, group(3)=N
SLIDER_PATTERN = re.compile(
    r'new\s+Slider\s*\((\d+)\)\s*\{'
    r'(\s*\n\s*)'
    r'public\s+int\s+trackX\s*\(\s*\)\s*\{\s*return\s+(\d+)\s*;\s*\}\s*\n',
    re.MULTILINE,
)


def migrate_source(source: str) -> tuple[str, bool]:
    """Return (migrated_source, changed)."""
    all_vals = all_trackx_values(source)
    if not all_vals:
        return source, False

    def replace_match(m: re.Match) -> str:
        init_y   = m.group(1)
        trackx_n = int(m.group(3))
        expr     = resolve_expr(trackx_n, all_vals)
        # Fold trackX into the constructor; remove the trackX() method line.
        # End with a bare newline — the following line already carries its own indentation.
        return f"new Slider({init_y}, {expr}) {{\n"

    modified = SLIDER_PATTERN.sub(replace_match, source)
    if modified == source:
        return source, False

    # Insert ScreenProfile import if any constant was introduced and it is not yet imported.
    if "ScreenProfile." in modified and SCREEN_PROFILE_IMPORT not in modified:
        if SLIDER_IMPORT in modified:
            # Insert alphabetically before Slider (Sc < Sl).
            modified = modified.replace(
                SLIDER_IMPORT,
                SCREEN_PROFILE_IMPORT + "\n" + SLIDER_IMPORT,
            )
        else:
            # Fallback: insert after the last import line.
            last_import = max(
                (m.end() for m in re.finditer(r"^import .*;", modified, re.MULTILINE)),
                default=0,
            )
            if last_import:
                modified = (
                    modified[:last_import]
                    + "\n"
                    + SCREEN_PROFILE_IMPORT
                    + modified[last_import:]
                )

    return modified, True


def migrate_file(path: str) -> bool:
    with open(path) as f:
        original = f.read()
    modified, changed = migrate_source(original)
    if changed:
        with open(path, "w") as f:
            f.write(modified)
    return changed


def main() -> int:
    changed, skipped = [], []
    for device_dir in DEVICE_DIRS:
        for fname in sorted(os.listdir(device_dir)):
            if not fname.endswith(".java"):
                continue
            if fname in SKIP_FILES:
                skipped.append(fname)
                continue
            path = os.path.join(device_dir, fname)
            if migrate_file(path):
                changed.append(fname)
                print(f"  CHANGED : {fname}")
            else:
                skipped.append(fname)
                print(f"  no-op   : {fname}")

    print(f"\nChanged: {len(changed)}, Skipped/no-op: {len(skipped)}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
