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
import android.text.method.ScrollingMovementMethod;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.TextView;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import android.content.DialogInterface;

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
    }

    @Override
    public void notifyConnectionFailed(DeviceConnection devConn, Exception e) {
        ADBConnected = false;
        Log.e(LOG_TAG, "notifyConnectionFailed: " + e.getMessage() + " — scheduling reconnect");
        scheduleReconnect();
    }

    @Override
    public void notifyStreamFailed(DeviceConnection devConn, Exception e) {
        ADBConnected = false;
        Log.e(LOG_TAG, "notifyStreamFailed: " + e.getMessage() + " — scheduling reconnect");
        scheduleReconnect();
    }

    @Override
    public void notifyStreamClosed(DeviceConnection devConn) {
        ADBConnected = false;
        Log.e(LOG_TAG, "notifyStreamClosed — scheduling reconnect");
        scheduleReconnect();
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

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == REQUEST_CODE) {
            resultReceiver.handleActivityResult(requestCode, resultCode, data);
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
        initLogFile();

        TextView versionLabel = findViewById(R.id.versionLabel);
        versionLabel.setText("v" + BuildConfig.VERSION_NAME + "  (build " + BuildConfig.VERSION_CODE + ")");

        CheckBox debugLog = findViewById(R.id.debuglog);
        CheckBox OCR = findViewById(R.id.checkOCR);
        CheckBox ADBLog = findViewById(R.id.checkADBLog);

        debugLog.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                SharedPreferences.Editor myEdit = sharedPreferences.edit();
                myEdit.putBoolean("debugLog", debugLog.isChecked());
                myEdit.commit();

                new AlertDialog.Builder(view.getContext())
                        .setTitle("Settings Saved")
                        .setMessage("Please restart the device to apply the new settings")
                        .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                dialog.dismiss();
                            }
                        })
                        .show();
            }
        });

        OCR.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                SharedPreferences.Editor myEdit = sharedPreferences.edit();
                myEdit.putBoolean("OCR", OCR.isChecked());
                myEdit.commit();

                new AlertDialog.Builder(view.getContext())
                        .setTitle("Settings Saved")
                        .setMessage("Please restart the device to apply the new settings")
                        .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                dialog.dismiss();
                            }
                        })
                        .show();
            }
        });

        ADBLog.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                SharedPreferences.Editor myEdit = sharedPreferences.edit();
                myEdit.putBoolean("ADBLog", ADBLog.isChecked());
                myEdit.commit();

                new AlertDialog.Builder(view.getContext())
                        .setTitle("Settings Saved")
                        .setMessage("Please restart the device to apply the new settings")
                        .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                dialog.dismiss();
                            }
                        })
                        .show();
            }
        });

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

        debugLog.setChecked(sharedPreferences.getBoolean("debugLog", false));
        OCR.setChecked(sharedPreferences.getBoolean("OCR", false));
        ADBLog.setChecked(sharedPreferences.getBoolean("ADBLog", false));

        String savedId = sharedPreferences.getString("deviceId", DeviceRegistry.DeviceId.other.name());
        try {
            DeviceRegistry.DeviceId id = DeviceRegistry.DeviceId.valueOf(savedId);
            deviceAdapter.setSelectedId(id);
            selectDevice(DeviceRegistry.forId(id));
        } catch (IllegalArgumentException ignored) {}

        Button dumplog = findViewById(R.id.dumplog);
        dumplog.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // test
                DeviceRegistry.DeviceId selectedId = deviceAdapter.getSelectedId();
                if (selectedId == DeviceRegistry.DeviceId.x22i_noadb || selectedId == DeviceRegistry.DeviceId.t95s)
                    MyAccessibilityService.performSwipe(600, 600, 300, 400, 100);


                TextView tv = (TextView)findViewById(R.id.dumplog_tv);
                synchronized (appLogBuffer) {
                    tv.setText(android.text.TextUtils.join("\n", appLogBuffer));
                }

                String command = "logcat -b all -d > /sdcard/logcat.log";
                MainActivity.sendCommand(command);
                Log.i(LOG_TAG, command);
            }
        });


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

        if(sharedPreferences.getBoolean("OCR", false))
            startOCR();
        else {
            if (savedInstanceState == null) {
                moveTaskToBack(true);
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

    /** Selects {@code device} as the active device and wires up its executor and logger. */
    private void selectDevice(Device device) {
        device.commandExecutor = MainActivity::sendCommand;
        device.logger = (tag, msg) -> Log.i(tag, msg);
        Device.instance = device;
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