package org.cagnulein.qzcompanionnordictracktreadmill.device.catalog;

import org.cagnulein.qzcompanionnordictracktreadmill.MyAccessibilityService;

/**
 * S22i Bike variant that injects swipe gestures via AccessibilityService
 * instead of ADB.  Use this when the ADB loopback connection cannot be
 * established (the most common case on stock S22i firmware).
 *
 * Requires QZCompanion to be enabled in Android Accessibility Settings.
 */
public class S22iNoAdbDevice extends S22iDevice {

    @Override
    public String displayName() { return "S22i Bike (No ADB)"; }

    @Override
    protected void swipe(int x, int y1, int y2) {
        String cmd = "input swipe " + x + " " + y1 + " " + x + " " + y2 + " 200";
        logger.log("QZ:Device", "swipe -> " + cmd + " (AccessibilityService)");
        MyAccessibilityService.performSwipe(x, y1, x, y2, 200);
    }
}
