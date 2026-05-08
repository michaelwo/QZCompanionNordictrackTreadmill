package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.command.CommandDispatcher;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.CalibrationDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.telemetry.Telemetry;
import org.cagnulein.qzcompanionnordictracktreadmill.telemetry.TelemetryHub;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandSubscriber;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;

import java.io.IOException;
import java.util.List;

public class DeviceController implements QZCommandSubscriber {

    private static final String LOG_TAG = DeviceLogTags.DISPATCH;

    private final Device device;
    private final CalibrationDevice calibrationDevice;
    private final CommandDispatcher dispatcher;
    private final TelemetryHub.Subscription telemetrySubscription;

    public DeviceController(Device device) {
        this.device            = device;
        this.calibrationDevice = new CalibrationDevice();
        this.calibrationDevice.logger = device.logger;
        this.dispatcher        = new CommandDispatcher(this::executeCommand);
        this.telemetrySubscription = subscribeTelemetry();
    }

    /** Test constructor: injectable clock, no background drain thread. */
    public DeviceController(Device device, CommandDispatcher.Clock clock) {
        this.device            = device;
        this.calibrationDevice = new CalibrationDevice();
        this.calibrationDevice.logger = device.logger;
        this.dispatcher        = new CommandDispatcher(this::executeCommand, clock);
        this.telemetrySubscription = null;
    }

    private void executeCommand(Command cmd) {
        device.logger.log(Device.Logger.DEBUG, LOG_TAG, "drain: " + cmd);
        device.applyCommand(cmd);
    }

    public void onTelemetry(Telemetry telemetry) {
        String label = device.telemetryLabel(telemetry);
        if (label != null) device.logger.log(Device.Logger.DEBUG, LOG_TAG, "telemetry: " + label);
        device.applyTelemetry(telemetry);
    }

    @Override
    public void onPacket(QZCommandPacket packet) {
        calibrationDevice.logger = device.logger;
        List<Command> commands = calibrationDevice.decodeCommands(packet);
        if (commands.isEmpty()) commands = device.decodeCommands(packet);
        for (Command cmd : commands) {
            int depth = dispatcher.enqueue(cmd);
            if (depth >= 0)
                device.logger.log(Device.Logger.DEBUG, LOG_TAG,
                        "enqueue: " + cmd + " depth=" + depth + "/" + CommandDispatcher.QUEUE_CAPACITY);
            else
                device.logger.log(Device.Logger.WARN, LOG_TAG,
                        "drop: " + cmd + " (queue full at " + CommandDispatcher.QUEUE_CAPACITY + ")");
        }
        // Sentinel packets (empty command list) still act as passive drain drivers.
        if (commands.isEmpty()) dispatcher.drain();
    }

    public void shutdown() {
        if (telemetrySubscription != null) telemetrySubscription.close();
        device.shutdown();
        dispatcher.shutdown();
    }

    public Device device() { return device; }

    private TelemetryHub.Subscription subscribeTelemetry() {
        try {
            return TelemetryHub.shared().subscribe(this::onTelemetry);
        } catch (IOException e) {
            device.logger.log(Device.Logger.ERROR, LOG_TAG,
                    "telemetry subscription failed: " + e.getMessage());
            return null;
        }
    }
}
