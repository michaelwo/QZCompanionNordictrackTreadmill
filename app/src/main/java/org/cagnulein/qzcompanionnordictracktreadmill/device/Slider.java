package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

/**
 * Represents one physical slider on the fitness device's touch screen.
 *
 * A slider has:
 *   - a fixed horizontal track position ({@link #trackX})
 *   - a movable thumb whose current vertical position is tracked in {@link #thumbY}
 *   - a formula mapping a metric value to a target Y coordinate ({@link #targetY})
 *
 * Subclasses (typically anonymous) supply the screen coordinates and formula.
 * Devices that derive the current thumb position from live observed metrics
 * (rather than tracking it as state) override {@link #currentThumbY}.
 */
public abstract class Slider {

    private int thumbY;
    private Float lastApplied = null;

    protected Slider(int initialThumbY) {
        this.thumbY = initialThumbY;
    }

    /** Fixed horizontal pixel coordinate of this slider's track on screen. */
    public abstract int trackX();

    /** Pixel Y coordinate the thumb should move to for the given metric {@code value}. */
    public abstract int targetY(double v);

    /**
     * Current pixel Y of the slider thumb.
     * Default: returns the internally tracked position, updated after each {@link #moveTo}.
     * Override to derive from live observed metrics instead — used by devices that re-read
     * the current position from the device display rather than tracking it as state.
     */
    protected int currentThumbY(MetricSnapshot current) { return thumbY; }

    /**
     * Snap {@code value} to the nearest position this slider can physically reach.
     * Default: identity (no snapping). Override for sliders with fixed increments.
     */
    public float quantize(float value) { return value; }

    /**
     * Swipe the slider thumb from its current position to the position for {@code value}.
     * The device's own {@code lastSnapshot} is used to determine the starting thumb position
     * for devices that derive it from live metrics rather than tracking it as state.
     */
    public void moveTo(double value, Device device) {
        int fromY = currentThumbY(device.lastSnapshot);
        int toY   = targetY(value);
        device.swipe(trackX(), fromY, toY);
        thumbY      = toY;
        lastApplied = (float) value;
    }

    public int   thumbY()       { return thumbY; }
    public Float lastApplied()  { return lastApplied; }
}
