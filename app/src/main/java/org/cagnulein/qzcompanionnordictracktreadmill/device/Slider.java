package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;

/**
 * Represents one physical slider on the fitness device's touch screen.
 *
 * A slider has:
 *   - a fixed horizontal track position ({@link #trackX})
 *   - a movable thumb whose current vertical position is tracked in {@link #thumbY}
 *   - a formula mapping a metric value to a target Y coordinate ({@link #targetThumbY})
 *   - an optional live metric value ({@link #liveValue}) updated via {@link #applyIfMatch}
 *
 * The formula can be supplied either as a {@link ThumbYFormula} constructor argument
 * (preferred for simple sliders) or by overriding {@link #targetThumbY} in a subclass
 * (required when {@link #currentThumbY}, {@link #quantize}, or {@link #hysteresisPixels}
 * also need overriding).
 *
 * Factory methods (linear, inclineLive, speedLive, resistanceLive, gearLive) cover the
 * most common patterns and eliminate boilerplate anonymous subclasses in device classes.
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
    private SliderMetric metric = null;
    protected volatile Float liveValue = null;

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

    // ── Static factory methods ─────────────────────────────────────────────────

    /** Creates a Slider with targetThumbY = (int)(origin - scale * v). */
    public static Slider linear(int trackX, int origin, double scale) {
        return new Slider(trackX, origin, v -> (int)(origin - scale * v));
    }

    /** Creates a Slider with targetThumbY = (int)(origin - scale * (v + shift)). */
    public static Slider linear(int trackX, int origin, double scale, double shift) {
        return new Slider(trackX, origin, v -> (int)(origin - scale * (v + shift)));
    }

    /** Creates a Slider that derives currentThumbY from the live incline metric. */
    public static Slider inclineLive(int trackX, int initialY, ThumbYFormula formula) {
        return new Slider(trackX, initialY, formula).withMetric(SliderMetric.GRADE);
    }

    /** Creates a Slider that derives currentThumbY from the live speed metric. */
    public static Slider speedLive(int trackX, int initialY, ThumbYFormula formula) {
        return new Slider(trackX, initialY, formula).withMetric(SliderMetric.KPH);
    }

    /** Creates a Slider that derives currentThumbY from the live resistance metric. */
    public static Slider resistanceLive(int trackX, int initialY, ThumbYFormula formula) {
        return new Slider(trackX, initialY, formula).withMetric(SliderMetric.RESISTANCE);
    }

    /** Creates a Slider that derives currentThumbY from the live gear metric. */
    public static Slider gearLive(int trackX, int initialY, ThumbYFormula formula) {
        return new Slider(trackX, initialY, formula).withMetric(SliderMetric.CURRENT_GEAR);
    }

    // ── Live metric ownership ──────────────────────────────────────────────────

    public Slider withMetric(SliderMetric m) { this.metric = m; return this; }

    public void applyIfMatch(SliderMetric m, float value) {
        if (metric != null && metric == m) liveValue = value;
    }

    public float liveValueOrZero() { return liveValue != null ? liveValue : 0f; }

    // ── Instance API ───────────────────────────────────────────────────────────

    /** Fixed horizontal pixel coordinate of this slider's track on screen. */
    public int trackX() { return trackX; }

    /** Pixel Y coordinate the thumb should move to for the given metric {@code value}. */
    public int targetThumbY(double v) { return formula.apply(v); }

    /**
     * Current pixel Y of the slider thumb.
     * For live sliders (metric != null): returns targetThumbY(liveValue) when a live
     * value is known, else targetThumbY(0) — matching the pre-live-data neutral position.
     * For non-live sliders: returns the internally tracked thumbY.
     * Override when additional guards are needed (e.g. resistance level must be >= 1).
     */
    protected int currentThumbY() {
        if (liveValue != null) return targetThumbY(liveValue);
        if (metric != null) return targetThumbY(0.0);
        return thumbY;
    }

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
     */
    public void moveTo(double value, Device device) {
        int fromY  = currentThumbY();
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
