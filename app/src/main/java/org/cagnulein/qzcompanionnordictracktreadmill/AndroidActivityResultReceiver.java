package org.cagnulein.qzcompanionnordictracktreadmill;
import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.util.Log;


public class AndroidActivityResultReceiver {

    private Context context;

    public AndroidActivityResultReceiver(Context context) {
        this.context = context;
    }

    public void handleActivityResult(int receiverRequestCode, int resultCode, Intent data) {
        Log.d("AndroidActivityResultReceiver", "handleActivityResult: " + receiverRequestCode + " " + resultCode);
        MediaProjection.startService(context, resultCode, data);
        Intent calibration = new Intent(context, OcrCalibrationService.class);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            context.startForegroundService(calibration);
        } else {
            context.startService(calibration);
        }
    }
}
