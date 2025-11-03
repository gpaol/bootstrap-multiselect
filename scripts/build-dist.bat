@echo off
REM ========================================================================
REM Bootstrap MultiSelect - Distribution Build Script (Batch)
REM Author: Paolo Gaetano
REM Description: Creates distribution files for the plugin (npm package)
REM ========================================================================

setlocal enabledelayedexpansion

set "PROJECT_ROOT=%~dp0.."
set "PLUGIN_ROOT=%PROJECT_ROOT%\src\BootstrapMultiSelect.Plugin"
set "MVC_ROOT=%PROJECT_ROOT%\src\BootstrapMultiSelect.MVC"
set "SAMPLES_WWWROOT=%PROJECT_ROOT%\samples\AspNetCore\wwwroot"
set "PLUGIN_DIST_ROOT=%PROJECT_ROOT%\dist\plugin"
set "NUGET_DIST_ROOT=%PROJECT_ROOT%\dist\nuget"

echo.
echo ========================================================================
echo Bootstrap MultiSelect - Distribution Build
echo ========================================================================
echo.

REM Check if clean parameter is provided
if "%1"=="-clean" (
    if exist "%PLUGIN_DIST_ROOT%" (
        echo [INFO] Cleaning existing plugin dist folder...
        rmdir /s /q "%PLUGIN_DIST_ROOT%"
    )
    if exist "%NUGET_DIST_ROOT%" (
        echo [INFO] Cleaning existing NuGet dist folder...
        rmdir /s /q "%NUGET_DIST_ROOT%"
    )
)

REM Create dist folder structure
echo [INFO] Creating plugin dist folder structure...
mkdir "%PLUGIN_DIST_ROOT%\css" 2>nul
mkdir "%PLUGIN_DIST_ROOT%\js" 2>nul
mkdir "%PLUGIN_DIST_ROOT%\langs" 2>nul
mkdir "%NUGET_DIST_ROOT%" 2>nul
echo [OK] Plugin folder structure created

REM Copy CSS files
echo [INFO] Copying CSS files...
copy /y "%SAMPLES_WWWROOT%\css\jquery-bootstrap-multiselect.css" "%PLUGIN_DIST_ROOT%\css\bootstrap-multiselect.css" >nul
copy /y "%SAMPLES_WWWROOT%\css\jquery-bootstrap-multiselect.min.css" "%PLUGIN_DIST_ROOT%\css\bootstrap-multiselect.min.css" >nul
echo [OK] CSS files copied (2 files)

REM Copy JS files
echo [INFO] Copying JS files...
copy /y "%SAMPLES_WWWROOT%\js\jquery-bootstrap-multiselect.js" "%PLUGIN_DIST_ROOT%\js\bootstrap-multiselect.js" >nul
copy /y "%SAMPLES_WWWROOT%\js\jquery-bootstrap-multiselect.min.js" "%PLUGIN_DIST_ROOT%\js\bootstrap-multiselect.min.js" >nul
echo [OK] JS files copied (2 files)

REM Copy language files
echo [INFO] Copying language files...
copy /y "%SAMPLES_WWWROOT%\js\langs\*.js" "%PLUGIN_DIST_ROOT%\langs\" >nul
for /f %%i in ('dir /b "%PLUGIN_DIST_ROOT%\langs\*.js" ^| find /c ".js"') do set LANG_COUNT=%%i
echo [OK] Language files copied (!LANG_COUNT! files)

REM Copy additional files to plugin dist
echo [INFO] Copying additional files to plugin dist...
if exist "%PLUGIN_ROOT%\README.md" (
    copy /y "%PLUGIN_ROOT%\README.md" "%PLUGIN_DIST_ROOT%\" >nul
    echo [OK] README.md copied to plugin dist
)
if exist "%PROJECT_ROOT%\LICENSE" (
    copy /y "%PROJECT_ROOT%\LICENSE" "%PLUGIN_DIST_ROOT%\" >nul
    echo [OK] LICENSE copied to plugin dist
)

echo.
echo ========================================================================
echo Building NuGet package...
echo ========================================================================
echo.

REM Build NuGet package
cd /d "%MVC_ROOT%"
echo [INFO] Running dotnet pack...
dotnet pack -c Release --output "%NUGET_DIST_ROOT%"

if %ERRORLEVEL% EQU 0 (
    echo [OK] NuGet package built successfully
) else (
    echo [ERROR] dotnet pack failed with exit code %ERRORLEVEL%
)

cd /d "%~dp0"

echo.
echo ========================================================================
echo Distribution build completed!
echo ========================================================================
echo.
echo npm Plugin Package:
echo   Location: %PLUGIN_DIST_ROOT%
echo   Structure:
echo     dist/plugin/css/         - 2 CSS files
echo     dist/plugin/js/          - 2 JS files
echo     dist/plugin/langs/       - !LANG_COUNT! language files
echo.
echo NuGet MVC Package:
echo   Location: %NUGET_DIST_ROOT%
echo   Packages:
dir /b "%NUGET_DIST_ROOT%\*.nupkg" 2>nul | findstr "." >nul && (
    for %%f in ("%NUGET_DIST_ROOT%\*.nupkg") do echo     - %%~nxf
) || (
    echo     - No packages found
)
echo.
echo Next steps:
echo   npm plugin:
echo     1. cd dist\plugin
echo     2. Copy package.json from src\BootstrapMultiSelect.Plugin
echo     3. Update version in package.json if needed
echo     4. npm publish
echo.
echo   NuGet package:
echo     1. Review packages in dist\nuget
echo     2. dotnet nuget push dist\nuget\*.nupkg --api-key YOUR_KEY --source https://api.nuget.org/v3/index.json
echo.

endlocal
