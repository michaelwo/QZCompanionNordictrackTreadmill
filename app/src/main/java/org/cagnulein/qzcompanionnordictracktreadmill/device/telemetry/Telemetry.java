package org.cagnulein.qzcompanionnordictracktreadmill.device.telemetry;

public abstract class Telemetry {
    public final float value;

    protected Telemetry(float value) {
        this.value = value;
    }
}
