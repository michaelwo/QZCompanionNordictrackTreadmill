#!/usr/bin/env bash
# Extracts Sindarin DLLs from the com.ifit.standalone APK and decompiles them to C#.
#
# Usage:
#   ./decompile-sindarin.sh [path/to/ifit-standalone.apk]
#
# Prerequisites (run once):
#   docker build -f Dockerfile.ilspy -t ilspy .
#
# Step 0 — if you haven't pulled the APK yet, run these on your machine:
#   adb shell pm list packages | grep ifit
#   adb shell pm path com.ifit.standalone
#   adb pull /data/app/~~XXXX==/com.ifit.standalone-YYYY==/base.apk ./ifit-standalone.apk

set -euo pipefail

APK="${1:-ifit-standalone.apk}"
WORK_DIR="$(dirname "$APK")/sindarin_work"
ASSEMBLY_DIR="$WORK_DIR/assemblies"
OUT_DIR="$(pwd)/extracted_assemblies"
DECOMPILED_DIR="$(pwd)/decompiled"

if [[ ! -f "$APK" ]]; then
    echo "ERROR: APK not found at '$APK'"
    echo ""
    echo "Pull it from the device first:"
    echo "  adb shell pm path com.ifit.standalone"
    echo "  adb pull /data/app/~~XXXX==/com.ifit.standalone-YYYY==/base.apk ./ifit-standalone.apk"
    exit 1
fi

echo "==> Unpacking $APK"
rm -rf "$WORK_DIR"
unzip -q "$APK" -d "$WORK_DIR"
ASSET_DIR="$WORK_DIR/assets/assemblies"

if [[ ! -d "$ASSET_DIR" ]]; then
    echo "ERROR: assets/assemblies/ not found in APK — unexpected APK structure"
    exit 1
fi

mkdir -p "$OUT_DIR"

# ── Detect assembly layout ────────────────────────────────────────────────────

if ls "$ASSET_DIR"/*.blob &>/dev/null 2>&1; then
    echo "==> Detected Assembly Store blob (Xamarin.Android 12+)"
    BLOB=$(ls "$ASSET_DIR"/assemblies.blob 2>/dev/null || ls "$ASSET_DIR"/*.blob | head -1)
    echo "    blob: $BLOB"

    if command -v pyxastore &>/dev/null; then
        echo "==> Extracting with pyxastore"
        pyxastore extract "$BLOB" -o "$OUT_DIR"
    else
        echo "WARNING: pyxastore not installed. Install it with:"
        echo "  pip install pyxastore"
        echo ""
        echo "Or use the Xamarin assembly-store-reader-mk2 tool:"
        echo "  https://github.com/xamarin/xamarin-android/tree/main/tools/assembly-store-reader-mk2"
        echo ""
        echo "Alternatively, run:"
        echo "  pip install pyxastore && pyxastore extract $BLOB -o $OUT_DIR"
        exit 1
    fi

elif ls "$ASSET_DIR"/Sindarin*.dll &>/dev/null 2>&1 || ls "$ASSET_DIR"/Sindarin*.dll.lz4 &>/dev/null 2>&1; then
    echo "==> Detected individual DLL files (Xamarin.Android < 12)"

    for f in "$ASSET_DIR"/Sindarin*.dll.lz4; do
        [[ -f "$f" ]] || continue
        base="$(basename "$f" .lz4)"
        echo "    decompressing $base"
        lz4 -dq "$f" "$OUT_DIR/$base"
    done

    for f in "$ASSET_DIR"/Sindarin*.dll; do
        [[ -f "$f" ]] || continue
        echo "    copying $(basename "$f")"
        cp "$f" "$OUT_DIR/"
    done

else
    echo "ERROR: No Sindarin DLLs or assemblies.blob found under $ASSET_DIR"
    echo "Contents:"
    ls "$ASSET_DIR" | head -20
    exit 1
fi

echo ""
echo "==> Extracted assemblies:"
ls "$OUT_DIR"/Sindarin*.dll 2>/dev/null || echo "  (none — check $OUT_DIR for all files)"

# ── Decompile with ILSpyCmd via Docker ───────────────────────────────────────

mkdir -p "$DECOMPILED_DIR"

if ! docker image inspect ilspy &>/dev/null; then
    echo ""
    echo "==> Building ilspy Docker image (first run, ~2 min)"
    docker build -f "$(dirname "$0")/Dockerfile.ilspy" -t ilspy "$(dirname "$0")"
fi

for DLL in "$OUT_DIR"/Sindarin.FitPro1.Core.dll \
            "$OUT_DIR"/Sindarin.FitPro1.Tcp.dll \
            "$OUT_DIR"/Sindarin.FitPro1.dll; do
    [[ -f "$DLL" ]] || continue
    NAME="$(basename "$DLL" .dll)"
    echo "==> Decompiling $NAME"
    docker run --rm \
        -v "$OUT_DIR":/assemblies:ro \
        -v "$DECOMPILED_DIR":/decompiled \
        ilspy \
        ilspycmd -p -o "/decompiled/$NAME" "/assemblies/$(basename "$DLL")"
done

echo ""
echo "Done. Decompiled source → $DECOMPILED_DIR"
echo ""
echo "Useful greps:"
echo "  grep -r 'TcpListener\\|Listen\\|IPEndPoint' $DECOMPILED_DIR/Sindarin.FitPro1.Tcp/"
echo "  grep -ri 'incline\\|grade\\|SetIncline\\|HidWrite\\|SendReport' $DECOMPILED_DIR/Sindarin.FitPro1.Core/"
