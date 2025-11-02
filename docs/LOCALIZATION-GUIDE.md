# Localization Guide - Bootstrap MultiSelect

## 📋 Overview

This guide explains how to use the localization feature in Bootstrap MultiSelect for both the JavaScript plugin and the ASP.NET Core MVC library.

**Important Terminology**:

- **JavaScript Plugin** uses `lang` (e.g., `data-lang="it"`, `$.fn.bootstrapMultiSelect.lang`)
- **ASP.NET Core MVC** uses `locale` (e.g., `locale="it"`, `Locale = "it"`)

Language files **register** translations but do NOT automatically change the global language. This gives you maximum flexibility to use English as default and apply other languages selectively, or set a global default manually.

## 🌍 Available Languages

| Language | Code | File | Status |
|----------|------|------|--------|
| English | `en` | Built-in (default) | ✅ Complete |
| Italian | `it` | `jquery-bootstrap-multiselect.it.js` | ✅ Complete |
| Spanish | `es` | `jquery-bootstrap-multiselect.es.js` | ✅ Complete |
| French | `fr` | `jquery-bootstrap-multiselect.fr.js` | ✅ Complete |
| German | `de` | `jquery-bootstrap-multiselect.de.js` | ✅ Complete |
| Portuguese | `pt` | `jquery-bootstrap-multiselect.pt.js` | ✅ Complete |

## 📖 Quick Start

### Option 1: English Default + Selective Localization

```html
<!-- Load jQuery -->
<script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>

<!-- Load plugin -->
<script src="~/js/jquery-bootstrap-multiselect.js"></script>

<!-- Load language files (just registers, doesn't change default) -->
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>

<!-- All instances use English unless specified -->
<select data-toggle="bootstrap-multiselect">...</select>  <!-- English -->

<!-- Use Italian for this specific instance -->
<select data-toggle="bootstrap-multiselect" data-lang="it">...</select>
```

### Option 2: Set Global Language

```html
<!-- Load plugin and language file -->
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>

<!-- Set Italian as global default -->
<script>
    $.fn.bootstrapMultiSelect.lang = 'it';
</script>

<!-- Now all instances use Italian by default -->
<select data-toggle="bootstrap-multiselect">...</select>  <!-- Italian -->
```

### Option 3: Per-Instance Language

```html
<select data-toggle="bootstrap-multiselect" data-lang="it">
    <option value="1">Opzione 1</option>
    <option value="2">Opzione 2</option>
</select>

<script>
    // Or with JavaScript
    $('#mySelect').bootstrapMultiSelect({ lang: 'it' });
</script>
```

### ASP.NET Core MVC

**TagHelper:**

```cshtml
<multiselect asp-for="SelectedItems" 
             asp-items="ViewBag.Items"
             locale="it" />
```

**HtmlHelper:**

```csharp
@Html.MultiSelectFor(m => m.SelectedItems, ViewBag.Items, new MultiSelectConfig
{
    Locale = "it"
})
```

## 📖 Detailed Usage

### 1. JavaScript - Global Language

Set the language once and all instances use it:

```html
<!-- _Layout.cshtml or index.html -->
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>

<!-- Set Italian as global default -->
<script>
    $.fn.bootstrapMultiSelect.lang = 'it';
</script>
```

Now every multiselect will automatically use Italian:

```html
<!-- No lang attribute needed -->
<select data-toggle="bootstrap-multiselect">
    <option>...</option>
</select>

<script>
    // No lang option needed
    $('#mySelect').bootstrapMultiSelect();
</script>
```

### 2. JavaScript - Per-Instance Language

Override the global language for specific instances:

```javascript
// Load Italian locale file first
// (Italian is now the global default)

// This instance uses Spanish instead
$('#spanishSelect').bootstrapMultiSelect({ 
    lang: 'es' 
});

// This instance uses global Italian
$('#italianSelect').bootstrapMultiSelect();
```

Or with HTML data attributes:

```html
<!-- Load Italian language file first -->
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>

<script>
    // Set Italian as global default
    $.fn.bootstrapMultiSelect.lang = 'it';
</script>

<!-- This uses Spanish (overrides global Italian) -->
<select data-toggle="bootstrap-multiselect" data-lang="es">
    <option>...</option>
</select>

<!-- This uses Italian (global default) -->
<select data-toggle="bootstrap-multiselect">
    <option>...</option>
</select>
```

### 3. ASP.NET Core - Culture-Based Automatic Localization

Automatically load the correct locale based on user's culture:

**Program.cs or Startup.cs:**

```csharp
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Configure localization
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("it-IT"),
        new CultureInfo("es-ES"),
        new CultureInfo("fr-FR"),
        new CultureInfo("de-DE"),
        new CultureInfo("pt-PT")
    };
    
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

// Use request localization
app.UseRequestLocalization();
```

**_Layout.cshtml:**

```cshtml
@using System.Globalization
@{
    var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
}

<!-- Load plugin -->
<script src="~/js/jquery-bootstrap-multiselect.js"></script>

<!-- Load language file based on current culture -->
@if (culture != "en")
{
    <script src="~/js/langs/jquery-bootstrap-multiselect.@(culture).js"></script>
    <script>
        // Set the language globally based on culture
        $.fn.bootstrapMultiSelect.lang = '@culture';
    </script>
}
```

