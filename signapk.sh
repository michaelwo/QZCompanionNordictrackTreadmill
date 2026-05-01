#!/bin/bash
jarsigner -verbose -sigalg SHA256withRSA -digestalg SHA-256 -keystore mykeystore.jks -signedjar app-release-signed.apk ./build-download/app-release-unsigned.apk myalias

zipalign -v 4 app-release-signed.apk app-release-signed-aligned.apk

mv app-release-signed-aligned.apk QZCompanionNordictrackTreadmill.apk 

echo ready to deploy
