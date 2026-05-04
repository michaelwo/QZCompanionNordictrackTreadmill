package org.cagnulein.qzcompanionnordictracktreadmill.command;

public interface PacketSubscriber {
    void onPacket(QZCommandPacket packet);
    void onCalibrationSwipe(CalibrationSwipeCommand cmd);
}
