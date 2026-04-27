package org.cagnulein.qzcompanionnordictracktreadmill;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.os.Handler;
import android.util.DisplayMetrics;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ProgressBar;
import android.widget.TextView;

import org.cagnulein.qzcompanionnordictracktreadmill.calibration.CalibrationResult;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.FormulaFitter;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceRegistry;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MonoStdoutMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.service.MyAccessibilityService;

import java.util.ArrayList;
import java.util.List;

/**
 * Fully automated incline discovery: moves to background so iFit is in the
 * foreground, sweeps the slider via ADB input-swipe, reads grade from the
 * mono-stdout logcat stream (same source as MetricReaderUnicastingService),
 * fits Y = a − b×grade via FormulaFitter, validates at 5%, then saves.
 *
 * No screen capture, no ML Kit — works on all Android versions.
 */
public class AutoDiscoverInclineActivity extends Activity {

    private static final String TAG = "QZ:AutoDiscover";

    // Fine sweep (same constants as deleted CalibrationActivity)
    private static final int FINE_STEP     = 25;
    private static final int SETTLE_MS     = 300;
    private static final int POLL_INTERVAL = 400;
    private static final int TIMEOUT_MS    = 6_000;
    private static final float STABLE_TOL  = 0.3f;
    private static final int STABLE_COUNT  = 3;

    // Coarse sweep
    private static final int COARSE_STEP    = 50;
    private static final int COARSE_SETTLE  = 500;
    private static final int COARSE_TIMEOUT = 2_000;
    private static final int COARSE_MARGIN  = 200;

    private final Handler handler = new Handler();

    private TextView phaseLabel;
    private ProgressBar progressBar;
    private TextView gradeReading;
    private TextView dataPoints;
    private View resultsSection;
    private TextView resultFormula;
    private TextView resultR2;
    private TextView resultHyst;
    private TextView validationText;
    private Button btnStart;
    private Button btnSave;
    private Button btnRetry;

    private volatile boolean cancelled = false;
    private Thread discoveryThread;

    // Grade readings from iFit's mono-stdout logcat stream
    private MonoStdoutMetricReader monoReader;
    private volatile MetricSnapshot latestMonoSnapshot;

