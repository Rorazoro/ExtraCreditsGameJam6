#!/bin/bash
set -x

echo "Checking Unity Activation"
echo ${UNITY_PATH}
${UNITY_PATH} \
    -logFile /dev/stdout \
    -batchmode \
    -nographics \
    -manualLicenseFile ${UNITY_LICENSE_CONTENT}
UNITY_EXIT_CODE=$?