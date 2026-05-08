package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

public final class GearCommand extends Command {
    public final float gear;

    public GearCommand(float gear) { this.gear = gear; }

    @Override public String toString() { return "gear=" + gear; }
}
