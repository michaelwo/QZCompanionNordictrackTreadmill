package org.cagnulein.qzcompanionnordictracktreadmill.device.slider;

import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.ResistanceCommand;

public class ResistanceSlider extends Slider {

    public ResistanceSlider(int trackX, int initialThumbY, ThumbYFormula formula) {
        super(trackX, initialThumbY, formula, SliderMetric.RESISTANCE);
    }

    protected ResistanceSlider(int initialThumbY) {
        super(0, initialThumbY, null, SliderMetric.RESISTANCE);
    }

    @Override
    protected int currentThumbY() { return thumbY(); }

    public static ResistanceSlider live(int trackX, int initialThumbY, ThumbYFormula formula) {
        return new ResistanceSlider(trackX, initialThumbY, formula) {
            @Override
            protected int currentThumbY() {
                if (liveValue != null) return targetThumbY(liveValue);
                return targetThumbY(0.0);
            }
        };
    }

    @Override
    public void handle(double lvl, Device device) {
        Float last = lastApplied();
        device.logger.log(Device.Logger.VERBOSE, "QZ:Dispatch", "requestResistance: " + lvl + " last=" + last);
        if (last == null || !Float.valueOf((float) lvl).equals(last)) {
            moveTo(lvl, device);
            device.logger.log(Device.Logger.DEBUG, "QZ:Dispatch", "applyResistance: " + lvl);
        } else {
            device.logger.log(Device.Logger.VERBOSE, "QZ:Dispatch", "de-dup: skipping resistance " + lvl + " (already at " + last + ")");
        }
    }

    @Override
    public Command commandFor(double lvl) { return new ResistanceCommand((float) lvl); }
}
