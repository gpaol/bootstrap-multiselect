# Bootstrap MultiSelect - Language Files

This directory contains language files for the Bootstrap MultiSelect plugin. Each file provides translations for all user-facing text in a specific language.

## Available Languages

| Language | Code | File | Status |
|----------|------|------|--------|
| English | `en` | Built-in (default) | ✅ Complete |
| Italian | `it` | `jquery-bootstrap-multiselect.it.js` | ✅ Complete |
| Spanish | `es` | `jquery-bootstrap-multiselect.es.js` | ✅ Complete |
| French | `fr` | `jquery-bootstrap-multiselect.fr.js` | ✅ Complete |
| German | `de` | `jquery-bootstrap-multiselect.de.js` | ✅ Complete |
| Portuguese | `pt` | `jquery-bootstrap-multiselect.pt.js` | ✅ Complete |

## Important: How Language Files Work

**Language files only REGISTER translations** - they do NOT automatically change the global language.

This gives you maximum flexibility:

- ✅ Keep English as default and use other languages only for specific instances
- ✅ Load multiple language files and use different languages on the same page
- ✅ Set a global default language manually when needed

## Usage

### Method 1: English Default + Selective Localization

Load language files you need, but **don't set a global default**. Each instance uses English unless you specify otherwise.

```html
<!-- Load jQuery -->
<script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>

<!-- Load Bootstrap MultiSelect plugin -->
<script src="~/js/jquery-bootstrap-multiselect.js"></script>

<!-- Load language files (just registers translations, doesn't change default) -->
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.es.js"></script>

<!-- All instances use English by default -->
<select data-toggle="bootstrap-multiselect">...</select>  <!-- English -->
<select data-toggle="bootstrap-multiselect">...</select>  <!-- English -->

<!-- Use Italian for specific instance -->
<select data-toggle="bootstrap-multiselect" data-lang="it">...</select>  <!-- Italian -->

<!-- Use Spanish for specific instance -->
<select data-toggle="bootstrap-multiselect" data-lang="es">...</select>  <!-- Spanish -->
```

### Method 2: Set Global Default Language

Load language file(s) and **explicitly set the global default**.

```html
<!-- Load jQuery and plugin -->
<script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
<script src="~/js/jquery-bootstrap-multiselect.js"></script>

<!-- Load language file (only registers the translation) -->
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>

<!-- Manually set Italian as global default -->
<script>
    $.fn.bootstrapMultiSelect.lang = 'it';
</script>

<!-- Now all instances use Italian by default -->
<select data-toggle="bootstrap-multiselect">...</select>  <!-- Italian -->
<select data-toggle="bootstrap-multiselect">...</select>  <!-- Italian -->

<!-- Override to English for specific instance -->
<select data-toggle="bootstrap-multiselect" data-lang="en">...</select>  <!-- English -->
```

### Method 3: Multiple Languages on Same Page

Load all needed languages and use `data-lang` attribute for each instance.

```html
<!-- Load all language files you need -->
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.es.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.fr.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.de.js"></script>

<!-- Use different languages on the same page -->
<select data-toggle="bootstrap-multiselect">...</select>              <!-- English (default) -->
<select data-toggle="bootstrap-multiselect" data-lang="it">...</select>  <!-- Italian -->
<select data-toggle="bootstrap-multiselect" data-lang="es">...</select>  <!-- Spanish -->
<select data-toggle="bootstrap-multiselect" data-lang="fr">...</select>  <!-- French -->
<select data-toggle="bootstrap-multiselect" data-lang="de">...</select>  <!-- German -->
```

### Method 4: ASP.NET Core with Culture Detection

In your `_Layout.cshtml`:

```html
@using System.Globalization
@{
    var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
}

<!-- Load jQuery and plugin -->
<script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
<script src="~/js/jquery-bootstrap-multiselect.js"></script>

@if (culture != "en")
{
    <!-- Load language file -->
    <script src="~/js/langs/jquery-bootstrap-multiselect.@(culture).js"></script>
    <!-- Set as global default -->
    <script>
        $.fn.bootstrapMultiSelect.lang = '@culture';
    </script>
}
```

