package org.cagnulein.qzcompanionnordictracktreadmill;

import android.app.Service;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothGatt;
import android.bluetooth.BluetoothGattCharacteristic;
import android.bluetooth.BluetoothGattDescriptor;
import android.bluetooth.BluetoothGattServer;
import android.bluetooth.BluetoothGattServerCallback;
import android.bluetooth.BluetoothGattService;
import android.bluetooth.BluetoothManager;
import android.bluetooth.BluetoothProfile;
import android.bluetooth.le.AdvertiseCallback;
import android.bluetooth.le.AdvertiseData;
import android.bluetooth.le.AdvertiseSettings;
import android.bluetooth.le.BluetoothLeAdvertiser;
import android.content.Intent;
import android.os.IBinder;
import android.os.ParcelUuid;
import android.util.Log;

import java.util.UUID;

/**
 * BLE FTMS canary service — proves that:
 *   1. The iFit tablet supports BLE peripheral (advertising) mode
 *   2. Zwift can discover, connect to, and send commands to this device
 *
 * This service does NOT control the bike. It logs every Zwift interaction to
 * logcat under the tag "QZ:BLE" and responds to the FTMS handshake correctly.
 * Once Zwift successfully sends "Set Inclination" commands and you see them in
 * logcat, the BLE channel is proven and wiring to CommandDispatcher is the
 * only remaining step.
 *
 * Monitor with:
 *   adb logcat -s QZ:BLE
 *
 * FTMS reference: Bluetooth SIG "Fitness Machine Service" spec v1.0
 */
public class BleCanaryService extends Service {

    private static final String LOG_TAG = "QZ:BLE";

    // ── FTMS UUIDs (Bluetooth SIG assigned) ──────────────────────────────────
    private static final UUID FTMS_SERVICE_UUID =
            UUID.fromString("00001826-0000-1000-8000-00805f9b34fb");
    private static final UUID FITNESS_MACHINE_FEATURE_UUID =
            UUID.fromString("00002acc-0000-1000-8000-00805f9b34fb");
    private static final UUID INDOOR_BIKE_DATA_UUID =
            UUID.fromString("00002ad2-0000-1000-8000-00805f9b34fb");
    private static final UUID FITNESS_MACHINE_CONTROL_POINT_UUID =
            UUID.fromString("00002ad9-0000-1000-8000-00805f9b34fb");
    private static final UUID FITNESS_MACHINE_STATUS_UUID =
            UUID.fromString("00002ada-0000-1000-8000-00805f9b34fb");

    // Client Characteristic Configuration Descriptor — required for notify/indicate
    private static final UUID CCCD_UUID =
            UUID.fromString("00002902-0000-1000-8000-00805f9b34fb");

    // ── State ─────────────────────────────────────────────────────────────────
    private BluetoothManager    bluetoothManager;
    private BluetoothAdapter    bluetoothAdapter;
    private BluetoothLeAdvertiser advertiser;
    private BluetoothGattServer  gattServer;

    /** The single connected central device (Zwift). Null when nobody is connected. */
    private BluetoothDevice connectedDevice = null;

    private BluetoothGattCharacteristic controlPointChar;
    private BluetoothGattCharacteristic indoorBikeDataChar;

    // ── Service lifecycle ─────────────────────────────────────────────────────

