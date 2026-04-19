package org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.ShellRuntime;

public class X9iDevice extends TreadmillDevice {
    @Override public boolean requiresAdb() { return false; }
    private final ShellRuntime shellRuntime = new ShellRuntime();

    public X9iDevice() {         super(
            new Slider(332) {
                public int trackX() { return 725; }
                public int targetY(double v) { return (int) (345.6315 - 13.6315 * v); }
            },
            new Slider(332) {
                public int trackX() { return 73; }
                public int targetY(double v) { return (int) (311.91 - 3.3478 * v); }
            }
        );
        commandExecutor = cmd -> {
            try { shellRuntime.exec(cmd); } catch (java.io.IOException ignored) {}
        };
    }

    @Override
    public String displayName() { return "X9i Treadmill"; }





}
