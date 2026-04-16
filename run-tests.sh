#!/bin/bash
# Run unit tests without Android SDK (pure Java + JUnit 4)
set -e

SRC=app/src/main/java/org/cagnulein/qzcompanionnordictracktreadmill
TEST=app/src/test/java/org/cagnulein/qzcompanionnordictracktreadmill
GRADLE_LIB=/root/.gradle/wrapper/dists/gradle-8.9-bin/90cnw93cvbtalezasaz0blq0a/gradle-8.9/lib
JUNIT=$GRADLE_LIB/junit-4.13.2.jar
HAMCREST=$GRADLE_LIB/hamcrest-core-1.3.jar
OUT=/tmp/qztest-classes

rm -rf $OUT && mkdir -p $OUT

# Stubs for Android-dependent classes
# QZService stub only needs ifit_v2; lastSnapshot lives on Device.
mkdir -p /tmp/stubs/org/cagnulein/qzcompanionnordictracktreadmill
cat > /tmp/stubs/org/cagnulein/qzcompanionnordictracktreadmill/QZService.java << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
public class QZService {
    public boolean ifit_v2 = false;
    public static void sendBroadcast(String msg) {}
}
EOF
cat > /tmp/stubs/org/cagnulein/qzcompanionnordictracktreadmill/MainActivity.java << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
public class MainActivity {
    public static void sendCommand(String cmd) {}
}
EOF

cat > /tmp/stubs/org/cagnulein/qzcompanionnordictracktreadmill/ShellRuntime.java << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
import java.io.IOException;
import java.io.InputStream;
public class ShellRuntime implements org.cagnulein.qzcompanionnordictracktreadmill.reader.Shell {
    public InputStream execAndGetOutput(String command) throws IOException { return Runtime.getRuntime().exec(command).getInputStream(); }
    public Process exec(String command) throws IOException { return Runtime.getRuntime().exec(command); }
}
EOF

cat > /tmp/stubs/org/cagnulein/qzcompanionnordictracktreadmill/MyAccessibilityService.java << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
public class MyAccessibilityService {
    public static void performSwipe(int x1, int y1, int x2, int y2, int duration) {}
}
EOF

STUBS=/tmp/stubs/org/cagnulein/qzcompanionnordictracktreadmill

# Compile production sources (no Android imports needed)
javac -d $OUT -cp $JUNIT:$HAMCREST \
  $STUBS/QZService.java \
  $STUBS/MainActivity.java \
  $SRC/reader/MetricSnapshot.java \
  $SRC/reader/MetricReader.java \
  $SRC/reader/Shell.java \
  $SRC/reader/CatFileMetricReader.java \
  $SRC/reader/LogcatDumpMetricReader.java \
  $SRC/reader/DirectLogcatMetricReader.java \
  $SRC/reader/TailGrepMetricReader.java \
  $SRC/ocr/OcrBlock.java \
  $SRC/ocr/Ocr.java \
  $STUBS/MyAccessibilityService.java \
  $STUBS/ShellRuntime.java \
  $SRC/device/Device.java \
  $SRC/device/Slider.java \
  $SRC/device/BikeDevice.java \
  $SRC/device/TreadmillDevice.java \
  $SRC/device/OtherDevice.java \
  $SRC/device/T65sDevice.java \
  $SRC/device/S22iDevice.java \
  $SRC/device/S22iNoAdbDevice.java \
  $SRC/device/S22iNtex02117Device.java \
  $SRC/device/S22iNtex02121Device.java \
  $SRC/device/S27iDevice.java \
  $SRC/device/S40Device.java \
  $SRC/device/S15iDevice.java \
  $SRC/device/X11iDevice.java \
  $SRC/device/X14iDevice.java \
  $SRC/device/X22iDevice.java \
  $SRC/device/X22iNoAdbDevice.java \
  $SRC/device/X22iV2Device.java \
  $SRC/device/X32iDevice.java \
  $SRC/device/X32iNtl39019Device.java \
  $SRC/device/X32iNtl39221Device.java \
  $SRC/device/X9iDevice.java \
  $SRC/device/C1750Device.java \
  $SRC/device/C1750_2020Device.java \
  $SRC/device/C1750_2020KphDevice.java \
  $SRC/device/C1750_2021Device.java \
  $SRC/device/C1750MphMinus3GradeDevice.java \
  $SRC/device/C1750Ntl14122Device.java \
  $SRC/device/Nordictrack2450Device.java \
  $SRC/device/Nordictrack2950Device.java \
  $SRC/device/Nordictrack2950MaxSpeed22Device.java \
  $SRC/device/Ntex71021Device.java \
  $SRC/device/Elite900Device.java \
  $SRC/device/Elite1000Device.java \
  $SRC/device/Exp7iDevice.java \
  $SRC/device/Proform2000Device.java \
  $SRC/device/ProformCarbonC10Device.java \
  $SRC/device/ProformCarbonE7Device.java \
  $SRC/device/ProformCarbonT14Device.java \
  $SRC/device/ProformPro9000Device.java \
  $SRC/device/ProformStudioBikePro22Device.java \
  $SRC/device/Se9iEllipticalDevice.java \
  $SRC/device/T85sDevice.java \
  $SRC/device/T95sDevice.java \
  $SRC/device/Tdf10Device.java \
  $SRC/device/Tdf10InclinationDevice.java \
  $SRC/device/DeviceRegistry.java \
  $SRC/dispatch/CommandDispatcher.java \
  $SRC/dispatch/UDPReceiveLoop.java

# Compile tests
javac -d $OUT -cp $OUT:$JUNIT:$HAMCREST \
  $TEST/OcrTest.java \
  $TEST/CommandDispatcherTest.java \
  $TEST/BikeDeviceTest.java \
  $TEST/TreadmillDeviceTest.java \
  $TEST/MetricReaderTest.java \
  $TEST/UdpPipelineTest.java \
  $TEST/ZwiftRideSimulationTest.java

# Run tests
java -cp $OUT:$JUNIT:$HAMCREST org.junit.runner.JUnitCore \
  org.cagnulein.qzcompanionnordictracktreadmill.OcrTest \
  org.cagnulein.qzcompanionnordictracktreadmill.CommandDispatcherTest \
  org.cagnulein.qzcompanionnordictracktreadmill.BikeDeviceTest \
  org.cagnulein.qzcompanionnordictracktreadmill.TreadmillDeviceTest \
  org.cagnulein.qzcompanionnordictracktreadmill.MetricReaderTest \
  org.cagnulein.qzcompanionnordictracktreadmill.UdpPipelineTest \
  org.cagnulein.qzcompanionnordictracktreadmill.ZwiftRideSimulationTest
