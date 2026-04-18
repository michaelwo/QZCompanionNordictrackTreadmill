package org.cagnulein.qzcompanionnordictracktreadmill.reader;

/**
 * iFit v2 log-file reader. The v2 format uses "INCLINE" instead of "Grade" as the incline
 * keyword, and places the numeric value at the second-to-last token position (followed by a
 * unit token such as "kmh" or "pct").
 */
public class TailGrepIfitV2MetricReader extends TailGrepMetricReader {

    @Override
    protected String inclineKeyword() { return "INCLINE"; }

    @Override
    protected int valueTokenIndex(String[] tokens) { return tokens.length - 2; }
}
