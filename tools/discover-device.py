#!/usr/bin/env python3
"""
discover-device.py — ADB-based incline + resistance calibration for iFit bikes.

Sweeps both sliders, reads grade/resistance events from logcat -s mono-stdout,
fits Y = origin - scale * value for each slider, and writes qz-calibration.json.
Push the file to /sdcard/ and restart QZCompanion to apply.

Two sweep modes:
  default   -- adb shell input swipe (works on Android 11+, non-Xamarin iFit)
  --a11y    -- routes swipes via QZCompanion's AccessibilityService over UDP port
               8003 (required for API 25 / Xamarin iFit — NordicTrack S22i etc.)

Usage:
    python3 tools/discover-device.py --device 192.168.1.213:5555 [--push] [--out FILE]
    python3 tools/discover-device.py --device 192.168.1.213:5555 --a11y [--push]

Requirements:
    - adb in PATH, connected to device
    - iFit running in active manual workout (screen on)
    - Python 3.6+, stdlib only
    - --a11y: QZCompanion installed and running with Accessibility Service enabled
"""

import argparse
import json
import re
import socket
import subprocess
import sys
import threading
import time


# ── logcat parsing ────────────────────────────────────────────────────────────

GRADE_RE      = re.compile(r"Changed Grade to:\s*([-\d.]+)")
RESISTANCE_RE = re.compile(r"Changed Resistance to:\s*([-\d.]+)")


class MetricReader:
    """Background thread that streams mono-stdout logcat and caches latest values."""

    def __init__(self, device):
        self._device = device
        self._grade      = None
        self._resistance = None
        self._grade_ts      = 0.0
        self._resistance_ts = 0.0
        self._lock = threading.Lock()
        self._proc = None

    def start(self):
        self._proc = subprocess.Popen(
            ["adb", "-s", self._device, "logcat", "-s", "mono-stdout"],
            stdout=subprocess.PIPE, stderr=subprocess.DEVNULL, text=True,
        )
        t = threading.Thread(target=self._read, daemon=True)
        t.start()

    def stop(self):
        if self._proc:
            self._proc.kill()

    def _read(self):
        for line in self._proc.stdout:
            now = time.time()
            m = GRADE_RE.search(line)
            if m:
                with self._lock:
                    self._grade    = float(m.group(1))
                    self._grade_ts = now
                continue
            m = RESISTANCE_RE.search(line)
            if m:
                v = float(m.group(1))
                if v >= 1:          # filter iFit's noise "Changed Resistance to: 0" events
                    with self._lock:
                        self._resistance    = v
                        self._resistance_ts = now

    def wait_fresh_grade(self, after_ts, timeout=5.0):
        """Return grade value if a new event arrived after after_ts, else None."""
        deadline = time.time() + timeout
        while time.time() < deadline:
            with self._lock:
                if self._grade_ts > after_ts and self._grade is not None:
                    return self._grade
            time.sleep(0.2)
        return None

    def wait_fresh_resistance(self, after_ts, timeout=5.0):
        deadline = time.time() + timeout
        while time.time() < deadline:
            with self._lock:
                if self._resistance_ts > after_ts and self._resistance is not None:
                    return self._resistance
            time.sleep(0.2)
        return None

    def any_event_ts(self):
        with self._lock:
            return max(self._grade_ts, self._resistance_ts)


# ── ADB helpers ───────────────────────────────────────────────────────────────

def adb(device, *args, check=True):
    return subprocess.run(
        ["adb", "-s", device] + list(args),
        capture_output=True, text=True, check=check,
    )


# Module-level: set to device IP when --a11y is active, else None.
_a11y_host = None


def swipe(device, x, from_y, to_y, duration_ms=200):
    """Swipe the slider track. Uses CALSWIPE UDP relay when --a11y is active."""
    if _a11y_host is not None:
        msg = f"CALSWIPE:{int(x)}:{int(from_y)}:{int(to_y)}"
        s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        s.sendto(msg.encode(), (_a11y_host, 8003))
        s.close()
    else:
        adb(device, "shell", "input", "swipe",
            str(x), str(from_y), str(x), str(to_y), str(duration_ms))


