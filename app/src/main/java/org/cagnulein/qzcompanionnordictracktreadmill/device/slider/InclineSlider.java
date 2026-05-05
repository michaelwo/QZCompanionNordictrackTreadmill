package org.cagnulein.qzcompanionnordictracktreadmill.device.slider;

import org.cagnulein.qzcompanionnordictracktreadmill.console.SliderMetric;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import org.cagnulein.qzcompanionnordictracktreadmill.device.Slider;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.Command;
import android.util.Log;
import org.cagnulein.qzcompanionnordictracktreadmill.device.command.InclineCommand;

public class InclineSlider extends Slider {

    public InclineSlider(int trackX, int initialThumbY, ThumbYFormula formula) {
        super(trackX, initialThumbY, formula, SliderMetric.GRADE);
    }

    protected InclineSlider(int initialThumbY) {
        super(0, initialThumbY, null, SliderMetric.GRADE);
    }

    @Override
    protected int currentThumbY() { return thumbY(); }

    public static InclineSlider live(int trackX, int initialThumbY, ThumbYFormula formula) {
        return new InclineSlider(trackX, initialThumbY, formula) {
            @Override
            protected int currentThumbY() {
                if (liveValue != null) return targetThumbY(liveValue);
                return targetThumbY(0.0);
            }
        };
    }

    @Override
    public void handle(double pct, Device device) {
        float quantized = quantize((float) pct);
        Float last = lastApplied();
        device.logger.log(Log.VERBOSE, "QZ:Dispatch", "requestIncline: " + pct + " quantized=" + quantized + " last=" + last);
        if (last == null || quantized != last) {
            moveTo(quantized, device);
            device.logger.log(Log.DEBUG, "QZ:Dispatch", "applyIncline: " + quantized);
        } else {
            device.logger.log(Log.VERBOSE, "QZ:Dispatch", "de-dup: skipping incline " + pct + " (quantized=" + quantized + " already at " + last + ")");
        }
    }

    @Override
    public Command commandFor(double pct) { return new InclineCommand((float) pct); }
}
