package org.cagnulein.qzcompanionnordictracktreadmill.qz;

import org.cagnulein.qzcompanionnordictracktreadmill.device.telemetry.CadenceTelemetry;
import org.cagnulein.qzcompanionnordictracktreadmill.device.telemetry.GearTelemetry;
import org.cagnulein.qzcompanionnordictracktreadmill.device.telemetry.HeartRateTelemetry;
import org.cagnulein.qzcompanionnordictracktreadmill.device.telemetry.InclineTelemetry;
import org.cagnulein.qzcompanionnordictracktreadmill.device.telemetry.ResistanceTelemetry;
import org.cagnulein.qzcompanionnordictracktreadmill.device.telemetry.SpeedTelemetry;
import org.cagnulein.qzcompanionnordictracktreadmill.device.telemetry.WattsTelemetry;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class QZTelemetryEncoderTest {
    @Test
    public void encode_mapsTelemetryToExistingWireFormat() {
        assertEquals("Changed KPH 12.5",
                QZTelemetryEncoder.encode(new SpeedTelemetry(12.5f)).serialize());
        assertEquals("Changed Grade 3.0",
                QZTelemetryEncoder.encode(new InclineTelemetry(3.0f)).serialize());
        assertEquals("Changed Resistance 15.0",
                QZTelemetryEncoder.encode(new ResistanceTelemetry(15.0f)).serialize());
        assertEquals("Changed CurrentGear 4.0",
                QZTelemetryEncoder.encode(new GearTelemetry(4.0f)).serialize());
        assertEquals("Changed RPM 80.0",
                QZTelemetryEncoder.encode(new CadenceTelemetry(80.0f)).serialize());
        assertEquals("Changed Watts 180",
                QZTelemetryEncoder.encode(new WattsTelemetry(180.7f)).serialize());
        assertEquals("HeartRateDataUpdate 72",
                QZTelemetryEncoder.encode(new HeartRateTelemetry(72.0f)).serialize());
    }
}
