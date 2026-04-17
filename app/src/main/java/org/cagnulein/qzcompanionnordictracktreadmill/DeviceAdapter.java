package org.cagnulein.qzcompanionnordictracktreadmill;

import android.view.ViewGroup;
import android.widget.RadioButton;
import androidx.recyclerview.widget.RecyclerView;
import org.cagnulein.qzcompanionnordictracktreadmill.device.catalog.DeviceRegistry;
import java.util.Arrays;
import java.util.List;

public class DeviceAdapter extends RecyclerView.Adapter<DeviceAdapter.ViewHolder> {

    interface OnDeviceSelectedListener {
        void onDeviceSelected(DeviceRegistry.DeviceId id);
    }

    static final List<DeviceRegistry.DeviceId> DEVICE_ORDER = Arrays.asList(
        DeviceRegistry.DeviceId.x11i,
        DeviceRegistry.DeviceId.x14i,
        DeviceRegistry.DeviceId.x22i,
        DeviceRegistry.DeviceId.x22i_v2,
        DeviceRegistry.DeviceId.x22i_noadb,
        DeviceRegistry.DeviceId.x9i,
        DeviceRegistry.DeviceId.t85s,
        DeviceRegistry.DeviceId.t95s,
        DeviceRegistry.DeviceId.s40,
        DeviceRegistry.DeviceId.nordictrack_2450,
        DeviceRegistry.DeviceId.nordictrack_2950,
        DeviceRegistry.DeviceId.nordictrack_2950_maxspeed22,
        DeviceRegistry.DeviceId.proform_2000,
        DeviceRegistry.DeviceId.proform_carbon_e7,
        DeviceRegistry.DeviceId.se9i_elliptical,
        DeviceRegistry.DeviceId.proform_pro_9000,
        DeviceRegistry.DeviceId.proform_carbon_c10,
        DeviceRegistry.DeviceId.proform_carbon_t14,
        DeviceRegistry.DeviceId.s15i,
        DeviceRegistry.DeviceId.s22i,
        DeviceRegistry.DeviceId.s22i_NTEX02121_5,
        DeviceRegistry.DeviceId.s22i_NTEX02117_2,
        DeviceRegistry.DeviceId.s22i_noadb,
        DeviceRegistry.DeviceId.s27i,
        DeviceRegistry.DeviceId.tdf10,
        DeviceRegistry.DeviceId.tdf10_inclination,
        DeviceRegistry.DeviceId.exp7i,
        DeviceRegistry.DeviceId.other,
        DeviceRegistry.DeviceId.x32i,
        DeviceRegistry.DeviceId.x32i_NTL39019,
        DeviceRegistry.DeviceId.x32i_NTL39221,
        DeviceRegistry.DeviceId.c1750,
        DeviceRegistry.DeviceId.c1750_2020,
        DeviceRegistry.DeviceId.c1750_2020_kph,
        DeviceRegistry.DeviceId.c1750_mph_minus3grade,
        DeviceRegistry.DeviceId.c1750_NTL14122_2_MPH,
        DeviceRegistry.DeviceId.elite900,
        DeviceRegistry.DeviceId.elite1000,
        DeviceRegistry.DeviceId.proform_pro_2000,
        DeviceRegistry.DeviceId.c1750_2021,
        DeviceRegistry.DeviceId.t65s,
        DeviceRegistry.DeviceId.t75s,
        DeviceRegistry.DeviceId.grand_tour_pro,
        DeviceRegistry.DeviceId.proform_studio_bike_pro22,
        DeviceRegistry.DeviceId.NTEX71021
    );

    private int selectedPosition = RecyclerView.NO_POSITION;
    private final OnDeviceSelectedListener listener;

    DeviceAdapter(OnDeviceSelectedListener listener) {
        this.listener = listener;
    }

    void setSelectedId(DeviceRegistry.DeviceId id) {
        int newPos = DEVICE_ORDER.indexOf(id);
        if (newPos < 0) return;
        int prev = selectedPosition;
        selectedPosition = newPos;
        if (prev != RecyclerView.NO_POSITION) notifyItemChanged(prev);
        notifyItemChanged(selectedPosition);
    }

    DeviceRegistry.DeviceId getSelectedId() {
        return selectedPosition != RecyclerView.NO_POSITION
                ? DEVICE_ORDER.get(selectedPosition)
                : DeviceRegistry.DeviceId.other;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        RadioButton rb = new RadioButton(parent.getContext());
        rb.setLayoutParams(new RecyclerView.LayoutParams(
                ViewGroup.LayoutParams.MATCH_PARENT,
                ViewGroup.LayoutParams.WRAP_CONTENT));
        rb.setClickable(false);
        rb.setFocusable(false);
        return new ViewHolder(rb);
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {
        DeviceRegistry.DeviceId id = DEVICE_ORDER.get(position);
        holder.radioButton.setText(DeviceRegistry.forId(id).displayName());
        holder.radioButton.setChecked(position == selectedPosition);
        holder.itemView.setOnClickListener(v -> {
            int pos = holder.getAdapterPosition();
            if (pos == RecyclerView.NO_POSITION) return;
            int prev = selectedPosition;
            selectedPosition = pos;
            if (prev != RecyclerView.NO_POSITION) notifyItemChanged(prev);
            notifyItemChanged(selectedPosition);
            listener.onDeviceSelected(DEVICE_ORDER.get(pos));
        });
    }

    @Override
    public int getItemCount() { return DEVICE_ORDER.size(); }

    static class ViewHolder extends RecyclerView.ViewHolder {
        final RadioButton radioButton;
        ViewHolder(RadioButton rb) {
            super(rb);
            radioButton = rb;
        }
    }
}
