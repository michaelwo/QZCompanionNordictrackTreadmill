package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.ShellRuntime;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class S22iNtex02117Device extends S22iDevice {
    private final ShellRuntime shellRuntime = new ShellRuntime();

    @Override
    public String displayName() { return "S22i Bike (NTEX02117.2)"; }

    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }

    @Override
    protected void execute(String command) {
        try { shellRuntime.exec(command); } catch (java.io.IOException ignored) {}
    }
}
