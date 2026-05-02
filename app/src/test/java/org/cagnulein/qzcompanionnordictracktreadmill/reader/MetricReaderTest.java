package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MonoStdoutMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

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
        MonoStdoutMetricReader reader = new MonoStdoutMetricReader();
        reader.read();
        MetricSnapshot m = reader.awaitCurrentStream();
        assertEquals(12.11f, m.speedKmh,      DELTA);
        assertEquals(5f,     m.inclinePct,    DELTA);
        assertEquals(13f,    m.resistanceLvl, DELTA);
        assertEquals(128f,   m.watts,         DELTA);
        assertEquals(43f,    m.cadenceRpm,    DELTA);
    }

    @Test
    public void monoStdout_parsesActualInclineKeyword() throws IOException, InterruptedException {
        MonoStdoutMetricReader.factory = () -> fakeProcess(
            "V/mono-stdout(2174): [Trace:FitPro] Changed Actual Incline to: 3.5\n"
        );
        MonoStdoutMetricReader reader = new MonoStdoutMetricReader();
        reader.read();
        MetricSnapshot m = reader.awaitCurrentStream();
        assertEquals(3.5f, m.inclinePct, DELTA);
    }

    @Test
    public void monoStdout_parsesHeartRate() throws IOException, InterruptedException {
        MonoStdoutMetricReader.factory = () -> fakeProcess(
            "V/mono-stdout(2174): [Trace:FitPro] HeartRateDataUpdate 72\n"
        );
        MonoStdoutMetricReader reader = new MonoStdoutMetricReader();
        reader.read();
        MetricSnapshot m = reader.awaitCurrentStream();
        assertEquals(72f, m.heartRate, DELTA);
    }

    @Test
    public void monoStdout_filtersOwnLogTag() throws IOException, InterruptedException {
        MonoStdoutMetricReader.factory = () -> fakeProcess(
            "QZ:Service Changed KPH 99.9\n" +
            "V/mono-stdout(2174): [Trace:FitPro] Changed KPH to: 12.11\n"
        );
        MonoStdoutMetricReader reader = new MonoStdoutMetricReader();
        reader.read();
        MetricSnapshot m = reader.awaitCurrentStream();
        assertEquals(12.11f, m.speedKmh, DELTA);
    }
}
