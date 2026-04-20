#!/bin/bash
# Run pure-JVM unit tests without Android SDK or Gradle.
# Excludes Robolectric tests (ZwiftRideRobolectricTest, CommandListenerServiceTest,
# MetricReaderBroadcastingServiceTest) which require the Android runtime.
set -e

SRC=app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill
TEST=app/src/test/java/org/cagnulein/qzcompanionnordictracktreadmill
JUNIT=/usr/share/java/junit4.jar
HAMCREST=/usr/share/java/hamcrest-all.jar
OUT=/tmp/qztest-classes

rm -rf "$OUT" && mkdir -p "$OUT"

# ── Stubs for Android-dependent classes ──────────────────────────────────────
STUB_DIR=/tmp/qz-stubs/org/cagnulein/qzcompanionnordictracktreadmill
mkdir -p "$STUB_DIR"

cat > "$STUB_DIR/MainActivity.java" << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
public class MainActivity { public static void sendCommand(String cmd) {} }
EOF

cat > "$STUB_DIR/MyAccessibilityService.java" << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
public class MyAccessibilityService {
    public static void performSwipe(int x1, int y1, int x2, int y2, int duration) {}
}
EOF

cat > "$STUB_DIR/ShellRuntime.java" << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
import java.io.IOException;
import java.io.InputStream;
public class ShellRuntime implements org.cagnulein.qzcompanionnordictracktreadmill.reader.Shell {
    public InputStream execAndGetOutput(String cmd) throws IOException { return Runtime.getRuntime().exec(cmd).getInputStream(); }
    public Process exec(String cmd) throws IOException { return Runtime.getRuntime().exec(cmd); }
}
EOF

cat > "$STUB_DIR/SharedPreferences.java" << 'EOF'
package android.content;
public interface SharedPreferences {
    String getString(String key, String defValue);
    int getInt(String key, int defValue);
    float getFloat(String key, float defValue);
    boolean getBoolean(String key, boolean defValue);
    boolean contains(String key);
    long getLong(String key, long defValue);
    interface Editor {
        Editor putString(String key, String value);
        Editor putInt(String key, int value);
        Editor putFloat(String key, float value);
        Editor putBoolean(String key, boolean value);
        Editor putLong(String key, long value);
        void apply();
        boolean commit();
    }
    Editor edit();
}
EOF

# ── Compile production sources ────────────────────────────────────────────────
find "$SRC/reader" "$SRC/device" "$SRC/calibration" "$SRC/dispatch" "$SRC/ocr" \
     -name "*.java" > /tmp/qz-sources.txt
echo "$STUB_DIR/MainActivity.java"           >> /tmp/qz-sources.txt
echo "$STUB_DIR/MyAccessibilityService.java" >> /tmp/qz-sources.txt
echo "$STUB_DIR/ShellRuntime.java"           >> /tmp/qz-sources.txt
echo "$STUB_DIR/SharedPreferences.java"      >> /tmp/qz-sources.txt

javac -encoding UTF-8 -d "$OUT" -cp "$JUNIT:$HAMCREST" @/tmp/qz-sources.txt

# ── Compile tests (pure-JVM only) ─────────────────────────────────────────────
javac -encoding UTF-8 -d "$OUT" -cp "$OUT:$JUNIT:$HAMCREST" \
  "$TEST/MetricReaderTest.java" \
  "$TEST/OcrTest.java" \
  "$TEST/CommandDispatcherTest.java" \
  "$TEST/UdpPipelineTest.java" \
  "$TEST/ZwiftRideSimulationTest.java" \
  "$TEST/device/BikeDeviceTest.java" \
  "$TEST/device/TreadmillDeviceTest.java" \
  "$TEST/device/HillyRouteReplayTest.java"

# ── Run ───────────────────────────────────────────────────────────────────────
java -cp "$OUT:$JUNIT:$HAMCREST" org.junit.runner.JUnitCore \
  org.cagnulein.qzcompanionnordictracktreadmill.MetricReaderTest \
  org.cagnulein.qzcompanionnordictracktreadmill.OcrTest \
  org.cagnulein.qzcompanionnordictracktreadmill.CommandDispatcherTest \
  org.cagnulein.qzcompanionnordictracktreadmill.UdpPipelineTest \
  org.cagnulein.qzcompanionnordictracktreadmill.ZwiftRideSimulationTest \
  org.cagnulein.qzcompanionnordictracktreadmill.device.BikeDeviceTest \
  org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDeviceTest \
  org.cagnulein.qzcompanionnordictracktreadmill.device.HillyRouteReplayTest
