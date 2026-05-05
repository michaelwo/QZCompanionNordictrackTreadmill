package org.cagnulein.qzcompanionnordictracktreadmill.ui;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothManager;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.os.Environment;
import android.provider.Settings;
import android.text.TextUtils;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import java.net.Inet4Address;
import java.net.NetworkInterface;

import android.graphics.Typeface;
import android.util.TypedValue;
import android.widget.LinearLayout;

import java.sql.Timestamp;
import java.util.Date;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;


import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandListenerService;
import org.cagnulein.qzcompanionnordictracktreadmill.device.gesture.GestureService;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricUnicastingService;
import org.cagnulein.qzcompanionnordictracktreadmill.console.IfitConsoleSnapshot;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceCalibration;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceController;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceRegistry;
import org.cagnulein.qzcompanionnordictracktreadmill.BuildConfig;
import org.cagnulein.qzcompanionnordictracktreadmill.R;
import org.cagnulein.qzcompanionnordictracktreadmill.MyExceptionHandler;

import androidx.appcompat.app.AlertDialog;

public class MainActivity extends AppCompatActivity {
    private static final long MAX_LOG_FILE_BYTES = 1024 * 1024;
    private static BufferedWriter logFileWriter = null;

    private DeviceAdapter deviceAdapter;
    private DeviceController activeController = null;
    private static SharedPreferences sharedPreferences;

    private final android.os.Handler heartbeatHandler =
            new android.os.Handler(android.os.Looper.getMainLooper());
    private final Runnable heartbeatTick = new Runnable() {
        @Override public void run() {
            updateRequirementsCard();
            heartbeatHandler.postDelayed(this, 5_000);
        }
    };

    private boolean checkPermissions(){
        if(ActivityCompat.checkSelfPermission(this, android.Manifest.permission.WRITE_EXTERNAL_STORAGE) == PackageManager.PERMISSION_GRANTED) {
            return true;
        }
        else {
            ActivityCompat.requestPermissions(this, new String[]{android.Manifest.permission.WRITE_EXTERNAL_STORAGE}, 100);
            return false;
        }
    }

    public static void initLogFile() {
        try {
            File logFile = new File(Environment.getExternalStorageDirectory(), "qzcompanion.log");
            if (logFile.exists() && logFile.length() > MAX_LOG_FILE_BYTES) {
                File bak = new File(Environment.getExternalStorageDirectory(), "qzcompanion.log.bak");
                bak.delete();
                logFile.renameTo(bak);
            }
            logFileWriter = new BufferedWriter(new FileWriter(logFile, true));
        } catch (IOException e) {
            Log.e("QZ:Main", "Failed to open log file: " + e.getMessage());
        }
    }

    public static final String PREF_DEVICE_ID = "deviceId";
    public static final String PREF_DEBUG_LOG = "debugLog";

    public static SharedPreferences prefs() { return sharedPreferences; }
    public static boolean isDebugLog() { return sharedPreferences != null && sharedPreferences.getBoolean(PREF_DEBUG_LOG, false); }

