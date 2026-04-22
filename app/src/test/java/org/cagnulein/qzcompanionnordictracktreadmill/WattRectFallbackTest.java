package org.cagnulein.qzcompanionnordictracktreadmill;

import org.cagnulein.qzcompanionnordictracktreadmill.calibration.Ocr;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.OcrBlock;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.OcrRect;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.WattRectFallback;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 * Unit tests for OcrRect and WattRectFallback.
 *
 * Blocks are constructed via Ocr.blocks() from raw strings so no Android classes
 * are needed.  Raw string format: "text1$$RectString1§§text2$$RectString2..."
 * (null rectString means the block carries no rect suffix).
 */
public class WattRectFallbackTest {

    /** Builds a raw OCR string from (text, rectString) pairs; null rect → no $$ suffix. */
    private static String raw(String... pairs) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < pairs.length; i += 2) {
            if (sb.length() > 0) sb.append("§§");
            sb.append(pairs[i]);
            if (pairs[i + 1] != null) sb.append("$$").append(pairs[i + 1]);
        }
        return sb.toString();
    }

    private static OcrBlock[] blocks(String... pairs) {
        return Ocr.blocks(raw(pairs));
    }

    // ── OcrRect.fromString ────────────────────────────────────────────────────

    @Test
    public void ocrRect_fromString_parsesValidRect() {
        OcrRect r = OcrRect.fromString("Rect(10,20-100,40)");
        assertNotNull(r);
        assertEquals(10,  r.left);
        assertEquals(20,  r.top);
        assertEquals(100, r.right);
        assertEquals(40,  r.bottom);
    }

    @Test
    public void ocrRect_fromString_nullInput_returnsNull() {
        assertNull(OcrRect.fromString(null));
    }

    @Test
    public void ocrRect_fromString_missingDashSeparator_returnsNull() {
        assertNull(OcrRect.fromString("Rect(10,20,100,40)"));
    }

    @Test
    public void ocrRect_fromString_nonNumericPart_returnsNull() {
        assertNull(OcrRect.fromString("Rect(x,20-100,40)"));
    }

    @Test
    public void ocrRect_width_returnsRightMinusLeft() {
        OcrRect r = OcrRect.fromString("Rect(10,20-100,40)");
        assertNotNull(r);
        assertEquals(90, r.width());
    }

    // ── OcrRect.intersects ────────────────────────────────────────────────────

    @Test
    public void ocrRect_intersects_overlappingRects_returnsTrue() {
        OcrRect a = new OcrRect(0, 0, 100, 50);
        OcrRect b = new OcrRect(50, 25, 150, 75);
        assertTrue(a.intersects(b));
        assertTrue(b.intersects(a));
    }

    @Test
    public void ocrRect_intersects_nonOverlappingRects_returnsFalse() {
        OcrRect a = new OcrRect(0, 0, 50, 50);
        OcrRect b = new OcrRect(100, 0, 200, 50);
        assertFalse(a.intersects(b));
        assertFalse(b.intersects(a));
    }

    @Test
    public void ocrRect_intersects_adjacentEdge_returnsFalse() {
        // Rects sharing an edge do not intersect (check is strict <, not ≤)
        OcrRect a = new OcrRect(0, 0, 50, 50);
        OcrRect b = new OcrRect(50, 0, 100, 50);
        assertFalse(a.intersects(b));
    }

    @Test
    public void ocrRect_intersects_containedRect_returnsTrue() {
        OcrRect outer = new OcrRect(0, 0, 200, 200);
        OcrRect inner = new OcrRect(50, 50, 100, 100);
        assertTrue(outer.intersects(inner));
        assertTrue(inner.intersects(outer));
    }

    // ── WattRectFallback.update ───────────────────────────────────────────────

    @Test
    public void update_wattsNull_doesNotCache() {
        WattRectFallback f = new WattRectFallback();
        // Watts is null → update must not cache; tryRecover on any subsequent frame returns null
        f.update(blocks("215", "Rect(10,20-100,40)", "watt", "Rect(10,40-100,60)"), null);
        assertNull(f.tryRecover(blocks("218", "Rect(5,20-95,40)")));
    }

    @Test
    public void update_wattsPresent_noWattLabelInBlocks_doesNotCache() {
        WattRectFallback f = new WattRectFallback();
        // Label says "speed", not "watt" → no cache
        f.update(blocks("215", "Rect(10,20-100,40)", "speed", "Rect(10,40-100,60)"), 215.0f);
        assertNull(f.tryRecover(blocks("218", "Rect(5,20-95,40)")));
    }

    @Test
    public void update_wattsPresent_valueBlockHasNoRect_doesNotCache() {
        WattRectFallback f = new WattRectFallback();
        // The VALUE block (blocks[i-1]) has no rect suffix → OcrRect.fromString(null) = null → not cached
        f.update(blocks("215", null, "watt", "Rect(10,40-100,60)"), 215.0f);
        assertNull(f.tryRecover(blocks("218", "Rect(5,20-95,40)")));
    }

    // ── WattRectFallback.tryRecover ───────────────────────────────────────────

    @Test
    public void tryRecover_noCacheSet_returnsNull() {
        assertNull(new WattRectFallback().tryRecover(blocks("218", "Rect(5,20-95,40)")));
    }

    @Test
    public void tryRecover_blockInExpandedRegion_returnsWatts() {
        // Cache = Rect(10,20-100,40): width=90, expandedWidth=135, expandedLeft=-12
        // expanded = OcrRect(-12,20,123,40)
        // Rect(5,20-95,40) → intersects expanded → 218 > MIN_WATTS → recovered
        WattRectFallback f = new WattRectFallback();
        f.update(blocks("215", "Rect(10,20-100,40)", "watt", "Rect(10,40-100,60)"), 215.0f);

        Float got = f.tryRecover(blocks("218", "Rect(5,20-95,40)", "watt", "Rect(10,40-100,60)"));
        assertNotNull(got);
        assertEquals(218.0f, got, 0.001f);
    }

    @Test
    public void tryRecover_blockOutsideExpandedRegion_returnsNull() {
        // expanded = OcrRect(-12,20,123,40); Rect(200,20-300,40) → 200 < 123 fails → no intersection
        WattRectFallback f = new WattRectFallback();
        f.update(blocks("215", "Rect(10,20-100,40)", "watt", "Rect(10,40-100,60)"), 215.0f);

        assertNull(f.tryRecover(blocks("218", "Rect(200,20-300,40)")));
    }

    @Test
    public void tryRecover_blockInRegionButBelowMinWatts_returnsNull() {
        WattRectFallback f = new WattRectFallback();
        f.update(blocks("215", "Rect(10,20-100,40)", "watt", "Rect(10,40-100,60)"), 215.0f);

        // 15 ≤ Ocr.MIN_WATTS (20) → rejected
        assertNull(f.tryRecover(blocks("15", "Rect(5,20-95,40)")));
    }

    @Test
    public void tryRecover_blockInRegionWithNonNumericText_returnsNull() {
        WattRectFallback f = new WattRectFallback();
        f.update(blocks("215", "Rect(10,20-100,40)", "watt", "Rect(10,40-100,60)"), 215.0f);

        assertNull(f.tryRecover(blocks("---", "Rect(5,20-95,40)")));
    }

    @Test
    public void tryRecover_cachePersistsAcrossMultipleFrames() {
        WattRectFallback f = new WattRectFallback();
        f.update(blocks("215", "Rect(10,20-100,40)", "watt", "Rect(10,40-100,60)"), 215.0f);

        assertNotNull(f.tryRecover(blocks("220", "Rect(5,20-95,40)")));
        assertNotNull(f.tryRecover(blocks("225", "Rect(5,20-95,40)")));
    }

    @Test
    public void tryRecover_updateOverwritesCache_newPositionHits_oldMisses() {
        WattRectFallback f = new WattRectFallback();
        // First cache: Rect(10,20-100,40) → expanded covers x≈−12..123
        f.update(blocks("215", "Rect(10,20-100,40)", "watt", "Rect(10,40-100,60)"), 215.0f);

        // Second update: watt moved to Rect(500,20-600,40) → expanded covers x≈475..625
        f.update(blocks("220", "Rect(500,20-600,40)", "watt", "Rect(500,40-600,60)"), 220.0f);

        // Old screen position (x=5..95) no longer intersects new expanded rect (x=475..625)
        assertNull("old position must miss", f.tryRecover(blocks("225", "Rect(5,20-95,40)")));

        // New screen position (x=510..590) is inside the new expanded rect
        assertNotNull("new position must hit", f.tryRecover(blocks("230", "Rect(510,20-590,40)")));
    }
}
