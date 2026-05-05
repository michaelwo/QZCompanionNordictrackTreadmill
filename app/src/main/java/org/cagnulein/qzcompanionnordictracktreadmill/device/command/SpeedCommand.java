package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.SpeedSlider;

public final class SpeedCommand extends Command {
    public final float speedKmh;

    public SpeedCommand(float speedKmh) { this.speedKmh = speedKmh; }

    @Override
    public void applyTo(Device device) {
        SpeedSlider s = device.sliderOf(SpeedSlider.class);
        if (s != null) s.handle(speedKmh, device);
    }

    @Override public String toString() { return "speed=" + speedKmh; }
}