def screen_size(device):
    out = adb(device, "shell", "wm", "size").stdout
    m = re.search(r"(\d+)x(\d+)", out)
    if not m:
        raise RuntimeError(f"Could not parse screen size from: {out!r}")
    return int(m.group(1)), int(m.group(2))


def screen_profile(width):
    """Return (incline_trackX, resistance_trackX).

    inc_x is the horizontal centre of the incline button column, not the ScreenProfile
    track used by QZCompanion for swiping.  For Xamarin iFit the AccessibilityService swipe
    must start at the button-column centre (≈57 px on a 1920-wide screen); starting at the
    column right edge (75 px) is unreliable.  The trackX written to qz-calibration.json is
    this centre value, so QZCompanion also benefits.
    """
    if width >= 1920: return 57, 1845
    if width >= 1280: return 57, 1205
    if width >= 1024: return 56,  950
    return 55, 725


# ── sweep logic ───────────────────────────────────────────────────────────────

COARSE_STEP   = 50
COARSE_MARGIN = 200
COARSE_SETTLE = 2.5   # seconds
COARSE_TIMEOUT = 4.0

FINE_STEP    = 25
FINE_SETTLE  = 2.0
FINE_TIMEOUT = 6.0


def coarse_sweep(device, reader, track_x, screen_h, metric, start_y=None):
    """Sweep full height at coarse resolution; return [(y, value)] where value changed."""
    wait_fn = reader.wait_fresh_grade if metric == "grade" else reader.wait_fresh_resistance
    readings = []
    # start_y: where the slider thumb is before this sweep begins (set by probe tap in
    # --a11y mode). Each CALSWIPE starts from the previous endpoint so iFit recognises it.
    prev_y = start_y if start_y is not None else COARSE_MARGIN
    for y in range(COARSE_MARGIN, screen_h - COARSE_MARGIN + 1, COARSE_STEP):
        ts = time.time()
        swipe(device, track_x, prev_y, y)
        prev_y = y
        time.sleep(COARSE_SETTLE)
        v = wait_fn(ts, COARSE_TIMEOUT)
        if v is not None:
            readings.append((y, v))
            print(f"    coarse y={y:4d} → {metric}={v}")
        else:
            print(f"    coarse y={y:4d} → (no change)")
    return readings


def find_active_range(readings, screen_h):
    """Expand one coarse step beyond the observed endpoints."""
    if len(readings) < 3:
        return None
    y_top    = max(COARSE_MARGIN,              readings[0][0]  - COARSE_STEP)
    y_bottom = min(screen_h - COARSE_MARGIN,  readings[-1][0] + COARSE_STEP)
    if y_bottom - y_top < FINE_STEP * 3:
        return None
    return y_top, y_bottom


def fine_sweep(device, reader, track_x, y_top, y_bottom, screen_h, metric):
    """Fine sweep in the active range; return [(y, value)]."""
    wait_fn = reader.wait_fresh_grade if metric == "grade" else reader.wait_fresh_resistance
    # Reset to top of active range starting from y_bottom (which is within the slider
    # after the coarse sweep), so iFit recognises the reset swipe as a slider interaction.
    swipe(device, track_x, y_bottom, y_top)
    time.sleep(FINE_SETTLE * 2)
    prev_y = y_top
    points = []
    for y in range(y_top, y_bottom + 1, FINE_STEP):
        ts = time.time()
        swipe(device, track_x, prev_y, y)
        prev_y = y
        time.sleep(FINE_SETTLE)
        v = wait_fn(ts, FINE_TIMEOUT)
        if v is not None:
            points.append((y, v))
            print(f"    fine   y={y:4d} → {metric}={v:.2f}")
        else:
            print(f"    fine   y={y:4d} → (timeout)")
    return points


