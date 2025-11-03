# BootstrapMultiSelect.MVC

A .NET Core MVC library providing TagHelper and HtmlHelper extensions for the Bootstrap MultiSelect jQuery plugin.

## Installation

Install the package via NuGet:

```bash
dotnet add package BootstrapMultiSelect.MVC
```

Or via Package Manager Console:

```powershell
Install-Package BootstrapMultiSelect.MVC
```

### How It Works - Static Web Assets

After installation, all CSS and JavaScript files are **automatically available** via ASP.NET Core's **Static Web Assets** feature.

**Important:** Files are **NOT physically copied** to your `wwwroot` folder. They are:

- ✅ Served directly from the NuGet package cache during development
- ✅ Available immediately at `~/lib/bootstrap-multiselect/` URLs
- ✅ Automatically included in publish output
- ✅ Removed automatically when you uninstall the package

This is the **same behavior** as Bootstrap, jQuery, and other standard NuGet packages.

### Usage in Your Application

Simply add the script and style references in your `_Layout.cshtml`:

```html
<!DOCTYPE html>
<html>
<head>
    <!-- Bootstrap MultiSelect CSS -->
    <link rel="stylesheet" href="~/lib/bootstrap-multiselect/css/bootstrap-multiselect.min.css" />
</head>
<body>
    <!-- Your content -->
    
    <!-- Required: jQuery and Bootstrap -->
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    
    <!-- Bootstrap MultiSelect JS -->
    <script src="~/lib/bootstrap-multiselect/js/bootstrap-multiselect.min.js"></script>
    
    <!-- Optional: Language file -->
    <script src="~/lib/bootstrap-multiselect/langs/jquery-bootstrap-multiselect.it.min.js"></script>
</body>
</html>
```

**That's it!** The files are available immediately - no build required, no manual copying needed.

### Troubleshooting

**Files not found (404)?**

1. Verify package is installed: `dotnet list package`
2. Ensure `app.UseStaticFiles()` is in your `Program.cs`
3. Restart your application
4. Check the URL path is correct: `~/lib/bootstrap-multiselect/...`

**Note:** You will **NOT** see a `wwwroot/lib/bootstrap-multiselect` folder in your project - this is normal and correct!

## Localization

The library supports multiple languages through lang files. Available languages:

- **en** - English (default, built-in)
- **it** - Italian
- **es** - Spanish
- **fr** - French
- **de** - German
- **pt** - Portuguese

### Global Localization

To set a language globally for all multiselect instances, you must use the `lang` property:

```html
<!-- Load plugin -->
<script src="~/lib/bootstrap-multiselect/js/bootstrap-multiselect.min.js"></script>

<!-- Load Italian translations (optional but recommended) -->
<script src="~/lib/bootstrap-multiselect/langs/jquery-bootstrap-multiselect.it.min.js"></script>

<!-- Set Italian as global default -->
<script>
    $.fn.bootstrapMultiSelect.lang = 'it';
</script>
```

Now all multiselect instances will use Italian text automatically.

**Note:** Loading the language file provides the translations, but you still need to set `$.fn.bootstrapMultiSelect.lang = 'it'` to apply them globally.

### Dynamic Locale Based on Culture

In your `_Layout.cshtml`:

```html
@using System.Globalization
@{
    var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
}

<script src="~/lib/bootstrap-multiselect/js/bootstrap-multiselect.min.js"></script>

@if (culture != "en")
{
    <!-- Language is automatically set when the file is loaded -->
    <script src="~/lib/bootstrap-multiselect/langs/jquery-bootstrap-multiselect.@(culture).min.js"></script>

    <!-- Set a global default -->
    <script>
        $.fn.bootstrapMultiSelect.lang = '@(culture)';
    </script>
}
```

### Per-Instance Language

You can override the global language for specific instances:

**Tag Helper:**

```html
<multiselect asp-for="SelectedItems" 
             asp-items="Model.AvailableItems"
             lang="it"
             placeholder="Seleziona elementi..." />
```

**HTML Helper:**

