---
description: Run local tests, preview commit, wait for confirmation, then commit and push to fork
---

Prepare and ship a commit to michaelwo's fork. Follow these steps exactly.

## Step 1 — Run local unit tests

The Android build (AAPT2) is broken on this ARM64 host, so compile and run
the pure-Java unit tests manually. Run these commands:

```bash
JUNIT=/usr/share/java/junit4.jar
HAMCREST=/usr/share/java/hamcrest-all.jar
ANDROID=/opt/android-sdk/platforms/android-34/android.jar
ANNOTATION=/workspace/.gradle/caches/modules-2/files-2.1/androidx.annotation/annotation-jvm/1.6.0/a7257339a052df0f91433cf9651231bbb802b502/annotation-jvm-1.6.0.jar
OUT=app/build/manual-test-classes
TEST_OUT=app/build/manual-test-classes-test

rm -rf $OUT $TEST_OUT && mkdir -p $OUT $TEST_OUT

# Compile main sources (excluding files that need R.java)
find app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill/device \
     app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill/reader \
     -name "*.java" > /tmp/ship-sources.txt
echo "app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill/ShellRuntime.java" >> /tmp/ship-sources.txt
echo "app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill/MyAccessibilityService.java" >> /tmp/ship-sources.txt
echo "/tmp/MainActivity.java" >> /tmp/ship-sources.txt

# Ensure stub MainActivity exists
cat > /tmp/MainActivity.java << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
public class MainActivity { public static void sendCommand(String cmd) {} }
EOF

javac -encoding UTF-8 -cp "$ANDROID:$ANNOTATION" -d $OUT @/tmp/ship-sources.txt 2>&1

# Compile tests
find app/src/test/java/org/cagnulein/qzcompanionnordictracktreadmill/device \
     -name "*.java" > /tmp/ship-test-sources.txt
javac -encoding UTF-8 -cp "$ANDROID:$ANNOTATION:$JUNIT:$HAMCREST:$OUT" -d $TEST_OUT @/tmp/ship-test-sources.txt 2>&1

# Run tests
java -cp "$JUNIT:$HAMCREST:$ANDROID:$ANNOTATION:$OUT:$TEST_OUT" \
     org.junit.runner.JUnitCore \
     org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDeviceTest \
     org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDeviceTest \
     org.cagnulein.qzcompanionnordictracktreadmill.device.MetricReaderTest 2>&1
```

**If any test fails, stop here.** Report the failures and do not proceed to commit.

## Step 1.5 — Clean Code smell check

Perform the same two-pass review defined in `/smells`, scoped to the Java files changed
since the last commit (`git diff --name-only HEAD -- '*.java'`).

**Critical smells block the commit.** Report them and stop. Do not proceed to Step 2 until
the user resolves them or explicitly overrides ("ship anyway").

Critical smells (always blocking):
- Flag arguments (boolean literals passed directly to a method)
- Commented-out code blocks
- Base class referencing a subclass by name
- Law of Demeter violations in the dispatch path
- Hybrid structures with public mutable fields and complex behavior

Advisory smells (reported in the Step 5 preview, do not block):
- Methods over 20 lines
- Negative conditionals
- Long parameter lists (≥ 4 params)
- Magic numbers outside `device/catalog/`
- TODO/FIXME without owner
- Naming issues

Formula constants in `device/catalog/` are auditability debt tracked in the maturity model —
note count only, do not block.

## Step 2 — Inventory

Run all of these in parallel:
- `git status`
- `git diff`
- `git diff --cached`
- `git log --oneline -5`

## Step 3 — Stage

Stage only files relevant to the current task. Never use `git add -A` or `git add .`.
Never stage:
- `.env`, `*.jks`, `*.p12`, `*.keystore`, `signapk.sh` — may contain secrets
- `*.rtf`, `download-build.sh~` — scratch files
- `app/build/` — build artifacts

If it is ambiguous which files belong in this commit, ask before staging.

## Step 4 — Draft commit message

Write a conventional commit message:
- First line: `Type: short description` (≤72 chars). Type: `Feat`, `Fix`, `Refactor`, `Test`, `Docs`, `Chore`.
- Body (optional): explain WHY, not what.
- Trailer: `Co-Authored-By: Claude Sonnet 4.6 <noreply@anthropic.com>`

## Step 5 — Show preview and STOP

Present the following to the user and **do not proceed until they explicitly confirm**:

```
Tests: N passed, 0 failed ✓

Smells: <"None" | list advisory findings — critical findings would have already blocked>

Files to commit:
  <list staged files>

Commit message:
  <full message>

Target: fork → michaelwo/QZCompanionNordictrackTreadmill  (<branch>)

Reply "yes" (or "go") to commit and push, or give corrections.
```

## Step 6 — Commit and push (only after confirmation)

```bash
git commit -m "..."
git push fork <branch>
```

**CRITICAL: always push to `fork`, never `origin`.**
- `fork` = michaelwo/QZCompanionNordictrackTreadmill ✓
- `origin` = cagnulein/QZCompanionNordictrackTreadmill ✗ (upstream — never push here)

After pushing, confirm the remote URL in the push output contains `michaelwo/`.
