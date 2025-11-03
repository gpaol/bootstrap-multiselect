# Build Scripts

This folder contains build scripts for creating distribution packages for both the npm plugin and the NuGet MVC library.

## Scripts

### build-dist.ps1 (PowerShell)

Creates the distribution files for both the npm package (plugin) and the NuGet package (MVC library).

**Usage:**

```powershell
# Basic build
.\build-dist.ps1

# Clean build (removes existing dist folder first)
.\build-dist.ps1 -Clean

# Verbose output (shows all language files being copied)
.\build-dist.ps1 -Clean -Verbose
```

**Parameters:**

- `-Clean`: Removes the existing `dist` folder before building
- `-Verbose`: Shows detailed output during the build process

### build-dist.bat (Batch)

Batch file version of the distribution build script for environments without PowerShell. Creates both npm and NuGet packages.

**Usage:**

```cmd
# Basic build
build-dist.bat

# Clean build
build-dist.bat -clean
```

**Parameters:**

- `-clean`: Removes the existing `dist` folder before building

## What the Scripts Do

The build scripts perform the following operations:

### 1. npm Plugin Package

Creates a `dist` folder in `dist/plugin` with the following structure:

```text
dist/
├── css/
│   ├── bootstrap-multiselect.css
│   └── bootstrap-multiselect.min.css
├── js/
│   ├── bootstrap-multiselect.js
│   └── bootstrap-multiselect.min.js
└── langs/
    ├── jquery-bootstrap-multiselect.de.js
    ├── jquery-bootstrap-multiselect.de.min.js
    ├── jquery-bootstrap-multiselect.es.js
    ├── jquery-bootstrap-multiselect.es.min.js
    ├── jquery-bootstrap-multiselect.fr.js
    ├── jquery-bootstrap-multiselect.fr.min.js
    ├── jquery-bootstrap-multiselect.it.js
    ├── jquery-bootstrap-multiselect.it.min.js
    ├── jquery-bootstrap-multiselect.pt.js
    └── jquery-bootstrap-multiselect.pt.min.js
```

### 2. NuGet MVC Package

Builds the .NET library and creates NuGet packages in `dist/nuget`:

- Runs `dotnet pack -c Release` on the MVC project
- Generates `.nupkg` files (main package and symbols package)
- Supports multi-targeting (.NET 8.0 and .NET 9.0)

The scripts also ensure that `README.md` and `LICENSE` files are present in the plugin root directory.

## When to Run

Run these scripts before:

- Publishing to npm (`npm publish`)
- Publishing to NuGet (`dotnet nuget push`)
- Creating a GitHub release
- Testing packages locally (`npm pack` or `dotnet nuget push` to local feed)

## Author

Paolo Gaetano
