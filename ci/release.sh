echo "Deleting existing v$TAG_MAJOR.$TAG_MINOR.$TAG_PATCH tag"
ci/git_tag_manager.sh \
    -M ${TAG_MAJOR} \
    -m ${TAG_MINOR} \
    -p ${TAG_PATCH} \
    -D

echo "Creating new v$TAG_MAJOR.$TAG_MINOR.$TAG_PATCH tag"
ci/git_tag_manager.sh \
    -M ${TAG_MAJOR} \
    -m ${TAG_MINOR} \
    -p ${TAG_PATCH}

echo "Create release for v$TAG_MAJOR.$TAG_MINOR.$TAG_PATCH"
export RELEASE_FILES="
    ${ARTIFACTS}\\Builds\\StandaloneLinux64_Build.zip 
    ${ARTIFACTS}\\Builds\\StandaloneWindows64_Build.zip 
"

ci/github_release_manager.sh \
    -l ${GITHUB_CREDS_USR} \
    -t ${GITHUB_CREDS_PSW} \
    -o Rorazoro \
    -r ExtraCreditsGameJam6 \
    -d v$TAG_MAJOR.$TAG_MINOR.$TAG_PATCH \
    -c upload ${RELEASE_FILES}