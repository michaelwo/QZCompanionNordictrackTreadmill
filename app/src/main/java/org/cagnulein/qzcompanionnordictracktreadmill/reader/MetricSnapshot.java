package org.cagnulein.qzcompanionnordictracktreadmill.reader;

/**
 * Typed snapshot of all device metrics for one parse cycle.
 * null means "not observed this cycle" — consumers re-broadcast the last known value.
 * Used by both the log-file readers (MetricReader) and the OCR path (OcrParser).
 */
public class MetricSnapshot {
    public Float speedKmh      = null;
    public Float inclinePct    = null;
    public Float resistanceLvl = null;
    public Float cadenceRpm    = null;
    public Float watts         = null;
    public Float gearLevel     = null;
    public Float heartRate     = null;

    /** Returns the current speed in km/h, or 0 if no reading has been received yet. */
    public float speed()      { return speedKmh      != null ? speedKmh      : 0f; }
    /** Returns the current incline in percent, or 0 if no reading has been received yet. */
    public float incline()    { return inclinePct    != null ? inclinePct    : 0f; }
    /** Returns the current resistance level, or 0 if no reading has been received yet. */
    public float resistance() { return resistanceLvl != null ? resistanceLvl : 0f; }
    /** Returns the current gear level, or 0 if no reading has been received yet. */
    public float gear()       { return gearLevel     != null ? gearLevel     : 0f; }

    /** Fluent builder for constructing a MetricSnapshot from a parse result. */
    public static class Builder {
        private final MetricSnapshot s = new MetricSnapshot();
        public Builder speedKmh(Float v)      { s.speedKmh      = v; return this; }
        public Builder inclinePct(Float v)    { s.inclinePct    = v; return this; }
        public Builder resistanceLvl(Float v) { s.resistanceLvl = v; return this; }
        public Builder cadenceRpm(Float v)    { s.cadenceRpm    = v; return this; }
        public Builder watts(Float v)         { s.watts         = v; return this; }
        public Builder gearLevel(Float v)     { s.gearLevel     = v; return this; }
        public Builder heartRate(Float v)     { s.heartRate     = v; return this; }
        public MetricSnapshot build()         { return s; }
    }
}
