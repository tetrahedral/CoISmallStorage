@echo off

if "%COI_ROOT%" == "" (
	echo Environmental variable COI_ROOT is not defined
	goto :eof
)

for %%s in ("Mafi.dll" "Mafi.Core.dll" "Mafi.Base.dll" "Mafi.Unity.dll" "Mafi.ModsAuthoringSupport.dll") do (
	del "%~dp0\%%s"
	copy "%COI_ROOT%\Captain of Industry_Data\Managed\%%s" "%~dp0\%%s"
)