@echo off
Rem Kill RebornBuddy if it is running Make sure to run the bat file as administrator or it will not work. (Run Rider, or Visual Studio as administrator)
Rem check if RebornBuddy.exe is running
SETLOCAL EnableExtensions
SET EXE=RebornBuddy.exe
FOR /F %%x IN ('tasklist /NH /FI "IMAGENAME eq %EXE%"') DO IF NOT %%x == %EXE% (
  ECHO %EXE% is Not Running
) ELSE (
  ECHO %EXE is running
  taskkill /F /IM "RebornBuddy.exe"
)

Rem Get current directory + Output folder 
set currentdir=%cd%
Rem Make sure change this to your own directory
set outputdir="C:\Users\Black\Documents\Rebornbuddy64 1.0.485.0\Routines\"
Rem Go up one directory
set currentdir=%currentdir%\..\Output
cd %currentdir%
Rem Copy everything from the output folder to the specified folder
xcopy /s/z /y %currentdir% %outputdir%
pause

