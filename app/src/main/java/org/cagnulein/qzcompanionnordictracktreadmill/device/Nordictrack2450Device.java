package org.cagnulein.qzcompanionnordictracktreadmill.device;

import org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot;

public class Nordictrack2450Device extends TreadmillDevice {
    public Nordictrack2450Device() {         super(
            new Slider(807) {
                public int trackX() { return 1845; }
                public int targetY(double v) { return (int) (-26.33 * (v * 0.621371) + 831.39); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.speed()); }
            },
            new Slider(717) {
                public int trackX() { return 72; }
                public int targetY(double v) { return 715 - (int) ((v + 3) * 29.26); }
                protected int currentThumbY(MetricSnapshot current) { return targetY(current.incline()); }
            }
        ); }

    @Override
    public String displayName() { return "NordicTrack 2450 Treadmill"; }






}
