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
$NpmDistRoot = Join-Path $ProjectRoot "dist\npm"
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
        if (Test-Path $NpmDistRoot) {
            Write-Warning "Cleaning existing npm dist folder..."
            Remove-Item -Path $NpmDistRoot -Recurse -Force
        }
        if (Test-Path $NugetDistRoot) {
            Write-Warning "Cleaning existing NuGet dist folder..."
            Remove-Item -Path $NugetDistRoot -Recurse -Force
        }
    }
    
    # Create dist folder structure
    Write-Status "Creating dist folder structure..."
    New-Item -ItemType Directory -Path $NpmDistRoot -Force | Out-Null
    New-Item -ItemType Directory -Path $NugetDistRoot -Force | Out-Null
    
    Write-Success "[OK] Folder structure created"
    
    # Build npm package
    Write-Host ""
    Write-Status "=====================================" "Cyan"
    Write-Status "Building npm package..." "Cyan"
    Write-Status "=====================================" "Cyan"
    Write-Host ""
    
    Push-Location $PluginRoot
    try {
        Write-Status "Running npm pack..."
        
        # Temporarily disable ErrorActionPreference for npm pack
        $PrevErrorActionPreference = $ErrorActionPreference
        $ErrorActionPreference = "Continue"
        
        # Run npm pack
        $NpmOutput = npm pack 2>&1
        $NpmExitCode = $LASTEXITCODE
        
        # Restore ErrorActionPreference
        $ErrorActionPreference = $PrevErrorActionPreference
        
        if ($NpmExitCode -eq 0) {
            Write-Success "[OK] npm package built successfully"
            
            # Find the generated .tgz file
            $TgzFiles = @(Get-ChildItem -Path $PluginRoot -Filter "*.tgz")
            if ($TgzFiles.Count -gt 0) {
                foreach ($TgzFile in $TgzFiles) {
                    Write-Status "Copying $($TgzFile.Name) to npm dist..."
                    Copy-Item -Path $TgzFile.FullName -Destination $NpmDistRoot -Force
                    
                    # Clean up the .tgz file from plugin root
                    Remove-Item -Path $TgzFile.FullName -Force
                    
                    if ($Verbose) {
                        Write-Host "  - $($TgzFile.Name)" -ForegroundColor Gray
                    }
                }
                Write-Success "[OK] npm package copied to dist ($($TgzFiles.Count) file(s))"
            }
            else {
                Write-Warning "No .tgz files found after npm pack"
                throw "npm pack did not generate a .tgz file"
            }
        }
        else {
            Write-Error-Message "npm pack failed with exit code $NpmExitCode"
            if ($Verbose -and $NpmOutput) {
                Write-Host ($NpmOutput | Out-String) -ForegroundColor Red
            }
            throw "npm pack failed"
        }
    }
    finally {
        Pop-Location
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
    
    # npm summary
    Write-Status "npm Package:" "Cyan"
    Write-Host "  Location: $NpmDistRoot" -ForegroundColor Cyan
    $NpmPackages = Get-ChildItem -Path $NpmDistRoot -Filter "*.tgz" -ErrorAction SilentlyContinue
    if ($NpmPackages) {
        Write-Host "  Packages:" -ForegroundColor Gray
        foreach ($Package in $NpmPackages) {
            Write-Host "    - $($Package.Name)" -ForegroundColor Gray
        }
    }
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
    Write-Host "  npm package:" -ForegroundColor Cyan
    Write-Host "    1. cd dist\npm" -ForegroundColor Gray
    Write-Host "    2. npm publish <package-name>.tgz" -ForegroundColor Gray
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
