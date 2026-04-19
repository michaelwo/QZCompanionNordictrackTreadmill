#!/bin/bash
# calibrate-device.sh — new device onboarding: discover log format and derive swipe formula
#
# Phase 1 (default): drive known grades via UDP, capture OCR + firmware log diff
#   Discovers which firmware log lines track which metrics.
#   OCR is ground truth — grade landing accuracy doesn't matter here.
#
# Phase 2 (--sweep-swipe): drive raw swipe Y coordinates via ADB, capture OCR grade
#   Derives the (Y → grade) formula empirically, without needing an existing formula.
#   Spring-back appears naturally in the data: swipe to Y=548, OCR reads 4.7% → residual
#   is hysteresis for that travel distance. Sweep both directions to see asymmetry.
#
# Usage:
#   ./calibrate-device.sh <device_ip>                         Phase 1 only
#   ./calibrate-device.sh <device_ip> --sweep-swipe           Phase 2 only
#   ./calibrate-device.sh <device_ip> --sweep-swipe --x 75 --neutral 622 --y-start 400 --y-end 720 --y-step 25
#   ./calibrate-device.sh <device_ip> --grades "0 5 10 15 20" --settle 4
#
# Requires:
#   nc (netcat), adb connected to the iFit device, QZCompanion running with
#   screen-capture permission granted (OcrCalibrationService active).
#
# Output: calibration/<timestamp>/
#   Phase 1:
#     summary.tsv          — grade → OCR readings → new firmware log line count
#     step_N_screen.png    — screencap at each grade step
#     step_N_logcat.txt    — OcrCalibrationService readings at each step
#     step_N_logdiff.txt   — firmware log lines that appeared at each step
#   Phase 2:
#     sweep_summary.tsv    — Y_commanded → OCR grade → spring-back px
#     sweep_N_screen.png   — screencap at each Y position
#     sweep_N_logcat.txt   — OcrCalibrationService readings at each Y
#     formula_fit.txt      — least-squares formula coefficients ready to paste into a device class

PORT=8003
SETTLE=3
GRADES=(0 5 10 15 20)
OUTPUT_DIR="calibration/$(date +%Y-%m-%d_%H%M%S)"
TARGET=""
SWEEP_SWIPE=false
SWEEP_X=75
SWEEP_NEUTRAL=622
SWEEP_Y_START=400
SWEEP_Y_END=720
SWEEP_Y_STEP=25

# ── arg parsing ───────────────────────────────────────────────────────────────
while [[ $# -gt 0 ]]; do
    case $1 in
        --grades)      IFS=' ' read -ra GRADES <<< "$2"; shift 2 ;;
        --settle)      SETTLE="$2";         shift 2 ;;
        --sweep-swipe) SWEEP_SWIPE=true;    shift   ;;
        --x)           SWEEP_X="$2";        shift 2 ;;
        --neutral)     SWEEP_NEUTRAL="$2";  shift 2 ;;
        --y-start)     SWEEP_Y_START="$2";  shift 2 ;;
        --y-end)       SWEEP_Y_END="$2";    shift 2 ;;
        --y-step)      SWEEP_Y_STEP="$2";   shift 2 ;;
        *)             TARGET="$1";         shift   ;;
    esac
done

if [ -z "$TARGET" ]; then
    echo "Usage: $0 <device_ip> [options]"
    echo "  Phase 1: --grades '0 5 10 15 20'  --settle 3"
    echo "  Phase 2: --sweep-swipe  --x 75  --neutral 622  --y-start 400  --y-end 720  --y-step 25"
    exit 1
fi

# ── log file discovery (mirrors MetricReaderBroadcastingService path priority) ─
find_log_file() {
    local v2="/sdcard/android/data/com.ifit.glassos_service/files/.valinorlogs/log.latest.txt"
    if adb shell "[ -f '$v2' ] && echo yes" 2>/dev/null | grep -q yes; then
        echo "$v2"; return
    fi
    local dirs=("/sdcard/.wolflogs/" "/.wolflogs/" "/sdcard/eru/" "/storage/emulated/0/.wolflogs/")
    for dir in "${dirs[@]}"; do
        local file
        file=$(adb shell "ls -t ${dir}*_logs.txt ${dir}FitPro_*.txt 2>/dev/null | head -1" 2>/dev/null | tr -d '\r')
        [ -n "$file" ] && { echo "$file"; return; }
    done
    echo ""
}

# ── shared helpers ────────────────────────────────────────────────────────────
send_grade() {
    echo -n "${1};0" | nc -u -w1 "$TARGET" "$PORT"
}

snapshot_log() {
    [ -n "$1" ] && adb shell "cat '$1'" 2>/dev/null || echo ""
}

# Logcat tags containing colons can't be used with adb logcat -s; grep instead
capture_logcat() {
    adb logcat -d 2>/dev/null | grep "QZ:OcrCalibration"
}

clear_logcat() {
    adb logcat -c 2>/dev/null
}

parse_ocr() {
    local field=$1 logcat=$2
    echo "$logcat" | grep "${field}=" | tail -1 | sed "s/.*${field}=//" | tr -d '\r'
}

