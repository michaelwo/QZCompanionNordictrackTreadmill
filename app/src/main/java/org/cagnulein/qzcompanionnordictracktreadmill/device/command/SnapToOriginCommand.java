package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.Slider;

public final class SnapToOriginCommand extends Command {
    private final Slider slider;

    public SnapToOriginCommand(Slider slider) { this.slider = slider; }

    public Slider slider() { return slider; }

    @Override public String toString() { return "snapToOrigin"; }
}
