package org.cagnulein.qzcompanionnordictracktreadmill;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.media.projection.MediaProjectionManager;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;

import org.cagnulein.qzcompanionnordictracktreadmill.calibration.CalibrationResult;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.FormulaFitter;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceRegistry;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 * Guides the user through an automated swipe calibration for a new device.
 *
 * Sweep: drives the incline slider to a series of Y coordinates via shell
 * input-swipe commands, waits for the slider to settle, reads the resulting
 * grade from OcrCalibrationService, then fits Y = a − b × grade and derives
 * per-device hysteresis compensation from the residuals.
 *
 * The result is saved to SharedPreferences and to CalibrationResult.current
 * so CalibratedBikeDevice can use it immediately without a restart.
 */
public class CalibrationActivity extends Activity {

    private static final int OCR_REQUEST_CODE = 1;

    // Sweep config — covers a ~15% grade range in 10 steps
    private static final int Y_STEP        = 25;
    private static final int Y_RANGE       = 225;   // total pixels below neutral
    private static final int SETTLE_MS     = 300;   // after swipe, before polling
    private static final int POLL_INTERVAL = 400;   // OCR poll cadence (ms)
    private static final int TIMEOUT_MS    = 6_000; // per step
    private static final float STABLE_TOL  = 0.3f;  // grade tolerance for stability
    private static final int STABLE_COUNT  = 3;     // consecutive reads needed

    private final Handler handler = new Handler();
    private final ShellRuntime shellRuntime = new ShellRuntime();

    // Config inputs
    private EditText inputX;
    private EditText inputNeutralY;

    // Sections
    private View setupSection;
    private View sweepSection;
    private View resultsSection;

    // Sweep views
    private ProgressBar progressBar;
    private TextView statusText;
    private TextView ocrReadingText;
    private TextView dataPointsText;

    // Result views
    private TextView resultFormula;
    private TextView resultR2;
    private TextView resultHyst;
    private TextView resultPoints;

