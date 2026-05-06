package org.cagnulein.qzcompanionnordictracktreadmill.console;

import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricPacket;

import java.io.IOException;
import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;
import java.util.function.Consumer;

/**
 * Fanout wrapper for the single mono-stdout metric stream.
 *
 * QZ telemetry, DeviceController, and calibration can subscribe without each starting their
 * own logcat reader. The underlying reader is started lazily and kept alive for process lifetime.
 */
public final class MonoStdoutMetricHub {

    public interface Subscription {
        void close();
    }

    private static final MonoStdoutMetricHub SHARED =
            new MonoStdoutMetricHub(new MonoStdoutMetricReader());

    private final MetricReader reader;
    private final List<Consumer<QZMetricPacket>> subscribers = new CopyOnWriteArrayList<>();
    private boolean started = false;

    public MonoStdoutMetricHub(MetricReader reader) {
        this.reader = reader;
        this.reader.subscribe(this::dispatch);
    }

    public static MonoStdoutMetricHub shared() {
        return SHARED;
    }

    public Subscription subscribe(Consumer<QZMetricPacket> subscriber) throws IOException {
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

    private void dispatch(QZMetricPacket packet) {
        for (Consumer<QZMetricPacket> subscriber : subscribers) {
            subscriber.accept(packet);
        }
    }
}
