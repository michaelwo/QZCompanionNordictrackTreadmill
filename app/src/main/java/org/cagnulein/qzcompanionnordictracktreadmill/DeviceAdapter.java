package org.cagnulein.qzcompanionnordictracktreadmill;

import android.graphics.Color;
import android.util.TypedValue;
import android.view.ViewGroup;
import android.widget.RadioButton;
import android.widget.TextView;
import androidx.recyclerview.widget.RecyclerView;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceRegistry;
import org.cagnulein.qzcompanionnordictracktreadmill.device.DeviceRegistry.DeviceId;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.EnumMap;
import java.util.List;
import java.util.Map;

public class DeviceAdapter extends RecyclerView.Adapter<RecyclerView.ViewHolder> {

    interface OnDeviceSelectedListener {
        void onDeviceSelected(DeviceId id);
    }

    // ── Section definitions ────────────────────────────────────────────────────

    private static final List<DeviceId> BIKE_DEVICES = Arrays.asList(
        DeviceId.s15i,
        DeviceId.s22i,
        DeviceId.s22i_NTEX02121_5,
        DeviceId.s22i_NTEX02117_2,
        DeviceId.s22i_noadb,
        DeviceId.s27i,
        DeviceId.NTEX71021,
        DeviceId.tdf10,
        DeviceId.tdf10_inclination,
        DeviceId.proform_studio_bike_pro22,
        DeviceId.proform_carbon_e7,
        DeviceId.proform_carbon_c10,
        DeviceId.custom_calibrated
    );

    private static final List<DeviceId> TREADMILL_DEVICES = Arrays.asList(
        DeviceId.x9i,
        DeviceId.x11i,
        DeviceId.x14i,
        DeviceId.x22i,
        DeviceId.x22i_v2,
        DeviceId.x22i_noadb,
        DeviceId.x32i,
        DeviceId.x32i_NTL39019,
        DeviceId.x32i_NTL39221,
        DeviceId.c1750,
        DeviceId.c1750_2020,
        DeviceId.c1750_2020_kph,
        DeviceId.c1750_mph_minus3grade,
        DeviceId.c1750_NTL14122_2_MPH,
        DeviceId.c1750_2021,
        DeviceId.t65s,
        DeviceId.t75s,
        DeviceId.t85s,
        DeviceId.t95s,
        DeviceId.s40,
        DeviceId.nordictrack_2450,
        DeviceId.nordictrack_2950,
        DeviceId.nordictrack_2950_maxspeed22,
        DeviceId.proform_2000,
        DeviceId.proform_carbon_t14,
        DeviceId.proform_pro_9000,
        DeviceId.proform_pro_2000,
        DeviceId.elite900,
        DeviceId.elite1000,
        DeviceId.exp7i,
        DeviceId.grand_tour_pro
    );

    private static final List<DeviceId> OTHER_DEVICES = Arrays.asList(
        DeviceId.se9i_elliptical,
        DeviceId.other
    );

    /** Maps every DeviceId to its section label. Used for O(1) category lookup. */
    static final Map<DeviceId, String> SECTION_MAP;
    static {
        Map<DeviceId, String> m = new EnumMap<>(DeviceId.class);
        for (DeviceId id : BIKE_DEVICES)      m.put(id, "BIKES");
        for (DeviceId id : TREADMILL_DEVICES) m.put(id, "TREADMILLS");
        for (DeviceId id : OTHER_DEVICES)     m.put(id, "OTHER");
        SECTION_MAP = Collections.unmodifiableMap(m);
    }

    // ── Flat item list (headers + devices) ────────────────────────────────────

    private static final int TYPE_HEADER = 0;
    private static final int TYPE_DEVICE = 1;

    private static class Item {
        final int type;
        final String label;
        final DeviceId deviceId;

        private Item(int type, String label, DeviceId deviceId) {
            this.type     = type;
            this.label    = label;
            this.deviceId = deviceId;
        }

        static Item header(String label)  { return new Item(TYPE_HEADER, label, null); }
        static Item device(DeviceId id)   { return new Item(TYPE_DEVICE, null, id); }
    }

    private static final List<Item> ITEMS;
    static {
        List<Item> items = new ArrayList<>();
        items.add(Item.header("BIKES"));
        for (DeviceId id : BIKE_DEVICES)      items.add(Item.device(id));
        items.add(Item.header("TREADMILLS"));
        for (DeviceId id : TREADMILL_DEVICES) items.add(Item.device(id));
        items.add(Item.header("OTHER"));
        for (DeviceId id : OTHER_DEVICES)     items.add(Item.device(id));
        ITEMS = Collections.unmodifiableList(items);
    }

