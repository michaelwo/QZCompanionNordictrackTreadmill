package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.function.Consumer;

/**
 * Streams {@code logcat -s mono-stdout} in a daemon thread, emitting a {@link QZMetricPacket}
 * for each matched line. {@code mono-stdout} is the logcat tag emitted by the Xamarin/Mono
 * runtime for all {@code com.ifit.standalone} (iFit APK) metric changes — present on every
 * supported device.
 *
 * The stream is started lazily on the first {@link #read} call and restarts automatically
 * if the underlying logcat process exits.
 */
public class MonoStdoutMetricReader implements MetricReader {

    private static final String OWN_LOG_TAG = "QZ:Service";

    private static final String[] KPH_KEYWORDS   = { "Changed KPH", "Changed Actual KPH" };
    private static final String[] GRADE_KEYWORDS  = { "Changed Grade", "Changed Actual Grade",
                                                       "Changed Actual Incline", "Grade changed" };

    @FunctionalInterface
    public interface ProcessFactory { Process launch() throws IOException; }

    public static ProcessFactory factory = () -> Runtime.getRuntime().exec(
            new String[]{"logcat", "-s", "mono-stdout"});

    /** Called when {@link #streamLoop()} catches an IOException. Default is a no-op so tests
     *  can run without Android. The service overrides this to log via {@code Log.e()}. */
    public static volatile Consumer<Exception> onError = e -> {};

    /** Called for each raw logcat line that produced a packet. No-op by default;
     *  the service sets this to a logger when verbose mode is on. */
    public static volatile Consumer<String> onLine = s -> {};

    private volatile Consumer<QZMetricPacket> listener;
    private Thread readerThread;

    @Override
    public void read() {
        ensureRunning();
    }

    @Override
    public boolean subscribe(Consumer<QZMetricPacket> l) {
        this.listener = l;
        return true;
    }

    /**
     * Blocks until the reader thread terminates. Intended for tests that inject a finite
     * stream via {@link #factory} and need to drain it before asserting.
     */
    public void awaitStream() throws InterruptedException {
        if (readerThread != null) readerThread.join();
    }

    private synchronized void ensureRunning() {
        if (readerThread != null && readerThread.isAlive()) return;
        Thread t = new Thread(this::streamLoop);
        t.setDaemon(true);
        t.start();
        readerThread = t;
    }

    private void streamLoop() {
        try {
            Process p = factory.launch();
            try (BufferedReader br = new BufferedReader(new InputStreamReader(p.getInputStream()))) {
                String line;
                while ((line = br.readLine()) != null) {
                    if (!line.contains(OWN_LOG_TAG)) {
                        try { parseLine(line); }
                        catch (Exception e) { onError.accept(e); }
                    }
                }
            }
        } catch (IOException e) { onError.accept(e); }
    }

    private void parseLine(String line) {
        QZMetricPacket packet = null;
        if (containsAny(line, KPH_KEYWORDS)) {
            Float v = lastFloat(line); if (v != null) packet = new QZMetricPacket(QZMetricPacket.Metric.KPH, v);
        } else if (containsAny(line, GRADE_KEYWORDS)) {
            Float v = lastFloat(line); if (v != null) packet = new QZMetricPacket(QZMetricPacket.Metric.GRADE, v);
        } else if (line.contains("Changed Watts")) {
            Float v = lastFloat(line); if (v != null) packet = new QZMetricPacket(QZMetricPacket.Metric.WATTS, v);
        } else if (line.contains("Changed RPM")) {
            Float v = lastFloat(line); if (v != null) packet = new QZMetricPacket(QZMetricPacket.Metric.RPM, v);
        } else if (line.contains("Changed CurrentGear")) {
            Float v = lastFloat(line); if (v != null) packet = new QZMetricPacket(QZMetricPacket.Metric.CURRENT_GEAR, v);
        } else if (line.contains("Changed Resistance")) {
            Float v = lastFloat(line); if (v != null) packet = new QZMetricPacket(QZMetricPacket.Metric.RESISTANCE, v);
        } else if (line.contains("HeartRateDataUpdate")) {
            Float v = lastFloat(line); if (v != null) packet = new QZMetricPacket(QZMetricPacket.Metric.HEART_RATE, v);
        }
        if (packet != null) {
            onLine.accept(line);
            Consumer<QZMetricPacket> l = listener;
            if (l != null) l.accept(packet);
        }
    }

    private static boolean containsAny(String line, String[] keywords) {
        for (String kw : keywords) if (line.contains(kw)) return true;
        return false;
    }

    private static Float lastFloat(String line) {
        try {
            String[] parts = line.trim().split("\\s+");
            return Float.parseFloat(parts[parts.length - 1]);
        } catch (Exception ignored) {
            return null;
        }
    }
}
