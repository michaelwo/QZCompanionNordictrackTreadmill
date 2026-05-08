package org.cagnulein.qzcompanionnordictracktreadmill.device.control;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;

public interface CommandHandler {
    boolean apply(Command command, Device device);

    default void shutdown() {}
}
