package org.cagnulein.qzcompanionnordictracktreadmill.device;

import android.util.Log;
import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import org.cagnulein.qzcompanionnordictracktreadmill.device.gesture.GestureService;

/**
 * Represents one physical slider on the fitness device's touch screen.
 *
 * A slider has:
 *   - a fixed horizontal track position ({@link #trackX})
 *   - a movable thumb whose current vertical position is tracked in {@link #thumbY}
 *   - a formula mapping a metric value to a target Y coordinate ({@link #targetThumbY})
 *   - an optional live metric value ({@link #liveValue}) updated via {@link #applyIfMatch}
 *
 * Concrete subclasses ({@code InclineSlider}, {@code SpeedSlider}, {@code ResistanceSlider},
 * {@code GearSlider}) implement {@link #handle} and {@link #commandFor}, encapsulating
 * dedup, belt-gate, and command-creation logic for their slider type.
 */
public abstract class Slider {

    @FunctionalInterface
    public interface ThumbYFormula {
        int apply(double v);
    }

    private final int trackX;
    private final ThumbYFormula formula;
    private int thumbY;
    private Float lastApplied = null;
    private SliderMetric metric;
    protected volatile Float liveValue = null;

    protected Slider(int trackX, int initialThumbY, ThumbYFormula formula, SliderMetric metric) {
        this.trackX  = trackX;
        this.thumbY  = initialThumbY;
        this.formula = formula;
        this.metric  = metric;
    }

    // ── Abstract API ───────────────────────────────────────────────────────────

    /** Apply a command value to this slider, handling dedup, belt-gate, and swipe. */
    public abstract void handle(double value, Device device);

    /** Create the matching Command type for this slider with the given value. */
    public abstract Command commandFor(double value);

    // ── Live metric ownership ──────────────────────────────────────────────────

    public void applyIfMatch(SliderMetric m, float value) {
        if (metric != null && metric == m) liveValue = value;
    }

    /** 3-arg overload called by {@link Device#applyMetric}; default delegates to 2-arg. */
    public void applyIfMatch(SliderMetric m, float value, Device device) {
        applyIfMatch(m, value);
    }

    public float liveValueOrZero() { return liveValue != null ? liveValue : 0f; }

    // ── Instance API ───────────────────────────────────────────────────────────

    /** Fixed horizontal pixel coordinate of this slider's track on screen. */
    public int trackX() { return trackX; }

    /** Pixel Y coordinate the thumb should move to for the given metric {@code value}. */
    public int targetThumbY(double v) { return formula.apply(v); }

    /**
     * Current pixel Y of the slider thumb.
     * Override in typed subclasses to choose live or dead mode:
     *   - Live: {@code liveValue != null ? targetThumbY(liveValue) : targetThumbY(0.0)}
     *   - Dead: {@code thumbY()}
     */
    protected abstract int currentThumbY();

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
        String cmd = "input swipe " + trackX() + " " + fromY + " " + trackX() + " " + swipeY
                   + " " + GestureService.SWIPE_DURATION_MS;
        device.logger.log(Log.DEBUG, "QZ:Slider", "swipe -> " + cmd);
        if (GestureService.isConnected()) {
            GestureService.performSwipe(trackX(), fromY, trackX(), swipeY, GestureService.SWIPE_DURATION_MS);
        } else {
            device.logger.log(Log.ERROR, "QZ:Slider", "swipe dropped: AccessibilityService not connected");
        }
        device.commandExecutor.send(cmd);
        thumbY      = toY;
        lastApplied = (float) value;
    }

    public int   thumbY()       { return thumbY; }
    public Float lastApplied()  { return lastApplied; }
}
