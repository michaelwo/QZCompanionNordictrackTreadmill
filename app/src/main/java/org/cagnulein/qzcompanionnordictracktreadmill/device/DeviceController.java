package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.CommandDispatcher;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.SliderMetric;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandSubscriber;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricSubscriber;

import java.util.List;

public class DeviceController implements QZMetricSubscriber, QZCommandSubscriber {

    private static final String LOG_TAG = DeviceLogTags.DISPATCH;

    private final Device device;
    private final CalibrationDevice calibrationDevice;
    private final CommandDispatcher dispatcher;

    public DeviceController(Device device) {
        this.device     = device;
        this.calibrationDevice = new CalibrationDevice();
        this.calibrationDevice.logger = device.logger;
        this.dispatcher = new CommandDispatcher(this::executeCommand);
    }

    /** Test constructor: injectable clock, no background drain thread. */
    public DeviceController(Device device, CommandDispatcher.Clock clock) {
        this.device     = device;
        this.calibrationDevice = new CalibrationDevice();
        this.calibrationDevice.logger = device.logger;
        this.dispatcher = new CommandDispatcher(this::executeCommand, clock);
    }

    private void executeCommand(Command cmd) {
        device.logger.log(Device.Logger.DEBUG, LOG_TAG, "drain: " + cmd);
        device.applyCommand(cmd);
    }

    @Override
    public void onMetric(SliderMetric metric, float value) {
        device.applyMetric(metric, value);
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

    public void shutdown() { dispatcher.shutdown(); }

    public Device device() { return device; }
}
