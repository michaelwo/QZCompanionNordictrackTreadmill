package org.cagnulein.qzcompanionnordictracktreadmill;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.media.projection.MediaProjectionManager;
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
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.ShellRuntime;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceRegistry;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ScreenProfile;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;
import org.cagnulein.qzcompanionnordictracktreadmill.service.OcrCalibrationService;
import org.cagnulein.qzcompanionnordictracktreadmill.service.ScreenCaptureService;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 * Replaces CalibrationActivity with a fully automated incline discovery flow.
 *
 * Performs a two-phase sweep (coarse to find the active Y range, fine to collect
 * formula data), fits Y = a − b×grade via FormulaFitter, validates at 5%, then
 * saves as CalibrationResult. No user input required.
 */
public class AutoDiscoverInclineActivity extends Activity {

    private static final String TAG = "QZ:AutoDiscover";
    private static final int OCR_REQUEST_CODE = 1;

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
    private final ShellRuntime shellRuntime = new ShellRuntime();

    private TextView phaseLabel;
    private ProgressBar progressBar;
    private TextView ocrReading;
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

    private FormulaFitter.Result pendingResult;
    private int pendingTrackX;
    private int pendingNeutralY;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_auto_discover_incline);

        phaseLabel     = findViewById(R.id.phaseLabel);
        progressBar    = findViewById(R.id.progressBar);
        ocrReading     = findViewById(R.id.ocrReading);
        dataPoints     = findViewById(R.id.dataPoints);
        resultsSection = findViewById(R.id.resultsSection);
        resultFormula  = findViewById(R.id.resultFormula);
        resultR2       = findViewById(R.id.resultR2);
        resultHyst     = findViewById(R.id.resultHyst);
        validationText = findViewById(R.id.validationText);
        btnStart       = findViewById(R.id.btnStart);
        btnSave        = findViewById(R.id.btnSave);
        btnRetry       = findViewById(R.id.btnRetry);

        btnSave.setOnClickListener(v -> saveAndFinish());
        btnRetry.setOnClickListener(v -> restart());
        findViewById(R.id.btnCancel).setOnClickListener(v -> finish());
        btnStart.setOnClickListener(v -> {
            btnStart.setVisibility(View.GONE);
            moveTaskToBack(true);
            startDiscovery();
        });

        Log.i(TAG, "onCreate: latestReading=" + OcrCalibrationService.latestReading);
        if (OcrCalibrationService.latestReading != null) {
            Log.i(TAG, "onCreate: OCR already running, showing instruction step");
            showInstructionStep();
        } else {
            Log.i(TAG, "onCreate: requesting screen-capture permission");
            phaseLabel.setText("Waiting for screen-capture permission…");
            MediaProjectionManager mpm = (MediaProjectionManager)
                    getSystemService(Context.MEDIA_PROJECTION_SERVICE);
            startActivityForResult(mpm.createScreenCaptureIntent(), OCR_REQUEST_CODE);
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        Log.i(TAG, "onActivityResult: requestCode=" + requestCode + " resultCode=" + resultCode);
        if (requestCode != OCR_REQUEST_CODE) return;
        if (resultCode != RESULT_OK) { finish(); return; }
        try {
            Log.i(TAG, "onActivityResult: starting MediaProjection + OCR services");
            MediaProjection.startService(this, resultCode, data);
            Log.i(TAG, "onActivityResult: MediaProjection.startService done");
            startService(new Intent(this, OcrCalibrationService.class));
            Log.i(TAG, "onActivityResult: OcrCalibrationService started — showing instruction step");
            showInstructionStep();
        } catch (Throwable t) {
            Log.e(TAG, "onActivityResult: crash starting services", t);
            phaseLabel.setText("Failed to start capture services: " + t.getMessage());
            btnRetry.setVisibility(View.VISIBLE);
        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        cancelled = true;
    }

    // ── instruction step ──────────────────────────────────────────────────────

    private void showInstructionStep() {
        phaseLabel.setText("Open iFit and start a Manual Ride, then tap Start Scan.\n\n"
                + "QZCompanion will move to the background and sweep the incline slider automatically.");
        btnStart.setVisibility(View.VISIBLE);
    }

    // ── start / restart ───────────────────────────────────────────────────────

    private void startDiscovery() {
        cancelled  = false;
        pendingResult = null;
        btnStart.setVisibility(View.GONE);
        resultsSection.setVisibility(View.GONE);
        validationText.setVisibility(View.GONE);
        btnSave.setVisibility(View.GONE);
        btnRetry.setVisibility(View.GONE);
        dataPoints.setText("");
        progressBar.setMax(1);
        progressBar.setProgress(0);

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

        // Determine trackX from physical screen width (gesture coords are in screen space)
        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getRealMetrics(dm);
        int screenWidth  = dm.widthPixels;
        int screenHeight = dm.heightPixels;
        Log.i(TAG, "screen: widthPx=" + screenWidth + " heightPx=" + screenHeight);

        // Prefer the width from the captured frame — same coordinate space as OCR/gestures
        int captureWidth = ScreenCaptureService.getImageWidth();
        if (captureWidth > 0) screenWidth = captureWidth;
        Log.i(TAG, "captureWidth=" + captureWidth + " effectiveScreenWidth=" + screenWidth);

        ScreenProfile profile;
        if      (screenWidth >= 1920) profile = ScreenProfile.W1920;
        else if (screenWidth >= 1280) profile = ScreenProfile.W1280;
        else if (screenWidth >= 1024) profile = ScreenProfile.W1024;
        else                          profile = ScreenProfile.W800;

        int trackX = profile.leftTrackX;
        Log.i(TAG, "profile=" + profile.name() + " trackX=" + trackX);

        // Phase 1 — wait for iFit workout screen to be visible (user navigated away from QZCompanion)
        Log.i(TAG, "phase1: waiting for OCR incline reading");
        post(() -> phaseLabel.setText("Waiting for iFit workout screen…\n(Navigate to a Manual Ride on iFit)"));
        if (!waitForOcrReading(60_000)) {
            post(() -> {
                phaseLabel.setText("No OCR incline data after 60 s — is iFit running with the workout screen visible?");
                btnRetry.setVisibility(View.VISIBLE);
            });
            return;
        }
        Log.i(TAG, "phase1: OCR confirmed");
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
                phaseLabel.setText("Could not determine active range — check iFit screen visibility.");
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
                    ? r.r2String() + "\n⚠ Poor fit — retry or check iFit screen layout."
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
            phaseLabel.setText("Discovery complete.");
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
                post(() -> ocrReading.setText(
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

        // First index where grade starts changing (after any top-cap run)
        int first = 0;
        for (int i = 0; i < n - 1; i++) {
            if (Math.abs(readings.get(i).grade - readings.get(i + 1).grade) > STABLE_TOL) {
                first = (i == 0) ? 0 : i + 1;
                break;
            }
        }

        // Last index before grade stops changing (before any bottom-cap run)
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

        // Position slider at active top before starting
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
                post(() -> ocrReading.setText("OCR: timed out at Y=" + y + " — skipping"));
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
        if (grade == null) return "Validation: OCR timed out";
        if (Math.abs(grade - 5.0f) <= 0.5f) {
            return String.format("✓ Validated: commanded 5.0%%, OCR read %.1f%%", grade);
        }
        return String.format("⚠ Validation gap: commanded 5.0%%, OCR read %.1f%%", grade);
    }

    // ── OCR polling ───────────────────────────────────────────────────────────

    private boolean waitForOcrReading(long timeoutMs) {
        long deadline = System.currentTimeMillis() + timeoutMs;
        while (System.currentTimeMillis() < deadline) {
            if (cancelled) return false;
            MetricSnapshot snap = OcrCalibrationService.latestReading;
            if (snap != null && snap.inclinePct != null) return true;
            sleep(200);
        }
        return false;
    }

    private Float waitForStable(long timeoutMs, int requiredStreak) {
        float last  = Float.NaN;
        int streak  = 0;
        long deadline = System.currentTimeMillis() + timeoutMs;

        while (System.currentTimeMillis() < deadline) {
            if (cancelled) return null;
            MetricSnapshot snap = OcrCalibrationService.latestReading;
            if (snap != null && snap.inclinePct != null) {
                float v = snap.inclinePct;
                post(() -> ocrReading.setText(String.format("OCR: %.1f%%", v)));
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
        try {
            shellRuntime.exec("input swipe " + x + " " + fromY + " " + x + " " + toY + " 200");
        } catch (IOException e) {
            post(() -> ocrReading.setText("Swipe failed: " + e.getMessage()));
        }
    }

    private void sleep(long ms) {
        try { Thread.sleep(ms); } catch (InterruptedException ignored) {
            Thread.currentThread().interrupt();
        }
    }

    private void post(Runnable r) { handler.post(r); }
}