```csharp
@Html.MultiSelectFor(m => m.SelectedItems, Model.AvailableItems, new MultiSelectConfig
{
    Lang = "it",
    Placeholder = "Seleziona elementi..."
})
```

### Priority Order

When determining which text to display:

1. **Explicit properties** (e.g., `placeholder="Custom text"`)
2. **Language file** (e.g., Italian language)
3. **Default English** (built-in)

### Available Language Files

Language files are automatically available via Static Web Assets at: `~/lib/bootstrap-multiselect/langs/`

- `jquery-bootstrap-multiselect.it.min.js` - Italian
- `jquery-bootstrap-multiselect.es.min.js` - Spanish
- `jquery-bootstrap-multiselect.fr.min.js` - French
- `jquery-bootstrap-multiselect.de.min.js` - German
- `jquery-bootstrap-multiselect.pt.min.js` - Portuguese

## Usage

### Tag Helper

Add the tag helper to your `_ViewImports.cshtml`:

```csharp
@addTagHelper *, BootstrapMultiSelect.MVC
```

Then use in your views:

```html
<multiselect asp-for="SelectedItems" 
             asp-items="Model.AvailableItems"
             placeholder="Select items..."
             max-selection="3"
             theme="primary"
             search="true"
             select-all="true" />
```

#### Tag Helper Attributes

| Attribute | Type | Default | Description |
|-----------|------|---------|-------------|
| `asp-for` | ModelExpression | (required) | The model property to bind |
| `asp-items` | IEnumerable&lt;SelectListItem&gt; | (required) | The items to display |
| `placeholder` | string | "Select items..." | Placeholder text |
| `max-selection` | int | 0 | Maximum items (0 = unlimited) |
| `select-all` | bool | true | Show select all buttons |
| `search` | bool | true | Enable search |
| `width` | string | "100%" | Dropdown width |
| `theme` | string | "primary" | Bootstrap theme |
| `close-on-select` | bool | false | Close on select |
| `button-class` | string | null | Custom button class |
| `search-placeholder` | string | "Search..." | Search placeholder |
| `select-all-text` | string | "Select All" | Select all button text |
| `deselect-all-text` | string | "Deselect All" | Deselect all button text |
| `no-results-text` | string | "No results found" | No results message |
| `max-height` | string | "300px" | Max dropdown height |
| `items-selected-text` | string | "items selected" | Text for multiple selection count |
| `lang` | string | null | Language code (e.g., "it", "es", "fr") |

### HTML Helper

Add the namespace to your view or `_ViewImports.cshtml`:

```csharp
@using BootstrapMultiSelect.MVC.HtmlHelpers
@using BootstrapMultiSelect.MVC.Models
```

Then use in your views:

```csharp
@Html.MultiSelectFor(m => m.SelectedItems, Model.AvailableItems, new MultiSelectConfig
{
    Placeholder = "Select items...",
    MaxSelection = 3,
    Theme = "primary",
    Search = true,
    SelectAll = true
})
```

Or without model binding:

```csharp
@Html.MultiSelect("selectedItems", Model.AvailableItems, new MultiSelectConfig
{
    Placeholder = "Choose items...",
    Theme = "success"
})
```

## Examples

### Basic Example

**Model:**

```csharp
public class MyViewModel
{
    public List<string> SelectedItems { get; set; } = new List<string>();
    public List<SelectListItem> AvailableItems { get; set; }
}
```

**Controller:**

```csharp
public IActionResult Index()
{
    var model = new MyViewModel
    {
        AvailableItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Item 1" },
            new SelectListItem { Value = "2", Text = "Item 2" },
            new SelectListItem { Value = "3", Text = "Item 3" },
            new SelectListItem { Value = "4", Text = "Item 4" }
        }
    };
    return View(model);
}
```

**View (Tag Helper):**

```html
<multiselect asp-for="SelectedItems" 
             asp-items="Model.AvailableItems"
             placeholder="Select items..."
             theme="primary" />
```

**View (HTML Helper):**

