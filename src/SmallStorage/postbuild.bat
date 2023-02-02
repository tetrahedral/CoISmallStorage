@echo off

for /f "tokens=* USEBACKQ" %%f in (`powershell "(new-object -COM Wscript.Shell).SpecialFolders('MyDocuments')"`) do (
    set DocumentsFolder=%%f
)

set MODS_FOLDER=%DocumentsFolder%\Captain of Industry\Mods
echo MODS_FOLDER=%MODS_FOLDER%

del "%MODS_FOLDER%\SmallStorage\SmallStorage.dll"
copy bin\Debug\net46\SmallStorage.dll "%MODS_FOLDER%\SmallStorage\SmallStorage.dll"

del "%MODS_FOLDER%\SmallStorage\SmallStorage.pdb"
copy bin\Debug\net46\SmallStorage.pdb "%MODS_FOLDER%\SmallStorage\SmallStorage.pdb"