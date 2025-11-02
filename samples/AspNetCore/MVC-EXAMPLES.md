# ASP.NET Core MVC Examples

Complete examples for using **Bootstrap MultiSelect MVC Library** with **ASP.NET Core** TagHelpers and HtmlHelpers.

## 📋 Table of Contents

1. [Setup](#setup)
2. [Basic TagHelper Usage](#basic-taghelper-usage)
3. [Complete Form Example](#complete-form-example)
4. [Configuration Options](#configuration-options)
5. [Validation](#validation)
6. [Localization](#localization)
7. [Advanced Scenarios](#advanced-scenarios)

---

## Setup

### 1. Install NuGet Package

```bash
dotnet add package BootstrapMultiSelect.MVC
```

### 2. Register TagHelpers

Add to `_ViewImports.cshtml`:

```cshtml
@addTagHelper *, BootstrapMultiSelect.MVC
```

### 3. Add CSS and JS References

In your layout file (`_Layout.cshtml`):

```html
<!DOCTYPE html>
<html>
<head>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- Bootstrap MultiSelect CSS -->
    <link href="~/css/jquery-bootstrap-multiselect.css" rel="stylesheet" />
    
    @await RenderSectionAsync("Styles", required: false)
</head>
<body>
    @RenderBody()
    
    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    
    <!-- jQuery Validation -->
    <script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.19.5/dist/jquery.validate.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-validation-unobtrusive@4.0.0/dist/jquery.validate.unobtrusive.min.js"></script>
    
    <!-- Bootstrap MultiSelect JS -->
    <script src="~/js/jquery-bootstrap-multiselect.js"></script>
    
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
```

---

## Basic TagHelper Usage

### Simple Example

**Model:**

```csharp
public class MyViewModel
{
    public List<string> SelectedItems { get; set; } = new();
}
```

**View:**

```cshtml
@model MyViewModel

<form method="post">
    <div class="mb-3">
        <label asp-for="SelectedItems" class="form-label">Choose Items</label>
        <multiselect asp-for="SelectedItems" placeholder="Select items...">
            <option value="item1">Item 1</option>
            <option value="item2">Item 2</option>
            <option value="item3">Item 3</option>
        </multiselect>
    </div>
    
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

**Controller:**

```csharp
[HttpPost]
public IActionResult Submit(MyViewModel model)
{
    // model.SelectedItems contains the selected values
    foreach (var item in model.SelectedItems)
    {
        Console.WriteLine($"Selected: {item}");
    }
    
    return View(model);
}
```

---

## Complete Form Example

### Model with Validation

```csharp
using System.ComponentModel.DataAnnotations;

namespace BootstrapMultiSelectExamples.Models
{
    /// <summary>
    /// Survey form model with validation
    /// </summary>
    public class SurveyFormModel
    {
        /// <summary>
        /// Gets or sets the selected programming languages
        /// </summary>
        [Required(ErrorMessage = "Please select at least one programming language")]
        [MinLength(1, ErrorMessage = "Please select at least one programming language")]
        [Display(Name = "Programming Languages")]
        public List<string> ProgrammingLanguages { get; set; } = new();

        /// <summary>
        /// Gets or sets the selected frameworks
        /// </summary>
        [Display(Name = "Frameworks")]
        public List<string> Frameworks { get; set; } = new();

        /// <summary>
        /// Gets or sets the selected databases
        /// </summary>
        [Required(ErrorMessage = "Please select at least one database")]
        [Display(Name = "Databases")]
        public List<string> Databases { get; set; } = new();

        /// <summary>
        /// Gets or sets user's name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets user's email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
```

### View

```cshtml
@model SurveyFormModel

@{
    ViewData["Title"] = "Tech Survey";
}

<div class="container mt-4">
    <h2>Developer Technology Survey</h2>
    
    <form asp-action="SubmitSurvey" method="post" class="needs-validation">
        <div asp-validation-summary="ModelOnly" class="alert alert-danger"></div>
        
        <!-- Name -->
        <div class="mb-3">
            <label asp-for="Name" class="form-label"></label>
            <input asp-for="Name" class="form-control" />
            <span asp-validation-for="Name" class="text-danger"></span>
        </div>
        
        <!-- Email -->
        <div class="mb-3">
            <label asp-for="Email" class="form-label"></label>
            <input asp-for="Email" class="form-control" type="email" />
            <span asp-validation-for="Email" class="text-danger"></span>
        </div>
        
        <!-- Programming Languages -->
        <div class="mb-3">
            <label asp-for="ProgrammingLanguages" class="form-label"></label>
            <multiselect asp-for="ProgrammingLanguages" 
                         placeholder="Select programming languages..."
                         enable-search="true"
                         show-select-all="true">
                <optgroup label="Compiled Languages">
                    <option value="csharp">C#</option>
                    <option value="java">Java</option>
                    <option value="cpp">C++</option>
                    <option value="go">Go</option>
                    <option value="rust">Rust</option>
                </optgroup>
                <optgroup label="Interpreted Languages">
                    <option value="python">Python</option>
                    <option value="javascript">JavaScript</option>
                    <option value="ruby">Ruby</option>
                    <option value="php">PHP</option>
                </optgroup>
            </multiselect>
            <span asp-validation-for="ProgrammingLanguages" class="text-danger"></span>
        </div>
        
        <!-- Frameworks -->
        <div class="mb-3">
            <label asp-for="Frameworks" class="form-label"></label>
            <multiselect asp-for="Frameworks" 
                         placeholder="Select frameworks (optional)..."
                         enable-search="true">
                <option value="aspnet">ASP.NET Core</option>
                <option value="spring">Spring Boot</option>
                <option value="django">Django</option>
                <option value="rails">Ruby on Rails</option>
                <option value="react">React</option>
                <option value="angular">Angular</option>
                <option value="vue">Vue.js</option>
                <option value="laravel">Laravel</option>
            </multiselect>
            <span asp-validation-for="Frameworks" class="text-danger"></span>
        </div>
        
        <!-- Databases -->
        <div class="mb-3">
            <label asp-for="Databases" class="form-label"></label>
            <multiselect asp-for="Databases" 
                         placeholder="Select databases..."
                         enable-search="true"
                         show-select-all="true"
                         select-all-text="Select All Databases"
                         deselect-all-text="Clear Selection">
                <optgroup label="SQL Databases">
                    <option value="sqlserver">SQL Server</option>
                    <option value="mysql">MySQL</option>
                    <option value="postgresql">PostgreSQL</option>
                    <option value="oracle">Oracle</option>
                    <option value="sqlite">SQLite</option>
                </optgroup>
                <optgroup label="NoSQL Databases">
                    <option value="mongodb">MongoDB</option>
                    <option value="redis">Redis</option>
                    <option value="cassandra">Cassandra</option>
                    <option value="couchdb">CouchDB</option>
                </optgroup>
            </multiselect>
            <span asp-validation-for="Databases" class="text-danger"></span>
        </div>
        
        <button type="submit" class="btn btn-primary">Submit Survey</button>
        <a asp-action="Index" class="btn btn-secondary">Cancel</a>
    </form>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

### Controller

```csharp
using Microsoft.AspNetCore.Mvc;
using BootstrapMultiSelectExamples.Models;

namespace BootstrapMultiSelectExamples.Controllers
{
    /// <summary>
    /// Controller for survey operations
    /// </summary>
    public class SurveyController : Controller
    {
        /// <summary>
        /// Display the survey form
        /// </summary>
        public IActionResult Index()
        {
            return View(new SurveyFormModel());
        }

        /// <summary>
        /// Process the submitted survey
        /// </summary>
        /// <param name="model">The survey form data</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitSurvey(SurveyFormModel model)
        {
            if (!ModelState.IsValid)
            {
                // Validation failed - redisplay form with errors
                return View("Index", model);
            }

            // Process the survey data
            var results = new
            {
                Name = model.Name,
                Email = model.Email,
                Languages = model.ProgrammingLanguages,
                Frameworks = model.Frameworks,
                Databases = model.Databases
            };

            // Store in database, send email, etc.
            // ...

            TempData["SuccessMessage"] = "Survey submitted successfully!";
            return RedirectToAction("ThankYou");
        }

        /// <summary>
        /// Display thank you page
        /// </summary>
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
```

---

## Configuration Options

### All TagHelper Attributes

```cshtml
<multiselect asp-for="PropertyName"
             placeholder="Select items..."
             enable-search="true"
             search-placeholder="Type to search..."
             show-select-all="true"
             select-all-text="Select All"
             deselect-all-text="Deselect All"
             lang="en">
    <option value="1">Option 1</option>
    <option value="2">Option 2</option>
</multiselect>
```

### Programmatic Configuration

You can also configure via C# using `MultiSelectConfig`:

**Model:**

```csharp
using BootstrapMultiSelect.MVC;

public class MyViewModel
{
    public List<string> SelectedItems { get; set; } = new();
    
    public MultiSelectConfig Config { get; set; } = new()
    {
        Placeholder = "Choose options...",
        EnableSearch = true,
        ShowSelectAll = true,
        Lang = "en"
    };
}
```

**View:**

```cshtml
@model MyViewModel

<multiselect asp-for="SelectedItems" config="@Model.Config">
    <option value="1">Option 1</option>
    <option value="2">Option 2</option>
</multiselect>
```

---

## Validation

### Client-Side Validation

The library automatically integrates with jQuery Validation:

```cshtml
@model MyViewModel

<form method="post">
    <div class="mb-3">
        <label asp-for="SelectedItems" class="form-label"></label>
        <multiselect asp-for="SelectedItems" placeholder="Select...">
            <option value="1">Option 1</option>
            <option value="2">Option 2</option>
        </multiselect>
        <!-- Validation message appears here -->
        <span asp-validation-for="SelectedItems" class="text-danger"></span>
    </div>
    
    <button type="submit" class="btn btn-primary">Submit</button>
</form>

@section Scripts {
    <!-- Include validation scripts -->
    <partial name="_ValidationScriptsPartial" />
}
```

### Server-Side Validation

```csharp
[HttpPost]
public IActionResult Submit(MyViewModel model)
{
    if (!ModelState.IsValid)
    {
        // Return to form with validation errors
        return View(model);
    }
    
    // Process valid data
    return RedirectToAction("Success");
}
```

### Custom Validation

```csharp
using System.ComponentModel.DataAnnotations;

public class MyViewModel
{
    [Required]
    [MinLength(2, ErrorMessage = "Please select at least 2 items")]
    [MaxLength(5, ErrorMessage = "You can select maximum 5 items")]
    public List<string> SelectedItems { get; set; } = new();
}
```

---

## Localization

### Global Language Setting

Set language for all instances in your layout or view:

```html
<script src="~/js/jquery-bootstrap-multiselect.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<script>
    // Set Italian as global default
    $.fn.bootstrapMultiSelect.lang = 'it';
</script>
```

### Per-Instance Language

Using TagHelper attribute:

```cshtml
<!-- Italian instance -->
<multiselect asp-for="Items1" lang="it" placeholder="Seleziona...">
    <option value="1">Opzione 1</option>
</multiselect>

<!-- Spanish instance -->
<multiselect asp-for="Items2" lang="es" placeholder="Seleccionar...">
    <option value="1">Opción 1</option>
</multiselect>

<!-- English instance (default) -->
<multiselect asp-for="Items3" placeholder="Select...">
    <option value="1">Option 1</option>
</multiselect>
```

### Using Configuration Object

```csharp
public class MyViewModel
{
    public List<string> ItalianItems { get; set; } = new();
    public List<string> SpanishItems { get; set; } = new();
    
    public MultiSelectConfig ItalianConfig { get; set; } = new()
    {
        Lang = "it",
        Placeholder = "Seleziona elementi..."
    };
    
    public MultiSelectConfig SpanishConfig { get; set; } = new()
    {
        Lang = "es",
        Placeholder = "Seleccionar elementos..."
    };
}
```

```cshtml
@model MyViewModel

<script src="~/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<script src="~/js/langs/jquery-bootstrap-multiselect.es.js"></script>

<multiselect asp-for="ItalianItems" config="@Model.ItalianConfig">
    <option value="1">Opzione 1</option>
</multiselect>

<multiselect asp-for="SpanishItems" config="@Model.SpanishConfig">
    <option value="1">Opción 1</option>
</multiselect>
```

---

## Advanced Scenarios

### Dynamic Options from Database

**Model:**

```csharp
using Microsoft.AspNetCore.Mvc.Rendering;

public class ProductSelectionViewModel
{
    public List<string> SelectedProductIds { get; set; } = new();
    
    public List<SelectListItem> AvailableProducts { get; set; } = new();
}
```

**Controller:**

```csharp
public IActionResult SelectProducts()
{
    var model = new ProductSelectionViewModel
    {
        AvailableProducts = _dbContext.Products
            .Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
                Disabled = !p.IsAvailable
            })
            .ToList()
    };
    
    return View(model);
}
```

**View:**

```cshtml
@model ProductSelectionViewModel

<multiselect asp-for="SelectedProductIds" 
             asp-items="@Model.AvailableProducts"
             placeholder="Select products..."
             enable-search="true"
             show-select-all="true">
</multiselect>
```

### Grouped Options from Database

**Model:**

```csharp
public class CategoryProductViewModel
{
    public List<string> SelectedProductIds { get; set; } = new();
    
    public List<SelectListGroup> Categories { get; set; } = new();
    public List<SelectListItem> Products { get; set; } = new();
}
```

**Controller:**

```csharp
public IActionResult SelectProducts()
{
    var categories = _dbContext.Categories.ToList();
    var products = _dbContext.Products.Include(p => p.Category).ToList();
    
    var model = new CategoryProductViewModel
    {
        Categories = categories
            .Select(c => new SelectListGroup { Name = c.Name })
            .ToList(),
            
        Products = products
            .Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
                Group = new SelectListGroup { Name = p.Category.Name }
            })
            .ToList()
    };
    
    return View(model);
}
```

**View:**

```cshtml
@model CategoryProductViewModel

<multiselect asp-for="SelectedProductIds" 
             asp-items="@Model.Products"
             placeholder="Select products by category..."
             enable-search="true">
</multiselect>
```

### Pre-selected Values

**Controller:**

```csharp
public IActionResult Edit(int id)
{
    var user = _dbContext.Users
        .Include(u => u.Roles)
        .FirstOrDefault(u => u.Id == id);
    
    var model = new UserEditViewModel
    {
        // Pre-select user's current roles
        SelectedRoleIds = user.Roles.Select(r => r.Id.ToString()).ToList(),
        
        AvailableRoles = _dbContext.Roles
            .Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            })
            .ToList()
    };
    
    return View(model);
}
```

### AJAX Loading

**View:**

```cshtml
<div class="mb-3">
    <label for="categories" class="form-label">Categories</label>
    <select id="categories" class="form-select" multiple>
        <!-- Options loaded via AJAX -->
    </select>
</div>

<script>
$(document).ready(function() {
    // Load options via AJAX
    $.ajax({
        url: '@Url.Action("GetCategories", "Api")',
        type: 'GET',
        success: function(data) {
            var $select = $('#categories');
            
            // Add options
            $.each(data, function(i, category) {
                $select.append(
                    $('<option></option>')
                        .val(category.id)
                        .text(category.name)
                );
            });
            
            // Initialize plugin after options are loaded
            $select.bootstrapMultiSelect({
                placeholder: 'Select categories...',
                enableSearch: true
            });
        }
    });
});
</script>
```

**API Controller:**

```csharp
[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    /// <summary>
    /// Get all categories for AJAX loading
    /// </summary>
    [HttpGet("categories")]
    public IActionResult GetCategories()
    {
        var categories = _dbContext.Categories
            .Select(c => new { id = c.Id, name = c.Name })
            .ToList();
            
        return Ok(categories);
    }
}
```

### Cascading Dropdowns

```cshtml
<div class="mb-3">
    <label for="country" class="form-label">Country</label>
    <select id="country" class="form-select">
        <option value="">Select country...</option>
        <option value="US">United States</option>
        <option value="IT">Italy</option>
        <option value="ES">Spain</option>
    </select>
</div>

<div class="mb-3">
    <label for="cities" class="form-label">Cities</label>
    <multiselect asp-for="SelectedCities" 
                 id="cities"
                 placeholder="First select a country..."
                 enable-search="true">
    </multiselect>
</div>

<script>
$(document).ready(function() {
    $('#country').change(function() {
        var countryCode = $(this).val();
        
        if (!countryCode) {
            $('#cities').empty().bootstrapMultiSelect('refresh');
            return;
        }
        
        // Load cities for selected country
        $.ajax({
            url: '@Url.Action("GetCities", "Api")',
            type: 'GET',
            data: { countryCode: countryCode },
            success: function(cities) {
                var $cities = $('#cities');
                $cities.empty();
                
                $.each(cities, function(i, city) {
                    $cities.append(
                        $('<option></option>').val(city.id).text(city.name)
                    );
                });
                
                $cities.bootstrapMultiSelect('refresh');
            }
        });
    });
});
</script>
```

---

## Complete Project Structure

### Recommended File Organization

```text
YourProject/
├── Controllers/
│   ├── HomeController.cs
│   ├── SurveyController.cs
│   └── ApiController.cs
├── Models/
│   ├── SurveyFormModel.cs
│   ├── UserEditViewModel.cs
│   └── ProductSelectionViewModel.cs
├── Views/
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── Home/
│   │   └── Index.cshtml
│   └── Survey/
│       ├── Index.cshtml
│       └── ThankYou.cshtml
├── wwwroot/
│   ├── css/
│   │   └── jquery-bootstrap-multiselect.css
│   └── js/
│       ├── jquery-bootstrap-multiselect.js
│       └── langs/
│           ├── jquery-bootstrap-multiselect.it.js
│           ├── jquery-bootstrap-multiselect.es.js
│           └── jquery-bootstrap-multiselect.fr.js
└── Program.cs
```

### _ViewImports.cshtml

```cshtml
@using YourProject
@using YourProject.Models
@using BootstrapMultiSelect.MVC
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@addTagHelper *, BootstrapMultiSelect.MVC
```

---

## See Also

- **Main Documentation**: `../README.md`
- **jQuery Plugin Examples**: `PLUGIN-EXAMPLES.md`
- **MVC Library Documentation**: `../BootstrapMultiSelect.MVC/README.md`
- **Localization Guide**: `../LOCALIZATION-GUIDE.md`
- **Project Overview**: `README.md`
