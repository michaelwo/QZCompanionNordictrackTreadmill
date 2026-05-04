package org.cagnulein.qzcompanionnordictracktreadmill.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;

public abstract class Command {
    public abstract void applyTo(Device device);
}
