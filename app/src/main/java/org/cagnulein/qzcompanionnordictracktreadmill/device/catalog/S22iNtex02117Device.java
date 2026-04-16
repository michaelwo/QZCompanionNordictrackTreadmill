package org.cagnulein.qzcompanionnordictracktreadmill.device.catalog;

import org.cagnulein.qzcompanionnordictracktreadmill.ShellRuntime;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class S22iNtex02117Device extends S22iDevice {
    private final ShellRuntime shellRuntime = new ShellRuntime();

    public S22iNtex02117Device() {
        commandExecutor = cmd -> {
            try { shellRuntime.exec(cmd); } catch (java.io.IOException ignored) {}
        };
    }

    @Override
    public String displayName() { return "S22i Bike (NTEX02117.2)"; }

    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }

}