Now all multiselect instances automatically use the user's language!

### 4. ASP.NET Core - TagHelper with Locale

```cshtml
@addTagHelper *, BootstrapMultiSelect.MVC

<!-- Italian -->
<multiselect asp-for="SelectedItems" 
             asp-items="ViewBag.Items"
             locale="it"
             search="true"
             select-all="true" />

<!-- Spanish -->
<multiselect asp-for="SelectedOtherItems" 
             asp-items="ViewBag.OtherItems"
             locale="es"
             search="true"
             select-all="true" />
```

### 5. ASP.NET Core - HtmlHelper with Locale

```csharp
@using BootstrapMultiSelect.MVC.HtmlHelpers
@using BootstrapMultiSelect.MVC.Models

@Html.MultiSelectFor(m => m.SelectedItems, ViewBag.Items, new MultiSelectConfig
{
    Locale = "it",
    Search = true,
    SelectAll = true,
    Theme = "primary"
})
```

## 🔤 Translated Texts

Each locale file translates these 6 text strings:

| Key | English | Italian | Spanish | French | German | Portuguese |
|-----|---------|---------|---------|--------|--------|------------|
| `placeholder` | "Select items..." | "Seleziona elementi..." | "Seleccionar elementos..." | "Sélectionner des éléments..." | "Elemente auswählen..." | "Selecionar itens..." |
| `searchPlaceholder` | "Search..." | "Cerca..." | "Buscar..." | "Rechercher..." | "Suchen..." | "Pesquisar..." |
| `selectAllText` | "Select All" | "Seleziona Tutti" | "Seleccionar Todo" | "Tout Sélectionner" | "Alle Auswählen" | "Selecionar Tudo" |
| `deselectAllText` | "Deselect All" | "Deseleziona Tutti" | "Deseleccionar Todo" | "Tout Désélectionner" | "Alle Abwählen" | "Desmarcar Tudo" |
| `noResultsText` | "No results found" | "Nessun risultato trovato" | "No se encontraron resultados" | "Aucun résultat trouvé" | "Keine Ergebnisse gefunden" | "Nenhum resultado encontrado" |
| `itemsSelectedText` | "items selected" | "elementi selezionati" | "elementos seleccionados" | "éléments sélectionnés" | "Elemente ausgewählt" | "itens selecionados" |

## ⚡ Priority Order

When determining which text to display, the plugin follows this priority order (highest to lowest):

1. **Explicit data attributes** or **JavaScript options**

   ```html
   data-placeholder="Custom text"
   ```

   ```javascript
   { placeholder: "Custom text" }
   ```

2. **Language file** (if loaded and set globally)

   ```javascript
   $.fn.bootstrapMultiSelect.lang = 'it';
   ```

3. **Default English** (built-in)

### Example

```javascript
// Load Italian locale
$.fn.bootstrapMultiSelect.lang = 'it';

$('#mySelect').bootstrapMultiSelect({
    placeholder: 'Custom placeholder' // This overrides Italian locale
});

// Result:
// - placeholder = "Custom placeholder" (from option)
// - searchPlaceholder = "Cerca..." (from Italian locale)
// - selectAllText = "Seleziona Tutti" (from Italian locale)
// - etc.
```

## 🌐 Browser Language Detection

Automatically use the browser's language:

```javascript
// Get browser language
var browserLang = (navigator.language || navigator.userLanguage).split('-')[0];

// Supported languages
var supportedLangs = ['en', 'it', 'es', 'fr', 'de', 'pt'];

// Load language file if supported
if (supportedLangs.includes(browserLang) && browserLang !== 'en') {
    $.getScript('/js/langs/jquery-bootstrap-multiselect.' + browserLang + '.js')
        .done(function() {
            $.fn.bootstrapMultiSelect.lang = browserLang;
            console.log('Language loaded:', browserLang);
        })
        .fail(function() {
            console.warn('Language file not found, using English');
        });
}
```

## 📁 File Locations

### JavaScript Plugin Files

Language files are located in:

```text
JQueryMultiSelect/
└── wwwroot/
    └── js/
        ├── jquery-bootstrap-multiselect.js
        └── langs/
            ├── README.md
            ├── jquery-bootstrap-multiselect.it.js
            ├── jquery-bootstrap-multiselect.es.js
            ├── jquery-bootstrap-multiselect.fr.js
            ├── jquery-bootstrap-multiselect.de.js
            └── jquery-bootstrap-multiselect.pt.js
```

### ASP.NET Core MVC Files

Updated files:

```text
BootstrapMultiSelect.MVC/
├── Models/
│   └── MultiSelectConfig.cs (added Locale property)
├── TagHelpers/
│   └── MultiSelectTagHelper.cs (added locale attribute support)
├── HtmlHelpers/
│   └── MultiSelectHtmlHelper.cs (added locale support)
└── README.md (updated with localization docs)
```

