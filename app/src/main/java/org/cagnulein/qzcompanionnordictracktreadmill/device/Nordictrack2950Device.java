package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Nordictrack2950Device extends TreadmillDevice {
    public Nordictrack2950Device() {         super(
            new Slider(807) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return 807 - (int) ((v - 1.0) * 31); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(717) {
                public int trackX() { return 75; }
                public int targetY(double v) { return 807 - (int) ((v + 3) * 31.1); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "NordicTrack 2950 Treadmill"; }






}
