# Development Guide - Bootstrap MultiSelect Plugin

## 🏗️ Project Structure

```
BootstrapMultiSelect.Plugin/
├── src/                       # Source files (for reference)
│   ├── css/
│   ├── js/
│   └── langs/
├── dist/                      # Distribution files (generated)
│   ├── css/
│   ├── js/
│   └── langs/
├── build.ps1                  # Build script
├── .gitignore                 # Git ignore (excludes dist/)
├── .npmignore                 # npm ignore (excludes src/)
├── package.json               # npm package configuration
├── LICENSE                    # MIT License
└── README.md                  # User documentation
```

## 🔧 Building the Package

### Prerequisites

- PowerShell (Windows) or PowerShell Core (cross-platform)
- Access to the parent `BootstrapMultiSelect.MVC` project

### Build Process

The plugin package is built by copying files from the MVC project's `wwwroot` directory:

```powershell
# Navigate to the plugin directory
cd src/BootstrapMultiSelect.Plugin

# Run the build script
.\build.ps1
```

Or use npm:

```bash
npm run build
```

### What the Build Script Does

1. **Cleans** the `dist/` directory
2. **Copies** JavaScript files from MVC project:
   - `bootstrap-multiselect.js` (source)
   - `bootstrap-multiselect.min.js` (minified)
3. **Copies** CSS files from MVC project:
   - `bootstrap-multiselect.css`
4. **Copies** language files from MVC project:
   - All `.js` files from `langs/` directory
5. **Populates** the `src/` directory with source files (non-minified versions)

## 📦 Publishing to npm

### 1. Build the Package

```bash
npm run build
```

### 2. Test the Package Locally

```bash
# Create a tarball
npm pack

# This creates bootstrap-multiselect-1.1.0.tgz
# You can test this in another project with:
# npm install /path/to/bootstrap-multiselect-1.1.0.tgz
```

### 3. Verify Package Contents

```bash
# Extract and inspect the tarball
tar -tzf bootstrap-multiselect-1.1.0.tgz
```

The package should contain:

- `package/dist/css/*`
- `package/dist/js/*`
- `package/dist/langs/*`
- `package/README.md`
- `package/LICENSE`
- `package/package.json`

### 4. Update Version (if needed)

```bash
# Patch version (1.1.0 -> 1.1.1)
npm version patch

# Minor version (1.1.0 -> 1.2.0)
npm version minor

# Major version (1.1.0 -> 2.0.0)
npm version major
```

### 5. Publish to npm

```bash
# Login to npm (first time only)
npm login

# Publish the package
npm publish

# Or for a dry run (to see what would be published)
npm publish --dry-run
```

## 🔄 Workflow

### When Source Files Change in MVC Project

1. Make changes in `BootstrapMultiSelect.MVC/wwwroot/`
2. Navigate to `BootstrapMultiSelect.Plugin/`
3. Run `npm run build` to update the plugin package
4. Commit changes (only source files, not dist/)
5. Before publishing to npm, the build runs automatically (`prepublishOnly`)

### Version Management

The version is managed in `package.json`. Keep it in sync with:

- MVC NuGet package version
- Git tags
- CHANGELOG.md

## 🚫 Git vs npm

### Git Repository (.gitignore)

Excludes from Git:

- `dist/` directory (generated files)
- `node_modules/`
- Build artifacts

**Why?** Generated files should not be in source control. They're created during the build process.

### npm Package (.npmignore)

Excludes from npm:

- `src/` directory (source files are optional)
- Build scripts (`build.ps1`)
- Development files

**Why?** npm users only need the distribution files in `dist/`, not the source or build infrastructure.

## 🧪 Testing

### Manual Testing

1. Build the package: `npm run build`
2. Pack it: `npm pack`
3. Create a test project:

   ```bash
   mkdir test-project
   cd test-project
   npm init -y
   npm install ../bootstrap-multiselect-1.1.0.tgz
   ```

4. Create a test HTML file and verify it works

### CDN Testing

After publishing to npm, the package is automatically available on CDN services:

- jsDelivr: `https://cdn.jsdelivr.net/npm/bootstrap-multiselect@1.1.0/dist/js/bootstrap-multiselect.js`
- unpkg: `https://unpkg.com/bootstrap-multiselect@1.1.0/dist/js/bootstrap-multiselect.js`

## 📋 Checklist for Publishing

- [ ] MVC project files are up to date
- [ ] Run `npm run build` successfully
- [ ] Review `dist/` directory contents
- [ ] Update version in `package.json` (if needed)
- [ ] Update CHANGELOG.md
- [ ] Test package locally with `npm pack`
- [ ] Commit changes to Git
- [ ] Run `npm publish`
- [ ] Create Git tag: `git tag v1.1.0`
- [ ] Push tag: `git push origin v1.1.0`
- [ ] Verify on npmjs.com
- [ ] Test CDN links (jsDelivr, unpkg)

## 🆘 Troubleshooting

### Build script fails

- Ensure you're in the correct directory
- Check that the MVC project exists at `../BootstrapMultiSelect.MVC/`
- Verify PowerShell execution policy: `Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass`

### npm publish fails

- Check you're logged in: `npm whoami`
- Verify package name is available (first time)
- Ensure version number is incremented
- Check network connection

### Package is missing files

- Review `.npmignore` - it might be excluding too much
- Use `npm pack` to inspect contents before publishing
- Check `package.json` "files" array

## 📚 Resources

- [npm Documentation](https://docs.npmjs.com/)
- [Semantic Versioning](https://semver.org/)
- [Creating Node.js modules](https://docs.npmjs.com/creating-node-js-modules)
