package org.cagnulein.qzcompanionnordictracktreadmill;

import android.util.Log;

import androidx.annotation.NonNull;

import java.io.IOException;
import java.io.InputStream;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ShellRuntime implements Shell {
    private static final String LOG_TAG = "QZ:Shell";

    /**
     * Single daemon thread shared across all ShellRuntime instances for exit-code checking.
     * Previously a new thread was spawned per exec() call — at 10 Hz with ~14 commands per
     * cycle that created ~140 threads/second, exhausting Android's per-process thread limit
     * well within a 60-minute ride.
     *
     * Checks are serialized on this thread: drain stderr (prevents the child blocking on a
     * full pipe buffer), then waitFor().
     */
    private static final ExecutorService EXIT_CHECKER =
            Executors.newSingleThreadExecutor(r -> {
                Thread t = new Thread(r, "ShellRuntime-exit-check");
                t.setDaemon(true);
                return t;
            });

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
        final String c = command;
        EXIT_CHECKER.submit(() -> {
            // Drain stderr before waitFor() — if the child writes to stderr and the pipe
            // buffer fills (~64 KB), the process blocks and waitFor() hangs indefinitely.
            try (InputStream err = proc.getErrorStream()) {
                byte[] buf = new byte[4096];
                while (err.read(buf) != -1) {}
            } catch (IOException ignored) {}
            try {
                int exit = proc.waitFor();
                if (exit != 0) {
                    Log.e(LOG_TAG, "Command failed (exit " + exit + "): " + c
                            + (c.contains("input swipe") ? " — check INJECT_EVENTS permission" : ""));
                }
            } catch (InterruptedException ignored) {
                Thread.currentThread().interrupt();
            }
        });
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
