package org.cagnulein.qzcompanionnordictracktreadmill;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import android.app.Service;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.media.projection.MediaProjectionManager;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.os.IBinder;
import android.os.PowerManager;
import android.provider.Settings;
import android.text.TextUtils;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import android.content.DialogInterface;

import java.net.Inet4Address;
import java.net.NetworkInterface;

import android.content.pm.PackageManager;
import android.graphics.Typeface;
import android.util.TypedValue;
import android.widget.LinearLayout;

import java.sql.Timestamp;
import java.util.Date;
import java.util.Timer;
import java.util.TimerTask;
import java.util.logging.Logger;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;


import static android.content.ContentValues.TAG;

import static org.cagnulein.qzcompanionnordictracktreadmill.MediaProjection.REQUEST_CODE;

import org.cagnulein.qzcompanionnordictracktreadmill.service.CommandListenerService;
import org.cagnulein.qzcompanionnordictracktreadmill.service.MetricReaderBroadcastingService;
import org.cagnulein.qzcompanionnordictracktreadmill.service.MyAccessibilityService;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.CalibrationResult;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceRegistry;

import com.cgutman.androidremotedebugger.AdbUtils;
import com.cgutman.androidremotedebugger.console.ConsoleBuffer;
import com.cgutman.androidremotedebugger.devconn.DeviceConnection;
import com.cgutman.androidremotedebugger.devconn.DeviceConnectionListener;
import com.cgutman.androidremotedebugger.service.ShellService;
import com.cgutman.adblib.AdbCrypto;

import androidx.appcompat.app.AlertDialog;

public class MainActivity extends AppCompatActivity  implements DeviceConnectionListener {
    private ShellService.ShellServiceBinder binder;
    private static DeviceConnection connection;
    private Intent service;
    private static final String LOG_TAG = "QZ:ADB";
    private static String lastCommand = "";
    private static boolean ADBConnected = false;
    private static final int MAX_LOG_LINES = 500;
    private static final java.util.ArrayDeque<String> appLogBuffer = new java.util.ArrayDeque<>();
    private static final long MAX_LOG_FILE_BYTES = 1024 * 1024;
    private static BufferedWriter logFileWriter = null;

	private final ShellRuntime shellRuntime = new ShellRuntime();

    private AndroidActivityResultReceiver resultReceiver;

    private DeviceAdapter deviceAdapter;
    SharedPreferences sharedPreferences;

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

    @Override
    public void notifyConnectionEstablished(DeviceConnection devConn) {
        ADBConnected = true;
        Log.i(LOG_TAG, "notifyConnectionEstablished" + lastCommand);
        runOnUiThread(this::updateRequirementsCard);
    }

    @Override
    public void notifyConnectionFailed(DeviceConnection devConn, Exception e) {
        ADBConnected = false;
        Log.e(LOG_TAG, "notifyConnectionFailed: " + e.getMessage() + " — scheduling reconnect");
        scheduleReconnect();
        runOnUiThread(this::updateRequirementsCard);
    }

    @Override
    public void notifyStreamFailed(DeviceConnection devConn, Exception e) {
        ADBConnected = false;
        Log.e(LOG_TAG, "notifyStreamFailed: " + e.getMessage() + " — scheduling reconnect");
        scheduleReconnect();
        runOnUiThread(this::updateRequirementsCard);
    }

    @Override
    public void notifyStreamClosed(DeviceConnection devConn) {
        ADBConnected = false;
        Log.e(LOG_TAG, "notifyStreamClosed — scheduling reconnect");
        scheduleReconnect();
        runOnUiThread(this::updateRequirementsCard);
    }

    private void scheduleReconnect() {
        new android.os.Handler(android.os.Looper.getMainLooper()).postDelayed(() -> {
            if (Device.instance == null || !Device.instance.requiresAdb()) return;
            Log.i(LOG_TAG, "Attempting ADB reconnect to 127.0.0.1:5555");
            if (binder != null) {
                connection = startConnection("127.0.0.1", 5555);
            } else {
                Log.e(LOG_TAG, "scheduleReconnect: binder is null, cannot reconnect");
            }
        }, 3000);
    }

