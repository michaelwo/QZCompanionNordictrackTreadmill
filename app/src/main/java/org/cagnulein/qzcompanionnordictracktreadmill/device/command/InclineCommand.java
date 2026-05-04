package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;

public final class InclineCommand extends Command {
    public final float inclinePct;

    public InclineCommand(float inclinePct) { this.inclinePct = inclinePct; }

    @Override public void applyTo(Device device) { device.handleIncline(inclinePct); }

    @Override public String toString() { return "incline=" + inclinePct; }
}
