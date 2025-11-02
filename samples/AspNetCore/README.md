# Bootstrap MultiSelect - Examples Project

This ASP.NET Core 9.0 web application demonstrates the **Bootstrap MultiSelect** plugin and MVC library with comprehensive, real-world examples.

## 🎯 Purpose

Showcase both implementation approaches of Bootstrap MultiSelect:

1. **jQuery Plugin** - Pure JavaScript/HTML implementation
2. **ASP.NET Core MVC Library** - Full .NET integration with TagHelpers

## 📁 Project Structure

```text
BootstrapMultiSelectExamples/
├── Controllers/
│   ├── HomeController.cs          # Landing page
│   └── ExamplesController.cs      # Plugin & MVC examples
├── Views/
│   ├── Home/
│   │   └── Index.cshtml           # Landing page
│   ├── Examples/
│   │   ├── Plugin.cshtml          # jQuery Plugin examples
│   │   ├── MVC.cshtml             # MVC Library examples
│   │   └── Success.cshtml         # Form submission success
│   └── Shared/
│       └── _Layout.cshtml         # Main layout
├── wwwroot/
│   ├── js/
│   │   ├── jquery-bootstrap-multiselect.js     # Main plugin
│   │   └── langs/                              # Language files
│   │       ├── jquery-bootstrap-multiselect.it.js
│   │       ├── jquery-bootstrap-multiselect.es.js
│   │       ├── jquery-bootstrap-multiselect.fr.js
│   │       ├── jquery-bootstrap-multiselect.de.js
│   │       └── jquery-bootstrap-multiselect.pt.js
│   └── css/
│       └── jquery-bootstrap-multiselect.css    # Plugin styles
└── Models/
    └── ExampleViewModel.cs        # Form model for MVC examples
```

## 🌐 Pages

### 1. Home (`/` or `/Home/Index`)

#### Landing Page

A professional introduction to Bootstrap MultiSelect with:

- Feature highlights (6 key features)
- Side-by-side comparison of Plugin vs MVC Library
- Quick start guides
- Links to example pages

**Technology:** Static HTML with Bootstrap 5

---

### 2. Plugin Examples (`/Examples/Plugin`)

#### Pure jQuery Plugin Demonstrations

8 interactive examples showing plugin capabilities:

1. **Basic MultiSelect** - Simple multi-select with pre-selected options
2. **Max Selection Limit** - Restrict number of selections
3. **OptGroups** - Organized options with groups
4. **Without Select All** - Hide select/deselect all buttons
5. **Programmatic Control** - JavaScript API usage
6. **Pre-selected Values** - Default selections
7. **Disabled Options** - Non-selectable items
8. **Localization** - Multi-language support (IT, ES, FR, DE, PT)

**Plus:**

- Configuration options table (15+ attributes)
- Events documentation
- Code examples for each scenario

**Technology:**

- Pure HTML `<select>` elements
- Data attributes configuration
- Vanilla JavaScript API calls
- No server-side dependencies

**Best for:** Learning plugin features, quick prototyping, non-.NET projects

---

### 3. MVC Examples (`/Examples/MVC`)

#### ASP.NET Core MVC Integration

Production-ready form with complete validation:

**Features:**

- ✅ **TagHelper syntax** (`<multiselect asp-for="..." asp-items="..." />`)
- ✅ **Model binding** with strongly-typed ViewModels
- ✅ **Data Annotations** validation
- ✅ **Client-side validation** (jQuery Validation Unobtrusive)
- ✅ **Server-side validation** with custom rules
- ✅ **Form POST** with validation messages
- ✅ **Success page** displaying submitted data

**Examples in the form:**

1. Countries (Required, basic validation)
2. Skills (Required, max 3 selections)
3. Technologies (OptGroups)
4. Departments (Pre-selected values)
5. Languages (Disabled options)

**Technology:**

- ASP.NET Core 9.0 MVC
- Razor TagHelpers
- Model binding & validation
- Bootstrap 5 form styling

**Best for:** .NET web applications, production scenarios, enterprise apps

---

## 🚀 Running the Project

### Prerequisites

- .NET 9.0 SDK
- Modern web browser

### Steps

