package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class S22iNtex02121Device extends BikeDevice {
    public S22iNtex02121Device() {         super(
            new Slider(535) {
                public int trackX() { return 75; }
                public int targetY(double v) { return 800 - (int) ((v + 10) * 19); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            },
            null
        ); }

    @Override
    public String displayName() { return "S22i Bike (NTEX02121.5)"; }



}
