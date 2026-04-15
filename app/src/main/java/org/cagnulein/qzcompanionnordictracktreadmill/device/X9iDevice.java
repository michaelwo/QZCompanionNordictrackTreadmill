package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.ShellRuntime;

public class X9iDevice extends TreadmillDevice {
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
        ); }

    @Override
    public String displayName() { return "X9i Treadmill"; }





    @Override
    protected void execute(String command) {
        try { shellRuntime.exec(command); } catch (java.io.IOException ignored) {}
    }
}
