package org.cagnulein.qzcompanionnordictracktreadmill.ocr;

/**
 * One block from ScreenCaptureService's OCR output.
 *
 * Raw format: blocks separated by "§§", each block optionally carrying a
 * "$$Rect(l,t-r,b)" rect suffix.  Ocr.blocks() splits the raw string
 * into these objects so callers don't need to repeat the split logic.
 */
public final class OcrBlock {
    /** The text content of this block (rect suffix already stripped). */
    public final String text;

    /** The raw rect string ("Rect(l,t-r,b)") appended by ScreenCaptureService, or null. */
    public final String rectString;

    OcrBlock(String text, String rectString) {
        this.text      = text;
        this.rectString = rectString;
    }
}
