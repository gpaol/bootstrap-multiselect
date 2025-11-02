# Bootstrap MultiSelect jQuery Plugin

This directory contains the **npm package** for the Bootstrap MultiSelect jQuery plugin.

## 📦 Package Name

`bootstrap-multiselect`

## 📂 Structure

```text
BootstrapMultiSelect.Plugin/
├── dist/                      # Distribution files
│   ├── css/
│   │   └── bootstrap-multiselect.css
│   ├── js/
│   │   └── bootstrap-multiselect.js
│   └── langs/                 # Language files
│       ├── bootstrap-multiselect.it.js
│       ├── bootstrap-multiselect.es.js
│       ├── bootstrap-multiselect.fr.js
│       ├── bootstrap-multiselect.de.js
│       └── bootstrap-multiselect.pt.js
├── package.json               # npm package configuration
└── README.md                  # This file
```

## 🚀 Installation

### via npm

```bash
npm install bootstrap-multiselect
```

### via CDN

```html
<!-- CSS -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap-multiselect@1.1.0/dist/css/bootstrap-multiselect.css" rel="stylesheet">

<!-- JavaScript -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap-multiselect@1.1.0/dist/js/bootstrap-multiselect.js"></script>
```

## 📖 Usage

```html
<!DOCTYPE html>
<html>
<head>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="path/to/bootstrap-multiselect.css" rel="stylesheet">
</head>
<body>
    <select id="mySelect" multiple>
        <option value="1">Option 1</option>
        <option value="2">Option 2</option>
        <option value="3">Option 3</option>
    </select>

    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="path/to/bootstrap-multiselect.js"></script>
    
    <script>
        $('#mySelect').bootstrapMultiSelect({
            placeholder: 'Select items...',
            enableSearch: true,
            showSelectAll: true
        });
    </script>
</body>
</html>
```

## 🌍 Localization

```html
<!-- Include language file -->
<script src="path/to/langs/bootstrap-multiselect.it.js"></script>

<!-- Set global language -->
<script>
    $.fn.bootstrapMultiSelect.lang = 'it';
</script>
```

## 📚 Documentation

- **Complete Examples**: [PLUGIN-EXAMPLES.md](../../docs/PLUGIN-EXAMPLES.md)
- **Localization Guide**: [LOCALIZATION-GUIDE.md](../../docs/LOCALIZATION-GUIDE.md)
- **Main README**: [README.md](../../README.md)

## 📄 License

MIT License - see [LICENSE](../../LICENSE) for details

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

## �🔗 Links

- **Repository**: <https://github.com/gpaol/bootstrap-multiselect>
- **Issues**: <https://github.com/gpaol/bootstrap-multiselect/issues>
- **npm**: <https://www.npmjs.com/package/bootstrap-multiselect>
