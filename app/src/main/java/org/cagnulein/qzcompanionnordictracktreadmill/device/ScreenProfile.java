package org.cagnulein.qzcompanionnordictracktreadmill.device;

/**
 * Screen geometry profiles for iFit console displays.
 *
 * Track positions are derived from iFit APK layout resources:
 *   workout_slider_margin = 12 dp, workout_slider_width = 125 dp  (mdpi: 1 dp = 1 px)
 *   left track centre = margin + width / 2 = 12 + 62.5 = 74.5 → rounded per screen calibration
 *
 * Both leftTrackX and rightTrackX are the hardware-calibrated values; they satisfy
 * leftTrackX + rightTrackX ≈ screen width but are stored independently because
 * the rounding used on each side can differ by 1–2 px.
 *
 * Usage in device constructors:
 *   new Slider(initialY, ScreenProfile.W1920.leftTrackX)    // incline / grade slider
 *   new Slider(initialY, ScreenProfile.W1920.rightTrackX)   // speed / resistance slider
 */
public enum ScreenProfile {
    W1920(75, 1845),
    W1280(75, 1205),
    W1024(74,  950),
    W800 (73,  725);

    public final int leftTrackX;
    public final int rightTrackX;

    ScreenProfile(int leftTrackX, int rightTrackX) {
        this.leftTrackX  = leftTrackX;
        this.rightTrackX = rightTrackX;
    }
}
