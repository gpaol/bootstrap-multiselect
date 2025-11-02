# GitHub Copilot Instructions

## General Guidelines

### Language
- **Use English language** for all code, comments, documentation, and identifiers
- Write all variable names, method names, class names, and other identifiers in English
- Provide all code comments and documentation in English

### XML Documentation
- **Add XML documentation** to all public classes, methods, properties, and fields
- Include comprehensive XML documentation comments for:
  - Classes and interfaces
  - Public and protected methods
  - Properties and fields
  - Constructors
  - Events and delegates
  
### XML Documentation Format
Use the following XML documentation tags appropriately:
- `<summary>` - Brief description of the member
- `<param>` - Description of method parameters
- `<returns>` - Description of return values
- `<exception>` - Exceptions that can be thrown
- `<remarks>` - Additional detailed information
- `<example>` - Code examples demonstrating usage
- `<value>` - Description of property values

### Example
```csharp
/// <summary>
/// Represents a multi-select dropdown component with jQuery integration.
/// </summary>
/// <remarks>
/// This class provides enhanced functionality for selecting multiple items
/// from a dropdown list with search and filtering capabilities.
/// </remarks>
public class MultiSelectDropdown
{
    /// <summary>
    /// Gets or sets the selected items in the dropdown.
    /// </summary>
    /// <value>
    /// A collection of selected item identifiers.
    /// </value>
    public List<string> SelectedItems { get; set; }
    
    /// <summary>
    /// Initializes the multi-select dropdown with the specified options.
    /// </summary>
    /// <param name="options">Configuration options for the dropdown.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="options"/> is null.
    /// </exception>
    public void Initialize(DropdownOptions options)
    {
        // Implementation
    }
}
```

## UI Development
- **Use Bootstrap** for creating all user interfaces
- **All UIs must be responsive** and work seamlessly across different screen sizes (mobile, tablet, desktop)
- Utilize Bootstrap components and utilities for consistent design
- Follow Bootstrap best practices and conventions
- Leverage Bootstrap's responsive grid system for layouts
- Use Bootstrap's built-in CSS classes for styling

## Code Quality Standards
- Follow consistent naming conventions (PascalCase for classes/methods, camelCase for parameters/local variables)
- Write clear, descriptive names that explain the purpose
- Keep methods focused and single-purpose
- Add documentation for complex logic or business rules
