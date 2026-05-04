package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.device.command.CalibrationSwipeCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.CommandDispatcher;
import org.cagnulein.qzcompanionnordictracktreadmill.device.gesture.GestureService;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandSubscriber;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZCommandPacket;
import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricSubscriber;
import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;

import java.util.List;

public class DeviceController implements QZMetricSubscriber, QZCommandSubscriber {

    private final Device device;
    private final CommandDispatcher dispatcher;

    public DeviceController(Device device) {
        this.device     = device;
        this.dispatcher = new CommandDispatcher(this::executeCommand);
    }

    /** Test constructor: injectable clock, no background drain thread. */
    public DeviceController(Device device, CommandDispatcher.Clock clock) {
        this.device     = device;
        this.dispatcher = new CommandDispatcher(this::executeCommand, clock);
    }

    private void executeCommand(Command cmd) {
        device.logger.log("QZ:Dispatcher", "drain: " + cmd);
        device.applyCommand(cmd);
    }

    @Override
    public void onMetric(SliderMetric metric, float value) {
        device.applyMetric(metric, value);
    }

    @Override
    public void onPacket(QZCommandPacket packet) {
        List<Command> commands = device.decodeCommands(packet);
        for (Command cmd : commands) {
            int depth = dispatcher.enqueue(cmd);
            if (depth >= 0)
                device.logger.log("QZ:Dispatcher",
                        "enqueue: " + cmd + " depth=" + depth + "/" + CommandDispatcher.QUEUE_CAPACITY);
            else
                device.logger.log("QZ:Dispatcher",
                        "drop: " + cmd + " (queue full at " + CommandDispatcher.QUEUE_CAPACITY + ")");
        }
        // Sentinel packets (empty command list) still act as passive drain drivers.
        if (commands.isEmpty()) dispatcher.drain();
    }

    @Override
    public void onCalibrationSwipe(CalibrationSwipeCommand cmd) {
        if (GestureService.isConnected())
            GestureService.performSwipe(cmd.x, cmd.fromY, cmd.x, cmd.toY, Device.SWIPE_DURATION_MS);
    }

    public void shutdown() { dispatcher.shutdown(); }

    public Device device() { return device; }
}
