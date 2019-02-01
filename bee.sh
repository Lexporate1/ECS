#!/usr/bin/env bash
PROJECT="Entitas"
PLUGINS=(changelog doxygen git github msbuild nspec tree utils version)
RESOURCES=.bee

source "${RESOURCES}"/entitas.sh

# changelog => version
CHANGELOG_PATH=CHANGELOG.md
CHANGELOG_CHANGES=CHANGES.md

# doxygen => utils version
DOXYGEN_EXPORT_PATH=docs
DOXYGEN_DOXY_FILES=("${RESOURCES}"/docs/html.doxyfile)
DOXYGEN_DOCSET_NAME="${PROJECT}.docset"
DOXYGEN_DOCSET="com.desperatedevs.${PROJECT}.docset"
DOXYGEN_DOCSET_KEY="$(echo "${PROJECT}" | tr "[:upper:]" "[:lower:]")"
DOXYGEN_DOCSET_ICONS=("${RESOURCES}"/docs/icon.png "${RESOURCES}"/docs/icon@2x.png)

# github => version
GITHUB_CHANGES=CHANGES.md
GITHUB_RELEASE_PREFIX="${PROJECT} "
GITHUB_REPO="sschmid/Entitas-CSharp"
GITHUB_ATTACHMENTS_ZIP=("Build/dist/${PROJECT}.zip")
if [[ -f "${HOME}/.bee/github.sh" ]]; then
  source "${HOME}/.bee/github.sh"
fi

# msbuild
MSBUILD_SOLUTION="${PROJECT}.sln"

# nspec => msbuild
NSPEC_TESTS_PROJECT=Tests/Tests/Tests.csproj
NSPEC_TESTS_RUNNER=Tests/Tests/bin/Release/Tests.exe

# tree
TREE_IGNORE="bin|obj|Library|Libraries|*Tests|Readme|ProjectSettings|Build|docs|Temp|Examples|*.csproj|*.meta|*.sln|*.userprefs|*.properties|tree.txt"
TREE_PATH=tree.txt

# utils
UTILS_RSYNC_INCLUDE="${RESOURCES}"/utils/rsync_include.txt
UTILS_RSYNC_EXCLUDE="${RESOURCES}"/utils/rsync_exclude.txt

# version
VERSION_PATH="${PROJECT}/${PROJECT}"/version.txt
