package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.command.CalibrationSwipeCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.command.CommandDispatcher;
import org.cagnulein.qzcompanionnordictracktreadmill.command.MyAccessibilityService;
import org.cagnulein.qzcompanionnordictracktreadmill.command.PacketSubscriber;
import org.cagnulein.qzcompanionnordictracktreadmill.command.QZCommandPacket;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSubscriber;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.SliderMetric;

import java.util.List;

public class DeviceController implements MetricSubscriber, PacketSubscriber {

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
        if (MyAccessibilityService.isConnected())
            MyAccessibilityService.performSwipe(cmd.x, cmd.fromY, cmd.x, cmd.toY, Device.SWIPE_DURATION_MS);
    }

    public void shutdown() { dispatcher.shutdown(); }

    public Device device() { return device; }
}
