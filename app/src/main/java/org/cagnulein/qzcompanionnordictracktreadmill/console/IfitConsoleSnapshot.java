package org.cagnulein.qzcompanionnordictracktreadmill.console;

import android.content.SharedPreferences;

/** Immutable snapshot of the values read from iFit's MachineInfoView screen. */
public class IfitConsoleSnapshot {

    static final String PREF_PART_NUMBER    = "ifit_snap_part_number";
    static final String PREF_MACHINE_TYPE   = "ifit_snap_machine_type";
    static final String PREF_MAX_KPH        = "ifit_snap_max_kph";
    static final String PREF_MAX_INCLINE    = "ifit_snap_max_incline";
    static final String PREF_MIN_INCLINE    = "ifit_snap_min_incline";
    static final String PREF_MAX_RESISTANCE = "ifit_snap_max_resistance";

    public final int    partNumber;
    public final String machineType;
    public final Float  maxKph;
    public final Float  maxIncline;
    public final Float  minIncline;
    public final Float  maxResistance;

    public IfitConsoleSnapshot(int partNumber, String machineType,
                        Float maxKph, Float maxIncline,
                        Float minIncline, Float maxResistance) {
        this.partNumber    = partNumber;
        this.machineType   = machineType != null ? machineType : "";
        this.maxKph        = maxKph;
        this.maxIncline    = maxIncline;
        this.minIncline    = minIncline;
        this.maxResistance = maxResistance;
    }

    /** Returns true if the snapshot contains a meaningful part number. */
    public boolean isValid() {
        return partNumber > 0;
    }

    public void save(SharedPreferences prefs) {
        prefs.edit()
             .putInt(PREF_PART_NUMBER,    partNumber)
             .putString(PREF_MACHINE_TYPE,   machineType)
             .putString(PREF_MAX_KPH,        maxKph        != null ? maxKph.toString()        : "")
             .putString(PREF_MAX_INCLINE,    maxIncline    != null ? maxIncline.toString()    : "")
             .putString(PREF_MIN_INCLINE,    minIncline    != null ? minIncline.toString()    : "")
             .putString(PREF_MAX_RESISTANCE, maxResistance != null ? maxResistance.toString() : "")
             .apply();
    }

    public static Float parseNullable(String s) {
        if (s == null || s.isEmpty()) return null;
        try { return Float.parseFloat(s); } catch (NumberFormatException e) { return null; }
    }

    /** Returns null if no valid snapshot has been saved yet. */
    public static IfitConsoleSnapshot load(SharedPreferences prefs) {
        int pn = prefs.getInt(PREF_PART_NUMBER, 0);
        if (pn == 0) return null;
        return new IfitConsoleSnapshot(
            pn,
            prefs.getString(PREF_MACHINE_TYPE,   ""),
            parseNullable(prefs.getString(PREF_MAX_KPH,        "")),
            parseNullable(prefs.getString(PREF_MAX_INCLINE,    "")),
            parseNullable(prefs.getString(PREF_MIN_INCLINE,    "")),
            parseNullable(prefs.getString(PREF_MAX_RESISTANCE, ""))
        );
    }

    @Override
    public String toString() {
        return "part#" + partNumber
             + " type=" + machineType
             + " maxKph=" + maxKph
             + " incline=[" + minIncline + "," + maxIncline + "]"
             + " maxRes=" + maxResistance;
    }
}