## 🎯 Common Scenarios

### Scenario 1: Single Language Website (Italian)

```html
<!-- _Layout.cshtml -->
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<!-- Italian is automatically set -->
```

All pages automatically use Italian.

### Scenario 2: Multi-Language Website

```cshtml
<!-- _Layout.cshtml -->
@using System.Globalization
@{
    var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
}

<script src="~/js/jquery-bootstrap-multiselect.js"></script>

@if (culture != "en")
{
    <script src="~/js/langs/jquery-bootstrap-multiselect.@(culture).js"></script>
    <script>
        $.fn.bootstrapMultiSelect.lang = '@culture';
    </script>
}
```

Each user sees their own language based on browser/culture settings.

### Scenario 3: Form with Multiple Languages

```cshtml
<div class="row">
    <div class="col-md-6">
        <h4>Italian Section</h4>
        <multiselect asp-for="ItalianItems" 
                     asp-items="ViewBag.ItalianItems"
                     locale="it" />
    </div>
    
    <div class="col-md-6">
        <h4>Spanish Section</h4>
        <multiselect asp-for="SpanishItems" 
                     asp-items="ViewBag.SpanishItems"
                     locale="es" />
    </div>
</div>
```

### Scenario 4: Custom Text with Locale

```cshtml
<!-- Use Italian locale but override placeholder -->
<multiselect asp-for="SelectedItems" 
             asp-items="ViewBag.Items"
             locale="it"
             placeholder="Scegli le tue preferenze..." />

<!-- Result:
     - placeholder: "Scegli le tue preferenze..." (custom)
     - searchPlaceholder: "Cerca..." (from Italian locale)
     - selectAllText: "Seleziona Tutti" (from Italian locale)
     - etc.
-->
```

## ✨ Creating Custom Languages

To add a new language (e.g., Japanese):

1. Create `jquery-bootstrap-multiselect.ja.js`:

```javascript
/*!
 * Bootstrap MultiSelect - Japanese Localization
 */

(function ($) {
    'use strict';

    // Register Japanese language
    $.fn.bootstrapMultiSelect.langs['ja'] = {
        placeholder: 'アイテムを選択...',
        searchPlaceholder: '検索...',
        selectAllText: 'すべて選択',
        deselectAllText: 'すべて選択解除',
        noResultsText: '結果が見つかりません',
        itemsSelectedText: '個のアイテムが選択されました'
    };

})(jQuery);
```

Then use it:

```html
<script src="~/js/jquery-bootstrap-multiselect.js"></script>

<!-- Set Japanese as global default -->
<script>
    $.fn.bootstrapMultiSelect.lang = 'ja';
</script>
```

## 🔍 Testing Localization

### Test 1: Verify Language Loaded

```javascript
console.log($.fn.bootstrapMultiSelect.langs);
// Should show: { en: {...}, it: {...}, es: {...}, fr: {...}, de: {...}, pt: {...} }

console.log($.fn.bootstrapMultiSelect.lang);
// Should show: 'it' (or your set language)
```

### Test 2: Check Plugin Initialization

```javascript
$('#mySelect').bootstrapMultiSelect({ lang: 'it' });

// Check applied options
var options = $('#mySelect').data('bootstrapMultiSelect').options;
console.log(options.placeholder); // "Seleziona elementi..."
console.log(options.searchPlaceholder); // "Cerca..."
```

### Test 3: Visual Verification

1. Open browser
2. Inspect button text: should show localized placeholder
3. Open dropdown: search box should have localized placeholder
4. Check "Select All" / "Deselect All" buttons: should be localized
5. Search for non-existent item: should show localized "No results found"
6. Select 4+ items: should show localized "X items selected"

## 📚 Resources

- **Main Plugin Documentation**: [Plugin README](../src/BootstrapMultiSelect.Plugin/README.md)
- **Language Files README**: [wwwroot/js/langs/README.md](../samples/AspNetCore/wwwroot/js/langs/README.md)
- **MVC Library Documentation**: [MVC README](../src/BootstrapMultiSelect.MVC/README.md)
- **MVC Examples**: [MVC-EXAMPLES.md](MVC-EXAMPLES.md)
- **Plugin Examples**: [PLUGIN-EXAMPLES.md](PLUGIN-EXAMPLES.md)

## 🎉 Summary

✅ **6 languages supported** out of the box (en, it, es, fr, de, pt)

✅ **JavaScript Plugin uses `lang`**:

- Global: `$.fn.bootstrapMultiSelect.lang = 'it'`
- Per-instance: `{ lang: 'it' }` or `data-lang="it"`

✅ **ASP.NET Core MVC uses `locale`**:

- TagHelper: `locale="it"` attribute
- HtmlHelper: `Locale = "it"` property

✅ **Automatic culture detection** in ASP.NET Core

✅ **Priority system** allows custom text overrides

✅ **Easy to extend** with new languages

✅ **Full MVC integration** with TagHelper and HtmlHelper support

---

**Need help?** Check the [language files README](../samples/AspNetCore/wwwroot/js/langs/README.md) or create an issue on GitHub.
