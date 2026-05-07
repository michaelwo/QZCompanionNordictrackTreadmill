package org.cagnulein.qzcompanionnordictracktreadmill.qz;

import org.cagnulein.qzcompanionnordictracktreadmill.device.slider.SliderMetric;

public interface QZMetricSubscriber {
    void onMetric(SliderMetric metric, float value);
}