    @Override
    public void onCreate() {
        super.onCreate();
        bluetoothManager = (BluetoothManager) getSystemService(BLUETOOTH_SERVICE);
        if (bluetoothManager == null) {
            Log.e(LOG_TAG, "BluetoothManager unavailable — BLE not supported on this device");
            stopSelf();
            return;
        }
        bluetoothAdapter = bluetoothManager.getAdapter();
        if (bluetoothAdapter == null || !bluetoothAdapter.isEnabled()) {
            Log.e(LOG_TAG, "Bluetooth is disabled — enable Bluetooth and restart the canary");
            stopSelf();
            return;
        }

        // ── Capability check ──────────────────────────────────────────────────
        if (!bluetoothAdapter.isMultipleAdvertisementSupported()) {
            Log.e(LOG_TAG, "BLE peripheral advertising NOT supported on this hardware — "
                + "FTMS approach is not feasible on this device");
            stopSelf();
            return;
        }
        Log.i(LOG_TAG, "BLE peripheral advertising supported — proceeding");

        openGattServer();
        startAdvertising();
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        return START_STICKY;
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onDestroy() {
        stopAdvertising();
        if (gattServer != null) {
            gattServer.close();
            gattServer = null;
        }
        Log.i(LOG_TAG, "BLE canary stopped");
        super.onDestroy();
    }

    // ── GATT server setup ─────────────────────────────────────────────────────

    private void openGattServer() {
        gattServer = bluetoothManager.openGattServer(this, gattServerCallback);
        if (gattServer == null) {
            Log.e(LOG_TAG, "openGattServer() returned null — check BLUETOOTH_CONNECT permission");
            stopSelf();
            return;
        }

        BluetoothGattService service = new BluetoothGattService(
                FTMS_SERVICE_UUID, BluetoothGattService.SERVICE_TYPE_PRIMARY);

        // 1. Fitness Machine Feature — READ, returns capability flags
        BluetoothGattCharacteristic featureChar = new BluetoothGattCharacteristic(
                FITNESS_MACHINE_FEATURE_UUID,
                BluetoothGattCharacteristic.PROPERTY_READ,
                BluetoothGattCharacteristic.PERMISSION_READ);
        featureChar.setValue(FtmsPacket.FEATURE_FLAGS);
        service.addCharacteristic(featureChar);

        // 2. Indoor Bike Data — NOTIFY (we push speed/cadence/power to Zwift)
        indoorBikeDataChar = new BluetoothGattCharacteristic(
                INDOOR_BIKE_DATA_UUID,
                BluetoothGattCharacteristic.PROPERTY_NOTIFY,
                0 /* no read/write permission — notify only */);
        indoorBikeDataChar.addDescriptor(cccd());
        service.addCharacteristic(indoorBikeDataChar);

        // 3. Fitness Machine Control Point — WRITE + INDICATE (Zwift sends commands here)
        controlPointChar = new BluetoothGattCharacteristic(
                FITNESS_MACHINE_CONTROL_POINT_UUID,
                BluetoothGattCharacteristic.PROPERTY_WRITE
                    | BluetoothGattCharacteristic.PROPERTY_INDICATE,
                BluetoothGattCharacteristic.PERMISSION_WRITE);
        controlPointChar.addDescriptor(cccd());
        service.addCharacteristic(controlPointChar);

        // 4. Fitness Machine Status — NOTIFY (we notify Zwift of state changes)
        BluetoothGattCharacteristic statusChar = new BluetoothGattCharacteristic(
                FITNESS_MACHINE_STATUS_UUID,
                BluetoothGattCharacteristic.PROPERTY_NOTIFY,
                0);
        statusChar.addDescriptor(cccd());
        service.addCharacteristic(statusChar);

        gattServer.addService(service);
        Log.i(LOG_TAG, "GATT server opened with FTMS service");
    }

    private static BluetoothGattDescriptor cccd() {
        BluetoothGattDescriptor d = new BluetoothGattDescriptor(
                CCCD_UUID,
                BluetoothGattDescriptor.PERMISSION_READ | BluetoothGattDescriptor.PERMISSION_WRITE);
        d.setValue(BluetoothGattDescriptor.DISABLE_NOTIFICATION_VALUE);
        return d;
    }

    // ── Advertising ───────────────────────────────────────────────────────────

    private void startAdvertising() {
        advertiser = bluetoothAdapter.getBluetoothLeAdvertiser();
        if (advertiser == null) {
            Log.e(LOG_TAG, "BluetoothLeAdvertiser unavailable — cannot advertise");
            stopSelf();
            return;
        }

        AdvertiseSettings settings = new AdvertiseSettings.Builder()
                .setAdvertiseMode(AdvertiseSettings.ADVERTISE_MODE_LOW_LATENCY)
                .setTxPowerLevel(AdvertiseSettings.ADVERTISE_TX_POWER_HIGH)
                .setConnectable(true)
                .setTimeout(0) // advertise indefinitely
                .build();

        AdvertiseData data = new AdvertiseData.Builder()
                .setIncludeDeviceName(true)
                .addServiceUuid(new ParcelUuid(FTMS_SERVICE_UUID))
                .build();

        advertiser.startAdvertising(settings, data, advertiseCallback);
    }

    private void stopAdvertising() {
        if (advertiser != null) {
            advertiser.stopAdvertising(advertiseCallback);
        }
    }

    private final AdvertiseCallback advertiseCallback = new AdvertiseCallback() {
        @Override
        public void onStartSuccess(AdvertiseSettings settingsInEffect) {
            Log.i(LOG_TAG, "BLE advertising started — look for this device in Zwift's "
                + "pairing screen under 'Controllable'");
        }
        @Override
        public void onStartFailure(int errorCode) {
            Log.e(LOG_TAG, "BLE advertising failed, errorCode=" + errorCode
                + advertiseErrorString(errorCode));
        }
    };

    // ── GATT server callbacks ─────────────────────────────────────────────────

    private final BluetoothGattServerCallback gattServerCallback =
            new BluetoothGattServerCallback() {

        @Override
        public void onConnectionStateChange(BluetoothDevice device, int status, int newState) {
            if (newState == BluetoothProfile.STATE_CONNECTED) {
                connectedDevice = device;
                Log.i(LOG_TAG, "Zwift connected: " + device.getAddress());
            } else if (newState == BluetoothProfile.STATE_DISCONNECTED) {
                connectedDevice = null;
                Log.i(LOG_TAG, "Zwift disconnected: " + device.getAddress());
            }
        }

        @Override
        public void onCharacteristicReadRequest(BluetoothDevice device, int requestId,
                int offset, BluetoothGattCharacteristic characteristic) {
            if (FITNESS_MACHINE_FEATURE_UUID.equals(characteristic.getUuid())) {
                Log.d(LOG_TAG, "Zwift read Fitness Machine Feature (capability handshake)");
                gattServer.sendResponse(device, requestId, BluetoothGatt.GATT_SUCCESS,
                        offset, FtmsPacket.FEATURE_FLAGS);
            } else {
                gattServer.sendResponse(device, requestId, BluetoothGatt.GATT_SUCCESS,
                        offset, characteristic.getValue());
            }
        }

        @Override
        public void onCharacteristicWriteRequest(BluetoothDevice device, int requestId,
                BluetoothGattCharacteristic characteristic, boolean preparedWrite,
                boolean responseNeeded, int offset, byte[] value) {

            if (!FITNESS_MACHINE_CONTROL_POINT_UUID.equals(characteristic.getUuid())) {
                if (responseNeeded) {
                    gattServer.sendResponse(device, requestId,
                            BluetoothGatt.GATT_SUCCESS, 0, null);
                }
                return;
            }

            // Always ACK writes to the control point
            if (responseNeeded) {
                gattServer.sendResponse(device, requestId, BluetoothGatt.GATT_SUCCESS, 0, null);
            }

            handleControlPoint(device, value);
        }

        @Override
        public void onDescriptorWriteRequest(BluetoothDevice device, int requestId,
                BluetoothGattDescriptor descriptor, boolean preparedWrite,
                boolean responseNeeded, int offset, byte[] value) {
            // Accept all CCCD writes (enable/disable notify or indicate)
            Log.d(LOG_TAG, "CCCD write on " + descriptor.getCharacteristic().getUuid()
                + " value=" + (value.length > 0 ? value[0] : "?"));
            if (responseNeeded) {
                gattServer.sendResponse(device, requestId, BluetoothGatt.GATT_SUCCESS, 0, null);
            }
        }
    };

    // ── Control point handling ────────────────────────────────────────────────

    private void handleControlPoint(BluetoothDevice device, byte[] value) {
        FtmsPacket.Command cmd = FtmsPacket.parseControlPoint(value);
        if (cmd == null) {
            Log.w(LOG_TAG, "Received unparseable control point write");
            return;
        }

        Log.i(LOG_TAG, "Control point: " + cmd);

        byte[] response;
        switch (cmd.opCode) {
            case FtmsPacket.OP_REQUEST_CONTROL:
                Log.i(LOG_TAG, "Zwift requested control — granting");
                response = FtmsPacket.response(FtmsPacket.OP_REQUEST_CONTROL,
                        FtmsPacket.RESULT_SUCCESS);
                break;

            case FtmsPacket.OP_RESET:
                Log.i(LOG_TAG, "Zwift sent Reset");
                response = FtmsPacket.response(FtmsPacket.OP_RESET, FtmsPacket.RESULT_SUCCESS);
                break;

            case FtmsPacket.OP_START_RESUME:
                Log.i(LOG_TAG, "Zwift started/resumed workout");
                response = FtmsPacket.response(FtmsPacket.OP_START_RESUME,
                        FtmsPacket.RESULT_SUCCESS);
                break;

            case FtmsPacket.OP_STOP_PAUSE:
                Log.i(LOG_TAG, "Zwift stopped/paused workout");
                response = FtmsPacket.response(FtmsPacket.OP_STOP_PAUSE,
                        FtmsPacket.RESULT_SUCCESS);
                break;

            case FtmsPacket.OP_SET_INCLINATION:
                Log.i(LOG_TAG, "*** Set Inclination: " + cmd.inclinePct + "% ***"
                    + "  (canary — bike NOT moving yet)");
                // TODO: wire to CommandDispatcher here when ready to go live
                response = FtmsPacket.response(FtmsPacket.OP_SET_INCLINATION,
                        FtmsPacket.RESULT_SUCCESS);
                break;

            case FtmsPacket.OP_SET_RESISTANCE:
                Log.i(LOG_TAG, "Set Resistance: " + cmd.inclinePct);
                response = FtmsPacket.response(FtmsPacket.OP_SET_RESISTANCE,
                        FtmsPacket.RESULT_SUCCESS);
                break;

            default:
                Log.w(LOG_TAG, "Unsupported op-code 0x" + Integer.toHexString(cmd.opCode));
                response = FtmsPacket.response(cmd.opCode, FtmsPacket.RESULT_NOT_SUPPORTED);
                break;
        }

        indicate(device, response);
    }

    /**
     * Sends an INDICATE notification on the Control Point characteristic.
     * FTMS spec requires INDICATE (not NOTIFY) for control point responses
     * so Zwift knows the response was received.
     */
    private void indicate(BluetoothDevice device, byte[] value) {
        if (gattServer == null || device == null) return;
        controlPointChar.setValue(value);
        gattServer.notifyCharacteristicChanged(device, controlPointChar, true /* confirm = indicate */);
    }

    // ── Helpers ───────────────────────────────────────────────────────────────

    private static String advertiseErrorString(int code) {
        switch (code) {
            case AdvertiseCallback.ADVERTISE_FAILED_ALREADY_STARTED:
                return " (already started)";
            case AdvertiseCallback.ADVERTISE_FAILED_DATA_TOO_LARGE:
                return " (data too large — shorten device name)";
            case AdvertiseCallback.ADVERTISE_FAILED_FEATURE_UNSUPPORTED:
                return " (BLE advertising not supported on this hardware)";
            case AdvertiseCallback.ADVERTISE_FAILED_INTERNAL_ERROR:
                return " (internal error — try toggling Bluetooth)";
            case AdvertiseCallback.ADVERTISE_FAILED_TOO_MANY_ADVERTISERS:
                return " (too many concurrent advertisers — stop other BLE apps)";
            default:
                return "";
        }
    }
}