1. **Clone the repository:**

   ```bash
   git clone <repository-url>
   cd BootstrapMultiSelectExamples
   ```

2. **Restore dependencies:**

   ```bash
   dotnet restore
   ```

3. **Run the application:**

   ```bash
   dotnet run
   ```

4. **Open in browser:**

   ```text
   https://localhost:5034
   ```

## 📚 Learning Path

### For jQuery Plugin Users

1. Start with **Home page** (`/`) to understand the project
2. Explore **Plugin Examples** (`/Examples/Plugin`) for pure JavaScript usage
3. Study the code examples and configuration options
4. Check **Localization Guide** for i18n support

### For ASP.NET Core Developers

1. Start with **Home page** (`/`) for overview
2. Check **MVC Examples** (`/Examples/MVC`) for .NET integration
3. Review `ExamplesController.cs` for server-side implementation
4. Study `ExampleViewModel.cs` for model structure
5. Reference **BootstrapMultiSelect.MVC** library documentation

## 🎨 Key Features Demonstrated

### jQuery Plugin Features

- ✅ Data attribute configuration
- ✅ Search and filtering
- ✅ Select All / Deselect All
- ✅ Maximum selection limits
- ✅ OptGroups support
- ✅ Theme customization
- ✅ Programmatic API
- ✅ Event handling
- ✅ Internationalization (6 languages)
- ✅ Disabled options
- ✅ Custom text overrides

### MVC Library Features

- ✅ TagHelper integration
- ✅ HtmlHelper support
- ✅ Model binding
- ✅ Data Annotations validation
- ✅ Client & server validation
- ✅ Unobtrusive validation
- ✅ Custom validation rules
- ✅ Strongly-typed configuration
- ✅ Bootstrap form integration

## � Related Documentation

- **Main Plugin README:** `../README.md`
- **MVC Library Documentation:** `../BootstrapMultiSelect.MVC/README.md`
- **Localization Guide:** `../LOCALIZATION-GUIDE.md`
- **Language Files:** `wwwroot/js/langs/README.md`

### 📖 Code Examples

For developers who prefer **code examples without running the project**:

- **jQuery Plugin Examples:** See [`PLUGIN-EXAMPLES.md`](PLUGIN-EXAMPLES.md) - Complete examples for pure JavaScript/HTML usage with all configuration options, events, and dynamic updates
- **ASP.NET Core MVC Examples:** See [`MVC-EXAMPLES.md`](MVC-EXAMPLES.md) - Complete examples for .NET integration with TagHelpers, validation, localization, and advanced scenarios

These documentation files provide **copy-paste ready code** covering everything from basic setup to advanced use cases.

## 🛠️ Technology Stack

- **Framework:** ASP.NET Core 9.0 MVC
- **UI:** Bootstrap 5.3
- **JavaScript:** jQuery 3.7.1
- **Validation:** jQuery Validation 1.19.5
- **Icons:** Bootstrap Icons 1.11.3
- **Plugin:** Bootstrap MultiSelect (custom)
- **Library:** BootstrapMultiSelect.MVC (custom)

## 📄 License

This example project is part of the Bootstrap MultiSelect solution and follows the same license terms.

## � Author

Paolo Gaetano

- GitHub: [@gpaol](https://github.com/gpaol)
- Repository: [bootstrap-multiselect](https://github.com/gpaol/bootstrap-multiselect)

## 🤝 Contributing

This is an example project. For plugin or library contributions, see the [main CONTRIBUTING.md](../../CONTRIBUTING.md).

## �💡 Tips

### Switching Languages Globally

In `_Layout.cshtml`, uncomment one of the language file imports and set the global language:

```html
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<script>
    $.fn.bootstrapMultiSelect.lang = 'it'; // Set Italian globally
</script>
```

### Per-Instance Language

Use `data-lang` attribute on specific elements:

```html
<select data-toggle="bootstrap-multiselect" data-lang="es">
    <!-- Spanish interface for this instance only -->
</select>
```

### Debugging

All multiselect changes are logged to console. Open browser DevTools to see:

```javascript
Selection changed: ["value1", "value2"]
```

## 📞 Support

- **Issues:** Report in main repository
- **Documentation:** See related docs above
- **Examples:** This project!
