package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.GearSlider;

public final class GearCommand extends Command {
    public final float gear;

    public GearCommand(float gear) { this.gear = gear; }

    @Override
    public void applyTo(Device device) {
        GearSlider s = device.sliderOf(GearSlider.class);
        if (s != null) s.handle(gear, device);
    }

    @Override public String toString() { return "gear=" + gear; }
}
