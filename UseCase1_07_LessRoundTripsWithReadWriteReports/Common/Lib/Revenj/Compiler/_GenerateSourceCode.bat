@echo off
echo Generating source code in to the _TempOutput folder, this may take a few seconds...
echo.
pushd "%~dp0\"
if not exist .\_TempOutput\Client md .\_TempOutput\Client
if not exist .\_TempOutput\Postgres md .\_TempOutput\Postgres

set timestamp=%DATE:~-4%-%DATE:~4,2%-%DATE:~7,2%_%time:~-11,2%-%time:~-8,2%-%time:~-5,2%
set srcDir="%~dp0..\..\..\..\TempTest\"
pushd %srcDir%
md DOTNET_CLIENT\Backup\%timestamp%
md REVENJ_NET\Backup\%timestamp%
move DOTNET_CLIENT\*.cs DOTNET_CLIENT\Backup\%timestamp%
move REVENJ_NET\*.cs REVENJ_NET\Backup\%timestamp%

pushd "%~dp0\"
java -jar dsl-clc.jar no-prompt force source-only target=dotnet_client settings=utc settings=active-record temp=_TempOutput/Client dsl=../../../Src/DSL
copy /y _TempOutput\Client\DOTNET_CLIENT\*.* %srcDir%DOTNET_CLIENT

java -jar dsl-clc.jar no-prompt force source-only target=revenj.net settings=utc settings=no-prepare-execute settings=minimal-serialization temp=_TempOutput/Postgres dsl=../../../Src/DSL
copy /y _TempOutput\Postgres\REVENJ_NET\*.* %srcDir%REVENJ_NET

echo.
echo Done.
echo.
popd
pause