package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;

public interface CommandHandler {
    boolean apply(Command command, Device device);

    default void shutdown() {}
}