### Method 5: Dynamic Language Loading

Load the appropriate language file based on user's preference:

```javascript
var userLang = 'it'; // Get from user preferences, browser, etc.

if (userLang !== 'en') {
    $.getScript('/js/langs/jquery-bootstrap-multiselect.' + userLang + '.js')
        .done(function() {
            // Set as global default
            $.fn.bootstrapMultiSelect.lang = userLang;
            console.log('Language set to:', userLang);
        })
        .fail(function() {
            console.warn('Language file not found, using English');
        });
}
```

### Method 6: Per-Instance Language Override

You can override the global language for individual instances:

```javascript
// Set Italian as global default
$.fn.bootstrapMultiSelect.lang = 'it';

// This instance uses Spanish instead
$('#mySelect1').bootstrapMultiSelect({ 
    lang: 'es'  // Override to Spanish
});

// This instance uses the global Italian
$('#mySelect2').bootstrapMultiSelect();

// This instance uses English
$('#mySelect3').bootstrapMultiSelect({ 
    lang: 'en' 
});
```

Or with data attributes:

```html
<!-- Set Italian as global default -->
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<script>
    $.fn.bootstrapMultiSelect.lang = 'it';
</script>

<!-- This instance uses Italian (global default) -->
<select data-toggle="bootstrap-multiselect">
    <option value="1">Opzione 1</option>
    <option value="2">Opzione 2</option>
</select>

<!-- This instance overrides to Spanish -->
<select data-toggle="bootstrap-multiselect" data-lang="es">
    <option value="1">Opción 1</option>
    <option value="2">Opción 2</option>
</select>
```

## Override Individual Texts

You can override specific texts even when using a language:

```javascript
// Use Italian language but customize the placeholder
$('#mySelect').bootstrapMultiSelect({ 
    lang: 'it',
    placeholder: 'Scegli le tue preferenze...' // Custom placeholder
});
```

Or with data attributes:

```html
<select data-toggle="bootstrap-multiselect" 
        data-lang="it"
        data-placeholder="Scegli le tue preferenze...">
    <!-- Options -->
</select>
```

## Translated Texts

Each language file translates the following strings:

| Key | English (default) | Description |
|-----|-------------------|-------------|
| `placeholder` | "Select items..." | Button text when nothing is selected |
| `searchPlaceholder` | "Search..." | Search input placeholder |
| `selectAllText` | "Select All" | Select all button text |
| `deselectAllText` | "Deselect All" | Deselect all button text |
| `noResultsText` | "No results found" | Message when search has no results |
| `itemsSelectedText` | "items selected" | Text shown when 4+ items are selected (e.g., "5 items selected") |
| `paginationPrevText` | "Previous" | Previous page button text |
| `paginationNextText` | "Next" | Next page button text |
| `paginationInfoText` | "Page {current} of {total}" | Page information text ({current} and {total} are placeholders) |

## Examples

### Italian Example

```html
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<script>
    // Set Italian as global default
    $.fn.bootstrapMultiSelect.lang = 'it';
</script>

<select id="hobby" data-toggle="bootstrap-multiselect">
    <option value="reading">Lettura</option>
    <option value="sports">Sport</option>
    <option value="music">Musica</option>
</select>

<!-- Will display: "Seleziona elementi..." as placeholder -->
<!-- Search box: "Cerca..." -->
<!-- Buttons: "Seleziona Tutti" / "Deseleziona Tutti" -->
```

### Spanish Example

```html
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.es.js"></script>
<script>
    // Set Spanish as global default
    $.fn.bootstrapMultiSelect.lang = 'es';
</script>

<select id="colores" data-toggle="bootstrap-multiselect">
    <option value="rojo">Rojo</option>
    <option value="azul">Azul</option>
    <option value="verde">Verde</option>
</select>

<!-- Will display: "Seleccionar elementos..." as placeholder -->
```

### Mixed Languages Example

