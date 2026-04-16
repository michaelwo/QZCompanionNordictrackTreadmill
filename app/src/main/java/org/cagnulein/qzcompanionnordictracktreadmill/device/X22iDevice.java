package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.ShellRuntime;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class X22iDevice extends TreadmillDevice {
    private final ShellRuntime shellRuntime = new ShellRuntime();

    public X22iDevice() {         super(
            new Slider(785) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return (int) (785 - 23.636363636363636 * v); }
            },
            new Slider(785) {
                public int trackX() { return 75; }
                public int targetY(double v) { return (int) (785 - 11.304347826086957 * (v + 6)); }
            }
        );
        commandExecutor = cmd -> {
            try { shellRuntime.exec(cmd); } catch (java.io.IOException ignored) {}
        };
    }

    @Override
    public String displayName() { return "X22i Treadmill"; }



    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }



}
