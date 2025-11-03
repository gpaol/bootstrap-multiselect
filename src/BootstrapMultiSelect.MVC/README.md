# BootstrapMultiSelect.MVC

A .NET Core MVC library providing TagHelper and HtmlHelper extensions for the Bootstrap MultiSelect jQuery plugin.

## Installation

1. Add reference to `BootstrapMultiSelect.MVC.dll` in your ASP.NET Core MVC project
2. Include the required CSS and JavaScript files in your layout:

```html
<!-- CSS -->
<link rel="stylesheet" href="~/css/jquery-bootstrap-multiselect.css" />

<!-- JavaScript -->
<script src="~/js/jquery-bootstrap-multiselect.js"></script>

<!-- Optional: Localization file (for non-English languages) -->
<script src="~/js/locales/jquery-bootstrap-multiselect.it.js"></script>
<script>
    // Set global locale for all multiselect instances
    $.fn.bootstrapMultiSelect.locale = 'it';
</script>
```

## Localization

The library supports multiple languages through lang files. Available languages:

- **en** - English (default, built-in)
- **it** - Italian
- **es** - Spanish
- **fr** - French
- **de** - German
- **pt** - Portuguese

### Global Localization

Load the lang file and it will automatically set the global lang:

```html
<!-- Load plugin -->
<script src="~/js/jquery-bootstrap-multiselect.js"></script>

<!-- Load Italian locale - automatically sets locale to 'it' -->
<script src="~/js/locales/jquery-bootstrap-multiselect.it.js"></script>
```

Now all multiselect instances will use Italian text automatically.

### Dynamic Locale Based on Culture

In your `_Layout.cshtml`:

```html
@using System.Globalization
@{
    var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
}

<script src="~/js/jquery-bootstrap-multiselect.js"></script>

@if (culture != "en")
{
    <!-- Language is automatically set when the file is loaded -->
    <script src="~/js/langs/jquery-bootstrap-multiselect.@(culture).js"></script>
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

Language files are located in: `wwwroot/js/langs/`

- `jquery-bootstrap-multiselect.it.js` - Italian
- `jquery-bootstrap-multiselect.es.js` - Spanish
- `jquery-bootstrap-multiselect.fr.js` - French
- `jquery-bootstrap-multiselect.de.js` - German
- `jquery-bootstrap-multiselect.pt.js` - Portuguese

See the [langs README](../JQueryMultiSelect/wwwroot/js/langs/README.md) for more details.

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
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<!-- Italian is now automatically set as the global language -->

<!-- Now all multiselect instances in all views will use Italian -->
```

**Dynamic Language Based on User Culture:**

```html
@using System.Globalization
@{
    var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
}

<script src="~/js/jquery-bootstrap-multiselect.js"></script>

@if (culture != "en")
{
    <!-- Automatically sets the language when loaded -->
    <script src="~/js/langs/jquery-bootstrap-multiselect.@(culture).js"></script>
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
