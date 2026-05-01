#!/usr/bin/env bash
# download-build.sh — Download the latest APK artifact from GitHub Actions.
#
# Usage:
#   ./download-build.sh [branch]
#
# Defaults to the current git branch if no branch is specified.

set -euo pipefail

REPO="michaelwo/QZCompanionNordictrackTreadmill"
BRANCH=${1:-$(git rev-parse --abbrev-ref HEAD)}
OUTDIR="./build-download"

echo "Fetching latest successful run on branch: $BRANCH"

RUN_ID=$(gh run list \
  --repo "$REPO" \
  --branch "$BRANCH" \
  --limit 1 \
  --json databaseId \
  --jq '.[0].databaseId')

if [[ -z "$RUN_ID" ]]; then
  echo "No successful runs found for branch '$BRANCH'."
  exit 1
fi

echo "Run ID: $RUN_ID"
rm -rf "$OUTDIR" && mkdir -p "$OUTDIR"
gh run download "$RUN_ID" --repo "$REPO" --name apk --dir "$OUTDIR"

APK=$(find "$OUTDIR" -name "*.apk" | head -n 1)
echo "Downloaded: $APK"

apkanalyzer apk summary "$APK"
