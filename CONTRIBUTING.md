# Contributing to Bootstrap MultiSelect

First off, thank you for considering contributing to Bootstrap MultiSelect! It's people like you that make this project great.

## 🤝 Code of Conduct

This project and everyone participating in it is governed by our Code of Conduct. By participating, you are expected to uphold this code.

## 🐛 How to Report a Bug

1. **Check existing issues** to see if the bug has already been reported
2. **Create a new issue** with a clear title and description
3. **Include**:
   - Steps to reproduce
   - Expected behavior
   - Actual behavior
   - Browser/OS information
   - Code samples or screenshots

## ✨ How to Suggest a Feature

1. **Check existing issues** to see if the feature has been suggested
2. **Create a new issue** with tag `enhancement`
3. **Describe**:
   - The problem you're trying to solve
   - Your proposed solution
   - Alternative solutions considered
   - Any relevant examples

## 🔧 Development Process

### Prerequisites

- .NET 8.0 SDK or later
- Node.js 14.0 or later
- Git
- Visual Studio 2022 or VS Code

### Setup

```bash
# Clone the repo
git clone https://github.com/gpaol/bootstrap-multiselect.git
cd bootstrap-multiselect

# Restore dependencies
dotnet restore

# Build
dotnet build

# Run samples
cd samples/AspNetCore
dotnet run
```

### Project Structure

```text
bootstrap-multiselect/
├── src/
│   ├── BootstrapMultiSelect.Plugin/  # jQuery plugin (npm)
│   └── BootstrapMultiSelect.MVC/     # .NET library (NuGet)
├── samples/                           # Example projects
├── docs/                              # Documentation
└── .github/                           # CI/CD workflows
```

### Coding Standards

#### C# Code

- Follow [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use **English** for all code, comments, and documentation
- Add **XML documentation** to all public members
- Use **PascalCase** for classes/methods
- Use **camelCase** for parameters/local variables

Example:

```csharp
/// <summary>
/// Represents a multi-select configuration.
/// </summary>
public class MultiSelectConfig
{
    /// <summary>
    /// Gets or sets the placeholder text.
    /// </summary>
    public string Placeholder { get; set; } = "Select items...";
}
```

#### JavaScript Code

- Use **ES6** features
- Follow jQuery plugin patterns
- Add JSDoc comments for functions
- Use meaningful variable names

Example:

```javascript
/**
 * Initialize the multiselect plugin
 * @param {Object} options - Configuration options
 * @returns {jQuery} jQuery object for chaining
 */
$.fn.bootstrapMultiSelect = function(options) {
    // Implementation
};
```

#### HTML/CSS

- Use **Bootstrap 5** classes
- Follow **BEM** naming for custom classes
- Ensure **responsive** design
- Add **ARIA** labels for accessibility

### Commit Messages

Follow the [Conventional Commits](https://www.conventionalcommits.org/) specification:

```text
<type>(<scope>): <subject>

<body>

<footer>
```

Types:

- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `style`: Code style changes (formatting, etc.)
- `refactor`: Code refactoring
- `test`: Adding tests
- `chore`: Maintenance tasks

Examples:

```text
feat(plugin): add Portuguese language support

Add pt-BR language file with all translations

Closes #123
```

```text
fix(mvc): correct TagHelper attribute binding

The 'enable-search' attribute was not being properly
bound to the EnableSearch property.

Fixes #456
```

### Pull Request Process

1. **Fork** the repository
2. **Create a branch** from `develop`:

   ```bash
   git checkout -b feature/my-new-feature develop
   ```

3. **Make your changes** following coding standards
4. **Add tests** if applicable
5. **Update documentation** if needed
6. **Commit your changes** with meaningful messages
7. **Push to your fork**:

   ```bash
   git push origin feature/my-new-feature
   ```

8. **Create a Pull Request** to the `develop` branch

### Pull Request Checklist

- [ ] Code follows project coding standards
- [ ] All tests pass
- [ ] New tests added for new features
- [ ] Documentation updated
- [ ] Commit messages follow conventions
- [ ] No merge conflicts
- [ ] PR description explains changes clearly

## 🧪 Testing

```bash
# Run all tests
dotnet test

# Run specific project tests
dotnet test src/BootstrapMultiSelect.MVC.Tests/
```

## 📝 Documentation

- Update **README.md** for major changes
- Update **CHANGELOG.md** following [Keep a Changelog](https://keepachangelog.com/)
- Add examples to **docs/** folder
- Update code comments and XML docs

## 🚀 Release Process

1. Update version in:
   - `src/BootstrapMultiSelect.MVC/BootstrapMultiSelect.MVC.csproj`
   - `src/BootstrapMultiSelect.Plugin/package.json`
   - `CHANGELOG.md`

2. Create a release branch:

   ```bash
   git checkout -b release/v1.x.x develop
   ```

3. Merge to `main`:

   ```bash
   git checkout main
   git merge release/v1.x.x
   git tag -a v1.x.x -m "Release version 1.x.x"
   git push origin main --tags
   ```

4. GitHub Actions will automatically:
   - Build the packages
   - Publish to NuGet
   - Publish to npm
   - Create GitHub Release

## 💬 Community

- **Discussions**: Ask questions and share ideas
- **Discord**: Join our community (link TBD)
- **Twitter**: Follow us @bootstrap_multiselect (TBD)

## 📄 License

By contributing, you agree that your contributions will be licensed under the MIT License.

## 🙏 Thank You

Your contributions make this project better for everyone. Thank you for taking the time to contribute!

---

If you have questions, feel free to open an issue or start a discussion.
