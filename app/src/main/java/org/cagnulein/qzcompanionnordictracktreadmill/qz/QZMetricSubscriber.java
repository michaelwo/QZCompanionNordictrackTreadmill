package org.cagnulein.qzcompanionnordictracktreadmill.qz;

import org.cagnulein.qzcompanionnordictracktreadmill.device.SliderMetric;

public interface QZMetricSubscriber {
    void onMetric(SliderMetric metric, float value);
}
