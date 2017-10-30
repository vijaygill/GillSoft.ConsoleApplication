@echo off

call C:\Dev\000-DevTools\BuildTools\setenv.bat

%MSBUILD_EXE% /p:Configuration=Release GillSoft.ConsoleApplication.sln

C:\Dev\000-DevTools\nuget.exe pack GillSoft.ConsoleApplication.nuspec

pause