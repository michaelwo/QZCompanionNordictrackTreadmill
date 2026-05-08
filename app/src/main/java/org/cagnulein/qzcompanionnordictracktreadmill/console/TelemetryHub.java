package org.cagnulein.qzcompanionnordictracktreadmill.console;

import android.content.Context;

import org.cagnulein.qzcompanionnordictracktreadmill.glassos.GlassOsTelemetryReader;
import org.cagnulein.qzcompanionnordictracktreadmill.telemetry.Telemetry;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;
import java.util.function.Consumer;

/**
 * Process-wide fanout wrapper for telemetry.
 *
 * The hub owns one active reader and fans its telemetry to QZ UDP output, device state,
 * and calibration. Production config tries GlassOS first on iFit2 and falls back to
 * mono-stdout for older iFit stacks.
 */
public final class TelemetryHub {

    public interface Subscription {
        void close();
    }

    private static final TelemetryHub SHARED =
            new TelemetryHub(new MonoStdoutTelemetryReader());

    private final List<TelemetryReader> readers;
    private final List<Consumer<Telemetry>> subscribers = new CopyOnWriteArrayList<>();
    private boolean started = false;
    private TelemetryReader activeReader = null;

    public TelemetryHub(TelemetryReader... readers) {
        this.readers = new ArrayList<>(Arrays.asList(readers));
        for (TelemetryReader reader : readers) {
            reader.subscribe(this::dispatch);
        }
    }

    public static TelemetryHub shared() {
        return SHARED;
    }

    public static synchronized void configure(Context context) {
        SHARED.configureReaders(
                new GlassOsTelemetryReader(context.getApplicationContext()),
                new MonoStdoutTelemetryReader());
    }

    private synchronized void configureReaders(TelemetryReader... newReaders) {
        if (started) return;
        readers.clear();
        readers.addAll(Arrays.asList(newReaders));
        for (TelemetryReader reader : newReaders) {
            reader.subscribe(this::dispatch);
        }
    }

    public Subscription subscribe(Consumer<Telemetry> subscriber) throws IOException {
        subscribers.add(subscriber);
        start();
        return () -> subscribers.remove(subscriber);
    }

    public synchronized void start() throws IOException {
        if (started) return;
        IOException lastError = null;
        for (TelemetryReader reader : readers) {
            try {
                reader.read();
                activeReader = reader;
                started = true;
                return;
            } catch (IOException e) {
                lastError = e;
            }
        }
        if (lastError != null) throw lastError;
        throw new IOException("No telemetry readers configured");
    }

    public int subscriberCount() {
        return subscribers.size();
    }

    public TelemetryReader activeReader() {
        return activeReader;
    }

    private void dispatch(Telemetry telemetry) {
        for (Consumer<Telemetry> subscriber : subscribers) {
            subscriber.accept(telemetry);
        }
    }
}
