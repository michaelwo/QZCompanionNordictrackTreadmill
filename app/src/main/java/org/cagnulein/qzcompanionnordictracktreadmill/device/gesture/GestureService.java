package org.cagnulein.qzcompanionnordictracktreadmill.device.gesture;

import android.accessibilityservice.AccessibilityService;
import android.accessibilityservice.GestureDescription;
import android.accessibilityservice.AccessibilityService.GestureResultCallback;
import android.content.SharedPreferences;
import android.graphics.Path;
import android.os.Build;
import android.provider.Settings;
import android.text.TextUtils;
import android.util.Log;
import android.view.accessibility.AccessibilityEvent;
import android.view.accessibility.AccessibilityNodeInfo;

import org.cagnulein.qzcompanionnordictracktreadmill.console.IfitConsoleSnapshot;
import org.cagnulein.qzcompanionnordictracktreadmill.ui.MainActivity;

import java.util.List;

public class GestureService extends AccessibilityService {

    private static final String TAG = "QZ:IFit";
    public static final int SWIPE_DURATION_MS = 200;
    private static final String IFIT_PACKAGE = "com.ifit.standalone";
    private static final String MACHINE_INFO_CLASS = "crc64ef9f2aa9b801e5a0.MachineInfoView";

    private static GestureService instance;

    @Override
    protected void onServiceConnected() {
        super.onServiceConnected();
        instance = this;
    }

    @Override
    public void onAccessibilityEvent(AccessibilityEvent event) {
        if (event.getEventType() == AccessibilityEvent.TYPE_WINDOW_STATE_CHANGED
                && MACHINE_INFO_CLASS.contentEquals(event.getClassName())) {
            scrapeAndSaveMachineInfo();
        }
    }

    @Override
    public void onInterrupt() {
    }

    // --- Gesture injection (existing) ---

    public static boolean isConnected() {
        return instance != null;
    }

    public static void performTap(float x, float y) {
        if (instance == null) {
            Log.e(TAG, "performTap: AccessibilityService not connected");
            return;
        }
        Path path = new Path();
        path.moveTo(x, y);

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
            GestureDescription.Builder builder = new GestureDescription.Builder();
            builder.addStroke(new GestureDescription.StrokeDescription(path, 0, 50));
            boolean accepted = instance.dispatchGesture(builder.build(), new GestureResultCallback() {
                @Override public void onCompleted(GestureDescription g) {
                    Log.d(TAG, "tap completed x=" + (int)x + " y=" + (int)y);
                }
                @Override public void onCancelled(GestureDescription g) {
                    Log.e(TAG, "tap CANCELLED x=" + (int)x + " y=" + (int)y);
                }
            }, null);
            if (!accepted) Log.e(TAG, "performTap: dispatchGesture rejected");
        }
    }

    public static void performSwipe(float startX, float startY, float endX, float endY, long duration) {
        if (instance == null) {
            Log.e(TAG, "performSwipe: AccessibilityService not connected");
            return;
        }
        Path path = new Path();
        path.moveTo(startX, startY);
        path.lineTo(endX, endY);

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
            GestureDescription.Builder builder = new GestureDescription.Builder();
            builder.addStroke(new GestureDescription.StrokeDescription(path, 0, duration));
            boolean accepted = instance.dispatchGesture(builder.build(), new GestureResultCallback() {
                @Override public void onCompleted(GestureDescription g) {
                    Log.d(TAG, "gesture completed x=" + (int)startX + " y=" + (int)startY
                            + "→" + (int)endY);
                }
                @Override public void onCancelled(GestureDescription g) {
                    Log.e(TAG, "gesture CANCELLED x=" + (int)startX + " y=" + (int)startY
                            + "→" + (int)endY);
                }
            }, null);
            if (!accepted) Log.e(TAG, "performSwipe: dispatchGesture rejected");
        }
    }

    // --- Passive iFit machine info scraping ---

    private void scrapeAndSaveMachineInfo() {
        AccessibilityNodeInfo root = getRootInActiveWindow();
        if (root == null) return;
        try {
            IfitConsoleSnapshot snap = scrape(root);
            if (snap != null && snap.isValid()) {
                SharedPreferences prefs = MainActivity.prefs();
                snap.save(prefs);
                Log.i(TAG, "Console snapshot saved: " + snap);
            }
        } finally {
            root.recycle();
        }
    }

    /**
     * Reads a field from a SettingsSimpleTwoTextsItem row identified by its Android resource ID.
     * Each row has a child with id "content" that holds the display value.
     */
    private static String contentOf(AccessibilityNodeInfo root, String itemId) {
        List<AccessibilityNodeInfo> items =
                root.findAccessibilityNodeInfosByViewId(IFIT_PACKAGE + ":id/" + itemId);
        if (items == null || items.isEmpty()) return null;
        AccessibilityNodeInfo item = items.get(0);
        List<AccessibilityNodeInfo> contents =
                item.findAccessibilityNodeInfosByViewId(IFIT_PACKAGE + ":id/content");
        if (contents == null || contents.isEmpty()) return null;
        CharSequence text = contents.get(0).getText();
        return text != null ? text.toString() : null;
    }

    private static IfitConsoleSnapshot scrape(AccessibilityNodeInfo root) {
        String partNumberStr = contentOf(root, "item_part_number");
        String machineType   = contentOf(root, "item_machine_type");
        String maxKph        = contentOf(root, "item_max_kph");
        String maxIncline    = contentOf(root, "item_max_incline");
        String minIncline    = contentOf(root, "item_min_incline");
        String maxResistance = contentOf(root, "item_max_resistance");

        int partNumber = 0;
        if (partNumberStr != null) {
            try {
                partNumber = Integer.parseInt(partNumberStr.trim());
            } catch (NumberFormatException ignored) {}
        }
        return new IfitConsoleSnapshot(
                partNumber, machineType,
                IfitConsoleSnapshot.parseNullable(maxKph),
                IfitConsoleSnapshot.parseNullable(maxIncline),
                IfitConsoleSnapshot.parseNullable(minIncline),
                IfitConsoleSnapshot.parseNullable(maxResistance));
    }
}
