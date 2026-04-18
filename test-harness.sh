#!/bin/bash
# test-harness.sh — simulate a Zwift ride against QZCompanion
#
# Usage:
#   ./test-harness.sh                  dry-run: prints expected swipe commands
#   ./test-harness.sh 192.168.1.213    live: sends UDP to running QZCompanion on S22i
#
# In dry-run mode no network traffic is sent; the script prints what commands the
# bike should receive so you can verify the formula is correct before a live test.
# In live mode, watch the incline slider on the bike respond to each grade change.
#
# Requirements (live mode only):
#   nc (netcat) — available on macOS and most Linux distros
#   QZCompanion installed and running on the S22i with "S22i Bike" selected

TARGET=${1:-"DRY_RUN"}
PORT=8003
DELAY=1.5   # seconds between messages — outside the 500ms throttle window

# ── S22i formula ─────────────────────────────────────────────────────────────
# x=75, y1=previous y2
# v≤0 → (int)(622 - 10*v)
# v>0 → (int)(622 - 14.8*v)
# Calibrated 2026-04-18: v=-10→Y=722, v=0→Y=622, v=20→Y=326
expected_y() {
    local grade=$1
    echo "$grade" | awk '{
        if ($1 <= 0) printf "%d", int(622 - 10 * $1)
        else         printf "%d", int(622 - 14.8 * $1)
    }'
}

expected_swipe() {
    local y1=$1
    local grade=$2
    local y2
    y2=$(expected_y "$grade")
    echo "input swipe 75 $y1 75 $y2 200  (grade ${grade}%)"
}

send_grade() {
    local grade=$1
    local y1=$2
    if [ "$TARGET" = "DRY_RUN" ]; then
        echo "  $(expected_swipe "$y1" "$grade")"
    else
        echo -n "${grade};0" | nc -u -w1 "$TARGET" "$PORT"
        echo "  sent grade ${grade}%  →  $(expected_swipe "$y1" "$grade")"
    fi
}

# ── Alpe du Zwift — simplified profile ───────────────────────────────────────
run_profile() {
    local -a grades=("$@")
    local y1=622  # S22i initial incline position (grade=0)

    for grade in "${grades[@]}"; do
        send_grade "$grade" "$y1"
        y1=$(expected_y "$grade")
        sleep "$DELAY"
    done
}

# ── Sentinel ──────────────────────────────────────────────────────────────────
send_sentinel() {
    if [ "$TARGET" = "DRY_RUN" ]; then
        echo "  (sentinel -1;-100 — no swipe expected)"
    else
        echo -n "-1;-100" | nc -u -w1 "$TARGET" "$PORT"
        echo "  sent sentinel"
    fi
}

# ── Main ─────────────────────────────────────────────────────────────────────
if [ "$TARGET" = "DRY_RUN" ]; then
    echo "=== QZCompanion Test Harness — DRY RUN ==="
    echo "Expected swipe commands (no UDP sent):"
    echo ""
else
    echo "=== QZCompanion Test Harness — LIVE ==="
    echo "Target: $TARGET:$PORT"
    echo "Sending UDP grade changes every ${DELAY}s"
    echo "Watch the incline slider on the S22i respond."
    echo ""
fi

echo "--- Profile: flat start → climb → descent → flat ---"
run_profile 0.0 3.0 7.0 10.0 12.0 10.0 7.0 3.0 0.0
echo ""

echo "--- Sentinel (end of ride) ---"
send_sentinel
echo ""

echo "Done."
