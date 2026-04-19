package org.cagnulein.qzcompanionnordictracktreadmill.device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.bike.*;
import org.cagnulein.qzcompanionnordictracktreadmill.device.treadmill.*;
import org.cagnulein.qzcompanionnordictracktreadmill.calibration.CalibrationResult;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.DirectLogcatMetricReader;
import org.cagnulein.qzcompanionnordictracktreadmill.reader.LogcatDumpMetricReader;

import java.util.Collections;
import java.util.EnumMap;
import java.util.Map;

/**
 * Central registry of all supported fitness devices.
 * Owns the DeviceId enum and the map from id to Device instance.
 * Neither CommandListenerService nor MainActivity need to know about
 * concrete device classes — they refer only to DeviceId values.
 */
public class DeviceRegistry {

    public enum DeviceId {
        x11i,
        nordictrack_2950,
        other,
        proform_2000,
        s22i,
        tdf10,
        t85s,
        s40,
        exp7i,
        x32i,
        c1750,
        t65s,
        nordictrack_2950_maxspeed22,
        t75s,
        grand_tour_pro,
        proform_studio_bike_pro22,
        x32i_NTL39019,
        x22i,
        NTEX71021,
        c1750_2021,
        s22i_NTEX02121_5,
        s22i_NTEX02117_2,
        s22i_noadb,
        x32i_NTL39221,
        c1750_2020,
        elite1000,
        x14i,
        x9i,
        nordictrack_2450,
        c1750_2020_kph,
        tdf10_inclination,
        proform_carbon_t14,
        x22i_v2,
        s15i,
        x22i_noadb,
        proform_pro_9000,
        proform_carbon_e7,
        t95s,
        proform_carbon_c10,
        elite900,
        c1750_mph_minus3grade,
        s27i,
        c1750_NTL14122_2_MPH,
        proform_pro_2000,
        se9i_elliptical,
        custom_calibrated,
    }

    private static final Map<DeviceId, Device> DEVICES;
    static {
        Map<DeviceId, Device> m = new EnumMap<>(DeviceId.class);
        m.put(DeviceId.x11i,                        new X11iDevice());
        m.put(DeviceId.nordictrack_2950,             new Nordictrack2950Device());
        m.put(DeviceId.other,                        new OtherDevice());
        m.put(DeviceId.proform_2000,                 new Proform2000Device());
        m.put(DeviceId.s22i,                         new S22iDevice());
        m.put(DeviceId.tdf10,                        new Tdf10Device());
        m.put(DeviceId.t85s,                         new T85sDevice());
        m.put(DeviceId.s40,                          new S40Device());
        m.put(DeviceId.exp7i,                        new Exp7iDevice());
        m.put(DeviceId.x32i,                         new X32iDevice());
        m.put(DeviceId.c1750,                        new C1750Device());
        m.put(DeviceId.t65s,                         new T65sDevice("T6.5s Treadmill"));
        m.put(DeviceId.nordictrack_2950_maxspeed22,  new Nordictrack2950MaxSpeed22Device());
        m.put(DeviceId.t75s,                         new T65sDevice("T7.5s Treadmill",          new LogcatDumpMetricReader()));
        m.put(DeviceId.grand_tour_pro,               new T65sDevice("Grand Tour Pro Treadmill", new DirectLogcatMetricReader()));
        m.put(DeviceId.proform_studio_bike_pro22,    new ProformStudioBikePro22Device());
        m.put(DeviceId.x32i_NTL39019,               new X32iNtl39019Device());
        m.put(DeviceId.x22i,                         new X22iDevice());
        m.put(DeviceId.NTEX71021,                    new Ntex71021Device());
        m.put(DeviceId.c1750_2021,                   new C1750_2021Device());
        m.put(DeviceId.s22i_NTEX02121_5,            new S22iNtex02121Device());
        m.put(DeviceId.s22i_NTEX02117_2,            new S22iNtex02117Device());
        m.put(DeviceId.s22i_noadb,                   new S22iNoAdbDevice());
        m.put(DeviceId.x32i_NTL39221,               new X32iNtl39221Device());
        m.put(DeviceId.c1750_2020,                   new C1750_2020Device());
        m.put(DeviceId.elite1000,                    new Elite1000Device("Elite 1000 Treadmill"));
        m.put(DeviceId.x14i,                         new X14iDevice());
        m.put(DeviceId.x9i,                          new X9iDevice());
        m.put(DeviceId.nordictrack_2450,             new Nordictrack2450Device());
        m.put(DeviceId.c1750_2020_kph,              new C1750_2020KphDevice());
        m.put(DeviceId.tdf10_inclination,            new Tdf10InclinationDevice());
        m.put(DeviceId.proform_carbon_t14,           new ProformCarbonT14Device());
        m.put(DeviceId.x22i_v2,                      new X22iV2Device());
        m.put(DeviceId.s15i,                         new S15iDevice());
        m.put(DeviceId.x22i_noadb,                   new X22iNoAdbDevice());
        m.put(DeviceId.proform_pro_9000,             new ProformPro9000Device());
        m.put(DeviceId.proform_carbon_e7,            new ProformCarbonE7Device());
        m.put(DeviceId.t95s,                         new T95sDevice());
        m.put(DeviceId.proform_carbon_c10,           new ProformCarbonC10Device());
        m.put(DeviceId.elite900,                     new Elite900Device());
        m.put(DeviceId.c1750_mph_minus3grade,        new C1750MphMinus3GradeDevice());
        m.put(DeviceId.s27i,                         new S27iDevice());
        m.put(DeviceId.c1750_NTL14122_2_MPH,        new C1750Ntl14122Device());
        m.put(DeviceId.proform_pro_2000,             new Elite1000Device("ProForm Pro 2000 Treadmill"));
        m.put(DeviceId.se9i_elliptical,              new Se9iEllipticalDevice());
        m.put(DeviceId.custom_calibrated,            new CalibratedBikeDevice());
        DEVICES = Collections.unmodifiableMap(m);
    }

    public static Device forId(DeviceId id) {
        Device device = DEVICES.get(id);
        if (device == null) throw new IllegalArgumentException("No device registered for id: " + id);
        return device;
    }
}
