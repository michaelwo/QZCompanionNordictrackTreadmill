package org.cagnulein.qzcompanionnordictracktreadmill.device.slider;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.GearCommand;

public class GearSlider extends Slider {

    public GearSlider(int trackX, int initialThumbY, ThumbYFormula formula) {
        super(trackX, initialThumbY, formula, SliderMetric.CURRENT_GEAR);
    }

    @Override
    protected int currentThumbY() { return thumbY(); }

    public static GearSlider live(int trackX, int initialThumbY, ThumbYFormula formula) {
        return new GearSlider(trackX, initialThumbY, formula) {
            @Override
            protected int currentThumbY() {
                if (liveValue != null) return targetThumbY(liveValue);
                return targetThumbY(0.0);
            }
        };
    }

    @Override
    public void handle(double gear, Device device) {
        Float last = lastApplied();
        if (last == null || (float) gear != last) moveTo(gear, device);
    }

    @Override
    public Command commandFor(double gear) { return new GearCommand((float) gear); }

    @Override protected float originValue() { return 1f; }
}
