package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.Slider;

public final class SnapToOriginCommand extends Command {
    private final Slider slider;

    public SnapToOriginCommand(Slider slider) { this.slider = slider; }

    @Override
    public void applyTo(Device device) { slider.snapToOrigin(device); }

    @Override public String toString() { return "snapToOrigin"; }
}