# ── formula fitting ───────────────────────────────────────────────────────────

def fit_linear(points):
    """
    Fit Y = origin - scale * x  (origin and scale both positive for iFit sliders).
    Returns (origin, scale, r2).  Pure Python OLS, no numpy.
    """
    n = len(points)
    ys = [p[0] for p in points]   # pixel Y
    xs = [p[1] for p in points]   # metric value
    sx = sum(xs);  sy = sum(ys)
    sxx = sum(xi * xi for xi in xs)
    sxy = sum(xi * yi for xi, yi in zip(xs, ys))
    denom = n * sxx - sx * sx
    if abs(denom) < 1e-9:
        raise ValueError("Degenerate fit — metric values did not vary")
    slope     = (n * sxy - sx * sy) / denom   # dy/dx (should be negative)
    intercept = (sy - slope * sx) / n
    # Y = intercept + slope*x  ↔  Y = origin - scale*x  where scale = -slope
    origin = intercept
    scale  = -slope
    y_mean  = sy / n
    ss_tot  = sum((yi - y_mean) ** 2 for yi in ys)
    ss_res  = sum((yi - (intercept + slope * xi)) ** 2 for xi, yi in zip(xs, ys))
    r2 = 1.0 - ss_res / ss_tot if ss_tot > 0 else 1.0
    return origin, scale, r2


# ── main ──────────────────────────────────────────────────────────────────────

