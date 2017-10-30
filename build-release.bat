@echo off

call C:\Dev\000-DevTools\BuildTools\setenv.bat

%MSBUILD_EXE% build-release.proj

pause