    public static void writeLog(String command) {
        String line = new Timestamp(new Date().getTime()) + " " + command;
        if (logFileWriter != null) {
            try {
                logFileWriter.write(line);
                logFileWriter.newLine();
                logFileWriter.flush();
            } catch (IOException ignored) {}
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        checkPermissions();
        Thread.setDefaultUncaughtExceptionHandler(new MyExceptionHandler(this));
        sharedPreferences = getSharedPreferences("QZ", MODE_PRIVATE);
        loadCalibration();
        initLogFile();
        initUi();
        startServices();
        restoreDeviceSelection();
        updateStatusChip();
        rebindAccessibilityService();
    }

    private void loadCalibration() {
        File calFile = new File(Environment.getExternalStorageDirectory(), "qz-calibration.json");
        if (calFile.exists()) {
            try {
                DeviceCalibration.current = DeviceCalibration.loadFromJson(calFile);
                String savedId = sharedPreferences.getString(PREF_DEVICE_ID,
                        DeviceRegistry.DeviceId.other.name());
                if (DeviceRegistry.DeviceId.other.name().equals(savedId)) {
                    sharedPreferences.edit()
                            .putString(PREF_DEVICE_ID, DeviceRegistry.DeviceId.custom_calibrated.name())
                            .apply();
                }
                Log.i("QZ:Main", "Loaded calibration from qz-calibration.json");
            } catch (Exception e) {
                Log.w("QZ:Main", "qz-calibration.json load failed, falling back: " + e.getMessage());
                DeviceCalibration.current = DeviceCalibration.load(sharedPreferences);
            }
        } else {
            DeviceCalibration.current = DeviceCalibration.load(sharedPreferences);
        }
    }

    private void initUi() {
        if (getSupportActionBar() != null) {
            String buildId = BuildConfig.IS_CI_BUILD
                    ? "build " + BuildConfig.VERSION_CODE
                    : "dev-" + BuildConfig.GIT_HASH;
            getSupportActionBar().setSubtitle("v" + BuildConfig.VERSION_NAME + "  ·  " + buildId);
        }

        RecyclerView deviceList = findViewById(R.id.deviceList);
        deviceList.setLayoutManager(new LinearLayoutManager(this));
        deviceAdapter = new DeviceAdapter(id -> {
            if (!isAccessibilityServiceEnabled(getApplicationContext(), GestureService.class)) {
                startActivity(new Intent(Settings.ACTION_ACCESSIBILITY_SETTINGS));
            }
            selectDevice(DeviceRegistry.forId(id));
            SharedPreferences.Editor myEdit = sharedPreferences.edit();
            myEdit.putString(PREF_DEVICE_ID, id.name());
            myEdit.apply();
        });
        deviceList.setAdapter(deviceAdapter);
    }

    private void restoreDeviceSelection() {
        String savedId = sharedPreferences.getString(PREF_DEVICE_ID, DeviceRegistry.DeviceId.other.name());
        try {
            DeviceRegistry.DeviceId id = DeviceRegistry.DeviceId.valueOf(savedId);
            deviceAdapter.setSelectedId(id);
            selectDevice(DeviceRegistry.forId(id));
        } catch (IllegalArgumentException ignored) {}
    }

    private void startServices() {
        Intent inServer = new Intent(getApplicationContext(), QZCommandListenerService.class);
        getApplicationContext().startService(inServer);
        Intent in = new Intent(getApplicationContext(), QZMetricUnicastingService.class);
        getApplicationContext().startService(in);
    }

    private boolean isAccessibilityServiceEnabled(Context context, Class<?> accessibilityService) {
        int accessibilityEnabled = 0;
        final String service = context.getPackageName() + "/" + accessibilityService.getCanonicalName();
        try {
            accessibilityEnabled = Settings.Secure.getInt(
                    context.getApplicationContext().getContentResolver(),
                    Settings.Secure.ACCESSIBILITY_ENABLED
            );
        } catch (Settings.SettingNotFoundException e) {
            e.printStackTrace();
        }
        TextUtils.SimpleStringSplitter colonSplitter = new TextUtils.SimpleStringSplitter(':');

        if (accessibilityEnabled == 1) {
            String settingValue = Settings.Secure.getString(
                    context.getApplicationContext().getContentResolver(),
                    Settings.Secure.ENABLED_ACCESSIBILITY_SERVICES
            );
            if (settingValue != null) {
                colonSplitter.setString(settingValue);
                while (colonSplitter.hasNext()) {
                    String componentName = colonSplitter.next();
                    if (componentName.equalsIgnoreCase(service)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void rebindAccessibilityService() {
        String svc = getPackageName() + "/.device.gesture.GestureService";
        try {
            Settings.Secure.putString(getContentResolver(),
                    Settings.Secure.ENABLED_ACCESSIBILITY_SERVICES, svc);
            Settings.Secure.putInt(getContentResolver(),
                    Settings.Secure.ACCESSIBILITY_ENABLED, 1);
            Log.i("QZ:Main", "AccessibilityService re-bound on startup");
        } catch (SecurityException e) {
            Log.w("QZ:Main", "WRITE_SECURE_SETTINGS not granted — grant via: "
                    + "adb shell pm grant " + getPackageName()
                    + " android.permission.WRITE_SECURE_SETTINGS");
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main_menu, menu);
        menu.findItem(R.id.menu_verbose_logging).setChecked(
                sharedPreferences.getBoolean(PREF_DEBUG_LOG, false));
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();
        if (id == R.id.menu_verbose_logging) {
            boolean next = !item.isChecked();
            item.setChecked(next);
            sharedPreferences.edit().putBoolean(PREF_DEBUG_LOG, next).apply();
            new androidx.appcompat.app.AlertDialog.Builder(this)
                    .setTitle("Settings Saved")
                    .setMessage("Restart the app to apply logging changes.")
                    .setPositiveButton("OK", (d, w) -> d.dismiss())
                    .show();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    protected void onResume() {
        super.onResume();
        updateStatusChip();
        updateRequirementsCard();
        heartbeatHandler.postDelayed(heartbeatTick, 5_000);
    }

    @Override
    protected void onPause() {
        super.onPause();
        heartbeatHandler.removeCallbacks(heartbeatTick);
    }

    private void updateRequirementsCard() {
        LinearLayout list = findViewById(R.id.requirementsList);
        if (list == null || activeController == null) return;
        list.removeAllViews();

        Device device = activeController.device();

        boolean ok = isAccessibilityServiceEnabled(this, GestureService.class);
        addRequirementRow(list, ok,
                "Accessibility service",
                ok ? "Enabled — app can adjust speed and incline"
                   : "Tap to enable — required to control the bike",
                ok ? null : v -> startActivity(new Intent(Settings.ACTION_ACCESSIBILITY_SETTINGS)));

        long lastHb = QZCommandListenerService.lastQzHeartbeatMs;
        boolean heartbeatActive = lastHb > 0
                && (System.currentTimeMillis() - lastHb) < QZCommandListenerService.QZ_HEARTBEAT_TIMEOUT_MS;
        java.net.InetAddress qzAddr = QZCommandListenerService.qzAddress;
        addRequirementRow(list, heartbeatActive,
                "QZ",
                heartbeatActive
                        ? "QZ heartbeat received from " + qzAddr.getHostAddress() + " on port " + QZCommandListenerService.LISTEN_PORT + ". Device telemetry unicast active."
                        : "Waiting for QZ heartbeat commands on port " + QZCommandListenerService.LISTEN_PORT + ". Device telemetry unicast paused.",
                null);

        boolean canAdvertise = false;
        try {
            BluetoothManager btMgr = (BluetoothManager) getSystemService(BLUETOOTH_SERVICE);
            BluetoothAdapter btAdapter = btMgr != null ? btMgr.getAdapter() : null;
            canAdvertise = btAdapter != null && btAdapter.isMultipleAdvertisementSupported();
        } catch (SecurityException ignored) {
            // BLUETOOTH permission not granted; treat as not capable (informational row only)
        }
        addRequirementRow(list, !canAdvertise,
                "Bluetooth",
                canAdvertise
                        ? "BLE advertising supported — install QZ or connect Zwift directly to your device"
                        : "BLE advertising not supported — QZCompanion is the right approach",
                null);

        IfitConsoleSnapshot snap = IfitConsoleSnapshot.load(sharedPreferences);
        if (snap != null && snap.isValid()) {
            String detail = snap.machineType + "  ·  Part# " + snap.partNumber;
            if (snap.maxKph != null) detail += "  ·  Max " + snap.maxKph + " kph";
            addRequirementRow(list, true, "iFit Hardware", detail, null);
        } else {
            addRequirementRow(list, false,
                    "iFit Hardware",
                    "Open iFit → Settings → Equipment Info → Machine Info  ›",
                    v -> {
                        Intent ifitIntent = new Intent(Intent.ACTION_MAIN);
                        ifitIntent.addCategory(Intent.CATEGORY_LAUNCHER);
                        ifitIntent.setPackage("com.ifit.standalone");
                        ifitIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                        try { startActivity(ifitIntent); }
                        catch (Exception ignored) {}
                    });
        }
    }

    private void addRequirementRow(LinearLayout container, boolean ok,
                                   String name, String detail,
                                   View.OnClickListener action) {
        Context ctx = container.getContext();
        int px16 = dpToPx(ctx, 16);
        int px10 = dpToPx(ctx, 10);

        LinearLayout row = new LinearLayout(ctx);
        row.setOrientation(LinearLayout.HORIZONTAL);
        row.setPadding(px16, px10, px16, px10);
        if (action != null) {
            row.setClickable(true);
            row.setFocusable(true);
            row.setOnClickListener(action);
            TypedValue ripple = new TypedValue();
            ctx.getTheme().resolveAttribute(android.R.attr.selectableItemBackground, ripple, true);
            row.setBackgroundResource(ripple.resourceId);
        }

        TextView dot = new TextView(ctx);
        dot.setText("● ");
        dot.setTextSize(TypedValue.COMPLEX_UNIT_SP, 14);
        dot.setTextColor(ok ? 0xFF4CAF50 : 0xFFFF5722);
        dot.setTypeface(null, Typeface.BOLD);

        TextView text = new TextView(ctx);
        text.setTextSize(TypedValue.COMPLEX_UNIT_SP, 13);
        android.text.SpannableStringBuilder sb = new android.text.SpannableStringBuilder();
        sb.append(name, new android.text.style.StyleSpan(Typeface.BOLD),
                android.text.Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
        sb.append("  ");
        sb.append(detail);
        if (action != null) {
            sb.append("  ›");
        }
        text.setText(sb);

        row.addView(dot);
        row.addView(text);
        container.addView(row);
    }

    private static int dpToPx(Context ctx, int dp) {
        return Math.round(TypedValue.applyDimension(
                TypedValue.COMPLEX_UNIT_DIP, dp,
                ctx.getResources().getDisplayMetrics()));
    }

    private void updateStatusChip() {
        TextView chip = findViewById(R.id.statusChip);
        if (chip == null) return;
        String deviceName = activeController != null
                ? activeController.device().displayName()
                : "No device selected";
        String ip = getLocalIpAddress();
        chip.setText("UDP " + QZCommandListenerService.LISTEN_PORT + "  ·  " + deviceName + "  ·  " + ip);
    }

    private String getLocalIpAddress() {
        try {
            for (NetworkInterface ni :
                    java.util.Collections.list(NetworkInterface.getNetworkInterfaces())) {
                if (!ni.isUp() || ni.isLoopback()) continue;
                for (java.net.InetAddress addr :
                        java.util.Collections.list(ni.getInetAddresses())) {
                    if (!addr.isLoopbackAddress() && addr instanceof Inet4Address)
                        return addr.getHostAddress();
                }
            }
        } catch (Exception ignored) {}
        return "no IP";
    }

    /** Selects {@code device} as the active device and wires it to both services. */
    private void selectDevice(Device device) {
        Log.i("QZ:Main", "device selected: " + device.displayName());
        device.logger = (level, tag, msg) -> Log.println(level, tag, msg);
        if (activeController != null) activeController.shutdown();
        activeController = new DeviceController(device);
        QZCommandListenerService.setSubscriber(activeController);
        QZMetricUnicastingService.setSubscriber(activeController);
        updateStatusChip();
        updateRequirementsCard();
    }

}
