package org.cagnulein.qzcompanionnordictracktreadmill;

import android.util.Log;

import androidx.annotation.NonNull;

import java.io.IOException;
import java.io.InputStream;

public class ShellRuntime implements Shell {
    private static final String LOG_TAG = "QZ:Shell";

    private final Runtime runtime = Runtime.getRuntime();
    private String sh = null;

    public InputStream execAndGetOutput(String command) throws IOException {
        Process proc = exec(command);
        return proc.getInputStream();
    }

    public Process exec(String command) throws IOException {
        Log.d(LOG_TAG, "exec: " + command);
        String[] cmd = {getSh(), "-c", " " + command};
        Process proc = runtime.exec(cmd);
        final Process p = proc;
        final String c = command;
        Thread exitChecker = new Thread(() -> {
            try {
                int exit = p.waitFor();
                if (exit != 0) {
                    Log.e(LOG_TAG, "Command failed (exit " + exit + "): " + c
                            + (c.contains("input swipe") ? " — check INJECT_EVENTS permission" : ""));
                }
            } catch (InterruptedException ignored) {}
        }, "ShellRuntime-exit-check");
        exitChecker.setDaemon(true);
        exitChecker.start();
        return proc;
    }

    @NonNull
    private String getSh() {
        if(sh == null) {
            sh = "/bin/sh";

            try {
                execAndGetOutput("ls");
            } catch (final Exception ex) {
                Log.w(LOG_TAG, "Calling " + sh + " failed", ex);
                sh = "/system/bin/sh";
            }

            Log.d(LOG_TAG, "Using sh: " + sh);
        }

        return sh;
    }
}
