# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2025-11-03

### Added

- Complete localization system with 6 languages (EN, IT, ES, FR, DE, PT)
- ASP.NET Core MVC library with TagHelper and HtmlHelper support (`BootstrapMultiSelect.MVC`)
- NuGet package with multi-targeting support (.NET 8.0, 9.0)
- npm package for jQuery plugin distribution (`bootstrap-multiselect`)
- Build automation scripts (PowerShell and Batch) for distribution packages
- Plugin package structure with proper npm/Git ignore configurations
- Comprehensive documentation with code examples
- Examples project with live demonstrations
- Support for grouped options (OptGroups)
- Search and filter functionality
- Select All/Deselect All buttons
- Event system for selection changes
- Programmatic API for dynamic control
- jQuery Validation integration with visual feedback
- Form reset functionality
- Minified CSS file for production use

### Changed

- Improved configuration system with data attributes
- Enhanced accessibility with ARIA labels
- Better Bootstrap 5 integration
- Optimized CSS and JavaScript performance
- Renamed `locale` property to `lang` for consistency across all components
- Updated all language files to version 1.1.0
- Improved language file documentation with clear usage instructions
- Fixed language file registration system (now registers only, doesn't auto-apply)

### Fixed

- Language files now properly register translations without overriding global defaults
- Corrected data attribute naming from `data-locale` to `data-lang`
- Fixed form validation integration with multiselect control
- Improved initial selection handling from HTML attributes

### Documentation

- Added comprehensive plugin development guide (DEVELOPMENT.md)
- Added build scripts documentation (scripts/README.md)
- Added detailed language files guide (src/BootstrapMultiSelect.Plugin/src/langs/README.md)
- Updated MVC library README with corrected language examples
- Added GitHub Actions integration guide
- Created setup summary documentation
- Improved code examples with XML documentation comments

## [1.0.0] - 2025-10-30

### Added

- Initial release
- Bootstrap 5 integration
- jQuery plugin implementation
- Basic multi-select functionality
- Declarative configuration via data attributes
- Custom events support
