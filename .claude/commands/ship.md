# /ship — Commit and push a change

Run this when ready to ship a batch of changes.

## Step 1 — Run tests

```bash
bash run-tests.sh 2>&1
```

All 314 tests must pass before proceeding.

## Step 2 — Bump version

Edit `version.properties`:
- Bug fix → increment patch (`3.6.29 → 3.6.30`)
- New feature → increment minor (`3.6.x → 3.7.0`)

`versionCode` is set automatically by CI — never edit it.

## Step 3 — Commit

```bash
git add -p          # stage selectively
git commit -m "..."
```

Commit message format: imperative mood, one line, ≤72 chars.

## Step 4 — Push to fork

```bash
git push fork <branch>
```

**Never** bare `git push` — that targets the upstream `cagnulein` repo.

## Step 5 — Confirm CI

Check the Actions tab on the fork. The build runs `./gradlew test assembleRelease` and publishes a release APK on success.
