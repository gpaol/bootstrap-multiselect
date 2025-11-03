#!/usr/bin/env pwsh
# ========================================================================
# Bootstrap MultiSelect - Distribution Build Script
# Author: Paolo Gaetano
# Description: Creates distribution files for the plugin (npm package)
# ========================================================================

param(
    [switch]$Clean = $false,
    [switch]$Verbose = $false
)

# Enable strict mode
Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

# Script variables
$ProjectRoot = Split-Path -Parent $PSScriptRoot
$PluginRoot = Join-Path $ProjectRoot "src\BootstrapMultiSelect.Plugin"
$MvcRoot = Join-Path $ProjectRoot "src\BootstrapMultiSelect.MVC"
$SamplesWwwRoot = Join-Path $ProjectRoot "samples\AspNetCore\wwwroot"
$PluginDistRoot = Join-Path $ProjectRoot "dist\plugin"
$NugetDistRoot = Join-Path $ProjectRoot "dist\nuget"

# Function to write colored output
function Write-Status {
    param([string]$Message, [string]$Color = "Cyan")
    Write-Host "[$([DateTime]::Now.ToString('HH:mm:ss'))] " -NoNewline -ForegroundColor Gray
    Write-Host $Message -ForegroundColor $Color
}

function Write-Success {
    param([string]$Message)
    Write-Status $Message "Green"
}

function Write-Warning {
    param([string]$Message)
    Write-Status $Message "Yellow"
}

function Write-Error-Message {
    param([string]$Message)
    Write-Status $Message "Red"
}

