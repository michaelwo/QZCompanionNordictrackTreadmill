package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

public final class InclineCommand extends Command {
    public final float inclinePct;

    public InclineCommand(float inclinePct) { this.inclinePct = inclinePct; }

    @Override public String toString() { return "incline=" + inclinePct; }
}
