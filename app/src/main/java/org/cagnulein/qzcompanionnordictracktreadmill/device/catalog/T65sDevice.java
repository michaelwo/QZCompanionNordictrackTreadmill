package org.cagnulein.qzcompanionnordictracktreadmill.device.catalog;
import org.cagnulein.qzcompanionnordictracktreadmill.device.TreadmillDevice;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricReader;

public class T65sDevice extends TreadmillDevice {
    private final String name;
    private final MetricReader reader;

    public T65sDevice(String name) { this(name, null); }

    public T65sDevice(String name, MetricReader reader) {
                super(
            new Slider(495) {
                public int trackX() { return 1205; }
                public int targetY(double v) { return (int) (578.36 - 35.866 * v * 0.621371); }
            },
            new Slider(585) {
                public int trackX() { return 74; }
                public int targetY(double v) { return (int) (576.91 - 34.182 * v); }
            }
        );
        this.name = name;
        this.reader = reader;
    }

    @Override
    public String displayName() { return name; }

    @Override
    public MetricReader defaultMetricReader() {
        return reader != null ? reader : super.defaultMetricReader();
    }




}
