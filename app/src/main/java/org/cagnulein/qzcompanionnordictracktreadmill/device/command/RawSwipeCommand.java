package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.gesture.GestureService;

public final class RawSwipeCommand extends Command {
    private final float x;
    private final float fromY;
    private final float toY;

    public RawSwipeCommand(float x, float fromY, float toY) {
        this.x = x;
        this.fromY = fromY;
        this.toY = toY;
    }

    @Override
    public void applyTo(Device device) {
        String cmd = "input swipe " + format(x) + " " + format(fromY) + " "
                + format(x) + " " + format(toY) + " " + GestureService.SWIPE_DURATION_MS;
        device.logger.log(Device.Logger.INFO, "QZ:Dispatch",
                "CALSWIPE x=" + format(x) + " " + format(fromY) + "->" + format(toY));
        device.logger.log(Device.Logger.DEBUG, "QZ:Dispatch", "raw swipe -> " + cmd);
        if (GestureService.isConnected()) {
            GestureService.performSwipe(x, fromY, x, toY, GestureService.SWIPE_DURATION_MS);
        } else {
            device.logger.log(Device.Logger.ERROR, "QZ:Dispatch",
                    "raw swipe dropped: AccessibilityService not connected");
        }
        device.commandExecutor.send(cmd);
    }

    @Override
    public String toString() {
        return "rawSwipe(" + format(x) + "," + format(fromY) + "->" + format(toY) + ")";
    }

    private static String format(float value) {
        if (value == Math.rint(value)) return Integer.toString((int) value);
        return Float.toString(value);
    }
}
