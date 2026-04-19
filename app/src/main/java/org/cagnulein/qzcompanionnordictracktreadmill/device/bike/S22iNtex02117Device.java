package org.cagnulein.qzcompanionnordictracktreadmill.device.bike;

import org.cagnulein.qzcompanionnordictracktreadmill.ShellRuntime;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class S22iNtex02117Device extends S22iDevice {
    @Override public boolean requiresAdb() { return false; }
    private final ShellRuntime shellRuntime = new ShellRuntime();

    public S22iNtex02117Device() {
        commandExecutor = cmd -> {
            try { shellRuntime.exec(cmd); } catch (java.io.IOException ignored) {}
        };
    }

    @Override
    public String displayName() { return "S22i Bike (NTEX02117.2)"; }

    @Override public MetricReader defaultMetricReader() { return new CatFileMetricReader(); }

}
