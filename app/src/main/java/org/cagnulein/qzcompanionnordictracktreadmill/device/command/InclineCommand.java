package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.InclineSlider;

public final class InclineCommand extends Command {
    public final float inclinePct;

    public InclineCommand(float inclinePct) { this.inclinePct = inclinePct; }

    @Override
    public void applyTo(Device device) {
        InclineSlider s = device.sliderOf(InclineSlider.class);
        if (s != null) s.handle(inclinePct, device);
    }

    @Override public String toString() { return "incline=" + inclinePct; }
}
