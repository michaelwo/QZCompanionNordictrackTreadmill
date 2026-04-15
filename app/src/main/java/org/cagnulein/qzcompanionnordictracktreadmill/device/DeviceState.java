package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

/**
 * Shared runtime state for the two companion services.
 *
 * QZService writes lastSnapshot after each parse/OCR cycle.
 * UDPListenerService writes currentDevice when the user selects a device,
 * and reads lastSnapshot to compute swipe origins.
 *
 * Neither service references the other directly — both reference this class.
 */
public class DeviceState {
    public static final DeviceState INSTANCE = new DeviceState();

    /** Latest observed metrics from the fitness device. Written by QZService. */
    public MetricSnapshot lastSnapshot = new MetricSnapshot();

    /** The active Device instance, derived from selectedDeviceId. */
    public Device currentDevice;

    /** Which device the user has selected. */
    public DeviceRegistry.DeviceId selectedDeviceId;

    /** Select a device by id, updating both fields atomically. */
    public void selectDevice(DeviceRegistry.DeviceId id) {
        selectedDeviceId = id;
        currentDevice = DeviceRegistry.forId(id);
        Device.logger.log("QZ:DeviceState", "Device selected: " + (currentDevice != null ? currentDevice.displayName() : String.valueOf(id)));
    }
}
