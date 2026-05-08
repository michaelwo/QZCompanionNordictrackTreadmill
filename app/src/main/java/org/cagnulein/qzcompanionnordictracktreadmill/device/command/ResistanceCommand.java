package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

public final class ResistanceCommand extends Command {
    public final float resistanceLvl;

    public ResistanceCommand(float resistanceLvl) { this.resistanceLvl = resistanceLvl; }

    @Override public String toString() { return "resistance=" + resistanceLvl; }
}