    // ── Adapter state ──────────────────────────────────────────────────────────

    private int selectedPosition = RecyclerView.NO_POSITION;
    private final OnDeviceSelectedListener listener;

    DeviceAdapter(OnDeviceSelectedListener listener) {
        this.listener = listener;
    }

    void setSelectedId(DeviceId id) {
        for (int i = 0; i < ITEMS.size(); i++) {
            if (ITEMS.get(i).type == TYPE_DEVICE && ITEMS.get(i).deviceId == id) {
                int prev = selectedPosition;
                selectedPosition = i;
                if (prev != RecyclerView.NO_POSITION) notifyItemChanged(prev);
                notifyItemChanged(selectedPosition);
                return;
            }
        }
    }

    DeviceId getSelectedId() {
        if (selectedPosition == RecyclerView.NO_POSITION) return DeviceId.other;
        Item item = ITEMS.get(selectedPosition);
        return item.type == TYPE_DEVICE ? item.deviceId : DeviceId.other;
    }

    // ── RecyclerView adapter methods ───────────────────────────────────────────

    @Override public int getItemViewType(int position) { return ITEMS.get(position).type; }
    @Override public int getItemCount() { return ITEMS.size(); }

    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        if (viewType == TYPE_HEADER) {
            TextView tv = new TextView(parent.getContext());
            tv.setLayoutParams(new RecyclerView.LayoutParams(
                    ViewGroup.LayoutParams.MATCH_PARENT,
                    ViewGroup.LayoutParams.WRAP_CONTENT));
            tv.setTextSize(TypedValue.COMPLEX_UNIT_SP, 11);
            tv.setAllCaps(true);
            tv.setTextColor(0xFF80CBC4); // teal_200 — matches colorSecondary
            tv.setTypeface(null, android.graphics.Typeface.BOLD);
            int px12 = dpToPx(parent, 12);
            int px16 = dpToPx(parent, 16);
            int px4  = dpToPx(parent, 4);
            tv.setPadding(px16, px12, px16, px4);
            tv.setClickable(false);
            return new HeaderViewHolder(tv);
        } else {
            RadioButton rb = new RadioButton(parent.getContext());
            rb.setLayoutParams(new RecyclerView.LayoutParams(
                    ViewGroup.LayoutParams.MATCH_PARENT,
                    ViewGroup.LayoutParams.WRAP_CONTENT));
            rb.setClickable(false);
            rb.setFocusable(false);
            return new DeviceViewHolder(rb);
        }
    }

    @Override
    public void onBindViewHolder(RecyclerView.ViewHolder holder, int position) {
        Item item = ITEMS.get(position);
        if (holder instanceof HeaderViewHolder) {
            ((HeaderViewHolder) holder).label.setText(item.label);
        } else {
            DeviceViewHolder dvh = (DeviceViewHolder) holder;
            dvh.radioButton.setText(DeviceRegistry.forId(item.deviceId).displayName());
            dvh.radioButton.setChecked(position == selectedPosition);
            holder.itemView.setOnClickListener(v -> {
                int pos = holder.getAdapterPosition();
                if (pos == RecyclerView.NO_POSITION) return;
                int prev = selectedPosition;
                selectedPosition = pos;
                if (prev != RecyclerView.NO_POSITION) notifyItemChanged(prev);
                notifyItemChanged(selectedPosition);
                listener.onDeviceSelected(ITEMS.get(pos).deviceId);
            });
        }
    }

    // ── ViewHolders ────────────────────────────────────────────────────────────

    static class HeaderViewHolder extends RecyclerView.ViewHolder {
        final TextView label;
        HeaderViewHolder(TextView tv) { super(tv); label = tv; }
    }

    static class DeviceViewHolder extends RecyclerView.ViewHolder {
        final RadioButton radioButton;
        DeviceViewHolder(RadioButton rb) { super(rb); radioButton = rb; }
    }

    private static int dpToPx(ViewGroup parent, int dp) {
        return Math.round(TypedValue.applyDimension(
                TypedValue.COMPLEX_UNIT_DIP, dp,
                parent.getContext().getResources().getDisplayMetrics()));
    }
}
