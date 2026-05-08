package org.cagnulein.qzcompanionnordictracktreadmill.glassos;

import android.content.Context;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.content.res.Resources;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.math.BigInteger;
import java.nio.charset.StandardCharsets;
import java.security.KeyFactory;
import java.security.PrivateKey;
import java.security.cert.Certificate;
import java.security.cert.CertificateFactory;
import java.security.cert.X509Certificate;
import java.security.interfaces.RSAPrivateKey;
import java.security.interfaces.RSAPublicKey;
import java.security.spec.PKCS8EncodedKeySpec;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipFile;

import javax.net.ssl.KeyManagerFactory;
import javax.net.ssl.SSLContext;
import javax.net.ssl.TrustManagerFactory;

final class GlassOsCredentials {
    static final String CLIENT_ID_HEADER_VALUE = "com.ifit.rivendell";

    private static final String[] RESOURCE_PACKAGES = {
            "com.ifit.rivendell",
            "com.ifit.glassos_service"
    };

    private static final String RAW_ENTRY_PREFIX = "res/raw/img_icon_";

    private final SSLContext sslContext;

    private GlassOsCredentials(SSLContext sslContext) {
        this.sslContext = sslContext;
    }

    SSLContext sslContext() {
        return sslContext;
    }

    static GlassOsCredentials load(Context context) throws Exception {
        PackageManager pm = context.getPackageManager();
        SharedPreferences prefs = context.getSharedPreferences("glassos_cred_v1", Context.MODE_PRIVATE);
        List<Exception> failures = new ArrayList<>();
        for (String packageName : RESOURCE_PACKAGES) {
            try {
                DiscoveredKeys keys = resolveKeys(pm, prefs, packageName);
                Resources resources = pm.getResourcesForApplication(packageName);
                String certPem = readPem(resources, packageName, keys.cert, "CERTIFICATE");
                String keyPem  = readPem(resources, packageName, keys.key,  "PRIVATE KEY");
                String caPem   = readPem(resources, packageName, keys.ca,   "CERTIFICATE");
                return new GlassOsCredentials(buildSslContext(certPem, keyPem, caPem));
            } catch (Exception e) {
                failures.add(e);
            }
        }
        Exception e = new Exception("GlassOS credential resources not found in any known package");
        for (Exception f : failures) e.addSuppressed(f);
        throw e;
    }

    private static DiscoveredKeys resolveKeys(PackageManager pm, SharedPreferences prefs,
            String packageName) throws Exception {
        long currentVersion = pm.getPackageInfo(packageName, 0).getLongVersionCode();
        long cachedVersion  = prefs.getLong(packageName + "_version", -1);

        if (cachedVersion == currentVersion) {
            String cert = prefs.getString(packageName + "_cert", null);
            String key  = prefs.getString(packageName + "_key",  null);
            String ca   = prefs.getString(packageName + "_ca",   null);
            if (cert != null && key != null && ca != null) return new DiscoveredKeys(cert, key, ca);
        }

        DiscoveredKeys keys = discoverKeys(pm, packageName);
        prefs.edit()
                .putLong(packageName + "_version", currentVersion)
                .putString(packageName + "_cert", keys.cert)
                .putString(packageName + "_key",  keys.key)
                .putString(packageName + "_ca",   keys.ca)
                .apply();
        return keys;
    }

    // Scans the installed APK for raw resources that decode as X.509 certs or RSA private keys,
    // then identifies the CA cert (self-signed), client cert (signed by CA), and matching private
    // key by comparing RSA moduli. No hardcoded resource names needed.
    private static DiscoveredKeys discoverKeys(PackageManager pm, String packageName) throws Exception {
        String apkPath = pm.getApplicationInfo(packageName, 0).sourceDir;

        List<CandidateCert> certCandidates = new ArrayList<>();
        List<CandidateKey>  keyCandidates  = new ArrayList<>();

        try (ZipFile apk = new ZipFile(apkPath)) {
            Enumeration<? extends ZipEntry> entries = apk.entries();
            while (entries.hasMoreElements()) {
                ZipEntry entry = entries.nextElement();
                if (!entry.getName().startsWith(RAW_ENTRY_PREFIX)) continue;

                String resourceName = resourceNameFromEntry(entry.getName());
                String content = stripJpegMarkers(
                        new String(readFully(apk.getInputStream(entry)), StandardCharsets.UTF_8));

                try {
                    String pem = "-----BEGIN CERTIFICATE-----\n" + content + "-----END CERTIFICATE-----\n";
                    X509Certificate cert = (X509Certificate) CertificateFactory.getInstance("X.509")
                            .generateCertificate(bytes(pem));
                    certCandidates.add(new CandidateCert(resourceName, cert));
                } catch (Exception ignored) {}

                try {
                    String pem = "-----BEGIN PRIVATE KEY-----\n" + content + "-----END PRIVATE KEY-----\n";
                    keyCandidates.add(new CandidateKey(resourceName, parsePrivateKey(pem)));
                } catch (Exception ignored) {}
            }
        }

        CandidateCert ca     = findCa(certCandidates, packageName);
        CandidateCert client = findClientCert(certCandidates, ca, packageName);
        CandidateKey  key    = findMatchingKey(keyCandidates, client, packageName);

        return new DiscoveredKeys(client.name, key.name, ca.name);
    }

