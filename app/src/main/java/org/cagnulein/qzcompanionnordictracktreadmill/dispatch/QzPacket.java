package org.cagnulein.qzcompanionnordictracktreadmill.dispatch;

public class QzPacket {
    public static final char   DELIMITER     = ';';
    public static final float  NO_COMMAND    = -100f;
    public static final float  NO_RESISTANCE = -1f;
    public static final String END_OF_RIDE   = "-1" + DELIMITER + "-100";

    private final String[] fields;

    private QzPacket(String[] fields) {
        this.fields = fields;
    }

    public static QzPacket parse(String raw) {
        return new QzPacket(raw.split(String.valueOf(DELIMITER)));
    }

    public int fieldCount() { return fields.length; }

    public String rawField(int i) { return fields[i]; }

    public String raw() {
        return String.join(String.valueOf(DELIMITER), fields);
    }
}