    @Override
    public AdbCrypto loadAdbCrypto(DeviceConnection devConn) {
        return AdbUtils.readCryptoConfig(getFilesDir());
    }

    @Override
    public boolean canReceiveData() {
        return true;
    }

    @Override
    public void receivedData(DeviceConnection devConn, byte[] data, int offset, int length) {
        Log.i(LOG_TAG, data.toString());
    }

    @Override
    public boolean isConsole() {
        return false;
    }

    @Override
    public void consoleUpdated(DeviceConnection devConn, ConsoleBuffer console) {

    }


    private DeviceConnection startConnection(String host, int port) {
        /* Create the connection object */
        DeviceConnection conn = binder.createConnection(host, port);

        /* Add this activity as a connection listener */
        binder.addListener(conn, this);

        /* Begin the async connection process */
        conn.startConnect();

        return conn;
    }

    private DeviceConnection connectOrLookupConnection(String host, int port) {
        DeviceConnection conn = binder.findConnection(host, port);
        if (conn == null) {
            /* No existing connection, so start the connection process */
            conn = startConnection(host, port);
        }
        else {
            /* Add ourselves as a new listener of this connection */
            binder.addListener(conn, this);
        }
        return conn;
    }

    private ServiceConnection serviceConn = new ServiceConnection() {
        @Override
        public void onServiceConnected(ComponentName arg0, IBinder arg1) {
            binder = (ShellService.ShellServiceBinder)arg1;
            if (connection != null) {
                binder.removeListener(connection, MainActivity.this);
            }
            connection = connectOrLookupConnection("127.0.0.1", 5555);
        }

        @Override
        public void onServiceDisconnected(ComponentName arg0) {
            binder = null;
        }
    };

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
            Log.e(LOG_TAG, "Failed to open log file: " + e.getMessage());
        }
    }

    public static void writeLog(String command) {
        String line = new Timestamp(new Date().getTime()) + " " + command;
        synchronized (appLogBuffer) {
            if (appLogBuffer.size() >= MAX_LOG_LINES) appLogBuffer.removeFirst();
            appLogBuffer.addLast(line);
            if (logFileWriter != null) {
                try {
                    logFileWriter.write(line);
                    logFileWriter.newLine();
                    logFileWriter.flush();
                } catch (IOException ignored) {}
            }
        }
    }

    public void startOCR() {
        final int REQUEST_CODE = 100;
        MediaProjectionManager mediaProjectionManager =
                (MediaProjectionManager) getSystemService(Context.MEDIA_PROJECTION_SERVICE);

        Intent intent = mediaProjectionManager.createScreenCaptureIntent();
        startActivityForResult(intent, REQUEST_CODE);
    }

    private static final int CALIBRATION_REQUEST_CODE = 200;

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == REQUEST_CODE) {
            resultReceiver.handleActivityResult(requestCode, resultCode, data);
        } else if (requestCode == CALIBRATION_REQUEST_CODE && resultCode == RESULT_OK && data != null) {
            String deviceId = data.getStringExtra("deviceId");
            if (deviceId != null) {
                try {
                    DeviceRegistry.DeviceId id = DeviceRegistry.DeviceId.valueOf(deviceId);
                    selectDevice(DeviceRegistry.forId(id));
                    deviceAdapter.setSelectedId(id);
                } catch (IllegalArgumentException ignored) {}
            }
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        resultReceiver = new AndroidActivityResultReceiver(this);
        checkPermissions();
        Thread.setDefaultUncaughtExceptionHandler(new MyExceptionHandler(this));

        sharedPreferences = getSharedPreferences("QZ",MODE_PRIVATE);
        CalibrationResult.current = CalibrationResult.load(sharedPreferences);
        initLogFile();

        if (getSupportActionBar() != null) {
            String buildId = BuildConfig.IS_CI_BUILD
                    ? "build " + BuildConfig.VERSION_CODE
                    : "dev-" + BuildConfig.GIT_HASH;
            getSupportActionBar().setSubtitle("v" + BuildConfig.VERSION_NAME + "  ·  " + buildId);
        }

        RecyclerView deviceList = findViewById(R.id.deviceList);
        deviceList.setLayoutManager(new LinearLayoutManager(this));
        deviceAdapter = new DeviceAdapter(id -> {
            if (id == DeviceRegistry.DeviceId.x22i_noadb
                    || id == DeviceRegistry.DeviceId.s22i_noadb
                    || id == DeviceRegistry.DeviceId.t95s) {
                if (!isAccessibilityServiceEnabled(getApplicationContext(), MyAccessibilityService.class)) {
                    startActivity(new Intent(Settings.ACTION_ACCESSIBILITY_SETTINGS));
                }
            }
            selectDevice(DeviceRegistry.forId(id));
            SharedPreferences.Editor myEdit = sharedPreferences.edit();
            myEdit.putString("deviceId", id.name());
            myEdit.commit();
        });
        deviceList.setAdapter(deviceAdapter);

        findViewById(R.id.btnCalibrate).setOnClickListener(v ->
                startActivityForResult(
                        new Intent(this, CalibrationActivity.class),
                        CALIBRATION_REQUEST_CODE));

        String savedId = sharedPreferences.getString("deviceId", DeviceRegistry.DeviceId.other.name());
        try {
            DeviceRegistry.DeviceId id = DeviceRegistry.DeviceId.valueOf(savedId);
            deviceAdapter.setSelectedId(id);
            selectDevice(DeviceRegistry.forId(id));
        } catch (IllegalArgumentException ignored) {}

        updateStatusChip();


        AlarmReceiver alarm = new AlarmReceiver();
        //alarm.setAlarm(this); // TODO RESTORE THIS IF POSSIBLE
        Intent inServer = new Intent(getApplicationContext(), CommandListenerService.class);
        getApplicationContext().startService(inServer);
        Intent in = new Intent(getApplicationContext(), MetricReaderBroadcastingService.class);
        getApplicationContext().startService(in);


        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M
                && Device.instance != null && Device.instance.requiresAdb()) {
            /* If we have old RSA keys, just use them */
            AdbCrypto crypto = AdbUtils.readCryptoConfig(getFilesDir());
            if (crypto == null) {
                /* We need to make a new pair */
                Log.i(LOG_TAG,
                        "This will only be done once.");

                new Thread(new Runnable() {
                    @Override
                    public void run() {
                        AdbCrypto crypto;

                        crypto = AdbUtils.writeNewCryptoConfig(getFilesDir());

                        if (crypto == null) {
                            Log.e(LOG_TAG,
                                    "Unable to generate and save RSA key pair");
                            return;
                        }

                    }
                }).start();
            }

            if (binder == null && Device.instance != null && Device.instance.requiresAdb()) {
                service = new Intent(this, ShellService.class);

                /* Bind the service if we're not bound already. After binding, the callback will
                 * perform the initial connection. */
                Log.i(LOG_TAG, "Binding ShellService for ADB loopback...");
                getApplicationContext().bindService(service, serviceConn, Service.BIND_AUTO_CREATE);

                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    startForegroundService(service);
                } else {
                    startService(service);
                }
            }
        }

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

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main_menu, menu);
        menu.findItem(R.id.menu_verbose_logging).setChecked(
                sharedPreferences.getBoolean("debugLog", false));
        menu.findItem(R.id.menu_live_logcat).setChecked(
                sharedPreferences.getBoolean("ADBLog", false));
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();
        if (id == R.id.menu_verbose_logging) {
            boolean next = !item.isChecked();
            item.setChecked(next);
            sharedPreferences.edit().putBoolean("debugLog", next).apply();
            new androidx.appcompat.app.AlertDialog.Builder(this)
                    .setTitle("Settings Saved")
                    .setMessage("Restart the app to apply logging changes.")
                    .setPositiveButton("OK", (d, w) -> d.dismiss())
                    .show();
            return true;
        } else if (id == R.id.menu_live_logcat) {
            boolean next = !item.isChecked();
            item.setChecked(next);
            sharedPreferences.edit().putBoolean("ADBLog", next).apply();
            new androidx.appcompat.app.AlertDialog.Builder(this)
                    .setTitle("Settings Saved")
                    .setMessage("Restart the app to apply logging changes.")
                    .setPositiveButton("OK", (d, w) -> d.dismiss())
                    .show();
            return true;
        } else if (id == R.id.menu_dump_log) {
            String command = "logcat -b all -d > /sdcard/logcat.log";
            MainActivity.sendCommand(command);
            Log.i(LOG_TAG, command);
            new androidx.appcompat.app.AlertDialog.Builder(this)
                    .setTitle("Log Dumped")
                    .setMessage("Logcat saved to /sdcard/logcat.log")
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
        if (list == null || Device.instance == null) return;
        list.removeAllViews();

        Device device = Device.instance;

        if (device.requiresAccessibility()) {
            boolean ok = isAccessibilityServiceEnabled(this, MyAccessibilityService.class);
            addRequirementRow(list, ok,
                    "Accessibility service",
                    ok ? "Enabled" : "Not enabled — tap to open Settings",
                    ok ? null : v -> startActivity(new Intent(Settings.ACTION_ACCESSIBILITY_SETTINGS)));

        } else if (device.requiresAdb()) {
            addRequirementRow(list, ADBConnected,
                    "ADB loopback",
                    ADBConnected ? "Connected" : "Not connected — enable wireless ADB on this device",
                    null);

        } else {
            boolean hasInject = checkSelfPermission("android.permission.INJECT_EVENTS")
                    == PackageManager.PERMISSION_GRANTED;
            addRequirementRow(list, hasInject,
                    "Input injection",
                    hasInject ? "Granted" : "Not granted — run via ADB:\n"
                            + "adb shell pm grant " + getPackageName()
                            + " android.permission.INJECT_EVENTS",
                    null);
        }

        long lastHb = CommandListenerService.lastQzHeartbeatMs;
        boolean heartbeatActive = lastHb > 0
                && (System.currentTimeMillis() - lastHb) < 30_000;
        addRequirementRow(list, heartbeatActive,
                "QZ App",
                heartbeatActive ? "Broadcasting command heartbeat" : "No heartbeat received yet",
                null);
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
        String deviceName = Device.instance != null
                ? Device.instance.displayName()
                : "No device selected";
        String ip = getLocalIpAddress();
        chip.setText("UDP 8003  ·  " + deviceName + "  ·  " + ip);
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

    /** Selects {@code device} as the active device and wires up its executor and logger. */
    private void selectDevice(Device device) {
        device.commandExecutor = MainActivity::sendCommand;
        device.logger = (tag, msg) -> Log.i(tag, msg);
        Device.instance = device;
        MetricReaderBroadcastingService.applyDevice(device);
        updateStatusChip();
        updateRequirementsCard();
    }

    static public void sendCommand(String command) {
        if(ADBConnected) {
            Log.d(LOG_TAG, "sendCommand [ADB UP]: " + command);
            StringBuilder commandBuffer = new StringBuilder();

            commandBuffer.append(command);

            /* Append a newline since it's not included in the command itself */
            commandBuffer.append('\n');

            /* Send it to the device */
            connection.queueCommand(commandBuffer.toString());
        } else {
            Log.e(LOG_TAG, "sendCommand [ADB DOWN]: " + command);
        }
    }

}