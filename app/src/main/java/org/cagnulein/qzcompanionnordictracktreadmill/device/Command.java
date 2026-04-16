package org.cagnulein.qzcompanionnordictracktreadmill.device;

/**
 * A requested change to a device — decoded from a single UDP message.
 *
 * null means "not requested this message". Distinct from {@link
 * org.cagnulein.qzcompanionnordictracktreadmill.reader.MetricSnapshot},
 * which represents what the device is currently doing.
 */
public class Command {
    public Float speedKmh      = null;
    public Float inclinePct    = null;
    public Float resistanceLvl = null;
}
