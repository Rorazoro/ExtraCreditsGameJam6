REM echo "Create Release"
REM "%GITHUB_RELEASE_PATH%" release ^
REM     --user rorazoro ^
REM     --repo %RELEASE_REPO% ^
REM     --tag %RELEASE_TAG% ^
REM     --name %RELEASE_NAME% ^
REM     --description %RELEASE_DESC% ^
REM     --pre-release

REM echo "Compressing artifacts into one file"
REM zip -r artifacts.zip artifacts_folder

REM echo "Exporting token and enterprise api to enable github-release tool"
REM export GITHUB_TOKEN=$$$$$$$$$$$$
REM export GITHUB_API=https://git.{your domain}.com/api/v3 # needed only for enterprise

REM echo "Deleting release from github before creating new one"
REM github-release delete --user ${GITHUB_ORGANIZATION} --repo ${GITHUB_REPO} --tag ${VERSION_NAME}

echo "Creating a new release in github"
"%GITHUB_RELEASE_PATH%" release --user rorazoro --repo "%RELEASE_REPO%" --tag "%RELEASE_TAG%" --name "%RELEASE_NAME%"

echo "Uploading the artifacts into github"
%GITHUB_RELEASE_PATH% upload --user rorazoro --repo "%RELEASE_REPO%" --tag "%RELEASE_TAG%" --name "%RELEASE_NAME%" --file "%ARTIFACTS%\\Builds\\**"