screencap() {
    local remote="/sdcard/qz_cal_tmp.png" local_path=$1
    adb shell screencap -p "$remote" 2>/dev/null
    adb pull "$remote" "$local_path" 2>/dev/null
    adb shell rm -f "$remote" 2>/dev/null
}

# ── setup ─────────────────────────────────────────────────────────────────────
mkdir -p "$OUTPUT_DIR"
echo "Output:  $OUTPUT_DIR"

LOG_FILE=$(find_log_file)
if [ -z "$LOG_FILE" ]; then
    echo "WARNING: no firmware log file found — log diff will be empty (is iFit running?)"
else
    echo "Log:     $LOG_FILE"
fi
echo ""

# ── Phase 1: grade sweep (log format discovery) ───────────────────────────────
run_grade_sweep() {
    printf "step\tgrade_sent\tocr_incline\tocr_speed\tocr_cadence\tocr_resistance\tocr_watts\tnew_log_lines\n" \
        > "$OUTPUT_DIR/summary.tsv"

    echo "=== Phase 1: grade sweep ${GRADES[*]}% (${SETTLE}s settle) ==="
    echo "    Discovers which firmware log lines track which metrics."
    echo ""

    clear_logcat
    local log_before
    log_before=$(snapshot_log "$LOG_FILE")

    local step=0
    for grade in "${GRADES[@]}"; do
        step=$((step + 1))
        echo "Step $step — grade ${grade}%"
        send_grade "$grade"
        sleep "$SETTLE"

        local logcat
        logcat=$(capture_logcat)
        echo "$logcat" > "$OUTPUT_DIR/step_${step}_logcat.txt"
        clear_logcat

        local ocr_incline ocr_speed ocr_cadence ocr_resistance ocr_watts
        ocr_incline=$(parse_ocr    "incline"    "$logcat")
        ocr_speed=$(parse_ocr      "speed"      "$logcat")
        ocr_cadence=$(parse_ocr    "cadence"    "$logcat")
        ocr_resistance=$(parse_ocr "resistance" "$logcat")
        ocr_watts=$(parse_ocr      "watts"      "$logcat")

        local log_after log_diff new_lines
        log_after=$(snapshot_log "$LOG_FILE")
        log_diff=$(diff <(echo "$log_before") <(echo "$log_after") | grep "^>" | sed 's/^> //')
        echo "$log_diff" > "$OUTPUT_DIR/step_${step}_logdiff.txt"
        log_before="$log_after"
        new_lines=$(echo "$log_diff" | grep -c . 2>/dev/null || echo 0)

        screencap "$OUTPUT_DIR/step_${step}_screen.png"

        echo "  OCR: incline=${ocr_incline:--}  speed=${ocr_speed:--}  cadence=${ocr_cadence:--}  resistance=${ocr_resistance:--}  watts=${ocr_watts:--}"
        echo "  Log: $new_lines new line(s)"
        [ -n "$log_diff" ] && echo "$log_diff" | head -5 | sed 's/^/         /'
        echo ""

        printf "%d\t%s\t%s\t%s\t%s\t%s\t%s\t%d\n" \
            "$step" "$grade" \
            "${ocr_incline:--}" "${ocr_speed:--}" "${ocr_cadence:--}" \
            "${ocr_resistance:--}" "${ocr_watts:--}" \
            "$new_lines" >> "$OUTPUT_DIR/summary.tsv"
    done

    echo "=== Phase 1 Summary ==="
    column -t -s $'\t' "$OUTPUT_DIR/summary.tsv"
    echo ""
    echo "Next: match step_N_logdiff.txt against step_N_screen.png to find the"
    echo "      firmware log line whose value tracks the displayed grade."
    echo ""
}

