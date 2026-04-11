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
# QZService stub only needs ifit_v2; lastSnapshot moved to DeviceState.
cat > /tmp/QZServiceStub.java << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
class QZService {
    boolean ifit_v2 = false;
    static void sendBroadcast(String msg) {}
}
EOF

cat > /tmp/MainActivityStub.java << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
class MainActivity {
    static void sendCommand(String cmd) {}
}
EOF

cat > /tmp/ShellRuntimeStub.java << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
import java.io.IOException;
import java.io.InputStream;
class ShellRuntime implements Shell {
    public InputStream execAndGetOutput(String command) throws IOException { return Runtime.getRuntime().exec(command).getInputStream(); }
    public Process exec(String command) throws IOException { return Runtime.getRuntime().exec(command); }
}
EOF

cat > /tmp/MyAccessibilityServiceStub.java << 'EOF'
package org.cagnulein.qzcompanionnordictracktreadmill;
class MyAccessibilityService {
    static void performSwipe(int x1, int y1, int x2, int y2, int duration) {}
}
EOF

# Compile production sources (no Android imports needed)
javac -d $OUT -cp $JUNIT:$HAMCREST \
  /tmp/QZServiceStub.java \
  /tmp/MainActivityStub.java \
  /tmp/ShellRuntimeStub.java \
  /tmp/MyAccessibilityServiceStub.java \
  $SRC/MetricSnapshot.java \
  $SRC/DeviceState.java \
  $SRC/DeviceRegistry.java \
  $SRC/MetricReader.java \
  $SRC/Shell.java \
  $SRC/Device.java \
  $SRC/BikeDevice.java \
  $SRC/TreadmillDevice.java \
  $SRC/CatFileMetricReader.java \
  $SRC/LogcatDumpMetricReader.java \
  $SRC/DirectLogcatMetricReader.java \
  $SRC/TailGrepMetricReader.java \
  $SRC/OcrParser.java \
  $SRC/CommandDispatcher.java \
  $SRC/T65sDevice.java \
  $SRC/OtherDevice.java \
  $SRC/S22iDevice.java \
  $SRC/S22iNtex02117Device.java \
  $SRC/S22iNtex02121Device.java \
  $SRC/S27iDevice.java \
  $SRC/S40Device.java \
  $SRC/S15iDevice.java \
  $SRC/X11iDevice.java \
  $SRC/X14iDevice.java \
  $SRC/X22iDevice.java \
  $SRC/X22iNoAdbDevice.java \
  $SRC/X22iV2Device.java \
  $SRC/X32iDevice.java \
  $SRC/X32iNtl39019Device.java \
  $SRC/X32iNtl39221Device.java \
  $SRC/X9iDevice.java \
  $SRC/C1750Device.java \
  $SRC/C1750_2020Device.java \
  $SRC/C1750_2020KphDevice.java \
  $SRC/C1750_2021Device.java \
  $SRC/C1750MphMinus3GradeDevice.java \
  $SRC/C1750Ntl14122Device.java \
  $SRC/Nordictrack2450Device.java \
  $SRC/Nordictrack2950Device.java \
  $SRC/Nordictrack2950MaxSpeed22Device.java \
  $SRC/Ntex71021Device.java \
  $SRC/Elite900Device.java \
  $SRC/Elite1000Device.java \
  $SRC/Exp7iDevice.java \
  $SRC/Proform2000Device.java \
  $SRC/ProformCarbonC10Device.java \
  $SRC/ProformCarbonE7Device.java \
  $SRC/ProformCarbonT14Device.java \
  $SRC/ProformPro9000Device.java \
  $SRC/ProformStudioBikePro22Device.java \
  $SRC/Se9iEllipticalDevice.java \
  $SRC/T85sDevice.java \
  $SRC/T95sDevice.java \
  $SRC/Tdf10Device.java \
  $SRC/Tdf10InclinationDevice.java \
  $SRC/UDPReceiveLoop.java

# Compile tests
javac -d $OUT -cp $OUT:$JUNIT:$HAMCREST \
  $TEST/OcrParserTest.java \
  $TEST/CommandDispatcherTest.java \
  $TEST/BikeDeviceTest.java \
  $TEST/TreadmillDeviceTest.java \
  $TEST/MetricReaderTest.java \
  $TEST/UdpPipelineTest.java \
  $TEST/ZwiftRideSimulationTest.java

# Run tests
java -cp $OUT:$JUNIT:$HAMCREST org.junit.runner.JUnitCore \
  org.cagnulein.qzcompanionnordictracktreadmill.OcrParserTest \
  org.cagnulein.qzcompanionnordictracktreadmill.CommandDispatcherTest \
  org.cagnulein.qzcompanionnordictracktreadmill.BikeDeviceTest \
  org.cagnulein.qzcompanionnordictracktreadmill.TreadmillDeviceTest \
  org.cagnulein.qzcompanionnordictracktreadmill.MetricReaderTest \
  org.cagnulein.qzcompanionnordictracktreadmill.UdpPipelineTest \
  org.cagnulein.qzcompanionnordictracktreadmill.ZwiftRideSimulationTest
