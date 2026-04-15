package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.ShellRuntime;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class X22iDevice extends TreadmillDevice {
    private final ShellRuntime shellRuntime = new ShellRuntime();

    public X22iDevice() { super(785, 785); }

    @Override
    public String displayName() { return "X22i Treadmill"; }

    @Override
    protected int speedX() { return 1845; }

    @Override
    protected int targetSpeedY(double v) {
        return (int) (785 - 23.636363636363636 * v);
    }

    @Override
    public MetricReader defaultMetricReader(boolean ifitV2) { return new CatFileMetricReader(); }

    @Override
    protected int inclineX() { return 75; }

    @Override
    protected int targetInclineY(double v) {
        return (int) (785 - 11.304347826086957 * (v + 6));
    }

    @Override
    protected void execute(String command) {
        try { shellRuntime.exec(command); } catch (java.io.IOException ignored) {}
    }
}