# ── Phase 2: swipe sweep (formula + hysteresis derivation) ───────────────────
run_swipe_sweep() {
    printf "step\ty_commanded\tocr_grade\tspring_back_px\tocr_speed\n" \
        > "$OUTPUT_DIR/sweep_summary.tsv"

    echo "=== Phase 2: swipe sweep X=$SWEEP_X, Y=$SWEEP_Y_START→$SWEEP_Y_END step=$SWEEP_Y_STEP ==="
    echo "    Neutral return position: Y=$SWEEP_NEUTRAL between each swipe."
    echo "    Spring-back = Y_commanded - Y_implied_by_OCR (derived after fit)."
    echo "    Note: sweep both ascending and descending to reveal hysteresis asymmetry."
    echo ""

    clear_logcat

    local step=0
    local y=$SWEEP_Y_START
    local direction=1
    [ "$SWEEP_Y_START" -gt "$SWEEP_Y_END" ] && direction=-1

    while true; do
        # Check termination before processing
        if [ "$direction" -eq 1 ] && [ "$y" -gt "$SWEEP_Y_END" ]; then break; fi
        if [ "$direction" -eq -1 ] && [ "$y" -lt "$SWEEP_Y_END" ]; then break; fi

        step=$((step + 1))
        echo "Step $step — swipe to Y=$y (returning from neutral $SWEEP_NEUTRAL first)"

        # Return to neutral to ensure consistent travel distance for each measurement
        adb shell input swipe "$SWEEP_X" "$SWEEP_NEUTRAL" "$SWEEP_X" "$SWEEP_NEUTRAL" 200 2>/dev/null
        sleep 1

        # Swipe to target Y
        adb shell input swipe "$SWEEP_X" "$SWEEP_NEUTRAL" "$SWEEP_X" "$y" 200 2>/dev/null
        sleep "$SETTLE"

        local logcat ocr_grade ocr_speed
        logcat=$(capture_logcat)
        echo "$logcat" > "$OUTPUT_DIR/sweep_${step}_logcat.txt"
        clear_logcat

        ocr_grade=$(parse_ocr "incline" "$logcat")
        ocr_speed=$(parse_ocr "speed"   "$logcat")

        screencap "$OUTPUT_DIR/sweep_${step}_screen.png"

        echo "  Y_commanded=$y  OCR grade=${ocr_grade:--}  speed=${ocr_speed:--}"
        echo ""

        # spring_back_px computed after fit — placeholder column for now
        printf "%d\t%d\t%s\t%s\t%s\n" \
            "$step" "$y" "${ocr_grade:--}" "-" "${ocr_speed:--}" \
            >> "$OUTPUT_DIR/sweep_summary.tsv"

        y=$((y + direction * SWEEP_Y_STEP))
    done

    echo "=== Phase 2 Summary ==="
    column -t -s $'\t' "$OUTPUT_DIR/sweep_summary.tsv"
    echo ""

    # ── least-squares fit: Y = a - b * grade ─────────────────────────────────
    echo "=== Formula Fit (least squares: Y = a - b × grade) ==="
    awk -F'\t' '
        NR > 1 && $3 != "-" && $3 != "" {
            n++
            g = $3 + 0   # OCR grade
            y = $2 + 0   # Y_commanded (proxy for Y_actual before spring-back correction)
            sg  += g;  sy  += y
            sgg += g*g; syy += y*y; sgy += g*y
        }
        END {
            if (n < 2) { print "Not enough data points with OCR readings."; exit }
            # fit Y = a - b*g  →  Y = a + c*g  where c = -b
            denom = n*sgg - sg*sg
            if (denom == 0) { print "Degenerate fit — all grade values identical?"; exit }
            c = (n*sgy - sg*sy) / denom
            a = (sy - c*sg) / n
            b = -c

            # R-squared
            ss_tot = syy - sy*sy/n
            ss_res = 0
            # (recompute residuals inline — awk single-pass workaround)
            print ""
            printf "  Fit:  Y = %.2f - %.4f * grade\n", a, b
            printf "  i.e.  y2 = (int)(%.2f - (%.4f * grade))\n", a, b
            printf "  n=%d data points\n", n
            printf "\n"
            printf "  Paste into your device class Slider:\n"
            printf "    protected int targetY(float grade) {\n"
            printf "        return (int)(%.2f - %.4f * grade);\n", a, b
            printf "    }\n"
            printf "\n"
            printf "  NOTE: this fit uses Y_commanded as a proxy for Y_actual.\n"
            printf "  The true formula accounts for spring-back: measure Y_actual\n"
            printf "  at 3+ known grades and refit to refine coefficients.\n"
        }
    ' "$OUTPUT_DIR/sweep_summary.tsv" | tee "$OUTPUT_DIR/formula_fit.txt"

    # ── spring-back column fill-in using the fitted formula ──────────────────
    echo "=== Spring-back per step (Y_commanded - Y_implied_by_fit) ==="
    awk -F'\t' '
        NR == 1 { next }
        $3 == "-" || $3 == "" { next }
        {
            # read fit from formula_fit.txt would require two passes; recompute inline
            # we approximate using the overall fit already printed
        }
    ' "$OUTPUT_DIR/sweep_summary.tsv"
    # Recompute spring-back against the fit in one awk pass
    awk -F'\t' '
        NR > 1 && $3 != "-" && $3 != "" {
            n++; g[n]=$3+0; y[n]=$2+0
            sg+=g[n]; sy+=y[n]; sgg+=g[n]*g[n]; sgy+=g[n]*y[n]
        }
        END {
            if (n < 2) exit
            denom = n*sgg - sg*sg
            if (denom == 0) exit
            c = (n*sgy - sg*sy) / denom
            a = (sy - c*sg) / n
            b = -c
            printf "  %-6s  %-12s  %-10s  %-14s\n", "step", "Y_commanded", "OCR_grade", "spring_back_px"
            for (i=1; i<=n; i++) {
                y_fit = a - b * g[i]
                sb = y[i] - y_fit
                printf "  %-6d  %-12d  %-10.1f  %+.1f\n", i, y[i], g[i], sb
            }
        }
    ' "$OUTPUT_DIR/sweep_summary.tsv"
    echo ""
}

# ── main ──────────────────────────────────────────────────────────────────────
if $SWEEP_SWIPE; then
    run_swipe_sweep
else
    run_grade_sweep
fi

echo "Results in $OUTPUT_DIR/"
