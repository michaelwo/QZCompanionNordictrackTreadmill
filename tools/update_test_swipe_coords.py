#!/usr/bin/env python3
"""
Update swipe coordinate assertions in test files to match the ScreenProfile-normalised
trackX values introduced by normalize_screen_profiles.py.

Each pair is (old_string, new_string) derived from the JUnit ComparisonFailure output.
"""

import os, sys

REPO = os.path.abspath(os.path.join(os.path.dirname(__file__), ".."))
TEST_DIR = os.path.join(
    REPO,
    "app/src/test/java/org/cagnulein/qzcompanionnordictracktreadmill",
)

# All (old, new) pairs extracted from the failing test XML reports.
PAIRS = [
    # ── right trackX 1207 → 1205  (X11i, T85s) ─────────────────────────────
    ("input swipe 1207 600 1207 621 200", "input swipe 1205 600 1205 621 200"),
    ("input swipe 1207 600 1207 447 200", "input swipe 1205 600 1205 447 200"),
    ("input swipe 1207 600 1207 404 200", "input swipe 1205 600 1205 404 200"),
    ("input swipe 1207 447 1207 425 200", "input swipe 1205 447 1205 425 200"),
    ("input swipe 1207 447 1207 404 200", "input swipe 1205 447 1205 404 200"),
    ("input swipe 1207 404 1207 513 200", "input swipe 1205 404 1205 513 200"),
    ("input swipe 1207 629 1207 463 200", "input swipe 1205 629 1205 463 200"),
    # ── right trackX 1206 → 1205  (C1750MphMinus3Grade) ─────────────────────
    ("input swipe 1206 603 1206 451 200", "input swipe 1205 603 1205 451 200"),
    # ── right trackX 1209 → 1205  (Elite1000) ───────────────────────────────
    ("input swipe 1209 600 1209 445 200", "input swipe 1205 600 1205 445 200"),
    # ── right trackX 1847 → 1845  (S27i) ────────────────────────────────────
    ("input swipe 1847 827 1847 707 200", "input swipe 1845 827 1845 707 200"),
    # ── right trackX 1848 → 1845  (S15i) ────────────────────────────────────
    ("input swipe 1848 790 1848 675 200", "input swipe 1845 790 1845 675 200"),
    ("input swipe 1848 790 1848 559 200", "input swipe 1845 790 1845 559 200"),
    ("input swipe 1848 790 1848 513 200", "input swipe 1845 790 1845 513 200"),
    # ── right trackX 1825 → 1845  (ProformPro9000) ──────────────────────────
    ("input swipe 1825 841 1825 635 200", "input swipe 1845 841 1845 635 200"),
    # ── right trackX 1828 → 1845  (ProformStudioBikePro22) ──────────────────
    ("input swipe 1828 805 1828 826 200", "input swipe 1845 805 1845 826 200"),
    # ── right trackX 1850 → 1845  (C1750Ntl14122) ───────────────────────────
    ("input swipe 1850 787 1850 439 200", "input swipe 1845 787 1845 439 200"),
    # ── right trackX 1857 → 1845  (Se9iElliptical) ──────────────────────────
    ("input swipe 1857 886 1857 745 200", "input swipe 1845 886 1845 745 200"),
    # ── right trackX 949 → 950  (S40) ───────────────────────────────────────
    ("input swipe 949 482 949 507 200",   "input swipe 950 482 950 507 200"),
    ("input swipe 949 507 949 407 200",   "input swipe 950 507 950 407 200"),
    # ── left trackX 57 → 75  (Se9iElliptical incline) ───────────────────────
    ("input swipe 57 858 57 696 200",     "input swipe 75 858 75 696 200"),
    # ── left trackX 70 → 75  (C1750Ntl14122 incline) ────────────────────────
    ("input swipe 70 700 70 555 200",     "input swipe 75 700 75 555 200"),
    # ── left trackX 72 → 75  (Nordictrack2450 incline) ──────────────────────
    ("input swipe 72 628 72 481 200",     "input swipe 75 628 75 481 200"),
    # ── left trackX 74 → 75  (X32iNtl39019, T65s, Tdf10Inclination) ─────────
    ("input swipe 74 482 74 482 200",     "input swipe 75 482 75 482 200"),
    ("input swipe 74 482 74 419 200",     "input swipe 75 482 75 419 200"),
    ("input swipe 74 585 74 576 200",     "input swipe 75 585 75 576 200"),
    ("input swipe 74 576 74 405 200",     "input swipe 75 576 75 405 200"),
    ("input swipe 74 740 74 749 200",     "input swipe 75 740 75 749 200"),
    ("input swipe 74 749 74 689 200",     "input swipe 75 749 75 689 200"),
    # ── left trackX 75 → 74  (ProformCarbonE7, S40 — W1024 devices) ─────────
    ("input swipe 75 440 75 385 200",     "input swipe 74 440 74 385 200"),
    ("input swipe 75 490 75 490 200",     "input swipe 74 490 74 490 200"),
    ("input swipe 75 490 75 383 200",     "input swipe 74 490 74 383 200"),
    # ── left trackX 76 → 75  (X32i, ProformCarbonT14, T95s, S27i, Elite1000) ─
    ("input swipe 76 881 76 734 200",     "input swipe 75 881 75 734 200"),
    ("input swipe 76 881 76 795 200",     "input swipe 75 881 75 795 200"),
    ("input swipe 76 844 76 609 200",     "input swipe 75 844 75 609 200"),
    ("input swipe 76 734 76 672 200",     "input swipe 75 734 75 672 200"),
    ("input swipe 76 618 76 526 200",     "input swipe 75 618 75 526 200"),
    ("input swipe 76 589 76 425 200",     "input swipe 75 589 75 425 200"),
    # ── left trackX 76 → 74  (Elite900 — W1024 device) ──────────────────────
    ("input swipe 76 450 76 346 200",     "input swipe 74 450 74 346 200"),
    # ── left trackX 79 → 75  (C1750, C1750_2021, OtherDevice, Proform2000) ───
    ("input swipe 79 694 79 700 200",     "input swipe 75 694 75 700 200"),
    ("input swipe 79 700 79 525 200",     "input swipe 75 700 75 525 200"),
    ("input swipe 79 547 79 553 200",     "input swipe 75 547 75 553 200"),
    ("input swipe 79 553 79 443 200",     "input swipe 75 553 75 443 200"),
    ("input swipe 79 455 79 346 200",     "input swipe 75 455 75 346 200"),
    # ── left trackX 90 → 75  (ProformPro9000 incline) ────────────────────────
    ("input swipe 90 720 90 548 200",     "input swipe 75 720 75 548 200"),
]


def update_file(path: str) -> bool:
    with open(path) as f:
        original = f.read()
    source = original
    for old, new in PAIRS:
        source = source.replace(old, new)
    if source != original:
        with open(path, "w") as f:
            f.write(source)
        return True
    return False


def main() -> int:
    changed = []
    for root, _, files in os.walk(TEST_DIR):
        for fname in sorted(files):
            if not fname.endswith(".java"):
                continue
            path = os.path.join(root, fname)
            if update_file(path):
                changed.append(os.path.relpath(path, TEST_DIR))
                print(f"  UPDATED : {os.path.relpath(path, TEST_DIR)}")
    print(f"\nUpdated {len(changed)} test file(s).")
    return 0


if __name__ == "__main__":
    sys.exit(main())