    private FormulaFitter.Result pendingResult;
    private int pendingTrackX;
    private int pendingNeutralY;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_auto_discover_incline);

        phaseLabel    = findViewById(R.id.phaseLabel);
        progressBar   = findViewById(R.id.progressBar);
        gradeReading  = findViewById(R.id.ocrReading);
        dataPoints    = findViewById(R.id.dataPoints);
        resultsSection = findViewById(R.id.resultsSection);
        resultFormula = findViewById(R.id.resultFormula);
        resultR2      = findViewById(R.id.resultR2);
        resultHyst    = findViewById(R.id.resultHyst);
        validationText = findViewById(R.id.validationText);
        btnStart      = findViewById(R.id.btnStart);
        btnSave       = findViewById(R.id.btnSave);
        btnRetry      = findViewById(R.id.btnRetry);

        btnSave.setOnClickListener(v -> saveAndFinish());
        btnRetry.setOnClickListener(v -> restart());
        findViewById(R.id.btnCancel).setOnClickListener(v -> finish());
        btnStart.setOnClickListener(v -> {
            btnStart.setVisibility(View.GONE);
            launchIfit();
            startDiscovery();
        });

        Log.i(TAG, "onCreate: showing instruction step");
        showInstructionStep();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        cancelled = true;
    }

    private void launchIfit() {
        android.content.pm.PackageManager pm = getPackageManager();
        Intent intent = pm.getLaunchIntentForPackage("com.ifit.standalone");
        if (intent != null) {
            intent.addFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
            try {
                startActivity(intent);
                return;
            } catch (Exception e) {
                Log.w(TAG, "iFit launch failed: " + e.getMessage());
            }
        } else {
            Log.w(TAG, "iFit not found via PackageManager");
        }
        moveTaskToBack(true);
    }

    // ── instruction step ──────────────────────────────────────────────────────

    private void showInstructionStep() {
        phaseLabel.setText("Open iFit and start a Manual Ride, then tap Start Scan.\n\n"
                + "QZCompanion moves to the background and sweeps the incline slider "
                + "automatically. Watch the incline change on iFit's screen as the scan runs.");
        btnStart.setVisibility(View.VISIBLE);
    }

    // ── start / restart ───────────────────────────────────────────────────────

    private void startDiscovery() {
        cancelled     = false;
        pendingResult = null;
        btnStart.setVisibility(View.GONE);
        resultsSection.setVisibility(View.GONE);
        validationText.setVisibility(View.GONE);
        btnSave.setVisibility(View.GONE);
        btnRetry.setVisibility(View.GONE);
        dataPoints.setText("");
        progressBar.setMax(1);
        progressBar.setProgress(0);

        // Start reading grade from iFit's logcat stream
        monoReader = new MonoStdoutMetricReader();
        monoReader.subscribe(snap -> latestMonoSnapshot = snap);
        monoReader.read();

        discoveryThread = new Thread(() -> {
            try {
                runDiscovery();
            } catch (Throwable t) {
                Log.e(TAG, "Discovery crashed", t);
                post(() -> {
                    phaseLabel.setText("Unexpected error: " + t.getClass().getSimpleName()
                            + ": " + t.getMessage());
                    btnRetry.setVisibility(View.VISIBLE);
                });
            }
        });
        discoveryThread.setDaemon(true);
        discoveryThread.start();
    }

    private void restart() {
        cancelled = true;
        if (discoveryThread != null) {
            try { discoveryThread.join(500); } catch (InterruptedException ignored) {}
        }
        pendingResult = null;
        resultsSection.setVisibility(View.GONE);
        validationText.setVisibility(View.GONE);
        btnSave.setVisibility(View.GONE);
        btnRetry.setVisibility(View.GONE);
        dataPoints.setText("");
        progressBar.setProgress(0);
        showInstructionStep();
    }

    // ── discovery pipeline ────────────────────────────────────────────────────

    private void runDiscovery() {
        Log.i(TAG, "runDiscovery: start");

        if (!MyAccessibilityService.isConnected()) {
            post(() -> {
                phaseLabel.setText("Accessibility service not enabled.\n"
                        + "Enable it in Settings → Accessibility → QZCompanion, then tap Retry.");
                btnRetry.setVisibility(View.VISIBLE);
            });
            return;
        }

        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getRealMetrics(dm);
        int screenWidth  = dm.widthPixels;
        int screenHeight = dm.heightPixels;
        Log.i(TAG, "screen: widthPx=" + screenWidth + " heightPx=" + screenHeight);

        ScreenProfile profile;
        if      (screenWidth >= 1920) profile = ScreenProfile.W1920;
        else if (screenWidth >= 1280) profile = ScreenProfile.W1280;
        else if (screenWidth >= 1024) profile = ScreenProfile.W1024;
        else                          profile = ScreenProfile.W800;

        int trackX = profile.leftTrackX;
        Log.i(TAG, "profile=" + profile.name() + " trackX=" + trackX);

        // Wait for iFit to reach the foreground before injecting gestures
        sleep(2_000);
        if (cancelled) return;

        // Phase 1 — confirm iFit is responding by issuing a test swipe and waiting
        //           for the first "Changed Grade" event on mono-stdout
        Log.i(TAG, "phase1: test swipe to confirm iFit is active");
        post(() -> phaseLabel.setText("Confirming iFit is active…"));
        int midY = screenHeight / 2;
        swipe(trackX, midY - 50, midY + 50);
        sleep(COARSE_SETTLE);
        if (!waitForGradeReading(5_000)) {
            post(() -> {
                phaseLabel.setText("No grade response from iFit after test swipe.\n"
                        + "Make sure iFit is open in a Manual Ride, then tap Retry.");
                btnRetry.setVisibility(View.VISIBLE);
            });
            return;
        }
        Log.i(TAG, "phase1: grade confirmed");
        if (cancelled) return;

        // Phase 2 — coarse sweep to find active Y range
        Log.i(TAG, "phase2: starting coarse sweep trackX=" + trackX + " screenHeight=" + screenHeight);
        post(() -> phaseLabel.setText("Scanning incline range…"));
        List<CoarseReading> coarse = runCoarseSweep(trackX, screenHeight);
        if (cancelled) return;
        Log.i(TAG, "phase2: coarse sweep complete, readings=" + coarse.size());

        int[] range = findActiveRange(coarse);
        if (range == null) {
            post(() -> {
                phaseLabel.setText("Could not determine active range — too few grade readings.");
                btnRetry.setVisibility(View.VISIBLE);
            });
            return;
        }

        int yTop    = range[0];
        int yBottom = range[1];
        Log.i(TAG, "phase2: active range yTop=" + yTop + " yBottom=" + yBottom);
        post(() -> phaseLabel.setText(
                String.format("Collecting data (Y %d–%d)…", yTop, yBottom)));

        // Phase 3 — fine sweep to collect (Y, grade) data points
        Log.i(TAG, "phase3: starting fine sweep");
        List<FormulaFitter.DataPoint> points = runFineSweep(trackX, yTop, yBottom, screenHeight);
        if (cancelled) return;
        Log.i(TAG, "phase3: fine sweep complete, points=" + points.size());

        if (points.size() < 3) {
            post(() -> {
                phaseLabel.setText("Not enough stable readings ("
                        + points.size() + " collected, 3 required).");
                btnRetry.setVisibility(View.VISIBLE);
            });
            return;
        }

        // Phase 4 — fit
        Log.i(TAG, "phase4: fitting formula");
        post(() -> phaseLabel.setText("Fitting formula…"));
        FormulaFitter.Result result;
        try {
            result = FormulaFitter.fit(points, approxNeutralY(points));
        } catch (IllegalArgumentException e) {
            post(() -> {
                phaseLabel.setText("Fit failed: " + e.getMessage());
                btnRetry.setVisibility(View.VISIBLE);
            });
            return;
        }

        Log.i(TAG, "phase4: fit result: " + result.formulaString() + " " + result.r2String());
        FormulaFitter.Result r = result;
        post(() -> {
            resultFormula.setText(r.formulaString());
            String r2text = r.r2 < 0.90
                    ? r.r2String() + "\n⚠ Poor fit — retry or check iFit is in Manual Ride."
                    : r.r2String();
            resultR2.setText(r2text);
            resultHyst.setText(r.hysteresisString());
            resultsSection.setVisibility(View.VISIBLE);
        });
        if (cancelled) return;

        // Phase 5 — validate at 5%
        Log.i(TAG, "phase5: validating at 5%");
        post(() -> phaseLabel.setText("Validating at 5%…"));
        String validation = validate(trackX, result);
        post(() -> {
            validationText.setText(validation);
            validationText.setVisibility(View.VISIBLE);
        });
        if (cancelled) return;

        pendingResult   = result;
        pendingTrackX   = trackX;
        pendingNeutralY = (int) result.a;

        post(() -> {
            phaseLabel.setText("Discovery complete. Switch back to QZCompanion to save.");
            btnSave.setVisibility(View.VISIBLE);
            btnRetry.setVisibility(View.VISIBLE);
        });
    }

    // ── coarse sweep ──────────────────────────────────────────────────────────

    private static class CoarseReading {
        final int   y;
        final float grade;
        CoarseReading(int y, float grade) { this.y = y; this.grade = grade; }
    }

    private List<CoarseReading> runCoarseSweep(int trackX, int screenHeight) {
        List<CoarseReading> readings = new ArrayList<>();
        int prevY = screenHeight / 2;

        for (int y = COARSE_MARGIN; y <= screenHeight - COARSE_MARGIN; y += COARSE_STEP) {
            if (cancelled) return readings;
            swipe(trackX, prevY, y);
            prevY = y;
            sleep(COARSE_SETTLE);
            if (cancelled) return readings;

            Float grade = waitForStable(COARSE_TIMEOUT, 2);
            if (grade != null) {
                readings.add(new CoarseReading(y, grade));
                int yCapture = y;
                float g = grade;
                post(() -> gradeReading.setText(
                        String.format("Scanning Y=%d → %.1f%%", yCapture, g)));
            }
        }
        return readings;
    }

    /**
     * Identifies the Y positions where the incline slider actively responds.
     * Strips leading and trailing runs of equal grade (physical stop regions).
     */
    private int[] findActiveRange(List<CoarseReading> readings) {
        int n = readings.size();
        if (n < 3) return null;

        int first = 0;
        for (int i = 0; i < n - 1; i++) {
            if (Math.abs(readings.get(i).grade - readings.get(i + 1).grade) > STABLE_TOL) {
                first = (i == 0) ? 0 : i + 1;
                break;
            }
        }

        int last = n - 1;
        for (int i = n - 1; i > 0; i--) {
            if (Math.abs(readings.get(i).grade - readings.get(i - 1).grade) > STABLE_TOL) {
                last = i - 1;
                break;
            }
        }

        if (last <= first + 1) return null;
        return new int[]{ readings.get(first).y, readings.get(last).y };
    }

    // ── fine sweep ────────────────────────────────────────────────────────────

    private List<FormulaFitter.DataPoint> runFineSweep(
            int trackX, int yTop, int yBottom, int screenHeight) {
        List<FormulaFitter.DataPoint> points = new ArrayList<>();

        List<Integer> positions = new ArrayList<>();
        for (int y = yTop; y <= yBottom; y += FINE_STEP) positions.add(y);

        int total = positions.size();
        post(() -> {
            progressBar.setMax(total);
            progressBar.setProgress(0);
        });

        swipe(trackX, screenHeight - COARSE_MARGIN, yTop);
        sleep(SETTLE_MS * 2);

        int prevY = yTop;
        for (int i = 0; i < total; i++) {
            if (cancelled) return points;
            int y    = positions.get(i);
            int step = i + 1;

            swipe(trackX, prevY, y);
            prevY = y;
            sleep(SETTLE_MS);
            if (cancelled) return points;

            Float grade = waitForStable(TIMEOUT_MS, STABLE_COUNT);
            if (grade != null) {
                float g = grade;
                points.add(new FormulaFitter.DataPoint(y, g));
                post(() -> {
                    dataPoints.append(String.format("Y=%-5d → %.1f%%%n", y, g));
                    progressBar.setProgress(step);
                });
            } else {
                post(() -> gradeReading.setText("Timed out at Y=" + y + " — skipping"));
            }
        }
        return points;
    }

    // ── validation ────────────────────────────────────────────────────────────

    private String validate(int trackX, FormulaFitter.Result result) {
        int fromY   = result.targetThumbY(10.0f);
        int targetY = result.targetThumbY(5.0f);
        swipe(trackX, fromY, targetY);
        sleep(SETTLE_MS);

        Float grade = waitForStable(TIMEOUT_MS, STABLE_COUNT);
        if (grade == null) return "Validation: grade reading timed out";
        if (Math.abs(grade - 5.0f) <= 0.5f) {
            return String.format("✓ Validated: commanded 5.0%%, iFit reported %.1f%%", grade);
        }
        return String.format("⚠ Validation gap: commanded 5.0%%, iFit reported %.1f%%", grade);
    }

    // ── grade polling (mono-stdout) ───────────────────────────────────────────

    /** Waits for the first "Changed Grade" event from iFit's logcat stream. */
    private boolean waitForGradeReading(long timeoutMs) {
        long deadline = System.currentTimeMillis() + timeoutMs;
        while (System.currentTimeMillis() < deadline) {
            if (cancelled) return false;
            MetricSnapshot snap = latestMonoSnapshot;
            if (snap != null && snap.inclinePct != null) return true;
            sleep(200);
        }
        return false;
    }

    /**
     * Polls latestMonoSnapshot until requiredStreak consecutive reads agree within
     * STABLE_TOL, or timeoutMs elapses. MonoStdout updates the snapshot whenever
     * iFit logs a grade change; a stable settled value will read identically across
     * multiple poll cycles.
     */
    private Float waitForStable(long timeoutMs, int requiredStreak) {
        float last  = Float.NaN;
        int streak  = 0;
        long deadline = System.currentTimeMillis() + timeoutMs;

        while (System.currentTimeMillis() < deadline) {
            if (cancelled) return null;
            MetricSnapshot snap = latestMonoSnapshot;
            if (snap != null && snap.inclinePct != null) {
                float v = snap.inclinePct;
                post(() -> gradeReading.setText(String.format("Grade: %.1f%%", v)));
                if (!Float.isNaN(last) && Math.abs(v - last) <= STABLE_TOL) {
                    if (++streak >= requiredStreak) return v;
                } else {
                    streak = 1;
                    last   = v;
                }
            }
            sleep(POLL_INTERVAL);
        }
        return null;
    }

    // ── save ─────────────────────────────────────────────────────────────────

    private void saveAndFinish() {
        if (pendingResult == null) return;
        FormulaFitter.Result r = pendingResult;

        CalibrationResult cal = new CalibrationResult(
                r.a, r.b,
                pendingTrackX, pendingNeutralY,
                r.hystThresholdPx, r.hystSmallPx, r.hystLargePx);

        SharedPreferences prefs = getSharedPreferences("QZ", MODE_PRIVATE);
        cal.save(prefs);
        CalibrationResult.current = cal;

        prefs.edit().putString("deviceId",
                DeviceRegistry.DeviceId.custom_calibrated.name()).apply();

        Intent result = new Intent();
        result.putExtra("deviceId", DeviceRegistry.DeviceId.custom_calibrated.name());
        setResult(RESULT_OK, result);
        finish();
    }

    // ── helpers ───────────────────────────────────────────────────────────────

    private static int approxNeutralY(List<FormulaFitter.DataPoint> points) {
        FormulaFitter.DataPoint closest = points.get(0);
        for (FormulaFitter.DataPoint p : points) {
            if (Math.abs(p.ocrGrade) < Math.abs(closest.ocrGrade)) closest = p;
        }
        return closest.yCommanded;
    }

    private void swipe(int x, int fromY, int toY) {
        if (!MyAccessibilityService.isConnected()) {
            post(() -> gradeReading.setText("Accessibility service not connected"));
            return;
        }
        MyAccessibilityService.performSwipe(x, fromY, x, toY, 200);
    }

    private void sleep(long ms) {
        try { Thread.sleep(ms); } catch (InterruptedException ignored) {
            Thread.currentThread().interrupt();
        }
    }

    private void post(Runnable r) { handler.post(r); }
}
