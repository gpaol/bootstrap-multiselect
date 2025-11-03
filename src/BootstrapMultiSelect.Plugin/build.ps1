# Build script for Bootstrap MultiSelect Plugin
# This script copies source files and prepares the distribution package

Write-Host "Building Bootstrap MultiSelect Plugin..." -ForegroundColor Green

# Define paths
$projectRoot = $PSScriptRoot
$mvcWwwroot = Join-Path $projectRoot "..\BootstrapMultiSelect.MVC\wwwroot"
$srcDir = Join-Path $projectRoot "src"
$distDir = Join-Path $projectRoot "dist"

# Clean dist directory
Write-Host "Cleaning dist directory..." -ForegroundColor Yellow
if (Test-Path $distDir) {
    Remove-Item -Path "$distDir\*" -Recurse -Force
}

# Create dist directories
New-Item -ItemType Directory -Force -Path "$distDir\js" | Out-Null
New-Item -ItemType Directory -Force -Path "$distDir\css" | Out-Null
New-Item -ItemType Directory -Force -Path "$distDir\langs" | Out-Null

# Copy JavaScript files
Write-Host "Copying JavaScript files..." -ForegroundColor Yellow
Copy-Item -Path "$mvcWwwroot\js\bootstrap-multiselect.js" -Destination "$distDir\js\" -Force
Copy-Item -Path "$mvcWwwroot\js\bootstrap-multiselect.min.js" -Destination "$distDir\js\" -Force

# Copy to src as well (source files)
Copy-Item -Path "$mvcWwwroot\js\bootstrap-multiselect.js" -Destination "$srcDir\js\" -Force

# Copy CSS files
Write-Host "Copying CSS files..." -ForegroundColor Yellow
Copy-Item -Path "$mvcWwwroot\css\bootstrap-multiselect.css" -Destination "$distDir\css\" -Force

# Copy to src as well
Copy-Item -Path "$mvcWwwroot\css\bootstrap-multiselect.css" -Destination "$srcDir\css\" -Force

# Copy language files
Write-Host "Copying language files..." -ForegroundColor Yellow
Copy-Item -Path "$mvcWwwroot\langs\*.js" -Destination "$distDir\langs\" -Force

# Copy README.md for language files
if (Test-Path "$mvcWwwroot\langs\README.md") {
    Copy-Item -Path "$mvcWwwroot\langs\README.md" -Destination "$distDir\langs\" -Force
}

# Copy only non-minified language files to src
Get-ChildItem -Path "$mvcWwwroot\langs\*.js" -Exclude "*.min.js" | ForEach-Object {
    Copy-Item -Path $_.FullName -Destination "$srcDir\langs\" -Force
}

# Copy README.md to src/langs as well
if (Test-Path "$mvcWwwroot\langs\README.md") {
    Copy-Item -Path "$mvcWwwroot\langs\README.md" -Destination "$srcDir\langs\" -Force
}

Write-Host "Build completed successfully!" -ForegroundColor Green
Write-Host ""
Write-Host "Distribution files are in: $distDir" -ForegroundColor Cyan
Write-Host "Source files are in: $srcDir" -ForegroundColor Cyan
Write-Host ""
Write-Host "Next steps:" -ForegroundColor Magenta
Write-Host "  1. Review the files in dist/" -ForegroundColor White
Write-Host "  2. Test the package with: npm pack" -ForegroundColor White
Write-Host "  3. Publish to npm with: npm publish" -ForegroundColor White
