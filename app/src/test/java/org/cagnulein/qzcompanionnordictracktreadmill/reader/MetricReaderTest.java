package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MonoStdoutMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.QZMetricPacket;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.List;

public class MetricReaderTest {

    private static final float DELTA = 0.01f;

    private static InputStream asStream(String text) {
        return new ByteArrayInputStream(text.getBytes());
    }

    private static Process fakeProcess(String output) {
        return new Process() {
            public InputStream  getInputStream()  { return asStream(output); }
            public int          waitFor()         { return 0; }
            public OutputStream getOutputStream() { return null; }
            public InputStream  getErrorStream()  { return asStream(""); }
            public int          exitValue()       { return 0; }
            public void         destroy()         {}
        };
    }

    @Before
    public void resetStaticState() {
        MonoStdoutMetricReader.factory = () -> fakeProcess("");
        MonoStdoutMetricReader.onError = e -> {};
    }

    @After
    public void restoreStaticState() {
        MonoStdoutMetricReader.factory = () -> Runtime.getRuntime().exec(
                new String[]{"logcat", "-s", "mono-stdout"});
        MonoStdoutMetricReader.onError = e -> {};
    }

    // ── MonoStdoutMetricReader ────────────────────────────────────────────────

    @Test
    public void monoStdout_parsesAllMetrics() throws IOException, InterruptedException {
        MonoStdoutMetricReader.factory = () -> fakeProcess(
            "V/mono-stdout(2174): [Trace:FitPro] Changed KPH to: 12.11\n" +
            "V/mono-stdout(2174): [Trace:FitPro] Changed Grade to: 5\n" +
            "V/mono-stdout(2174): [Trace:FitPro] Changed Resistance to: 13\n" +
            "V/mono-stdout(2174): [Trace:FitPro] Changed Watts to: 128\n" +
            "V/mono-stdout(2174): [Trace:FitPro] Changed RPM to: 43\n"
        );
        List<QZMetricPacket> received = new ArrayList<>();
        MonoStdoutMetricReader reader = new MonoStdoutMetricReader();
        reader.subscribe(received::add);
        reader.read();
        reader.awaitStream();

        assertEquals(5, received.size());
        assertEquals(QZMetricPacket.Metric.KPH,        received.get(0).metric);
        assertEquals(12.11f, received.get(0).value, DELTA);
        assertEquals(QZMetricPacket.Metric.GRADE,      received.get(1).metric);
        assertEquals(5f,     received.get(1).value, DELTA);
        assertEquals(QZMetricPacket.Metric.RESISTANCE, received.get(2).metric);
        assertEquals(13f,    received.get(2).value, DELTA);
        assertEquals(QZMetricPacket.Metric.WATTS,      received.get(3).metric);
        assertEquals(128f,   received.get(3).value, DELTA);
        assertEquals(QZMetricPacket.Metric.RPM,        received.get(4).metric);
        assertEquals(43f,    received.get(4).value, DELTA);
    }

    @Test
    public void monoStdout_parsesActualInclineKeyword() throws IOException, InterruptedException {
        MonoStdoutMetricReader.factory = () -> fakeProcess(
            "V/mono-stdout(2174): [Trace:FitPro] Changed Actual Incline to: 3.5\n"
        );
        List<QZMetricPacket> received = new ArrayList<>();
        MonoStdoutMetricReader reader = new MonoStdoutMetricReader();
        reader.subscribe(received::add);
        reader.read();
        reader.awaitStream();

        assertEquals(1, received.size());
        assertEquals(QZMetricPacket.Metric.GRADE, received.get(0).metric);
        assertEquals(3.5f, received.get(0).value, DELTA);
    }

    @Test
    public void monoStdout_parsesHeartRate() throws IOException, InterruptedException {
        MonoStdoutMetricReader.factory = () -> fakeProcess(
            "V/mono-stdout(2174): [Trace:FitPro] HeartRateDataUpdate 72\n"
        );
        List<QZMetricPacket> received = new ArrayList<>();
        MonoStdoutMetricReader reader = new MonoStdoutMetricReader();
        reader.subscribe(received::add);
        reader.read();
        reader.awaitStream();

        assertEquals(1, received.size());
        assertEquals(QZMetricPacket.Metric.HEART_RATE, received.get(0).metric);
        assertEquals(72f, received.get(0).value, DELTA);
    }

    @Test
    public void monoStdout_filtersOwnLogTag() throws IOException, InterruptedException {
        MonoStdoutMetricReader.factory = () -> fakeProcess(
            "QZ:Service Changed KPH 99.9\n" +
            "V/mono-stdout(2174): [Trace:FitPro] Changed KPH to: 12.11\n"
        );
        List<QZMetricPacket> received = new ArrayList<>();
        MonoStdoutMetricReader reader = new MonoStdoutMetricReader();
        reader.subscribe(received::add);
        reader.read();
        reader.awaitStream();

        assertEquals(1, received.size());
        assertEquals(QZMetricPacket.Metric.KPH, received.get(0).metric);
        assertEquals(12.11f, received.get(0).value, DELTA);
    }
}
