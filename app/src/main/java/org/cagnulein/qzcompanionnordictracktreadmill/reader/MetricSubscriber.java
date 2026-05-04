package org.cagnulein.qzcompanionnordictracktreadmill.reader;

public interface MetricSubscriber {
    void onMetric(SliderMetric metric, float value);
}
