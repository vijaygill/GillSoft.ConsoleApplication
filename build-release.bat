@echo off

setlocal

set MSBUILD_EXE=msbuild

%MSBUILD_EXE% build-release.proj

endlocal

pause