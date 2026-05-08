package org.cagnulein.qzcompanionnordictracktreadmill.console.ifit1;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.robolectric.RobolectricTestRunner;
import org.robolectric.annotation.Config;

/**
 * Destructive accessibility failure-path tests.
 */
@RunWith(RobolectricTestRunner.class)
@Config(sdk = 34)
public class GestureServiceTest {

    @Test
    public void performSwipe_withoutConnectedService_doesNotThrow() {
        GestureService.performSwipe(1, 2, 3, 4, GestureService.SWIPE_DURATION_MS);
    }

    @Test
    public void performTap_withoutConnectedService_doesNotThrow() {
        GestureService.performTap(1, 2);
    }
}