# Main execution
try {
    Write-Status "Starting distribution build..." "Cyan"
    Write-Status "Project Root: $ProjectRoot"
    
    # Clean dist folders if requested
    if ($Clean) {
        if (Test-Path $PluginDistRoot) {
            Write-Warning "Cleaning existing plugin dist folder..."
            Remove-Item -Path $PluginDistRoot -Recurse -Force
        }
        if (Test-Path $NugetDistRoot) {
            Write-Warning "Cleaning existing NuGet dist folder..."
            Remove-Item -Path $NugetDistRoot -Recurse -Force
        }
    }
    
    # Create dist folder structure
    Write-Status "Creating dist folder structure..."
    $DistCss = Join-Path $PluginDistRoot "css"
    $DistJs = Join-Path $PluginDistRoot "js"
    $DistLangs = Join-Path $PluginDistRoot "langs"
    
    New-Item -ItemType Directory -Path $DistCss -Force | Out-Null
    New-Item -ItemType Directory -Path $DistJs -Force | Out-Null
    New-Item -ItemType Directory -Path $DistLangs -Force | Out-Null
    New-Item -ItemType Directory -Path $NugetDistRoot -Force | Out-Null
    
    Write-Success "[OK] Folder structure created"
    
    # Create NuGet dist folder
    Write-Status "Creating NuGet dist folder..."
    New-Item -ItemType Directory -Path $NugetDistRoot -Force | Out-Null
    Write-Success "[OK] NuGet folder created"
    
    # Copy CSS files
    Write-Status "Copying CSS files..."
    $CssSource = Join-Path $SamplesWwwRoot "css"
    Copy-Item -Path "$CssSource\jquery-bootstrap-multiselect.css" -Destination "$DistCss\bootstrap-multiselect.css" -Force
    Copy-Item -Path "$CssSource\jquery-bootstrap-multiselect.min.css" -Destination "$DistCss\bootstrap-multiselect.min.css" -Force
    Write-Success "[OK] CSS files copied (2 files)"
    
    # Copy JS files
    Write-Status "Copying JS files..."
    $JsSource = Join-Path $SamplesWwwRoot "js"
    Copy-Item -Path "$JsSource\jquery-bootstrap-multiselect.js" -Destination "$DistJs\bootstrap-multiselect.js" -Force
    Copy-Item -Path "$JsSource\jquery-bootstrap-multiselect.min.js" -Destination "$DistJs\bootstrap-multiselect.min.js" -Force
    Write-Success "[OK] JS files copied (2 files)"
    
    # Copy language files
    Write-Status "Copying language files..."
    $LangsSource = Join-Path $JsSource "langs"
    $LangFiles = Get-ChildItem -Path $LangsSource -Filter "*.js"
    foreach ($LangFile in $LangFiles) {
        Copy-Item -Path $LangFile.FullName -Destination $DistLangs -Force
        if ($Verbose) {
            Write-Host "  - $($LangFile.Name)" -ForegroundColor Gray
        }
    }
    Write-Success "[OK] Language files copied ($($LangFiles.Count) files)"
    
    # Copy additional files to plugin dist root
    Write-Status "Copying additional files to plugin dist..."
    $ReadmeSource = Join-Path $PluginRoot "README.md"
    $LicenseSource = Join-Path $ProjectRoot "LICENSE"
    
    if (Test-Path $ReadmeSource) {
        $ReadmeDest = Join-Path $PluginDistRoot "README.md"
        Copy-Item -Path $ReadmeSource -Destination $ReadmeDest -Force
        Write-Success "[OK] README.md copied to plugin dist"
    }
    
    if (Test-Path $LicenseSource) {
        $LicenseDest = Join-Path $PluginDistRoot "LICENSE"
        Copy-Item -Path $LicenseSource -Destination $LicenseDest -Force
        Write-Success "[OK] LICENSE copied to plugin dist"
    }
    
    # Build NuGet package
    Write-Host ""
    Write-Status "=====================================" "Cyan"
    Write-Status "Building NuGet package..." "Cyan"
    Write-Status "=====================================" "Cyan"
    Write-Host ""
    
    Push-Location $MvcRoot
    try {
        Write-Status "Running dotnet pack..."
        $PackOutput = dotnet pack -c Release --output $NugetDistRoot 2>&1
        
        if ($LASTEXITCODE -eq 0) {
            Write-Success "[OK] NuGet package built successfully"
            
            # List generated packages
            $NugetPackages = @(Get-ChildItem -Path $NugetDistRoot -Filter "*.nupkg")
            if ($Verbose -and $NugetPackages.Count -gt 0) {
                Write-Status "Generated packages:"
                foreach ($Package in $NugetPackages) {
                    Write-Host "  - $($Package.Name)" -ForegroundColor Gray
                }
            }
            Write-Success "[OK] Found $($NugetPackages.Count) NuGet package(s)"
        }
        else {
            Write-Error-Message "dotnet pack failed with exit code $LASTEXITCODE"
            if ($Verbose) {
                Write-Host $PackOutput -ForegroundColor Red
            }
        }
    }
    finally {
        Pop-Location
    }
    
    # Display summary
    Write-Host ""
    Write-Status "=====================================" "Green"
    Write-Success "Distribution build completed!"
    Write-Status "=====================================" "Green"
    Write-Host ""
    
    # Plugin summary
    Write-Status "npm Plugin Package:" "Cyan"
    Write-Host "  Location: $PluginDistRoot" -ForegroundColor Cyan
    Write-Host "  Structure:" -ForegroundColor Gray
    Write-Host "    dist/plugin/css/         - 2 CSS files" -ForegroundColor Gray
    Write-Host "    dist/plugin/js/          - 2 JS files" -ForegroundColor Gray
    Write-Host "    dist/plugin/langs/       - $($LangFiles.Count) language files" -ForegroundColor Gray
    Write-Host ""
    
    # NuGet summary
    Write-Status "NuGet MVC Package:" "Cyan"
    Write-Host "  Location: $NugetDistRoot" -ForegroundColor Cyan
    $NugetPackages = Get-ChildItem -Path $NugetDistRoot -Filter "*.nupkg" -ErrorAction SilentlyContinue
    if ($NugetPackages) {
        Write-Host "  Packages:" -ForegroundColor Gray
        foreach ($Package in $NugetPackages) {
            Write-Host "    - $($Package.Name)" -ForegroundColor Gray
        }
    }
    Write-Host ""
    
    Write-Status "Next steps:" "Yellow"
    Write-Host "  npm plugin:" -ForegroundColor Cyan
    Write-Host "    1. cd dist\plugin" -ForegroundColor Gray
    Write-Host "    2. Copy package.json from src\BootstrapMultiSelect.Plugin" -ForegroundColor Gray
    Write-Host "    3. Update version in package.json if needed" -ForegroundColor Gray
    Write-Host "    4. npm publish" -ForegroundColor Gray
    Write-Host ""
    Write-Host "  NuGet package:" -ForegroundColor Cyan
    Write-Host "    1. Review packages in dist\nuget" -ForegroundColor Gray
    Write-Host "    2. dotnet nuget push dist\nuget\*.nupkg --api-key YOUR_KEY --source https://api.nuget.org/v3/index.json" -ForegroundColor Gray
    Write-Host ""
    
}
catch {
    Write-Error-Message "Build failed: $($_.Exception.Message)"
    exit 1
}
