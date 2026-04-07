package org.cagnulein.qzcompanionnordictracktreadmill;

/**
 * Typed snapshot of all device metrics for one parse cycle.
 * null means "not observed this cycle" — consumers re-broadcast the last known value.
 * Used by both the log-file readers (MetricReader) and the OCR path (OcrParser).
 */
class MetricSnapshot {
    Float speedKmh      = null;
    Float inclinePct    = null;
    Float resistanceLvl = null;
    Float cadenceRpm    = null;
    Float watts         = null;
    Float gearLevel     = null;
    Float heartRate     = null;

    /** Returns the current speed in km/h, or 0 if no reading has been received yet. */
    float speed()      { return speedKmh      != null ? speedKmh      : 0f; }
    /** Returns the current incline in percent, or 0 if no reading has been received yet. */
    float incline()    { return inclinePct    != null ? inclinePct    : 0f; }
    /** Returns the current resistance level, or 0 if no reading has been received yet. */
    float resistance() { return resistanceLvl != null ? resistanceLvl : 0f; }
    /** Returns the current gear level, or 0 if no reading has been received yet. */
    float gear()       { return gearLevel     != null ? gearLevel     : 0f; }

    /** Fluent builder for constructing a MetricSnapshot from a parse result. */
    static class Builder {
        private final MetricSnapshot s = new MetricSnapshot();
        Builder speedKmh(Float v)      { s.speedKmh      = v; return this; }
        Builder inclinePct(Float v)    { s.inclinePct    = v; return this; }
        Builder resistanceLvl(Float v) { s.resistanceLvl = v; return this; }
        Builder cadenceRpm(Float v)    { s.cadenceRpm    = v; return this; }
        Builder watts(Float v)         { s.watts         = v; return this; }
        Builder gearLevel(Float v)     { s.gearLevel     = v; return this; }
        Builder heartRate(Float v)     { s.heartRate     = v; return this; }
        MetricSnapshot build()         { return s; }
    }
}
