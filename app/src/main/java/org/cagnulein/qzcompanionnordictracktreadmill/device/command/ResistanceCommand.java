package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.ResistanceSlider;

public final class ResistanceCommand extends Command {
    public final float resistanceLvl;

    public ResistanceCommand(float resistanceLvl) { this.resistanceLvl = resistanceLvl; }

    @Override
    public void applyTo(Device device) {
        ResistanceSlider s = device.sliderOf(ResistanceSlider.class);
        if (s != null) s.handle(resistanceLvl, device);
    }

    @Override public String toString() { return "resistance=" + resistanceLvl; }
}
