package org.cagnulein.qzcompanionnordictracktreadmill.device.slider;

import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import android.util.Log;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.SpeedCommand;

public class SpeedSlider extends Slider {

    private volatile Float cachedKmh = null;

    public SpeedSlider(int trackX, int initialThumbY, ThumbYFormula formula) {
        super(trackX, initialThumbY, formula, SliderMetric.KPH);
    }

    @Override
    protected int currentThumbY() { return thumbY(); }

    public static SpeedSlider live(int trackX, int initialThumbY, ThumbYFormula formula) {
        return new SpeedSlider(trackX, initialThumbY, formula) {
            @Override
            protected int currentThumbY() {
                if (liveValue != null) return targetThumbY(liveValue);
                return targetThumbY(0.0);
            }
        };
    }

    @Override
    public void handle(double kmh, Device device) {
        synchronized (this) {
            device.logger.log(Log.VERBOSE, "QZ:Dispatch", "requestSpeed: " + kmh + " beltKph=" + liveValueOrZero() + " cached=" + cachedKmh);
            if (liveValueOrZero() <= 0) {
                device.logger.log(Log.DEBUG, "QZ:Dispatch", "speed gate: held " + kmh + " (belt stopped)");
                cachedKmh = (float) kmh;
                return;
            }
            cachedKmh = null;
        }
        device.logger.log(Log.DEBUG, "QZ:Dispatch", "applySpeed: " + kmh);
        moveTo(kmh, device);
    }

    @Override
    public void applyIfMatch(SliderMetric m, float value, Device device) {
        super.applyIfMatch(m, value);
        if (m != SliderMetric.KPH || value <= 0) return;
        float cached;
        synchronized (this) {
            if (cachedKmh == null) return;
            cached = cachedKmh;
            cachedKmh = null;
        }
        device.logger.log(Log.INFO, "QZ:Dispatch", "belt-gate flush: applySpeed " + cached);
        moveTo(cached, device);
    }

    @Override
    public Command commandFor(double kmh) { return new SpeedCommand((float) kmh); }
}
