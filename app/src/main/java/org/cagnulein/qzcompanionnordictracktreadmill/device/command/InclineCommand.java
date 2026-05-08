package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

public final class InclineCommand extends Command {
    public InclineCommand(float inclinePct) { super(inclinePct); }

    @Override public String toString() { return "incline=" + value; }
}
