package org.cagnulein.qzcompanionnordictracktreadmill.console;

import org.cagnulein.qzcompanionnordictracktreadmill.telemetry.Telemetry;

import java.io.IOException;
import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;
import java.util.function.Consumer;

/**
 * Fanout wrapper for the single mono-stdout telemetry stream.
 *
 * QZ UDP output, DeviceController, and calibration can subscribe without each starting their
 * own logcat reader. The underlying reader is started lazily and kept alive for process lifetime.
 */
public final class MonoStdoutTelemetryHub {

    public interface Subscription {
        void close();
    }

    private static final MonoStdoutTelemetryHub SHARED =
            new MonoStdoutTelemetryHub(new MonoStdoutTelemetryReader());

    private final TelemetryReader reader;
    private final List<Consumer<Telemetry>> subscribers = new CopyOnWriteArrayList<>();
    private boolean started = false;

    public MonoStdoutTelemetryHub(TelemetryReader reader) {
        this.reader = reader;
        this.reader.subscribe(this::dispatch);
    }

    public static MonoStdoutTelemetryHub shared() {
        return SHARED;
    }

    public Subscription subscribe(Consumer<Telemetry> subscriber) throws IOException {
        subscribers.add(subscriber);
        start();
        return () -> subscribers.remove(subscriber);
    }

    public synchronized void start() throws IOException {
        if (started) return;
        reader.read();
        started = true;
    }

    public int subscriberCount() {
        return subscribers.size();
    }

    private void dispatch(Telemetry telemetry) {
        for (Consumer<Telemetry> subscriber : subscribers) {
            subscriber.accept(telemetry);
        }
    }
}
