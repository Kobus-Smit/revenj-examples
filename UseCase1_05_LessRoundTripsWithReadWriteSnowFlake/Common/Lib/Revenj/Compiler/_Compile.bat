@echo off
pushd "%~dp0\"
if not exist .\_TempOutput\Poco md .\_TempOutput\Poco
if not exist .\_TempOutput\Client md .\_TempOutput\Client
if not exist .\_TempOutput\Postgres md .\_TempOutput\Postgres

java -jar dsl-clc.jar no-prompt force target=dotnet_poco settings=utc temp=_TempOutput/Poco dsl=../../../Src/DSL/DSL dotnet_poco="../../../../Back-end/Lib/Revenj/UseCase1.DSL.Postgres.dll"

java -jar dsl-clc.jar no-prompt force target=dotnet_client settings=utc settings=active-record temp=_TempOutput/Client dsl=../../../Src/DSL/DSL dotnet_client="../../../../Front-end/Lib/Revenj/UseCase1.DSL.Client.dll"

java -jar dsl-clc.jar no-prompt force target=revenj.net settings=utc settings=no-prepare-execute settings=minimal-serialization temp=_TempOutput/Postgres dsl=../../../Src/DSL/DSL revenj.net="../../../../Back-end/Lib/Revenj/UseCase1.DSL.Postgres.dll"

popd
pause