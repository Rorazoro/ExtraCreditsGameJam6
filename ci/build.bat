set BUILD_PATH=%WORKSPACE%\Builds\%BUILD_TARGET%
set ZIP_PATH="D:\Program Files\7-Zip\7z.exe"

echo "Building for "%BUILD_TARGET%
"%UNITY_PATH%" ^
-quit ^
-logFile ^
-batchmode ^
-nographics ^
-projectPath %WORKSPACE% ^
-buildTarget %BUILD_TARGET% ^
-customBuildTarget %BUILD_TARGET% ^
-customBuildName %BUILD_NAME% ^
-customBuildPath %BUILD_PATH% ^
-executeMethod BuildCommand.PerformBuild
set UNITY_EXIT_CODE=%ERRORLEVEL%

if %UNITY_EXIT_CODE%==0 echo "Run succeeded, no failures occurred"
if %UNITY_EXIT_CODE%==2 echo "Run succeeded, some tests failed"
if %UNITY_EXIT_CODE%==3 echo "Run failure (other failure)"

%ZIP_PATH% a -tzip %BUILD_TARGET%_Build.zip -r %BUILD_PATH%\*.*
move %BUILD_TARGET%_Build.zip %ARTIFACTS%

exit %UNITY_EXIT_CODE%