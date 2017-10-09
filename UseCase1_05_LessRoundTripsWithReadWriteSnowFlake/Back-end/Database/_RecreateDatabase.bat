@echo off
echo.
echo WARNING!!!!
echo.
echo Proceed to drop and recreate UseCase1 database?
echo.
echo (Note: Run this bat file as administrator to close existing 
echo        connections by stopping and restarting Postgres)
echo.
pause.
echo.

net stop "PostgreSQL 9.6 Server"
net start "PostgreSQL 9.6 Server"

C:\PostgreSQL\pg96\bin\dropdb.exe -e -i -U postgres "UseCase1"
echo.

C:\PostgreSQL\pg96\bin\psql.exe -U postgres -c "CREATE DATABASE \"UseCase1\" WITH ENCODING = 'UTF8';"
echo.

"%~dp0\_ApplyMigration.bat"

echo.
echo Completed.
pause