package org.cagnulein.qzcompanionnordictracktreadmill;

import android.content.Context;
import android.content.SharedPreferences;
import android.util.Log;

import java.io.PrintWriter;
import java.io.StringWriter;

public class MyExceptionHandler implements Thread.UncaughtExceptionHandler {
    private Context context;

    public MyExceptionHandler(Context context) {
        this.context = context;
    }

    @Override
    public void uncaughtException(Thread thread, Throwable throwable) {
        StringWriter sw = new StringWriter();
        PrintWriter pw = new PrintWriter(sw);
        throwable.printStackTrace(pw);
        String stackTraceString = sw.toString();

        // Salva l'errore nelle SharedPreferences
        SharedPreferences prefs = context.getSharedPreferences("CrashPrefs", Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = prefs.edit();
        editor.putString("last_crash", stackTraceString);
        editor.apply();

        // Termina l'app
        android.os.Process.killProcess(android.os.Process.myPid());
        System.exit(1);
    }
}
