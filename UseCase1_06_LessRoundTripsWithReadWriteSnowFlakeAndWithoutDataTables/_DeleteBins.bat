@echo off
pushd "%~dp0\"

rmdir /s /q .vs\Supercharger
rmdir /s /q Common\Packages
for /f "tokens=*" %%g in ('dir /b /ad /s bin') do rmdir /s /q "%%g"
for /f "tokens=*" %%g in ('dir /b /ad /s obj') do rmdir /s /q "%%g"

popd
pause