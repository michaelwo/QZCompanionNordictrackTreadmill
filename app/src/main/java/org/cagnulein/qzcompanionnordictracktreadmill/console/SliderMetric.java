package org.cagnulein.qzcompanionnordictracktreadmill.console;

import org.cagnulein.qzcompanionnordictracktreadmill.qz.QZMetricPacket;

/** Identifies a metric that drives a physical Slider on the device screen. */
public enum SliderMetric {
    KPH, GRADE, RESISTANCE, CURRENT_GEAR;

    public static SliderMetric from(QZMetricPacket.Metric m) {
        switch (m) {
            case KPH:          return SliderMetric.KPH;
            case GRADE:        return SliderMetric.GRADE;
            case RESISTANCE:   return SliderMetric.RESISTANCE;
            case CURRENT_GEAR: return SliderMetric.CURRENT_GEAR;
            default:           return null;
        }
    }
}