    private volatile boolean cancelled = false;
    private Thread sweepThread;
    private FormulaFitter.Result pendingResult;
    private List<FormulaFitter.DataPoint> pendingPoints;
    private int pendingX;
    private int pendingNeutralY;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_calibration);

        inputX       = findViewById(R.id.inputX);
        inputNeutralY = findViewById(R.id.inputNeutralY);

        setupSection   = findViewById(R.id.setupSection);
        sweepSection   = findViewById(R.id.sweepSection);
        resultsSection = findViewById(R.id.resultsSection);

        progressBar    = findViewById(R.id.progressBar);
        statusText     = findViewById(R.id.statusText);
        ocrReadingText = findViewById(R.id.ocrReading);
        dataPointsText = findViewById(R.id.dataPoints);

        resultFormula = findViewById(R.id.resultFormula);
        resultR2      = findViewById(R.id.resultR2);
        resultHyst    = findViewById(R.id.resultHyst);
        resultPoints  = findViewById(R.id.resultPoints);

        Button btnStart = findViewById(R.id.btnStart);
        btnStart.setOnClickListener(v -> startSweep());
        findViewById(R.id.btnCancelSweep).setOnClickListener(v -> cancel());
        findViewById(R.id.btnSave).setOnClickListener(v -> saveAndFinish());
        findViewById(R.id.btnRetry).setOnClickListener(v -> showSetup());
        findViewById(R.id.btnCancel).setOnClickListener(v -> finish());

        if (OcrCalibrationService.latestReading != null) {
            // OCR already running from an earlier calibration in this session
        } else {
            btnStart.setEnabled(false);
            btnStart.setText("Waiting for screen permission…");
            MediaProjectionManager mpm = (MediaProjectionManager)
                    getSystemService(Context.MEDIA_PROJECTION_SERVICE);
            startActivityForResult(mpm.createScreenCaptureIntent(), OCR_REQUEST_CODE);
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode != OCR_REQUEST_CODE) return;
        if (resultCode != RESULT_OK) {
            finish();
            return;
        }
        MediaProjection.startService(this, resultCode, data);
        Intent calibration = new Intent(this, OcrCalibrationService.class);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            startForegroundService(calibration);
        } else {
            startService(calibration);
        }
        Button btnStart = findViewById(R.id.btnStart);
        btnStart.setEnabled(true);
        btnStart.setText("Start Calibration");
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        cancelled = true;
    }

    // ── state transitions ─────────────────────────────────────────────────────

    private void showSetup() {
        setupSection.setVisibility(View.VISIBLE);
        sweepSection.setVisibility(View.GONE);
        resultsSection.setVisibility(View.GONE);
        dataPointsText.setText("");
    }

    private void showSweep(int totalSteps) {
        setupSection.setVisibility(View.GONE);
        sweepSection.setVisibility(View.VISIBLE);
        resultsSection.setVisibility(View.GONE);
        progressBar.setMax(totalSteps);
        progressBar.setProgress(0);
        dataPointsText.setText("");
        statusText.setText("Preparing…");
        ocrReadingText.setText("OCR: waiting…");
    }

    private void showResults(FormulaFitter.Result r, List<FormulaFitter.DataPoint> points) {
        setupSection.setVisibility(View.GONE);
        sweepSection.setVisibility(View.GONE);
        resultsSection.setVisibility(View.VISIBLE);

        resultFormula.setText(r.formulaString());
        resultR2.setText(r.r2String());
        resultHyst.setText(r.hysteresisString());

        StringBuilder sb = new StringBuilder();
        sb.append(String.format("%-12s  %-10s  %s%n", "Y_commanded", "OCR grade", "spring-back"));
        for (FormulaFitter.DataPoint p : points) {
            double springBack = p.yCommanded - (r.a - r.b * p.ocrGrade);
            sb.append(String.format("%-12d  %-10.1f  %+.1fpx%n",
                    p.yCommanded, p.ocrGrade, springBack));
        }
        resultPoints.setText(sb.toString());

        if (r.r2 < 0.90) {
            resultR2.setText(r.r2String() + "\n⚠ Poor fit — consider retrying or adjusting X/neutral Y.");
        }
    }

    // ── calibration sweep ─────────────────────────────────────────────────────

    private void startSweep() {
        int x, neutralY;
        try {
            x       = Integer.parseInt(inputX.getText().toString().trim());
            neutralY = Integer.parseInt(inputNeutralY.getText().toString().trim());
        } catch (NumberFormatException e) {
            statusText.setText("Invalid X or neutral Y — enter whole numbers.");
            return;
        }

        if (OcrCalibrationService.latestReading == null) {
            statusText.setText("OCR not ready yet — wait a moment after granting screen-capture permission.");
            return;
        }

        cancelled = false;
        pendingX       = x;
        pendingNeutralY = neutralY;

        List<Integer> positions = new ArrayList<>();
        for (int y = neutralY; y >= neutralY - Y_RANGE; y -= Y_STEP) {
            positions.add(y);
        }

        showSweep(positions.size());

        sweepThread = new Thread(() -> runSweep(x, neutralY, positions));
        sweepThread.setDaemon(true);
        sweepThread.start();
    }

    private void runSweep(int x, int neutralY, List<Integer> positions) {
        List<FormulaFitter.DataPoint> points = new ArrayList<>();
        int total = positions.size();

        for (int i = 0; i < total; i++) {
            if (cancelled) return;

            int y = positions.get(i);
            int step = i + 1;

            post(() -> {
                statusText.setText(String.format("Step %d/%d — swiping to Y=%d", step, total, y));
                progressBar.setProgress(step - 1);
            });

            // Return to neutral first so every swipe has a known starting position
            swipe(x, y == neutralY ? neutralY + 10 : neutralY, neutralY);
            sleep(SETTLE_MS);

            if (cancelled) return;

            // Swipe to target
            swipe(x, neutralY, y);
            sleep(SETTLE_MS);

            if (cancelled) return;

            // Wait for stable OCR reading
            Float grade = waitForStableReading();

            if (grade == null) {
                post(() -> ocrReadingText.setText("OCR: timed out at Y=" + y + " — skipping"));
                continue;
            }

            float g = grade;
            FormulaFitter.DataPoint pt = new FormulaFitter.DataPoint(y, g);
            points.add(pt);

            post(() -> {
                ocrReadingText.setText(String.format("OCR: %.1f%%", g));
                dataPointsText.append(String.format("Y=%-5d → %.1f%%%n", y, g));
            });
        }

        if (cancelled) return;

        if (points.size() < 3) {
            post(() -> {
                statusText.setText("Not enough OCR readings (" + points.size()
                        + " collected, 3 required). Check screen-capture permission.");
                progressBar.setProgress(0);
            });
            return;
        }

        try {
            FormulaFitter.Result result = FormulaFitter.fit(points, neutralY);
            pendingResult = result;
            pendingPoints = points;
            post(() -> {
                progressBar.setProgress(total);
                showResults(result, points);
            });
        } catch (IllegalArgumentException e) {
            post(() -> statusText.setText("Fit failed: " + e.getMessage()));
        }
    }

    // ── OCR stability polling ─────────────────────────────────────────────────

    private Float waitForStableReading() {
        float last = Float.NaN;
        int streak = 0;
        long deadline = System.currentTimeMillis() + TIMEOUT_MS;

        while (System.currentTimeMillis() < deadline) {
            if (cancelled) return null;

            MetricSnapshot snap = OcrCalibrationService.latestReading;
            if (snap != null && snap.inclinePct != null) {
                float reading = snap.inclinePct;
                float captured = last;
                post(() -> ocrReadingText.setText(String.format("OCR: %.1f%%", reading)));

                if (!Float.isNaN(captured) && Math.abs(reading - captured) <= STABLE_TOL) {
                    if (++streak >= STABLE_COUNT) return reading;
                } else {
                    streak = 1;
                    last = reading;
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
            r.a, r.b, pendingX, pendingNeutralY,
            r.hystThresholdPx, r.hystSmallPx, r.hystLargePx);

        SharedPreferences prefs = getSharedPreferences("QZ", MODE_PRIVATE);
        cal.save(prefs);
        CalibrationResult.current = cal;

        // Select the calibrated device and persist the choice
        DeviceRegistry.DeviceId id = DeviceRegistry.DeviceId.custom_calibrated;
        prefs.edit().putString("deviceId", id.name()).apply();

        Intent result = new Intent();
        result.putExtra("deviceId", id.name());
        setResult(RESULT_OK, result);
        finish();
    }

    private void cancel() {
        cancelled = true;
        showSetup();
    }

    // ── helpers ───────────────────────────────────────────────────────────────

    private void swipe(int x, int fromY, int toY) {
        try {
            shellRuntime.exec("input swipe " + x + " " + fromY + " " + x + " " + toY + " 200");
        } catch (IOException e) {
            post(() -> ocrReadingText.setText("Swipe failed: " + e.getMessage()));
        }
    }

    private void sleep(long ms) {
        try { Thread.sleep(ms); } catch (InterruptedException ignored) { Thread.currentThread().interrupt(); }
    }

    private void post(Runnable r) { handler.post(r); }
}
