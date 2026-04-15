package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Proform2000Device extends TreadmillDevice {
    public Proform2000Device() {         super(
            new Slider(598) {
                public int trackX() { return 1205; }
                public int targetY(double v) { return (int) (631.03 - 19.921 * v); }
            },
            new Slider(522) {
                public int trackX() { return 79; }
                public int targetY(double v) { return 520 - (int) ((v + 3) * 21.804); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "ProForm 2000 Treadmill"; }





}
