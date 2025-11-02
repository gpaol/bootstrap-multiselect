using System.Collections.Generic;
using System.Linq;
using System.Text;
using BootstrapMultiSelect.MVC.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapMultiSelect.MVC.TagHelpers
{
    /// <summary>
    /// Tag helper for creating Bootstrap MultiSelect dropdowns
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;multiselect asp-for="SelectedItems"
    ///              asp-items="Model.AvailableItems"
    ///              placeholder="Select items..."
    ///              max-selection="3"
    ///              theme="primary" /&gt;
    /// </code>
    /// </example>
    [HtmlTargetElement("multiselect")]
    public class MultiSelectTagHelper : TagHelper
    {
        private readonly IHtmlGenerator _htmlGenerator;

        /// <summary>
        /// Gets or sets the ViewContext
        /// </summary>
        [ViewContext]
        [HtmlAttributeNotBound]
        public required ViewContext ViewContext { get; set; }

        /// <summary>
        /// Gets or sets the model expression for the property to bind
        /// </summary>
        [HtmlAttributeName("asp-for")]
        public required ModelExpression For { get; set; }

        /// <summary>
        /// Gets or sets the items to display in the multiselect
        /// </summary>
        [HtmlAttributeName("asp-items")]
        public required IEnumerable<SelectListItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the placeholder text
        /// </summary>
        [HtmlAttributeName("placeholder")]
        public string Placeholder { get; set; } = "Select items...";

        /// <summary>
        /// Gets or sets the maximum number of items that can be selected (0 = unlimited)
        /// </summary>
        [HtmlAttributeName("max-selection")]
        public int MaxSelection { get; set; } = 0;

        /// <summary>
        /// Gets or sets whether to show the Select All/Deselect All buttons
        /// </summary>
        [HtmlAttributeName("select-all")]
        public bool SelectAll { get; set; } = true;

        /// <summary>
        /// Gets or sets whether to enable the search functionality
        /// </summary>
        [HtmlAttributeName("search")]
        public bool Search { get; set; } = true;

        /// <summary>
        /// Gets or sets the width of the dropdown
        /// </summary>
        [HtmlAttributeName("width")]
        public string Width { get; set; } = "100%";

        /// <summary>
        /// Gets or sets the Bootstrap theme
        /// </summary>
        [HtmlAttributeName("theme")]
        public string Theme { get; set; } = "primary";

        /// <summary>
        /// Gets or sets whether to close the dropdown when an item is selected
        /// </summary>
        [HtmlAttributeName("close-on-select")]
        public bool CloseOnSelect { get; set; } = false;

        /// <summary>
        /// Gets or sets the custom button CSS class
        /// </summary>
        [HtmlAttributeName("button-class")]
        public string? ButtonClass { get; set; }

        /// <summary>
        /// Gets or sets the search input placeholder
        /// </summary>
        [HtmlAttributeName("search-placeholder")]
        public string SearchPlaceholder { get; set; } = "Search...";

        /// <summary>
        /// Gets or sets the text for the Select All button
        /// </summary>
        [HtmlAttributeName("select-all-text")]
        public string SelectAllText { get; set; } = "Select All";

        /// <summary>
        /// Gets or sets the text for the Deselect All button
        /// </summary>
        [HtmlAttributeName("deselect-all-text")]
        public string DeselectAllText { get; set; } = "Deselect All";

        /// <summary>
        /// Gets or sets the text shown when no results are found
        /// </summary>
        [HtmlAttributeName("no-results-text")]
        public string NoResultsText { get; set; } = "No results found";

        /// <summary>
        /// Gets or sets the maximum height of the dropdown
        /// </summary>
        [HtmlAttributeName("max-height")]
        public string MaxHeight { get; set; } = "300px";

        /// <summary>
        /// Gets or sets the text shown when multiple items (4+) are selected (e.g., "items selected", "elementi selezionati")
        /// </summary>
        [HtmlAttributeName("items-selected-text")]
        public string ItemsSelectedText { get; set; } = "items selected";

        /// <summary>
        /// Gets or sets the locale code for localization (e.g., "it", "es", "fr", "de", "pt")
        /// </summary>
        /// <remarks>
        /// When set, the plugin will use the corresponding locale file for all text strings.
        /// Available locales: en (default), it, es, fr, de, pt
        /// Requires the locale file to be loaded: ~/js/locales/jquery-bootstrap-multiselect.{locale}.js
        /// </remarks>
        [HtmlAttributeName("locale")]
        public string? Locale { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiSelectTagHelper"/> class
        /// </summary>
        /// <param name="htmlGenerator">The HTML generator instance for generating form elements</param>
        public MultiSelectTagHelper(IHtmlGenerator htmlGenerator)
        {
            _htmlGenerator = htmlGenerator;
        }

        /// <summary>
        /// Processes the tag helper
        /// </summary>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.TagMode = TagMode.StartTagAndEndTag;

            // Add ID and Name attributes
            if (For != null)
            {
                var name = For.Name;
                var id = name.Replace(".", "_").Replace("[", "_").Replace("]", "_");

                output.Attributes.SetAttribute("id", id);
                output.Attributes.SetAttribute("name", name);

                // CRITICAL: Add validation attributes from ModelMetadata
                var metadata = For.Metadata;
                if (metadata != null && metadata.ValidatorMetadata.Count > 0)
                {
                    bool hasValidation = false;

                    // Add validation attributes from validators
                    foreach (var validator in metadata.ValidatorMetadata)
                    {
                        if (validator is System.ComponentModel.DataAnnotations.RequiredAttribute requiredAttr)
                        {
                            hasValidation = true;
                            var errorMessage = requiredAttr.ErrorMessage ??
                                $"The {metadata.DisplayName ?? metadata.PropertyName} field is required.";
                            output.Attributes.SetAttribute("data-val-required", errorMessage);
                        }
                        else if (validator is System.ComponentModel.DataAnnotations.MinLengthAttribute minLengthAttr)
                        {
                            hasValidation = true;
                            var errorMessage = minLengthAttr.ErrorMessage ??
                                $"The field {metadata.DisplayName ?? metadata.PropertyName} must have a minimum length of '{minLengthAttr.Length}'.";
                            output.Attributes.SetAttribute("data-val-minlength", errorMessage);
                            output.Attributes.SetAttribute("data-val-minlength-min", minLengthAttr.Length.ToString());
                        }
                        else if (validator is System.ComponentModel.DataAnnotations.MaxLengthAttribute maxLengthAttr)
                        {
                            hasValidation = true;
                            var errorMessage = maxLengthAttr.ErrorMessage ??
                                $"The field {metadata.DisplayName ?? metadata.PropertyName} must have a maximum length of '{maxLengthAttr.Length}'.";
                            output.Attributes.SetAttribute("data-val-maxlength", errorMessage);
                            output.Attributes.SetAttribute("data-val-maxlength-max", maxLengthAttr.Length.ToString());
                        }
                        else if (validator is System.ComponentModel.DataAnnotations.RangeAttribute rangeAttr)
                        {
                            hasValidation = true;
                            var errorMessage = rangeAttr.ErrorMessage ??
                                $"The field {metadata.DisplayName ?? metadata.PropertyName} must be between {rangeAttr.Minimum} and {rangeAttr.Maximum}.";
                            output.Attributes.SetAttribute("data-val-range", errorMessage);
                            output.Attributes.SetAttribute("data-val-range-min", rangeAttr.Minimum?.ToString() ?? "");
                            output.Attributes.SetAttribute("data-val-range-max", rangeAttr.Maximum?.ToString() ?? "");
                        }
                        else if (validator is System.ComponentModel.DataAnnotations.RegularExpressionAttribute regexAttr)
                        {
                            hasValidation = true;
                            var errorMessage = regexAttr.ErrorMessage ??
                                $"The field {metadata.DisplayName ?? metadata.PropertyName} must match the regular expression '{regexAttr.Pattern}'.";
                            output.Attributes.SetAttribute("data-val-regex", errorMessage);
                            output.Attributes.SetAttribute("data-val-regex-pattern", regexAttr.Pattern);
                        }
                        else if (validator is System.ComponentModel.DataAnnotations.CompareAttribute compareAttr)
                        {
                            hasValidation = true;
                            var errorMessage = compareAttr.ErrorMessage ??
                                $"'{metadata.DisplayName ?? metadata.PropertyName}' and '{compareAttr.OtherProperty}' do not match.";
                            output.Attributes.SetAttribute("data-val-equalto", errorMessage);
                            output.Attributes.SetAttribute("data-val-equalto-other", $"*.{compareAttr.OtherProperty}");
                        }
                        else if (validator is System.ComponentModel.DataAnnotations.ValidationAttribute validationAttr)
                        {
                            // Generic handler for any other ValidationAttribute (including custom ones)
                            // Uses the attribute type name as the validation type
                            hasValidation = true;
                            var validationType = validator.GetType().Name.Replace("Attribute", "").ToLower();
                            var displayName = metadata.DisplayName ?? metadata.PropertyName ?? string.Empty;
                            var errorMessage = validationAttr.ErrorMessage ??
                                validationAttr.FormatErrorMessage(displayName);
                            output.Attributes.SetAttribute($"data-val-{validationType}", errorMessage);
                        }
                    }

                    // Only add data-val="true" if we have at least one validation attribute
                    if (hasValidation)
                    {
                        output.Attributes.SetAttribute("data-val", "true");
                    }
                }
            }

            // CRITICAL: Add 'multiple' attribute for proper form submission
            output.Attributes.SetAttribute("multiple", "multiple");

            // Add data attributes for plugin configuration
            output.Attributes.SetAttribute("data-toggle", "bootstrap-multiselect");
            output.Attributes.SetAttribute("data-placeholder", Placeholder);

            if (MaxSelection > 0)
                output.Attributes.SetAttribute("data-max-selection", MaxSelection);

            output.Attributes.SetAttribute("data-select-all", SelectAll.ToString().ToLower());
            output.Attributes.SetAttribute("data-search", Search.ToString().ToLower());
            output.Attributes.SetAttribute("data-width", Width);
            output.Attributes.SetAttribute("data-theme", Theme);
            output.Attributes.SetAttribute("data-close-on-select", CloseOnSelect.ToString().ToLower());

            if (!string.IsNullOrEmpty(ButtonClass))
                output.Attributes.SetAttribute("data-button-class", ButtonClass);

            if (!string.IsNullOrEmpty(SearchPlaceholder))
                output.Attributes.SetAttribute("data-search-placeholder", SearchPlaceholder);

            if (!string.IsNullOrEmpty(SelectAllText))
                output.Attributes.SetAttribute("data-select-all-text", SelectAllText);

            if (!string.IsNullOrEmpty(DeselectAllText))
                output.Attributes.SetAttribute("data-deselect-all-text", DeselectAllText);

            if (!string.IsNullOrEmpty(NoResultsText))
                output.Attributes.SetAttribute("data-no-results-text", NoResultsText);

            if (!string.IsNullOrEmpty(MaxHeight))
                output.Attributes.SetAttribute("data-max-height", MaxHeight);

            if (!string.IsNullOrEmpty(ItemsSelectedText))
                output.Attributes.SetAttribute("data-items-selected-text", ItemsSelectedText);

            if (!string.IsNullOrEmpty(Locale))
                output.Attributes.SetAttribute("data-locale", Locale);

            // Build options
            if (Items != null)
            {
                var selectedValues = For?.Model as IEnumerable<string> ?? new List<string>();
                var sb = new StringBuilder();

                // Group items by Group property
                var groups = Items.GroupBy(i => i.Group?.Name ?? string.Empty);

                foreach (var group in groups)
                {
                    if (!string.IsNullOrEmpty(group.Key))
                    {
                        // OptGroup
                        sb.AppendLine($"<optgroup label=\"{group.Key}\">");
                        foreach (var item in group)
                        {
                            sb.AppendLine(BuildOption(item, selectedValues));
                        }
                        sb.AppendLine("</optgroup>");
                    }
                    else
                    {
                        // Regular options
                        foreach (var item in group)
                        {
                            sb.AppendLine(BuildOption(item, selectedValues));
                        }
                    }
                }

                output.Content.SetHtmlContent(sb.ToString());
            }
        }

        private string BuildOption(SelectListItem item, IEnumerable<string> selectedValues)
        {
            var selected = item.Selected || selectedValues.Contains(item.Value) ? " selected" : "";
            var disabled = item.Disabled ? " disabled" : "";
            return $"<option value=\"{item.Value}\"{selected}{disabled}>{item.Text}</option>";
        }
    }
}
