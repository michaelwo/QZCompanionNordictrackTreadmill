package org.cagnulein.qzcompanionnordictracktreadmill.reader;

import java.io.IOException;
import java.io.InputStream;

public interface Shell {
    InputStream execAndGetOutput(String command) throws IOException;
    Process exec(String command) throws IOException;
}
