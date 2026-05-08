package org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.control;

import org.cagnulein.qzcompanionnordictracktreadmill.console.ifit1.GestureService;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceLogTags;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.GearCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.InclineCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.RawSwipeCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.ResistanceCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.SnapToOriginCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.SpeedCommand;
import org.cagnulein.qzcompanionnordictracktreadmill.device.control.CommandHandler;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.slider.GearSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.slider.InclineSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.slider.ResistanceSlider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.ifit1.slider.SpeedSlider;

public final class IFit1CommandHandler implements CommandHandler {
    private static final String LOG_TAG = DeviceLogTags.DISPATCH;

    @Override
    public boolean apply(Command command, Device device) {
        if (command instanceof InclineCommand) {
            InclineSlider slider = device.sliderOf(InclineSlider.class);
            if (slider == null) return false;
            slider.handle(((InclineCommand) command).inclinePct, device);
            return true;
        }
        if (command instanceof ResistanceCommand) {
            ResistanceSlider slider = device.sliderOf(ResistanceSlider.class);
            if (slider == null) return false;
            slider.handle(((ResistanceCommand) command).resistanceLvl, device);
            return true;
        }
        if (command instanceof SpeedCommand) {
            SpeedSlider slider = device.sliderOf(SpeedSlider.class);
            if (slider == null) return false;
            slider.handle(((SpeedCommand) command).speedKmh, device);
            return true;
        }
        if (command instanceof GearCommand) {
            GearSlider slider = device.sliderOf(GearSlider.class);
            if (slider == null) return false;
            slider.handle(((GearCommand) command).gear, device);
            return true;
        }
        if (command instanceof SnapToOriginCommand) {
            ((SnapToOriginCommand) command).slider().snapToOrigin(device);
            return true;
        }
        if (command instanceof RawSwipeCommand) {
            applyRawSwipe((RawSwipeCommand) command, device);
            return true;
        }
        return false;
    }

    private static void applyRawSwipe(RawSwipeCommand command, Device device) {
        String cmd = "input swipe " + format(command.x()) + " " + format(command.fromY()) + " "
                + format(command.x()) + " " + format(command.toY()) + " "
                + GestureService.SWIPE_DURATION_MS;
        device.logger.log(Device.Logger.INFO, LOG_TAG,
                "CALSWIPE x=" + format(command.x()) + " " + format(command.fromY())
                        + "->" + format(command.toY()));
        device.logger.log(Device.Logger.DEBUG, LOG_TAG, "raw swipe -> " + cmd);
        if (GestureService.isConnected()) {
            GestureService.performSwipe(command.x(), command.fromY(), command.x(), command.toY(),
                    GestureService.SWIPE_DURATION_MS);
        } else {
            device.logger.log(Device.Logger.ERROR, LOG_TAG,
                    "raw swipe dropped: AccessibilityService not connected");
        }
        device.commandExecutor.send(cmd);
    }

    private static String format(float value) {
        if (value == Math.rint(value)) return Integer.toString((int) value);
        return Float.toString(value);
    }
}
