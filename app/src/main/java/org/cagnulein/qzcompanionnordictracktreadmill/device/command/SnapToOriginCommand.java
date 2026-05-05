package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

public final class SnapToOriginCommand extends Command {
    @Override
    public void applyTo(Device device) {
        for (Slider s : device.sliders()) s.snapToOrigin(device);
    }

    @Override public String toString() { return "snapToOrigin"; }
}
