package org.cagnulein.qzcompanionnordictracktreadmill.qz;

import org.cagnulein.qzcompanionnordictracktreadmill.device.command.CalibrationSwipeCommand;

public interface QZCommandSubscriber {
    void onPacket(QZCommandPacket packet);
    void onCalibrationSwipe(CalibrationSwipeCommand cmd);
}
