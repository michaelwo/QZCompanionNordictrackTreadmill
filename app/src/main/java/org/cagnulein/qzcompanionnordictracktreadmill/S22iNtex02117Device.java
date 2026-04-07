package org.cagnulein.qzcompanionnordictracktreadmill;

class S22iNtex02117Device extends S22iDevice {
    private final ShellRuntime shellRuntime = new ShellRuntime();

    @Override
    String displayName() { return "S22i Bike (NTEX02117.2)"; }

    @Override
    MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }

    @Override
    protected void execute(String command) {
        try { shellRuntime.exec(command); } catch (java.io.IOException ignored) {}
    }
}
