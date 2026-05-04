package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;

public final class ResistanceCommand extends Command {
    public final float resistanceLvl;

    public ResistanceCommand(float resistanceLvl) { this.resistanceLvl = resistanceLvl; }

    @Override public void applyTo(Device device) { device.handleResistance(resistanceLvl); }

    @Override public String toString() { return "resistance=" + resistanceLvl; }
}
