echo "Checking Unity Activation"

"%UNITY_PATH%" ^
-logFile ^
-batchmode ^
-nographics ^
-manualLicenseFile %UNITY_LICENSE_CONTENT%
set UNITY_EXIT_CODE=%ERRORLEVEL%