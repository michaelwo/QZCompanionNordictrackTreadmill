package org.cagnulein.qzcompanionnordictracktreadmill;

import java.io.IOException;
import java.io.InputStream;

interface Shell {
    InputStream execAndGetOutput(String command) throws IOException;
    Process exec(String command) throws IOException;
}
