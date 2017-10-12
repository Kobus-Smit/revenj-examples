@echo off

pushd %~dp0\..\..\Common\Lib\Revenj\Compiler\

set temp=_TempOutput\Migration

if exist %temp% rmdir /q /s %temp%
if not exist %temp% md %temp%

java -jar dsl-clc.jar "postgres=localhost/UseCase1?user=postgres&password=postgres" dsl=../../../Src/DSL/DSL sql=..\..\..\..\Back-end\Database\Migration\ temp=%temp% migration apply

popd
pause