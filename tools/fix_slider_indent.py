#!/usr/bin/env python3
"""
Fix the double-indentation introduced by migrate_slider_trackx.py.

The bug: the captured whitespace (newline + indent) between `new Slider(Y) {` and
`public int trackX()` was appended to the replacement string, then the *following*
line kept its own original indentation — doubling it.

This script finds lines immediately after `new Slider(anything) {` that have 16
extra leading spaces (exactly what the captured group added) and removes the extra 16.
"""

import re, os, sys

REPO = os.path.abspath(os.path.join(os.path.dirname(__file__), ".."))
DEVICE_DIRS = [
    os.path.join(REPO, "app/src/main/java/org/cagnulein/"
                       "qzcompanionnordictracktreadmill/device/bike"),
    os.path.join(REPO, "app/src/main/java/org/cagnulein/"
                       "qzcompanionnordictracktreadmill/device/treadmill"),
]

SLIDER_OPEN_RE = re.compile(r'^(\s+)new Slider\(.*\)\s*\{$')


def fix_file(path: str) -> bool:
    with open(path) as f:
        lines = f.readlines()

    new_lines = []
    changed = False
    fix_next = False
    slider_indent = 0

    for line in lines:
        if fix_next:
            fix_next = False
            stripped = line.lstrip()
            current = len(line) - len(line.lstrip('\n').lstrip())
            # The introduced bug added exactly 16 extra spaces to this line.
            if current == slider_indent + 16 + 4:
                # slider_indent (e.g. 12) + 16 (captured ws) + 4 (own indent) = 32
                line = ' ' * (slider_indent + 4) + stripped
                changed = True

        m = SLIDER_OPEN_RE.match(line.rstrip('\n'))
        if m:
            slider_indent = len(m.group(1))
            fix_next = True

        new_lines.append(line)

    if changed:
        with open(path, 'w') as f:
            f.writelines(new_lines)
    return changed


def main() -> int:
    fixed, clean = [], []
    for device_dir in DEVICE_DIRS:
        for fname in sorted(os.listdir(device_dir)):
            if not fname.endswith('.java'):
                continue
            path = os.path.join(device_dir, fname)
            if fix_file(path):
                fixed.append(fname)
                print(f"  FIXED   : {fname}")
            else:
                clean.append(fname)
    print(f"\nFixed: {len(fixed)}, Already clean: {len(clean)}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
