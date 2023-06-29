@ECHO OFF

@REM publish the plugin
dotnet publish^
    --framework net7.0^
    --runtime win-x64^
    --self-contained false^
    --configuration Release^
    -p:DebugType=None^
    -p:DebugSymbols=false^
    -p:GenerateRuntimeConfigurationFiles=false^
    --output %1^
    .

@REM delete the .exe file as it's not needed by MoBro
DEL %1\*.exe

@REM zip the plugin folder
"C:\Program Files\7-Zip\7z.exe" a -tzip "%1.zip" "%1\*"

@REM delete the plugin folder
rmdir /S /Q "%1"
