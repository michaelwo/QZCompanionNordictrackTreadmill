package org.cagnulein.qzcompanionnordictracktreadmill;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.BikeMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.CatFileMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.DirectLogcatMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.LogcatDumpMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.Shell;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.TailGrepIfitV2MetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.TailGrepMetricReader;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.HashMap;
import java.util.Map;

public class MetricReaderTest {

    // ── helpers ───────────────────────────────────────────────────────────────

    private static InputStream asStream(String text) {
        return new ByteArrayInputStream(text.getBytes());
    }

    private static final float DELTA = 0.01f;

    /** Shell that returns the same response for every command. */
    private static Shell fixedShell(String response) {
        return new Shell() {
            public InputStream execAndGetOutput(String cmd) { return asStream(response); }
            public Process exec(String cmd) { return null; }
        };
    }

    /** Shell that routes by substring match on the command. */
    private static Shell routingShell(Map<String, String> responses) {
        return new Shell() {
            public InputStream execAndGetOutput(String cmd) {
                for (Map.Entry<String, String> e : responses.entrySet())
                    if (cmd.contains(e.getKey())) return asStream(e.getValue());
                return asStream("");
            }
            public Process exec(String cmd) { return null; }
        };
    }

    /** Minimal fake Process whose stdout contains {@code output}. */
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
        LogcatDumpMetricReader.adbSender = cmd -> {};
        DirectLogcatMetricReader.factory = () -> fakeProcess("");
    }

    @After
    public void restoreStaticState() {
        LogcatDumpMetricReader.adbSender = MainActivity::sendCommand;
        DirectLogcatMetricReader.factory = () -> Runtime.getRuntime().exec("logcat -b all -d");
    }

    // ── CatFileMetricReader ───────────────────────────────────────────────────

    @Test
    public void catFile_parsesAllMetrics() throws IOException {
        Shell shell = fixedShell(
            "Changed KPH 8.5\n" +
            "Changed Grade 3.0\n" +
            "Changed Watts 120\n" +
            "Changed RPM 85\n" +
            "Changed CurrentGear 5\n" +
            "Changed Resistance 10\n" +
            "HeartRateDataUpdate 72\n"
        );
        MetricSnapshot m = new CatFileMetricReader().read("any.log", shell);
        assertEquals(8.5f,  m.speedKmh,      DELTA);
        assertEquals(3.0f,  m.inclinePct,    DELTA);
        assertEquals(120f,  m.watts,         DELTA);
        assertEquals(85f,   m.cadenceRpm,    DELTA);
        assertEquals(5f,    m.gearLevel,     DELTA);
        assertEquals(10f,   m.resistanceLvl, DELTA);
        assertEquals(72f,   m.heartRate,     DELTA);
    }

    @Test
    public void catFile_acceptsKphChangedVariant() throws IOException {
        MetricSnapshot m = new CatFileMetricReader().read("any.log", fixedShell("Kph changed 6.0\n"));
        assertEquals(6.0f, m.speedKmh, DELTA);
    }

    @Test
    public void catFile_acceptsGradeChangedVariant() throws IOException {
        MetricSnapshot m = new CatFileMetricReader().read("any.log", fixedShell("Grade changed 2.5\n"));
        assertEquals(2.5f, m.inclinePct, DELTA);
    }

    @Test
    public void catFile_acceptsWattsChangedVariant() throws IOException {
        MetricSnapshot m = new CatFileMetricReader().read("any.log", fixedShell("Watts changed 95\n"));
        assertEquals(95f, m.watts, DELTA);
    }

    @Test
    public void catFile_returnsLastMatchWhenMultipleLines() throws IOException {
        MetricSnapshot m = new CatFileMetricReader().read("any.log", fixedShell("Changed KPH 5.0\nChanged KPH 9.0\n"));
        assertEquals(9.0f, m.speedKmh, DELTA);
    }

    @Test
    public void catFile_emptyFile_allFieldsNull() throws IOException {
        MetricSnapshot m = new CatFileMetricReader().read("any.log", fixedShell(""));
        assertNull(m.speedKmh);
        assertNull(m.inclinePct);
        assertNull(m.watts);
    }

    // ── LogcatDumpMetricReader ────────────────────────────────────────────────

    @Test
    public void logcatDump_parsesStandardLines() throws IOException {
        MetricSnapshot m = new LogcatDumpMetricReader().read("any.log",
            fixedShell("Changed KPH 7.5\nChanged Grade 1.5\n"));
        assertEquals(7.5f, m.speedKmh,   DELTA);
        assertEquals(1.5f, m.inclinePct, DELTA);
    }

    @Test
    public void logcatDump_parsesActualVariant() throws IOException {
        MetricSnapshot m = new LogcatDumpMetricReader().read("any.log",
            fixedShell("Changed Actual KPH 7.5\nChanged Actual Grade 2.0\n"));
        assertEquals(7.5f, m.speedKmh,   DELTA);
        assertEquals(2.0f, m.inclinePct, DELTA);
    }

    @Test
    public void logcatDump_sendsAdbCommandBeforeReading() throws IOException {
        String[] captured = {null};
        LogcatDumpMetricReader.adbSender = cmd -> captured[0] = cmd;
        new LogcatDumpMetricReader().read("any.log", fixedShell(""));
        assertEquals("logcat -b all -d -t 500 > /sdcard/logcat.log", captured[0]);
    }

    // ── DirectLogcatMetricReader ──────────────────────────────────────────────

    @Test
    public void directLogcat_parsesAllMetrics() throws IOException {
        DirectLogcatMetricReader.factory = () -> fakeProcess(
            "Changed KPH 9.0\n" +
            "Changed Grade 4.0\n" +
            "Changed Watts 200\n" +
            "Changed RPM 90\n" +
            "Changed CurrentGear 3\n" +
            "Changed Resistance 8\n"
        );
        MetricSnapshot m = new DirectLogcatMetricReader().read("any.log", fixedShell(""));
        assertEquals(9.0f, m.speedKmh,      DELTA);
        assertEquals(4.0f, m.inclinePct,    DELTA);
        assertEquals(200f, m.watts,         DELTA);
        assertEquals(90f,  m.cadenceRpm,    DELTA);
        assertEquals(3f,   m.gearLevel,     DELTA);
        assertEquals(8f,   m.resistanceLvl, DELTA);
    }

    @Test
    public void directLogcat_parsesActualVariant() throws IOException {
        DirectLogcatMetricReader.factory = () -> fakeProcess(
            "Changed Actual KPH 5.0\nChanged Actual Grade 1.0\n"
        );
        MetricSnapshot m = new DirectLogcatMetricReader().read("any.log", fixedShell(""));
        assertEquals(5.0f, m.speedKmh,   DELTA);
        assertEquals(1.0f, m.inclinePct, DELTA);
    }

    @Test
    public void directLogcat_parsesGradeChangedVariant() throws IOException {
        DirectLogcatMetricReader.factory = () -> fakeProcess("Grade changed 2.0\n");
        MetricSnapshot m = new DirectLogcatMetricReader().read("any.log", fixedShell(""));
        assertEquals(2.0f, m.inclinePct, DELTA);
    }

    @Test
    public void directLogcat_filtersOwnLogTag() throws IOException {
        DirectLogcatMetricReader.factory = () -> fakeProcess(
            "QZ:Service Changed KPH 99.9\n" +
            "Changed KPH 6.0\n"
        );
        MetricSnapshot m = new DirectLogcatMetricReader().read("any.log", fixedShell(""));
        assertEquals(6.0f, m.speedKmh, DELTA);
    }

    // ── TailGrepMetricReader ──────────────────────────────────────────────────

    @Test
    public void tailGrep_findsSpeedAndInclineOnFirstAttempt() throws IOException {
        Map<String, String> r = new HashMap<>();
        r.put("Changed KPH",   "Changed KPH 8.0");
        r.put("Changed Grade", "Changed Grade 2.0");
        MetricSnapshot m = new TailGrepMetricReader().read("f.log", routingShell(r));
        assertEquals(8.0f, m.speedKmh,   DELTA);
        assertEquals(2.0f, m.inclinePct, DELTA);
    }

    @Test
    public void tailGrep_fallsBackToSecondCommandWhenFirstEmpty() throws IOException {
        int[] calls = {0};
        Shell shell = new Shell() {
            public InputStream execAndGetOutput(String cmd) {
                if (cmd.contains("Changed KPH"))
                    return asStream(++calls[0] == 1 ? "" : "Changed KPH 5.0");
                return asStream("");
            }
            public Process exec(String cmd) { return null; }
        };
        MetricSnapshot m = new TailGrepMetricReader().read("f.log", shell);
        assertEquals(5.0f, m.speedKmh, DELTA);
        assertEquals(2, calls[0]);
    }

    @Test
    public void tailGrep_fallsBackToThirdCommandWhenSecondEmpty() throws IOException {
        int[] calls = {0};
        Shell shell = new Shell() {
            public InputStream execAndGetOutput(String cmd) {
                if (cmd.contains("Changed KPH"))
                    return asStream(++calls[0] < 3 ? "" : "Changed KPH 4.0");
                return asStream("");
            }
            public Process exec(String cmd) { return null; }
        };
        MetricSnapshot m = new TailGrepMetricReader().read("f.log", shell);
        assertEquals(4.0f, m.speedKmh, DELTA);
        assertEquals(3, calls[0]);
    }

    @Test
    public void tailGrep_ifitV2_usesSecondToLastTokenAndInclineKeyword() throws IOException {
        // ifit_v2 log lines have the value at b.length-2 (a unit token follows)
        Map<String, String> r = new HashMap<>();
        r.put("Changed KPH", "Changed KPH 8.0 kmh");
        r.put("INCLINE",     "Changed INCLINE 3.0 pct");
        MetricSnapshot m = new TailGrepIfitV2MetricReader().read("f.log", routingShell(r));
        assertEquals(8.0f, m.speedKmh,   DELTA);
        assertEquals(3.0f, m.inclinePct, DELTA);
    }

    @Test
    public void tailGrep_emptyLog_allFieldsNull() throws IOException {
        MetricSnapshot m = new TailGrepMetricReader().read("f.log", fixedShell(""));
        assertNull(m.speedKmh);
        assertNull(m.inclinePct);
        assertNull(m.watts);
    }

    @Test
    public void tailGrep_truncatesFileAfter1200Cycles() throws IOException {
        String[] truncateCmd = {null};
        Shell shell = new Shell() {
            public InputStream execAndGetOutput(String cmd) { return asStream(""); }
            public Process exec(String cmd) { truncateCmd[0] = cmd; return null; }
        };
        TailGrepMetricReader.truncateCounter = 0;
        TailGrepMetricReader reader = new TailGrepMetricReader();
        for (int i = 0; i <= 1201; i++) reader.read("my.log", shell);
        assertNotNull("truncate should have been called", truncateCmd[0]);
        assertTrue(truncateCmd[0].contains("truncate -s0"));
        assertTrue(truncateCmd[0].contains("my.log"));
    }

    // ── BikeMetricReader ──────────────────────────────────────────────────────

    @Test
    public void bikeReader_parsesInclineAndBikeMetrics() throws IOException {
        Map<String, String> r = new HashMap<>();
        r.put("Changed Grade",       "Changed Grade 4.0");
        r.put("Changed Watts",       "Changed Watts 150");
        r.put("Changed RPM",         "Changed RPM 80");
        r.put("Changed CurrentGear", "Changed CurrentGear 3");
        r.put("Changed Resistance",  "Changed Resistance 12");
        MetricSnapshot m = new BikeMetricReader().read("f.log", routingShell(r));
        assertEquals(4.0f,  m.inclinePct,    DELTA);
        assertEquals(150f,  m.watts,         DELTA);
        assertEquals(80f,   m.cadenceRpm,    DELTA);
        assertEquals(3f,    m.gearLevel,     DELTA);
        assertEquals(12f,   m.resistanceLvl, DELTA);
        assertNull(m.speedKmh);
    }

    @Test
    public void bikeReader_neverSearchesForKph() throws IOException {
        boolean[] kphQueried = {false};
        Shell shell = new Shell() {
            public InputStream execAndGetOutput(String cmd) {
                if (cmd.contains("KPH")) kphQueried[0] = true;
                return asStream("");
            }
            public Process exec(String cmd) { return null; }
        };
        new BikeMetricReader().read("f.log", shell);
        assertFalse("BikeMetricReader must not search for 'Changed KPH'", kphQueried[0]);
    }

    @Test
    public void bikeReader_emptyLog_speedKphRemainsNull() throws IOException {
        MetricSnapshot m = new BikeMetricReader().read("f.log", fixedShell(""));
        assertNull(m.speedKmh);
    }
}