    private static CandidateCert findCa(List<CandidateCert> certs, String pkg) throws Exception {
        for (CandidateCert c : certs)
            if (c.cert.getSubjectX500Principal().equals(c.cert.getIssuerX500Principal())) return c;
        throw new Exception("No self-signed CA certificate found in " + pkg);
    }

    private static CandidateCert findClientCert(List<CandidateCert> certs, CandidateCert ca,
            String pkg) throws Exception {
        for (CandidateCert c : certs) {
            if (c == ca) continue;
            try { c.cert.verify(ca.cert.getPublicKey()); return c; } catch (Exception ignored) {}
        }
        throw new Exception("No client certificate signed by CA found in " + pkg);
    }

    private static CandidateKey findMatchingKey(List<CandidateKey> keys, CandidateCert client,
            String pkg) throws Exception {
        if (!(client.cert.getPublicKey() instanceof RSAPublicKey))
            throw new Exception("Client cert is not RSA in " + pkg);
        BigInteger modulus = ((RSAPublicKey) client.cert.getPublicKey()).getModulus();
        for (CandidateKey k : keys)
            if (k.key instanceof RSAPrivateKey && ((RSAPrivateKey) k.key).getModulus().equals(modulus))
                return k;
        throw new Exception("No RSA private key matching client cert found in " + pkg);
    }

    private static String resourceNameFromEntry(String entryName) {
        String basename = entryName.substring(RAW_ENTRY_PREFIX.length());
        int dot = basename.lastIndexOf('.');
        return dot >= 0 ? basename.substring(0, dot) : basename;
    }

    private static String stripJpegMarkers(String content) {
        StringBuilder sb = new StringBuilder();
        for (String line : content.split("\n")) {
            String t = line.trim();
            if (!t.isEmpty() && !"FFD8".equals(t) && !"FFD9".equals(t)) sb.append(t).append('\n');
        }
        return sb.toString();
    }

    private static byte[] readFully(InputStream in) throws Exception {
        try (in) {
            ByteArrayOutputStream out = new ByteArrayOutputStream();
            byte[] buf = new byte[8192];
            int n;
            while ((n = in.read(buf)) >= 0) out.write(buf, 0, n);
            return out.toByteArray();
        }
    }

    private static String readPem(Resources resources, String packageName, String key, String type)
            throws Exception {
        int id = resources.getIdentifier("img_icon_" + key, "raw", packageName);
        if (id <= 0) throw new Resources.NotFoundException("img_icon_" + key);

        StringBuilder body = new StringBuilder();
        try (InputStream in = resources.openRawResource(id)) {
            for (String line : new String(readFully(in), StandardCharsets.UTF_8).split("\n")) {
                String t = line.trim();
                if (!t.isEmpty() && !"FFD8".equals(t) && !"FFD9".equals(t)) body.append(t).append('\n');
            }
        }
        return "-----BEGIN " + type + "-----\n" + body + "-----END " + type + "-----\n";
    }

    private static SSLContext buildSslContext(String certPem, String keyPem, String caPem)
            throws Exception {
        CertificateFactory cf = CertificateFactory.getInstance("X.509");
        Certificate clientCert = cf.generateCertificate(bytes(certPem));
        Certificate caCert     = cf.generateCertificate(bytes(caPem));
        PrivateKey  privateKey = parsePrivateKey(keyPem);

        java.security.KeyStore keyStore = java.security.KeyStore.getInstance(
                java.security.KeyStore.getDefaultType());
        keyStore.load(null, null);
        keyStore.setKeyEntry("client", privateKey, new char[0], new Certificate[]{clientCert});
        KeyManagerFactory kmf = KeyManagerFactory.getInstance(
                KeyManagerFactory.getDefaultAlgorithm());
        kmf.init(keyStore, new char[0]);

        java.security.KeyStore trustStore = java.security.KeyStore.getInstance(
                java.security.KeyStore.getDefaultType());
        trustStore.load(null, null);
        trustStore.setCertificateEntry("glassos-ca", caCert);
        TrustManagerFactory tmf = TrustManagerFactory.getInstance(
                TrustManagerFactory.getDefaultAlgorithm());
        tmf.init(trustStore);

        SSLContext sslContext = SSLContext.getInstance("TLS");
        sslContext.init(kmf.getKeyManagers(), tmf.getTrustManagers(), null);
        return sslContext;
    }

    private static PrivateKey parsePrivateKey(String pem) throws Exception {
        String base64 = pem
                .replace("-----BEGIN PRIVATE KEY-----", "")
                .replace("-----END PRIVATE KEY-----", "")
                .replaceAll("\\s+", "");
        byte[] der = android.util.Base64.decode(base64, android.util.Base64.DEFAULT);
        return KeyFactory.getInstance("RSA").generatePrivate(new PKCS8EncodedKeySpec(der));
    }

    private static ByteArrayInputStream bytes(String s) {
        return new ByteArrayInputStream(s.getBytes(StandardCharsets.UTF_8));
    }

    private static final class DiscoveredKeys {
        final String cert, key, ca;
        DiscoveredKeys(String cert, String key, String ca) { this.cert = cert; this.key = key; this.ca = ca; }
    }

    private static final class CandidateCert {
        final String name;
        final X509Certificate cert;
        CandidateCert(String name, X509Certificate cert) { this.name = name; this.cert = cert; }
    }

    private static final class CandidateKey {
        final String name;
        final PrivateKey key;
        CandidateKey(String name, PrivateKey key) { this.name = name; this.key = key; }
    }
}
