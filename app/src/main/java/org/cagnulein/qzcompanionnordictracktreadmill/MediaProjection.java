package org.cagnulein.qzcompanionnordictracktreadmill;

import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.provider.Settings;
import android.app.AppOpsManager;
import android.annotation.TargetApi;

import com.rvalerio.fgchecker.AppChecker;

public class MediaProjection  {
    public static final int REQUEST_CODE = 100;
    private static Context _context;
    private static String _packageName = "";

    static void requestUsageStatsPermission() {
        if(android.os.Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP
        && !hasUsageStatsPermission(_context)) {
            _context.startActivity(new Intent(Settings.ACTION_USAGE_ACCESS_SETTINGS));
        }
    }

    @TargetApi(Build.VERSION_CODES.KITKAT)
    static boolean hasUsageStatsPermission(Context context) {
        AppOpsManager appOps = (AppOpsManager) context.getSystemService(Context.APP_OPS_SERVICE);
        int mode = appOps.checkOpNoThrow("android:get_usage_stats",
        android.os.Process.myUid(), context.getPackageName());
        boolean granted = mode == AppOpsManager.MODE_ALLOWED;
        return granted;
    }

    public static String getPackageName() {
        return _packageName;
    }

    public static void startService(Context context, int resultCode, Intent data) {
        _context = context;
        requestUsageStatsPermission();
        context.startService(ScreenCaptureService.getStartIntent(context, resultCode, data));

        AppChecker appChecker = new AppChecker();
        appChecker
            .whenAny(new AppChecker.Listener() {
                @Override
                public void onForeground(String packageName) {
                    _packageName = packageName;
                }
            })
            .timeout(1000)
            .start(context);
    }
}
