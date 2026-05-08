package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

public final class SpeedCommand extends Command {
    public SpeedCommand(float speedKmh) { super(speedKmh); }

    @Override public String toString() { return "speed=" + value; }
}
