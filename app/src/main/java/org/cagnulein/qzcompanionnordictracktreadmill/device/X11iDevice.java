package org.cagnulein.qzcompanionnordictracktreadmill.device;

public class X11iDevice extends TreadmillDevice {
    public X11iDevice() {         super(
            new Slider(600) {
                public int trackX() { return 1207; }
                public int targetY(double v) { return (int) (621.997 - 21.785 * v); }
            },
            new Slider(557) {
                public int trackX() { return 75; }
                public int targetY(double v) { return (int) (565.491 - 8.44 * v); }
            }
        ); }

    @Override
    public String displayName() { return "X11i Treadmill"; }




}
