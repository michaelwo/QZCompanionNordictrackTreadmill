package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

public final class SpeedCommand extends Command {
    public final float speedKmh;

    public SpeedCommand(float speedKmh) { this.speedKmh = speedKmh; }

    @Override public String toString() { return "speed=" + speedKmh; }
}
