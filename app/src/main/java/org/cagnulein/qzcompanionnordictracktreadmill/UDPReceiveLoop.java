package org.cagnulein.qzcompanionnordictracktreadmill;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

/**
 * Core UDP receive-and-dispatch logic, extracted from UDPListenerService for testability.
 *
 * This class has no Android dependencies — it operates on plain DatagramSocket,
 * Device, and CommandDispatcher.  UDPListenerService wraps this class and adds
 * the Android layer (WakeLock, SharedPreferences, Intent broadcast).
 *
 * Tests can instantiate UDPReceiveLoop directly to exercise the full receive →
 * parse → dispatch → swipe pipeline without any Android Service lifecycle.
 */
class UDPReceiveLoop {

    private final CommandDispatcher dispatcher;
    private final char decimalSeparator;

    UDPReceiveLoop(CommandDispatcher dispatcher, char decimalSeparator) {
        this.dispatcher      = dispatcher;
        this.decimalSeparator = decimalSeparator;
    }

    /**
     * Blocks until one UDP packet arrives on {@code socket}, then dispatches it.
     *
     * @param socket  the socket to receive on (already bound and open)
     * @param device  the currently active device
     * @param current latest observed metrics snapshot (for swipe-origin calculation)
     * @throws IOException if the receive fails (e.g. socket closed by tearDown)
     */
    void receiveOne(DatagramSocket socket, Device device, MetricSnapshot current)
            throws IOException {
        byte[] buf = new byte[15000];
        DatagramPacket pkt = new DatagramPacket(buf, buf.length);
        socket.receive(pkt);
        String msg = new String(pkt.getData(), 0, pkt.getLength()).trim();
        dispatcher.dispatch(msg, decimalSeparator, device, current);
    }
}