def main():
    parser = argparse.ArgumentParser(
        description="Discover iFit bike slider calibration via ADB"
    )
    parser.add_argument("--device", required=True,
                        help="ADB device address, e.g. 192.168.1.213:5555")
    parser.add_argument("--push", action="store_true",
                        help="Push output file to /sdcard/qz-calibration.json on device")
    parser.add_argument("--out", default="qz-calibration.json",
                        help="Local output file path (default: qz-calibration.json)")
    parser.add_argument("--a11y", action="store_true",
                        help="Route swipes via QZCompanion's AccessibilityService over UDP "
                             "(required for API 25/Xamarin iFit devices such as NordicTrack S22i)")
    args = parser.parse_args()

    device = args.device

    global _a11y_host
    if args.a11y:
        _a11y_host = device.split(":")[0]
        print(f"Mode: --a11y (swipes via QZCompanion UDP relay at {_a11y_host}:8003)")

    # ── screen geometry ───────────────────────────────────────────────────────
    w, h = screen_size(device)
    print(f"Screen: {w}×{h}")
    inc_x, res_x = screen_profile(w)
    print(f"Track X — incline: {inc_x}  resistance: {res_x}")

    # ── start metric reader ───────────────────────────────────────────────────
    adb(device, "logcat", "-c")
    reader = MetricReader(device)
    reader.start()
    # Give the logcat subprocess a moment to start reading before we fire probe events.
    time.sleep(1.0)

    # In --a11y mode, grade events only fire on slider movement and adb shell input swipe
    # doesn't reach Xamarin's SurfaceView.  Use adb shell input tap (which does reach it)
    # to force two distinct grade values — at least one tap will cause a change event.
    # Y=450 (≈grade 10) and Y=250 (≈grade 20) are far apart so one always differs from
    # whatever grade is currently active, guaranteeing at least one change event fires.
    if _a11y_host is not None:
        print("Probe taps (--a11y mode): tapping grade≈10 then grade≈20 buttons…")
        adb(device, "shell", "input", "tap", str(inc_x), "450")
        time.sleep(1.5)
        # Leave slider near max grade so the coarse sweep starts from a known position.
        adb(device, "shell", "input", "tap", str(inc_x), "250")
        time.sleep(1.5)

    print("\nWaiting up to 15s for iFit metric events (workout must be active)…")
    deadline = time.time() + 15
    while time.time() < deadline:
        if reader.any_event_ts() > 0:
            break
        time.sleep(0.5)
    else:
        print("ERROR: No iFit events received in 15s.")
        if _a11y_host is not None:
            print("  → Ensure QZCompanion is running with Accessibility Service enabled.")
        print("  → Open iFit, start a Manual Ride, press GO, then re-run.")
        reader.stop()
        sys.exit(1)
    print("✓ iFit is responding\n")

    result = {}

    # ── incline sweep ─────────────────────────────────────────────────────────
    print(f"── Incline sweep (trackX={inc_x}) ──")
    # In --a11y mode the probe left the slider at Y=250 (grade≈20); pass that as start_y.
    inc_start_y = 250 if _a11y_host is not None else None
    coarse = coarse_sweep(device, reader, inc_x, h, "grade", start_y=inc_start_y)
    r = find_active_range(coarse, h)
    if r is None:
        print(f"ERROR: Only {len(coarse)} coarse incline readings — need ≥ 3.")
        print("  Is the workout active and the incline slider responding?")
        reader.stop()
        sys.exit(1)
    print(f"  Active incline range: Y {r[0]}–{r[1]}")
    points = fine_sweep(device, reader, inc_x, r[0], r[1], h, "grade")
    if len(points) < 3:
        print(f"ERROR: Only {len(points)} incline fine points — need ≥ 3.")
        reader.stop()
        sys.exit(1)
    origin, scale, r2 = fit_linear(points)
    flag = "  ⚠ poor fit" if r2 < 0.97 else ""
    print(f"  Fit: origin={origin:.1f}  scale={scale:.4f}  R²={r2:.4f}{flag}")
    result["incline"] = {
        "trackX": inc_x,
        "origin": round(origin, 2),
        "scale":  round(scale, 4),
    }

    # ── resistance sweep ──────────────────────────────────────────────────────
    print(f"\n── Resistance sweep (trackX={res_x}) ──")
    coarse_r = coarse_sweep(device, reader, res_x, h, "resistance")
    rr = find_active_range(coarse_r, h)
    if rr is None:
        print(f"  WARNING: Only {len(coarse_r)} coarse resistance readings — skipping.")
    else:
        print(f"  Active resistance range: Y {rr[0]}–{rr[1]}")
        points_r = fine_sweep(device, reader, res_x, rr[0], rr[1], h, "resistance")
        if len(points_r) < 3:
            print(f"  WARNING: Only {len(points_r)} resistance fine points — skipping.")
        else:
            # Resistance starts at 1, not 0 — shift x so minLevel maps to origin
            min_level = int(round(min(v for _, v in points_r)))
            pts_adj   = [(y, v - min_level) for y, v in points_r]
            origin_r, scale_r, r2_r = fit_linear(pts_adj)
            flag_r = "  ⚠ poor fit" if r2_r < 0.97 else ""
            print(f"  Fit: origin={origin_r:.1f}  scale={scale_r:.4f}"
                  f"  minLevel={min_level}  R²={r2_r:.4f}{flag_r}")
            result["resistance"] = {
                "trackX":   res_x,
                "origin":   round(origin_r, 2),
                "scale":    round(scale_r, 4),
                "minLevel": min_level,
            }

    reader.stop()

    # ── write output ──────────────────────────────────────────────────────────
    with open(args.out, "w") as f:
        json.dump(result, f, indent=2)
        f.write("\n")
    print(f"\n✓ Written: {args.out}")
    print(json.dumps(result, indent=2))

    if args.push:
        adb(device, "push", args.out, "/sdcard/qz-calibration.json")
        print("\n✓ Pushed to /sdcard/qz-calibration.json")
        print("  Force-stop and restart QZCompanion to apply:")
        pkg = "org.cagnulein.qzcompanionnordictracktreadmill"
        print(f"    adb -s {device} shell am force-stop {pkg}")
        print(f"    adb -s {device} shell am start -n {pkg}/.MainActivity")


if __name__ == "__main__":
    main()
