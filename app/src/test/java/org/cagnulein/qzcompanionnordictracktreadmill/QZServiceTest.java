package org.cagnulein.qzcompanionnordictracktreadmill;

import android.content.Intent;
import android.os.IBinder;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.robolectric.Robolectric;
import org.robolectric.RobolectricTestRunner;
import org.robolectric.android.controller.ServiceController;
import org.robolectric.annotation.Config;

import org.cagnulein.qzcompanionnordictracktreadmill.device.Device;
import static org.junit.Assert.*;

/**
 * Robolectric tests for QZService.
 *
 * Primary goal: force Gradle to compile the real QZService.java so that
 * compilation errors (missing fields, bad imports, etc.) surface here
 * rather than only on the upstream CI.
 *
 * Secondary goal: verify the Android Service lifecycle contract — in
 * particular that onBind() and onUnbind() return the fields they promise,
 * since those fields are easy to accidentally remove during dead-code cleanup.
 */
@RunWith(RobolectricTestRunner.class)
@Config(sdk = 34)
public class QZServiceTest {

    private ServiceController<QZService> controller;

    @Before
    public void setUp() {
        Device.instance = null;
    }

    @After
    public void tearDown() {
        Device.instance = null;
        if (controller != null) {
            try { controller.destroy(); } catch (Exception ignored) {}
        }
    }

    // ── Lifecycle ─────────────────────────────────────────────────────────────

    @Test
    public void serviceCreates_withoutThrowingExceptions() {
        controller = Robolectric.buildService(QZService.class);
        assertNotNull(controller.create().get());
    }

    @Test
    public void serviceStarts_withoutThrowingExceptions() {
        controller = Robolectric.buildService(QZService.class);
        assertNotNull(controller.create().startCommand(0, 1).get());
    }

    @Test
    public void serviceDestroysCleanly() {
        controller = Robolectric.buildService(QZService.class);
        controller.create().startCommand(0, 1).destroy();
        // No exception = pass
    }

    // ── Binding contract ──────────────────────────────────────────────────────

    /**
     * onBind() must not throw — verifies the `binder` field exists.
     * This test would have caught the accidental deletion of `binder`
     * during dead-code cleanup.
     */
    @Test
    public void onBind_doesNotThrow() {
        controller = Robolectric.buildService(QZService.class);
        QZService svc = controller.create().get();
        // IBinder may be null (service doesn't support binding) but must not throw
        IBinder result = svc.onBind(new Intent());
        // No assertion needed — compile + no exception is the contract
    }

    /**
     * onUnbind() must not throw — verifies the `allowRebind` field exists.
     */
    @Test
    public void onUnbind_doesNotThrow() {
        controller = Robolectric.buildService(QZService.class);
        QZService svc = controller.create().get();
        svc.onUnbind(new Intent());
        // No exception = pass
    }
}
