package org.cagnulein.qzcompanionnordictracktreadmill.device.command;

public abstract class Command {
    public final float value;
    protected Command(float value) { this.value = value; }
}
