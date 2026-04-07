package org.cagnulein.qzcompanionnordictracktreadmill;

abstract class Device {
    /**
     * Command executor installed by the Android layer (MainActivity) at startup.
     * Default is no-op so device classes compile and run without Android dependencies.
     * Tests override execute() in anonymous subclasses to capture commands.
     */
    static CommandExecutor commandExecutor = command -> {};

    /** Functional interface so the executor can be set without Android imports. */
    interface CommandExecutor {
        void send(String command);
    }

    abstract String displayName();

    /**
     * Interprets a raw UDP message (already split on ";") for this device type.
     * Returns a MetricSnapshot whose non-null fields represent the requested values.
     * Fields not relevant to this device type (or absent from the message) are null.
     */
    abstract MetricSnapshot parseCommand(String[] parts, char decimalSeparator);

    /** Rounds to one decimal place (e.g. 5.25 → 5.3). */
    static float roundToOneDecimal(float value) {
        return Math.round(value * 10) / 10.0f;
    }

    /**
     * Parses one message part into a Float, handling locale decimal separators and
     * the common fallback of replacing ',' with '.'.  Returns null on parse failure.
     */
    static Float parseField(String part, char decimalSeparator) {
        String s = part.trim();
        if (decimalSeparator != '.') s = s.replace('.', decimalSeparator);
        try {
            return Float.parseFloat(s);
        } catch (NumberFormatException e) {
            try {
                return Float.parseFloat(s.replace(',', '.'));
            } catch (NumberFormatException e2) {
                return null;
            }
        }
    }

    MetricReader defaultMetricReader(boolean ifitV2) {
        return new TailGrepMetricReader(ifitV2);
    }

    protected void execute(String command) {
        commandExecutor.send(command);
    }

    protected void swipe(int x, int y1, int y2) {
        execute("input swipe " + x + " " + y1 + " " + x + " " + y2 + " 200");
    }
}
