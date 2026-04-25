package org.cagnulein.qzcompanionnordictracktreadmill;

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
    public final String maxKph;
    public final String maxIncline;
    public final String minIncline;
    public final String maxResistance;

    public IfitConsoleSnapshot(int partNumber, String machineType,
                        String maxKph, String maxIncline,
                        String minIncline, String maxResistance) {
        this.partNumber    = partNumber;
        this.machineType   = machineType != null ? machineType : "";
        this.maxKph        = maxKph        != null ? maxKph        : "";
        this.maxIncline    = maxIncline    != null ? maxIncline    : "";
        this.minIncline    = minIncline    != null ? minIncline    : "";
        this.maxResistance = maxResistance != null ? maxResistance : "";
    }

    /** Returns true if the snapshot contains a meaningful part number. */
    public boolean isValid() {
        return partNumber > 0;
    }

    public void save(SharedPreferences prefs) {
        prefs.edit()
             .putInt(PREF_PART_NUMBER,    partNumber)
             .putString(PREF_MACHINE_TYPE,   machineType)
             .putString(PREF_MAX_KPH,        maxKph)
             .putString(PREF_MAX_INCLINE,    maxIncline)
             .putString(PREF_MIN_INCLINE,    minIncline)
             .putString(PREF_MAX_RESISTANCE, maxResistance)
             .apply();
    }

    /** Returns null if no valid snapshot has been saved yet. */
    public static IfitConsoleSnapshot load(SharedPreferences prefs) {
        int pn = prefs.getInt(PREF_PART_NUMBER, 0);
        if (pn == 0) return null;
        return new IfitConsoleSnapshot(
            pn,
            prefs.getString(PREF_MACHINE_TYPE,   ""),
            prefs.getString(PREF_MAX_KPH,        ""),
            prefs.getString(PREF_MAX_INCLINE,    ""),
            prefs.getString(PREF_MIN_INCLINE,    ""),
            prefs.getString(PREF_MAX_RESISTANCE, "")
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
