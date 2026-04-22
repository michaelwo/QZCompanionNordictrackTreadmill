package org.cagnulein.qzcompanionnordictracktreadmill.calibration;

/**
 * Remembers where on screen the watt value appeared so it can be recovered
 * in frames where OCR misses it.
 *
 * When OCR successfully reads a watt value, {@link #update} caches the screen
 * position of that value block.  On subsequent frames where OCR returns no
 * watts, {@link #tryRecover} searches for any numeric block inside a 1.5×-wide
 * expansion of the cached position and returns the first value above
 * {@link Ocr#MIN_WATTS}.
 *
 * No Android dependencies — uses {@link OcrRect} instead of
 * {@code android.graphics.Rect} so this class is unit-testable on the JVM.
 */
public class WattRectFallback {

    private OcrRect cache = null;

    /**
     * If {@code watts} is non-null, searches {@code blocks} for the watt label and
     * caches the screen rect of the value block that preceded it.
     */
    public void update(OcrBlock[] blocks, Float watts) {
        if (watts == null) return;
        for (int i = 1; i < blocks.length; i++) {
            if (blocks[i].text.toLowerCase().contains("watt")) {
                OcrRect r = OcrRect.fromString(blocks[i - 1].rectString);
                if (r != null) { cache = r; return; }
            }
        }
    }

    /**
     * Searches {@code blocks} for a numeric value inside the 1.5×-wide expansion of
     * the cached watt-value rect.
     *
     * @return the recovered watt value, or {@code null} if the cache is empty or no
     *         matching block is found
     */
    public Float tryRecover(OcrBlock[] blocks) {
        if (cache == null) return null;
        int expandedWidth = (int) (cache.width() * 1.5);
        int expandedLeft  = cache.left - (expandedWidth - cache.width()) / 2;
        OcrRect expanded  = new OcrRect(expandedLeft, cache.top, expandedLeft + expandedWidth, cache.bottom);
        for (OcrBlock block : blocks) {
            OcrRect r = OcrRect.fromString(block.rectString);
            if (r != null && expanded.intersects(r)) {
                try {
                    String[] numbers = block.text.trim().replaceAll("[^0-9]", " ").trim().split("\\s+");
                    int w = Integer.parseInt(numbers[numbers.length - 1]);
                    if (w > Ocr.MIN_WATTS) return (float) w;
                } catch (Exception ignored) {}
            }
        }
        return null;
    }
}
