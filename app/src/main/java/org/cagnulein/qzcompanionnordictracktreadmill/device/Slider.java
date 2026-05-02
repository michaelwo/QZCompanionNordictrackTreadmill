package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

/**
 * Represents one physical slider on the fitness device's touch screen.
 *
 * A slider has:
 *   - a fixed horizontal track position ({@link #trackX})
 *   - a movable thumb whose current vertical position is tracked in {@link #thumbY}
 *   - a formula mapping a metric value to a target Y coordinate ({@link #targetThumbY})
 *
 * The formula can be supplied either as a {@link ThumbYFormula} constructor argument
 * (preferred for simple sliders) or by overriding {@link #targetThumbY} in a subclass
 * (required when {@link #currentThumbY}, {@link #quantize}, or {@link #hysteresisPixels}
 * also need overriding).
 */
public class Slider {

    @FunctionalInterface
    public interface ThumbYFormula {
        int apply(double v);
    }

    private final int trackX;
    private final ThumbYFormula formula;
    private int thumbY;
    private Float lastApplied = null;

    public Slider(int trackX, int initialThumbY, ThumbYFormula formula) {
        this.trackX  = trackX;
        this.thumbY  = initialThumbY;
        this.formula = formula;
    }

    protected Slider(int trackX, int initialThumbY) {
        this(trackX, initialThumbY, null);
    }

    /** Single-arg constructor for subclasses that override {@link #trackX()} at runtime. */
    protected Slider(int initialThumbY) {
        this(0, initialThumbY, null);
    }

    /** Fixed horizontal pixel coordinate of this slider's track on screen. */
    public int trackX() { return trackX; }

    /** Pixel Y coordinate the thumb should move to for the given metric {@code value}. */
    public int targetThumbY(double v) { return formula.apply(v); }

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
     * Pixels of directional overshoot applied to compensate for physical slider hysteresis.
     * The thumb is swiped this many pixels past {@code toY} in the direction of travel,
     * while {@link #thumbY} still tracks the logical target so de-dup and state-tracking remain
     * consistent. Override in device-specific subclasses; default is 0 (no overshoot).
     *
     * @param fromY current thumb pixel Y (starting position)
     * @param toY   logical target pixel Y
     */
    protected int hysteresisPixels(int fromY, int toY) { return 0; }

    /**
     * Swipe the slider thumb from its current position to the position for {@code value}.
     * The device's own {@code lastSnapshot} is used to determine the starting thumb position
     * for devices that derive it from live metrics rather than tracking it as state.
     */
    public void moveTo(double value, Device device) {
        int fromY  = currentThumbY(device.lastSnapshot);
        int toY    = targetThumbY(value);
        int h      = hysteresisPixels(fromY, toY);
        int swipeY = (h > 0 && toY != fromY) ? (toY < fromY ? toY - h : toY + h) : toY;
        device.swipe(trackX(), fromY, swipeY);
        thumbY      = toY;
        lastApplied = (float) value;
    }

    public int   thumbY()       { return thumbY; }
    public Float lastApplied()  { return lastApplied; }
}