```csharp
@Html.MultiSelectFor(m => m.SelectedItems, Model.AvailableItems, new MultiSelectConfig
{
    Placeholder = "Select items...",
    Theme = "primary"
})
```

### With Pre-selected Items

```csharp
var model = new MyViewModel
{
    SelectedItems = new List<string> { "1", "3" }, // Pre-select items 1 and 3
    AvailableItems = new List<SelectListItem>
    {
        new SelectListItem { Value = "1", Text = "Item 1" },
        new SelectListItem { Value = "2", Text = "Item 2" },
        new SelectListItem { Value = "3", Text = "Item 3" }
    }
};
```

### With Disabled Options

```csharp
var model = new MyViewModel
{
    AvailableItems = new List<SelectListItem>
    {
        new SelectListItem { Value = "1", Text = "Item 1" },
        new SelectListItem { Value = "2", Text = "Item 2 (Disabled)", Disabled = true },
        new SelectListItem { Value = "3", Text = "Item 3" }
    }
};
```

### With OptGroups

```csharp
var model = new MyViewModel
{
    AvailableItems = new List<SelectListItem>
    {
        new SelectListItem { Value = "html", Text = "HTML", Group = "Frontend" },
        new SelectListItem { Value = "css", Text = "CSS", Group = "Frontend" },
        new SelectListItem { Value = "js", Text = "JavaScript", Group = "Frontend" },
        new SelectListItem { Value = "csharp", Text = "C#", Group = "Backend" },
        new SelectListItem { Value = "python", Text = "Python", Group = "Backend" }
    }
};
```

### With Maximum Selection Limit

**Tag Helper:**

```html
<multiselect asp-for="SelectedItems" 
             asp-items="Model.AvailableItems"
             max-selection="3"
             placeholder="Select up to 3 items..." />
```

**HTML Helper:**

```csharp
@Html.MultiSelectFor(m => m.SelectedItems, Model.AvailableItems, new MultiSelectConfig
{
    MaxSelection = 3,
    Placeholder = "Select up to 3 items..."
})
```

### Custom Styling

```html
<multiselect asp-for="SelectedItems" 
             asp-items="Model.AvailableItems"
             theme="success"
             button-class="btn-success"
             width="300px"
             max-height="200px" />
```

### With Localization

**Tag Helper (Italian):**

```html
<multiselect asp-for="SelectedItems" 
             asp-items="Model.AvailableItems"
             lang="it" />
<!-- All text will be in Italian: "Seleziona elementi...", "Cerca...", etc. -->
```

**HTML Helper (Spanish):**

```csharp
@Html.MultiSelectFor(m => m.SelectedItems, Model.AvailableItems, new MultiSelectConfig
{
    Lang = "es"
})
<!-- All text will be in Spanish: "Seleccionar elementos...", "Buscar...", etc. -->
```

**Global Language in Layout:**

```html
<!-- _Layout.cshtml -->
<script src="~/lib/bootstrap-multiselect/js/bootstrap-multiselect.min.js"></script>
<script src="~/lib/bootstrap-multiselect/langs/jquery-bootstrap-multiselect.it.min.js"></script>
<!-- Italian is now automatically set as the global language -->

<!-- Now all multiselect instances in all views will use Italian -->
```

**Dynamic Language Based on User Culture:**

```html
@using System.Globalization
@{
    var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
}

<script src="~/lib/bootstrap-multiselect/js/bootstrap-multiselect.min.js"></script>

@if (culture != "en")
{
    <!-- Automatically sets the language when loaded -->
    <script src="~/lib/bootstrap-multiselect/langs/jquery-bootstrap-multiselect.@(culture).min.js"></script>
}

<!-- Automatically uses user's language (it, es, fr, de, pt) -->
```

## License

MIT License

## 👤 Author

Paolo Gaetano

- GitHub: [@gpaol](https://github.com/gpaol)
- Repository: [bootstrap-multiselect](https://github.com/gpaol/bootstrap-multiselect)

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

See [CONTRIBUTING.md](../../CONTRIBUTING.md) for detailed guidelines.
