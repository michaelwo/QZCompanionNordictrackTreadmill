package org.cagnulein.qzcompanionnordictracktreadmill.device.control;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;

public interface ControlTransport {
    boolean tryApply(Command command, Device device);

    default void shutdown() {}

    static ControlTransport none() {
        return (command, device) -> false;
    }
}
