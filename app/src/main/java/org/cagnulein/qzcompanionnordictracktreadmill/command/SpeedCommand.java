package org.cagnulein.qzcompanionnordictracktreadmill.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;

public final class SpeedCommand extends Command {
    public final float speedKmh;

    public SpeedCommand(float speedKmh) { this.speedKmh = speedKmh; }

    @Override public void applyTo(Device device) { device.handleSpeed(speedKmh); }

    @Override public String toString() { return "speed=" + speedKmh; }
}
