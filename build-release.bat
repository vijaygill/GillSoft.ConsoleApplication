@echo off

setlocal

set MSBUILD_EXE=msbuild

call C:\Dev\000-DevTools\BuildTools\setenv.bat

%MSBUILD_EXE% build-release.proj

endlocal

pause