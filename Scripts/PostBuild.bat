Rem Kill RebornBuddy if it is running Make sure to run the bat file as administrator or it will not work. (Run Rider, or Visual Studio as administrator)
taskkill /F /IM "RebornBuddy.exe"
Rem Get current directory + Output folder 
set currentdir=%cd%
Rem Make sure change this to your own directory
set outputdir="C:\Users\Black\Documents\Rebornbuddy64 1.0.485.0\Routines\"
Rem Go up one directory
set currentdir=%currentdir%\..\Output
cd %currentdir%
Rem Copy everything from the output folder to the specified folder
xcopy /s/z /y %currentdir% %outputdir%

