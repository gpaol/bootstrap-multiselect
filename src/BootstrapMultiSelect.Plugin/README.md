# Bootstrap MultiSelect jQuery Plugin

A modern, feature-rich Bootstrap 5 MultiSelect component with search, filtering, grouped options, and comprehensive localization support.

## 📦 Package Name

`@gpaol/bootstrap-multiselect`

## 📂 Package Structure

```text
@gpaol/bootstrap-multiselect/
├── src/
│   ├── css/
│   │   ├── bootstrap-multiselect.css
│   │   └── bootstrap-multiselect.min.css
│   ├── js/
│   │   ├── bootstrap-multiselect.js
│   │   └── bootstrap-multiselect.min.js
│   └── langs/                 # Localization files
│       ├── bootstrap-multiselect.de.js
│       ├── bootstrap-multiselect.de.min.js
│       ├── bootstrap-multiselect.es.js
│       ├── bootstrap-multiselect.es.min.js
│       ├── bootstrap-multiselect.fr.js
│       ├── bootstrap-multiselect.fr.min.js
│       ├── bootstrap-multiselect.it.js
│       ├── bootstrap-multiselect.it.min.js
│       ├── bootstrap-multiselect.pt.js
│       └── bootstrap-multiselect.pt.min.js
├── package.json
├── LICENSE
└── README.md
```

## 🚀 Installation

### via npm

```bash
npm install @gpaol/bootstrap-multiselect
```

### via CDN

```html
<!-- CSS -->
<link href="https://cdn.jsdelivr.net/npm/@gpaol/bootstrap-multiselect@1.2.0/src/css/bootstrap-multiselect.min.css" rel="stylesheet">

<!-- JavaScript -->
<script src="https://cdn.jsdelivr.net/npm/@gpaol/bootstrap-multiselect@1.2.0/src/js/bootstrap-multiselect.min.js"></script>
```

## 📖 Usage

After installing via npm, you can import the files in your project:

```html
<!DOCTYPE html>
<html>
<head>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="node_modules/@gpaol/bootstrap-multiselect/src/css/bootstrap-multiselect.min.css" rel="stylesheet">
</head>
<body>
    <select id="mySelect" multiple>
        <option value="1">Option 1</option>
        <option value="2">Option 2</option>
        <option value="3">Option 3</option>
    </select>

    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="node_modules/@gpaol/bootstrap-multiselect/src/js/bootstrap-multiselect.min.js"></script>
    
    <script>
        $('#mySelect').bootstrapMultiSelect({
            placeholder: 'Select items...',
            enableSearch: true,
            showSelectAll: true,
            enablePagination: true,
            itemsPerPage: 10
        });
    </script>
</body>
</html>
```

### Using with Module Bundlers

If you're using a module bundler like Webpack or Vite:

```javascript
// Import CSS
import '@gpaol/bootstrap-multiselect/src/css/bootstrap-multiselect.min.css';

// Import JavaScript
import '@gpaol/bootstrap-multiselect/src/js/bootstrap-multiselect.min.js';

// Use the plugin
$('#mySelect').bootstrapMultiSelect({
    placeholder: 'Select items...',
    enableSearch: true,
    showSelectAll: true
});
```

## 🌍 Localization

The plugin supports multiple languages. Language files are included in the package:

```html
<!-- Include language file -->
<script src="node_modules/@gpaol/bootstrap-multiselect/src/langs/bootstrap-multiselect.it.min.js"></script>

<!-- Set global language -->
<script>
    $.fn.bootstrapMultiSelect.lang = 'it';
</script>
```

### Available Languages

- German (`de`)
- Spanish (`es`)
- French (`fr`)
- Italian (`it`)
- Portuguese (`pt`)

For more details, see the [Localization Guide](https://github.com/gpaol/bootstrap-multiselect/blob/main/docs/LOCALIZATION-GUIDE.md).

## 📚 Documentation

- **Complete Examples**: [PLUGIN-EXAMPLES.md](https://github.com/gpaol/bootstrap-multiselect/blob/main/docs/PLUGIN-EXAMPLES.md)
- **Localization Guide**: [LOCALIZATION-GUIDE.md](https://github.com/gpaol/bootstrap-multiselect/blob/main/docs/LOCALIZATION-GUIDE.md)
- **Main README**: [README.md](https://github.com/gpaol/bootstrap-multiselect/blob/main/README.md)

## ⚡ Features

- ✅ **Bootstrap 5 Integration**: Full compatibility with Bootstrap 5
- ✅ **Search & Filtering**: Built-in search functionality
- ✅ **Select All**: Convenient select/deselect all options
- ✅ **Pagination**: Paginate long lists for better performance
- ✅ **Grouped Options**: Support for optgroup elements
- ✅ **Localization**: Multiple language support (DE, ES, FR, IT, PT)
- ✅ **Responsive Design**: Works seamlessly on all devices
- ✅ **Customizable**: Extensive configuration options
- ✅ **Lightweight**: Minimal footprint, optimized performance

## 📄 License

MIT License - see [LICENSE](../../LICENSE) for details

## 👤 Author

Paolo Gaetano

- GitHub: [@gpaol](https://github.com/gpaol)
- Repository: [bootstrap-multiselect](https://github.com/gpaol/bootstrap-multiselect)

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

See the [Contributing Guide](https://github.com/gpaol/bootstrap-multiselect/blob/main/CONTRIBUTING.md) for detailed guidelines.

## 🔗 Links

- **Repository**: <https://github.com/gpaol/bootstrap-multiselect>
- **Issues**: <https://github.com/gpaol/bootstrap-multiselect/issues>
- **npm Package**: <https://www.npmjs.com/package/@gpaol/bootstrap-multiselect>
- **CDN (jsDelivr)**: <https://cdn.jsdelivr.net/npm/@gpaol/bootstrap-multiselect@latest/>
- **CDN (unpkg)**: <https://unpkg.com/@gpaol/bootstrap-multiselect@latest/>

## 📋 Requirements

- Bootstrap 5.3.0 or higher
- jQuery 3.7.0 or higher
