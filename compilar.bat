@echo off
TITLE Compilador CLI de Magirenko
IF EXIST "C:\Program Files\dotnet\dotnet.exe" (
    GOTO ejecutar
) ELSE (
    IF EXIST "C:\Program Files (x86)\dotnet\dotnet.exe" (
        GOTO ejecutar
    ) ELSE (
      ECHO Nececitas .net 8.0+ para poder compilar este software con el Compilador CLI De Magirenko.
      ECHO.
      ECHO Requisitos:
      ECHO  - Lua for Windows
      ECHO  - .net 8.0+
      PAUSE
    )
)

:ejecutar
 setlocal
 set COMMAND=lua
where %COMMAND% >nul 2>&1
 if %ERRORLEVEL% EQU 0 (
  lua compilar.lua
 ) else (
  echo Nececitas instalar Lua for windows para compilar este software con el Compilador CLI De Magirenko.
 ) 
 endlocal
:end