```html
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.es.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.fr.js"></script>

<!-- Keep English as default, use languages selectively -->
<select data-toggle="bootstrap-multiselect">...</select>  <!-- English -->
<select data-toggle="bootstrap-multiselect" data-lang="it">...</select>  <!-- Italian -->
<select data-toggle="bootstrap-multiselect" data-lang="es">...</select>  <!-- Spanish -->
<select data-toggle="bootstrap-multiselect" data-lang="fr">...</select>  <!-- French -->
```

## Creating Your Own Language

To add a new language, create a file `jquery-bootstrap-multiselect.{code}.js`:

```javascript
/*!
 * Bootstrap MultiSelect - Your Language Localization
 */

(function ($) {
    'use strict';

    // Ensure the plugin namespace exists
    $.fn.bootstrapMultiSelect = $.fn.bootstrapMultiSelect || {};
    $.fn.bootstrapMultiSelect.langs = $.fn.bootstrapMultiSelect.langs || {};

    // Register your language (e.g., 'ja' for Japanese)
    $.fn.bootstrapMultiSelect.langs['ja'] = {
        placeholder: 'アイテムを選択...',
        searchPlaceholder: '検索...',
        selectAllText: 'すべて選択',
        deselectAllText: 'すべて選択解除',
        noResultsText: '結果が見つかりません',
        itemsSelectedText: '個のアイテムが選択されました',
        paginationPrevText: '前へ',
        paginationNextText: '次へ',
        paginationInfoText: 'ページ {current} / {total}'
    };

    // Note: This file only registers the translation.
    // To use it globally, add after loading this file:
    // $.fn.bootstrapMultiSelect.lang = 'ja';

})(jQuery);
```

Then use it:

```html
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.ja.js"></script>
<script>
    // Set Japanese as global default
    $.fn.bootstrapMultiSelect.lang = 'ja';
</script>
```

Or use it selectively:

```html
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.ja.js"></script>

<!-- Keep English as default -->
<select data-toggle="bootstrap-multiselect">...</select>  <!-- English -->

<!-- Use Japanese for specific instance -->
<select data-toggle="bootstrap-multiselect" data-lang="ja">...</select>  <!-- Japanese -->
```

## Priority Order

When determining which text to display, the plugin follows this priority order (highest to lowest):

1. **Data attribute** (e.g., `data-placeholder="Custom text"`)
2. **JavaScript options** (e.g., `{ placeholder: "Custom text" }`)
3. **Language file** (e.g., Italian language via `lang: 'it'` or `data-lang="it"`)
4. **Global language** (e.g., `$.fn.bootstrapMultiSelect.lang = 'it'`)
5. **Default English** (built-in)

Example:

```javascript
// Set Italian as global default
$.fn.bootstrapMultiSelect.lang = 'it';

$('#mySelect').bootstrapMultiSelect({
    placeholder: 'Custom placeholder' // This overrides Italian language
});
// Result: placeholder = "Custom placeholder"
//         other texts = Italian (from language file)
```

## Browser Language Detection

Automatically detect and use browser language:

```javascript
// Get browser language (e.g., 'it', 'es-ES', 'en-US')
var browserLang = navigator.language || navigator.userLanguage;
var lang = browserLang.split('-')[0]; // Get just 'it', 'es', 'en'

// Load language file if not English
if (lang !== 'en' && $.fn.bootstrapMultiSelect.langs[lang]) {
    $.getScript('/js/langs/jquery-bootstrap-multiselect.' + lang + '.js')
        .done(function() {
            // Set as global default
            $.fn.bootstrapMultiSelect.lang = lang;
            console.log('Language set to:', lang);
        });
}
```

## 👤 Author

Paolo Gaetano

- GitHub: [@gpaol](https://github.com/gpaol)
- Repository: [bootstrap-multiselect](https://github.com/gpaol/bootstrap-multiselect)

## 🤝 Contributing

We welcome contributions of new localization files! Please:

1. Fork the repository
2. Create a new locale file following the naming convention
3. Ensure all 9 text keys are translated
4. Update this README with the new language
5. Submit a pull request

See [CONTRIBUTING.md](https://github.com/gpaol/bootstrap-multiselect/blob/main/CONTRIBUTING.md) for detailed guidelines.

## License

MIT License - see main plugin license for details.
