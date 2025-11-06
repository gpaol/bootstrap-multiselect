# jQuery Plugin Examples

Complete examples for using **Bootstrap MultiSelect** as a pure **jQuery plugin** (no server-side dependencies).

## 📋 Table of Contents

1. [Basic Setup](#basic-setup)
2. [Example 1: Simple Multi-Select](#example-1-simple-multi-select)
3. [Example 2: With Search](#example-2-with-search)
4. [Example 3: Select All Button](#example-3-select-all-button)
5. [Example 4: Pre-selected Items](#example-4-pre-selected-items)
6. [Example 5: Grouped Options](#example-5-grouped-options)
7. [Example 6: Custom Placeholder](#example-6-custom-placeholder)
8. [Example 7: Disabled State](#example-7-disabled-state)
9. [Example 8: Pagination](#example-8-pagination)
10. [Example 9: All Features Combined](#example-9-all-features-combined)
11. [Localization Examples](#localization-examples)
12. [Event Handling](#event-handling)
13. [Dynamic Updates](#dynamic-updates)

---

## Basic Setup

### 1. Include Dependencies

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Bootstrap MultiSelect Examples</title>
    
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- Bootstrap MultiSelect CSS -->
    <link href="/css/jquery-bootstrap-multiselect.css" rel="stylesheet">
</head>
<body>
    <!-- Your content here -->
    
    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    
    <!-- Bootstrap MultiSelect JS -->
    <script src="/js/jquery-bootstrap-multiselect.js"></script>
</body>
</html>
```

### 2. Basic HTML Structure

```html
<select id="mySelect" multiple>
    <option value="1">Option 1</option>
    <option value="2">Option 2</option>
    <option value="3">Option 3</option>
</select>
```

### 3. Initialize Plugin

```javascript
$(document).ready(function() {
    $('#mySelect').bootstrapMultiSelect();
});
```

---

## Example 1: Simple Multi-Select

Minimal configuration for basic multi-selection.

```html
<div class="mb-3">
    <label for="select1" class="form-label">Choose Options</label>
    <select id="select1" class="form-select" multiple>
        <option value="apple">Apple</option>
        <option value="banana">Banana</option>
        <option value="cherry">Cherry</option>
        <option value="date">Date</option>
        <option value="elderberry">Elderberry</option>
    </select>
</div>

<script>
$(document).ready(function() {
    $('#select1').bootstrapMultiSelect({
        placeholder: 'Select fruits...'
    });
});
</script>
```

---

## Example 2: With Search

Enable search functionality for filtering options.

```html
<div class="mb-3">
    <label for="select2" class="form-label">Search and Select</label>
    <select id="select2" class="form-select" multiple>
        <option value="html">HTML</option>
        <option value="css">CSS</option>
        <option value="javascript">JavaScript</option>
        <option value="typescript">TypeScript</option>
        <option value="react">React</option>
        <option value="angular">Angular</option>
        <option value="vue">Vue.js</option>
        <option value="svelte">Svelte</option>
    </select>
</div>

<script>
$(document).ready(function() {
    $('#select2').bootstrapMultiSelect({
        placeholder: 'Select technologies...',
        enableSearch: true,
        searchPlaceholder: 'Type to search...'
    });
});
</script>
```

---

## Example 3: Select All Button

Add a "Select All" / "Deselect All" button.

```html
<div class="mb-3">
    <label for="select3" class="form-label">Select All Example</label>
    <select id="select3" class="form-select" multiple>
        <option value="mon">Monday</option>
        <option value="tue">Tuesday</option>
        <option value="wed">Wednesday</option>
        <option value="thu">Thursday</option>
        <option value="fri">Friday</option>
        <option value="sat">Saturday</option>
        <option value="sun">Sunday</option>
    </select>
</div>

<script>
$(document).ready(function() {
    $('#select3').bootstrapMultiSelect({
        placeholder: 'Select days...',
        showSelectAll: true,
        selectAllText: 'Select All Days',
        deselectAllText: 'Clear All'
    });
});
</script>
```

---

## Example 4: Pre-selected Items

Initialize with pre-selected values.

```html
<div class="mb-3">
    <label for="select4" class="form-label">Pre-selected Items</label>
    <select id="select4" class="form-select" multiple>
        <option value="red">Red</option>
        <option value="green" selected>Green</option>
        <option value="blue" selected>Blue</option>
        <option value="yellow">Yellow</option>
        <option value="purple">Purple</option>
    </select>
</div>

<script>
$(document).ready(function() {
    $('#select4').bootstrapMultiSelect({
        placeholder: 'Select colors...'
    });
});
</script>
```

---

## Example 5: Grouped Options

Organize options into groups.

```html
<div class="mb-3">
    <label for="select5" class="form-label">Grouped Options</label>
    <select id="select5" class="form-select" multiple>
        <optgroup label="Fruits">
            <option value="apple">Apple</option>
            <option value="banana">Banana</option>
            <option value="cherry">Cherry</option>
        </optgroup>
        <optgroup label="Vegetables">
            <option value="carrot">Carrot</option>
            <option value="broccoli">Broccoli</option>
            <option value="spinach">Spinach</option>
        </optgroup>
        <optgroup label="Grains">
            <option value="rice">Rice</option>
            <option value="wheat">Wheat</option>
            <option value="oats">Oats</option>
        </optgroup>
    </select>
</div>

<script>
$(document).ready(function() {
    $('#select5').bootstrapMultiSelect({
        placeholder: 'Select food items...',
        enableSearch: true
    });
});
</script>
```

---

## Example 6: Custom Placeholder

Customize the placeholder text based on selected items.

```html
<div class="mb-3">
    <label for="select6" class="form-label">Custom Placeholder</label>
    <select id="select6" class="form-select" multiple>
        <option value="feature1">Feature 1</option>
        <option value="feature2">Feature 2</option>
        <option value="feature3">Feature 3</option>
        <option value="feature4">Feature 4</option>
    </select>
</div>

<script>
$(document).ready(function() {
    $('#select6').bootstrapMultiSelect({
        placeholder: 'No features selected',
        // Custom text when items are selected
        selectedTextFormat: 'count',
        selectedTextFormatCount: '{0} features selected'
    });
});
</script>
```

---

## Example 7: Disabled State

Disable the entire dropdown or specific options.

```html
<div class="mb-3">
    <label for="select7" class="form-label">Disabled Example</label>
    <select id="select7" class="form-select" multiple>
        <option value="available1">Available Option 1</option>
        <option value="available2">Available Option 2</option>
        <option value="disabled1" disabled>Disabled Option</option>
        <option value="available3">Available Option 3</option>
    </select>
</div>

<button id="toggleDisable" class="btn btn-secondary">Toggle Disable</button>

<script>
$(document).ready(function() {
    $('#select7').bootstrapMultiSelect({
        placeholder: 'Select options...'
    });
    
    $('#toggleDisable').click(function() {
        $('#select7').prop('disabled', function(i, val) {
            return !val;
        }).bootstrapMultiSelect('refresh');
    });
});
</script>
```

---

## Example 8: Pagination

Paginate long lists of options for better performance and user experience.

```html
<div class="mb-3">
    <label for="select8" class="form-label">Countries (Paginated)</label>
    <select id="select8" class="form-select" multiple>
        <option value="usa">United States</option>
        <option value="canada">Canada</option>
        <option value="mexico">Mexico</option>
        <option value="uk">United Kingdom</option>
        <option value="france">France</option>
        <option value="germany">Germany</option>
        <option value="italy">Italy</option>
        <option value="spain">Spain</option>
        <option value="japan">Japan</option>
        <option value="china">China</option>
        <option value="india">India</option>
        <option value="brazil">Brazil</option>
        <option value="australia">Australia</option>
        <option value="russia">Russia</option>
        <option value="southkorea">South Korea</option>
        <!-- Add more options as needed -->
    </select>
</div>

<script>
$(document).ready(function() {
    $('#select8').bootstrapMultiSelect({
        placeholder: 'Select countries...',
        enableSearch: true,
        enablePagination: true,
        itemsPerPage: 5,
        paginationPosition: 'bottom' // 'top', 'bottom', or 'both'
    });
});
</script>
```

### Pagination Configuration Options

```javascript
$('#mySelect').bootstrapMultiSelect({
    enablePagination: true,           // Enable pagination
    itemsPerPage: 10,                 // Items per page (default: 10)
    paginationPosition: 'bottom',     // 'top', 'bottom', or 'both' (default: 'bottom')
    paginationPrevText: 'Previous',   // Previous button text
    paginationNextText: 'Next',       // Next button text
    paginationInfoText: 'Page {current} of {total}' // Info text template
});
```

---

## Example 9: All Features Combined

Complete example with all features enabled.

```html
<div class="mb-3">
    <label for="select9" class="form-label">Complete Example</label>
    <select id="select9" class="form-select" multiple>
        <optgroup label="Programming Languages">
            <option value="csharp">C#</option>
            <option value="java">Java</option>
            <option value="python" selected>Python</option>
            <option value="javascript">JavaScript</option>
        </optgroup>
        <optgroup label="Frameworks">
            <option value="dotnet">.NET</option>
            <option value="spring">Spring</option>
            <option value="django" selected>Django</option>
            <option value="react">React</option>
        </optgroup>
        <optgroup label="Databases">
            <option value="sqlserver">SQL Server</option>
            <option value="mysql">MySQL</option>
            <option value="postgresql">PostgreSQL</option>
            <option value="mongodb">MongoDB</option>
        </optgroup>
    </select>
</div>

<script>
$(document).ready(function() {
    $('#select9').bootstrapMultiSelect({
        placeholder: 'Select your tech stack...',
        enableSearch: true,
        searchPlaceholder: 'Search technologies...',
        showSelectAll: true,
        selectAllText: 'Select All Technologies',
        deselectAllText: 'Clear Selection',
        enablePagination: true,
        itemsPerPage: 8,
        paginationPosition: 'bottom'
    });
});
</script>
```

---

## Localization Examples

### Load Language File

```html
<!-- Include language file AFTER the main plugin -->
<script src="/js/jquery-bootstrap-multiselect.js"></script>
<script src="/js/langs/jquery-bootstrap-multiselect.it.js"></script>
```

### Global Language Setting

Apply Italian to all instances:

```javascript
// Set Italian as global default
$.fn.bootstrapMultiSelect.lang = 'it';

// All instances now use Italian
$('#select1').bootstrapMultiSelect();
$('#select2').bootstrapMultiSelect();
```

### Per-Instance Language

Different languages for different instances:

```html
<!-- Load all needed languages -->
<script src="/js/langs/jquery-bootstrap-multiselect.it.js"></script>
<script src="/js/langs/jquery-bootstrap-multiselect.es.js"></script>
<script src="/js/langs/jquery-bootstrap-multiselect.fr.js"></script>

<script>
// Each instance can have its own language
$('#select1').bootstrapMultiSelect({ lang: 'it' }); // Italian
$('#select2').bootstrapMultiSelect({ lang: 'es' }); // Spanish
$('#select3').bootstrapMultiSelect({ lang: 'fr' }); // French
$('#select4').bootstrapMultiSelect();              // English (default)
</script>
```

### Using Data Attribute

```html
<select id="selectIT" data-lang="it" multiple>
    <option value="1">Opzione 1</option>
    <option value="2">Opzione 2</option>
</select>

<script>
// Language is read from data-lang attribute
$('#selectIT').bootstrapMultiSelect();
</script>
```

---

## Event Handling

### Available Events

```javascript
$('#mySelect').bootstrapMultiSelect({
    placeholder: 'Select items...'
}).on('changed.bs.multiselect', function(e, option, checked) {
    // Triggered when an option is selected/deselected
    console.log('Option value:', option.value);
    console.log('Option text:', option.text);
    console.log('Is checked:', checked);
    
    // Get all selected values
    var selected = $(this).val();
    console.log('All selected:', selected);
});
```

### Multiple Event Handlers

```javascript
var $select = $('#mySelect').bootstrapMultiSelect();

// Listen to change events
$select.on('changed.bs.multiselect', function(e, option, checked) {
    $('#log').append('<div>Changed: ' + option.text + ' = ' + checked + '</div>');
});

// Listen to dropdown open
$select.on('show.bs.dropdown', function() {
    console.log('Dropdown opened');
});

// Listen to dropdown close
$select.on('hide.bs.dropdown', function() {
    console.log('Dropdown closed');
    var count = $(this).val()?.length || 0;
    console.log('Total selected:', count);
});
```

---

## Dynamic Updates

### Add Options Dynamically

```javascript
// Add new option
$('#mySelect').append('<option value="new">New Option</option>');

// Refresh the plugin to reflect changes
$('#mySelect').bootstrapMultiSelect('refresh');
```

### Remove Options

```javascript
// Remove option by value
$('#mySelect option[value="someValue"]').remove();

// Refresh
$('#mySelect').bootstrapMultiSelect('refresh');
```

### Update Selected Values

```javascript
// Select specific values programmatically
$('#mySelect').val(['value1', 'value2', 'value3']);

// Refresh to update UI
$('#mySelect').bootstrapMultiSelect('refresh');
```

### Clear Selection

```javascript
// Clear all selections
$('#mySelect').val([]);
$('#mySelect').bootstrapMultiSelect('refresh');
```

### Enable/Disable

```javascript
// Disable
$('#mySelect').prop('disabled', true).bootstrapMultiSelect('refresh');

// Enable
$('#mySelect').prop('disabled', false).bootstrapMultiSelect('refresh');
```

### Destroy and Reinitialize

```javascript
// Destroy plugin instance
$('#mySelect').bootstrapMultiSelect('destroy');

// Reinitialize with new config
$('#mySelect').bootstrapMultiSelect({
    placeholder: 'New placeholder',
    enableSearch: true
});
```

---

## Complete Working Example

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Bootstrap MultiSelect - Complete Example</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="/css/jquery-bootstrap-multiselect.css" rel="stylesheet">
</head>
<body>
    <div class="container mt-5">
        <h1>Bootstrap MultiSelect Demo</h1>
        
        <div class="row mt-4">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="techStack" class="form-label">Your Tech Stack</label>
                    <select id="techStack" class="form-select" multiple>
                        <optgroup label="Languages">
                            <option value="csharp">C#</option>
                            <option value="javascript">JavaScript</option>
                            <option value="python">Python</option>
                        </optgroup>
                        <optgroup label="Frameworks">
                            <option value="aspnet">ASP.NET Core</option>
                            <option value="react">React</option>
                            <option value="vue">Vue.js</option>
                        </optgroup>
                    </select>
                </div>
                
                <button id="getValues" class="btn btn-primary">Get Selected Values</button>
                <button id="clearAll" class="btn btn-secondary">Clear All</button>
            </div>
            
            <div class="col-md-6">
                <h5>Selected Values:</h5>
                <div id="output" class="alert alert-info">
                    <em>None selected</em>
                </div>
                
                <h5>Event Log:</h5>
                <div id="eventLog" class="border p-2" style="height: 200px; overflow-y: auto;">
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="/js/jquery-bootstrap-multiselect.js"></script>
    
    <script>
    $(document).ready(function() {
        // Initialize plugin
        $('#techStack').bootstrapMultiSelect({
            placeholder: 'Select your technologies...',
            enableSearch: true,
            showSelectAll: true
        }).on('changed.bs.multiselect', function(e, option, checked) {
            // Log event
            var action = checked ? 'Selected' : 'Deselected';
            $('#eventLog').prepend(
                '<div class="small">' + action + ': ' + option.text + '</div>'
            );
            
            // Update output
            updateOutput();
        });
        
        // Get values button
        $('#getValues').click(function() {
            var values = $('#techStack').val() || [];
            alert('Selected values: ' + values.join(', '));
        });
        
        // Clear all button
        $('#clearAll').click(function() {
            $('#techStack').val([]).bootstrapMultiSelect('refresh');
            updateOutput();
        });
        
        function updateOutput() {
            var selected = $('#techStack').val() || [];
            if (selected.length === 0) {
                $('#output').html('<em>None selected</em>');
            } else {
                var text = $('#techStack option:selected').map(function() {
                    return $(this).text();
                }).get().join(', ');
                $('#output').html('<strong>' + selected.length + ' selected:</strong> ' + text);
            }
        }
    });
    </script>
</body>
</html>
```

---

## Configuration Reference

### All Available Options

```javascript
$('#mySelect').bootstrapMultiSelect({
    // Text options
    placeholder: 'Select items...',
    selectAllText: 'Select All',
    deselectAllText: 'Deselect All',
    searchPlaceholder: 'Search...',
    noneSelectedText: 'None selected',
    noneResultsText: 'No results match',
    
    // Feature toggles
    enableSearch: true,
    showSelectAll: true,
    
    // Pagination options
    enablePagination: false,
    itemsPerPage: 10,
    paginationPosition: 'bottom', // 'top', 'bottom', or 'both'
    paginationPrevText: 'Previous',
    paginationNextText: 'Next',
    paginationInfoText: 'Page {current} of {total}',
    
    // Localization
    lang: 'en', // or 'it', 'es', 'fr', etc.
    
    // Display format
    selectedTextFormat: 'count', // 'count', 'values', or 'static'
    selectedTextFormatCount: '{0} items selected'
});
```

### Methods

```javascript
// Refresh after changes
$('#mySelect').bootstrapMultiSelect('refresh');

// Destroy instance
$('#mySelect').bootstrapMultiSelect('destroy');

// Get/set values
var values = $('#mySelect').val();
$('#mySelect').val(['value1', 'value2']);
```

---

## See Also

- **Main Documentation**: `../README.md`
- **MVC Examples**: `MVC-EXAMPLES.md`
- **Localization Guide**: `../LOCALIZATION-GUIDE.md`
- **Project Overview**: `README.md`
