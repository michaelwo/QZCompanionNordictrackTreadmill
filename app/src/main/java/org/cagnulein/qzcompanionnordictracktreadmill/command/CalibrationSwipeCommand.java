package org.cagnulein.qzcompanionnordictracktreadmill.command;

public final class CalibrationSwipeCommand {
    public final float x;
    public final float fromY;
    public final float toY;

    public CalibrationSwipeCommand(float x, float fromY, float toY) {
        this.x     = x;
        this.fromY = fromY;
        this.toY   = toY;
    }
}
