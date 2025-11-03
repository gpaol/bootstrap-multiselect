using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BootstrapMultiSelect.MVC.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BootstrapMultiSelect.MVC.HtmlHelpers
{
    /// <summary>
    /// HTML Helper extensions for Bootstrap MultiSelect
    /// </summary>
    public static class MultiSelectHtmlHelper
    {
        /// <summary>
        /// Creates a Bootstrap MultiSelect dropdown for the specified model property
        /// </summary>
        /// <typeparam name="TModel">The type of the model</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="htmlHelper">The HTML helper instance</param>
        /// <param name="expression">The property expression</param>
        /// <param name="items">The list of items to display</param>
        /// <param name="config">Optional configuration</param>
        /// <returns>HTML string</returns>
        /// <example>
        /// <code>
        /// @Html.MultiSelectFor(m => m.SelectedItems, Model.AvailableItems, new MultiSelectConfig
        /// {
        ///     Placeholder = "Select items...",
        ///     MaxSelection = 3,
        ///     Theme = "primary"
        /// })
        /// </code>
        /// </example>
        public static IHtmlContent MultiSelectFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> items,
            MultiSelectConfig? config = null)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            config ??= new MultiSelectConfig();

            var name = htmlHelper.NameFor(expression).ToString();
            var id = htmlHelper.IdFor(expression).ToString();

            // Get model metadata for validation attributes
            var expressionProvider = htmlHelper.ViewContext.HttpContext.RequestServices
                .GetService(typeof(ModelExpressionProvider)) as ModelExpressionProvider;

            ModelMetadata? metadata = null;
            if (expressionProvider != null)
            {
                var modelExpression = expressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
                metadata = modelExpression.Metadata;
            }

            var selectedValues = new List<string>();
            // Simplified approach: items with Selected=true will be marked as selected
            // The actual model binding will be handled by ASP.NET MVC

            var sb = new StringBuilder();

            // Build select element
            sb.Append($"<select id=\"{id}\" name=\"{name}\" ");
            sb.Append("multiple=\"multiple\" ");

            // Add validation attributes
            if (metadata != null)
            {
                AppendValidationAttributes(sb, metadata);
            }

            sb.Append("data-toggle=\"bootstrap-multiselect\" ");
            sb.Append($"data-placeholder=\"{config.Placeholder}\" ");

            if (config.MaxSelection > 0)
                sb.Append($"data-max-selection=\"{config.MaxSelection}\" ");

            sb.Append($"data-select-all=\"{config.SelectAll.ToString().ToLower()}\" ");
            sb.Append($"data-search=\"{config.Search.ToString().ToLower()}\" ");
            sb.Append($"data-width=\"{config.Width}\" ");
            sb.Append($"data-theme=\"{config.Theme}\" ");
            sb.Append($"data-close-on-select=\"{config.CloseOnSelect.ToString().ToLower()}\" ");

            if (!string.IsNullOrEmpty(config.ButtonClass))
                sb.Append($"data-button-class=\"{config.ButtonClass}\" ");

            if (!string.IsNullOrEmpty(config.DropdownClass))
                sb.Append($"data-dropdown-class=\"{config.DropdownClass}\" ");

            sb.Append($"data-search-placeholder=\"{config.SearchPlaceholder}\" ");
            sb.Append($"data-select-all-text=\"{config.SelectAllText}\" ");
            sb.Append($"data-deselect-all-text=\"{config.DeselectAllText}\" ");
            sb.Append($"data-no-results-text=\"{config.NoResultsText}\" ");
            sb.Append($"data-max-height=\"{config.MaxHeight}\" ");
            sb.Append($"data-items-selected-text=\"{config.ItemsSelectedText}\" ");

            if (!string.IsNullOrEmpty(config.Lang))
                sb.Append($"data-lang=\"{config.Lang}\" ");

            sb.AppendLine(">");

            // Group items by Group property
            var groups = items.GroupBy(i => i.Group?.Name ?? string.Empty);

            foreach (var group in groups)
            {
                if (!string.IsNullOrEmpty(group.Key))
                {
                    // OptGroup
                    sb.AppendLine($"    <optgroup label=\"{group.Key}\">");
                    foreach (var item in group)
                    {
                        sb.AppendLine($"        {BuildOption(item, selectedValues)}");
                    }
                    sb.AppendLine("    </optgroup>");
                }
                else
                {
                    // Regular options
                    foreach (var item in group)
                    {
                        sb.AppendLine($"    {BuildOption(item, selectedValues)}");
                    }
                }
            }

            sb.AppendLine("</select>");

            return new HtmlString(sb.ToString());
        }

        /// <summary>
        /// Creates a Bootstrap MultiSelect dropdown with the specified name
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance</param>
        /// <param name="name">The name of the select element</param>
        /// <param name="items">The list of items to display</param>
        /// <param name="config">Optional configuration</param>
        /// <returns>HTML string</returns>
        /// <example>
        /// <code>
        /// @Html.MultiSelect("SelectedItems", Model.AvailableItems, new MultiSelectConfig
        /// {
        ///     Placeholder = "Select items...",
        ///     Theme = "success"
        /// })
        /// </code>
        /// </example>
        public static IHtmlContent MultiSelect(
            this IHtmlHelper htmlHelper,
            string name,
            IEnumerable<SelectListItem> items,
            MultiSelectConfig? config = null)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            config ??= new MultiSelectConfig();

            var id = name.Replace(".", "_").Replace("[", "_").Replace("]", "_");

            var sb = new StringBuilder();

            // Build select element
            sb.Append($"<select id=\"{id}\" name=\"{name}\" ");
            sb.Append("multiple=\"multiple\" ");
            sb.Append("data-toggle=\"bootstrap-multiselect\" ");
            sb.Append($"data-placeholder=\"{config.Placeholder}\" ");

            if (config.MaxSelection > 0)
                sb.Append($"data-max-selection=\"{config.MaxSelection}\" ");

            sb.Append($"data-select-all=\"{config.SelectAll.ToString().ToLower()}\" ");
            sb.Append($"data-search=\"{config.Search.ToString().ToLower()}\" ");
            sb.Append($"data-width=\"{config.Width}\" ");
            sb.Append($"data-theme=\"{config.Theme}\" ");
            sb.Append($"data-close-on-select=\"{config.CloseOnSelect.ToString().ToLower()}\" ");

            if (!string.IsNullOrEmpty(config.ButtonClass))
                sb.Append($"data-button-class=\"{config.ButtonClass}\" ");

            if (!string.IsNullOrEmpty(config.DropdownClass))
                sb.Append($"data-dropdown-class=\"{config.DropdownClass}\" ");

            sb.Append($"data-search-placeholder=\"{config.SearchPlaceholder}\" ");
            sb.Append($"data-select-all-text=\"{config.SelectAllText}\" ");
            sb.Append($"data-deselect-all-text=\"{config.DeselectAllText}\" ");
            sb.Append($"data-no-results-text=\"{config.NoResultsText}\" ");
            sb.Append($"data-max-height=\"{config.MaxHeight}\" ");
            sb.Append($"data-items-selected-text=\"{config.ItemsSelectedText}\" ");

            if (!string.IsNullOrEmpty(config.Lang))
                sb.Append($"data-lang=\"{config.Lang}\" ");

            sb.AppendLine(">");

            // Group items by Group property
            var groups = items.GroupBy(i => i.Group?.Name ?? string.Empty);

            foreach (var group in groups)
            {
                if (!string.IsNullOrEmpty(group.Key))
                {
                    // OptGroup
                    sb.AppendLine($"    <optgroup label=\"{group.Key}\">");
                    foreach (var item in group)
                    {
                        sb.AppendLine($"        {BuildOption(item, new List<string>())}");
                    }
                    sb.AppendLine("    </optgroup>");
                }
                else
                {
                    // Regular options
                    foreach (var item in group)
                    {
                        sb.AppendLine($"    {BuildOption(item, new List<string>())}");
                    }
                }
            }

            sb.AppendLine("</select>");

            return new HtmlString(sb.ToString());
        }

        private static string BuildOption(SelectListItem item, IEnumerable<string> selectedValues)
        {
            var selected = item.Selected || selectedValues.Contains(item.Value) ? " selected" : "";
            var disabled = item.Disabled ? " disabled" : "";
            return $"<option value=\"{item.Value}\"{selected}{disabled}>{item.Text}</option>";
        }

        /// <summary>
        /// Appends validation attributes to the string builder based on model metadata
        /// </summary>
        private static void AppendValidationAttributes(StringBuilder sb, ModelMetadata metadata)
        {
            if (metadata.ValidatorMetadata.Count == 0)
                return;

            bool hasValidation = false;

            foreach (var validator in metadata.ValidatorMetadata)
            {
                if (validator is System.ComponentModel.DataAnnotations.RequiredAttribute requiredAttr)
                {
                    hasValidation = true;
                    var errorMessage = requiredAttr.ErrorMessage ??
                        $"The {metadata.DisplayName ?? metadata.PropertyName} field is required.";
                    sb.Append($"data-val-required=\"{System.Net.WebUtility.HtmlEncode(errorMessage)}\" ");
                }
                else if (validator is System.ComponentModel.DataAnnotations.MinLengthAttribute minLengthAttr)
                {
                    hasValidation = true;
                    var errorMessage = minLengthAttr.ErrorMessage ??
                        $"The field {metadata.DisplayName ?? metadata.PropertyName} must have a minimum length of '{minLengthAttr.Length}'.";
                    sb.Append($"data-val-minlength=\"{System.Net.WebUtility.HtmlEncode(errorMessage)}\" ");
                    sb.Append($"data-val-minlength-min=\"{minLengthAttr.Length}\" ");
                }
                else if (validator is System.ComponentModel.DataAnnotations.MaxLengthAttribute maxLengthAttr)
                {
                    hasValidation = true;
                    var errorMessage = maxLengthAttr.ErrorMessage ??
                        $"The field {metadata.DisplayName ?? metadata.PropertyName} must have a maximum length of '{maxLengthAttr.Length}'.";
                    sb.Append($"data-val-maxlength=\"{System.Net.WebUtility.HtmlEncode(errorMessage)}\" ");
                    sb.Append($"data-val-maxlength-max=\"{maxLengthAttr.Length}\" ");
                }
                else if (validator is System.ComponentModel.DataAnnotations.RangeAttribute rangeAttr)
                {
                    hasValidation = true;
                    var errorMessage = rangeAttr.ErrorMessage ??
                        $"The field {metadata.DisplayName ?? metadata.PropertyName} must be between {rangeAttr.Minimum} and {rangeAttr.Maximum}.";
                    sb.Append($"data-val-range=\"{System.Net.WebUtility.HtmlEncode(errorMessage)}\" ");
                    sb.Append($"data-val-range-min=\"{rangeAttr.Minimum}\" ");
                    sb.Append($"data-val-range-max=\"{rangeAttr.Maximum}\" ");
                }
                else if (validator is System.ComponentModel.DataAnnotations.RegularExpressionAttribute regexAttr)
                {
                    hasValidation = true;
                    var errorMessage = regexAttr.ErrorMessage ??
                        $"The field {metadata.DisplayName ?? metadata.PropertyName} must match the regular expression '{regexAttr.Pattern}'.";
                    sb.Append($"data-val-regex=\"{System.Net.WebUtility.HtmlEncode(errorMessage)}\" ");
                    sb.Append($"data-val-regex-pattern=\"{System.Net.WebUtility.HtmlEncode(regexAttr.Pattern)}\" ");
                }
                else if (validator is System.ComponentModel.DataAnnotations.CompareAttribute compareAttr)
                {
                    hasValidation = true;
                    var errorMessage = compareAttr.ErrorMessage ??
                        $"'{metadata.DisplayName ?? metadata.PropertyName}' and '{compareAttr.OtherProperty}' do not match.";
                    sb.Append($"data-val-equalto=\"{System.Net.WebUtility.HtmlEncode(errorMessage)}\" ");
                    sb.Append($"data-val-equalto-other=\"*.{compareAttr.OtherProperty}\" ");
                }
                else if (validator is System.ComponentModel.DataAnnotations.ValidationAttribute validationAttr)
                {
                    // Generic handler for any other ValidationAttribute (including custom ones)
                    hasValidation = true;
                    var validationType = validator.GetType().Name.Replace("Attribute", "").ToLower();
                    var displayName = metadata.DisplayName ?? metadata.PropertyName ?? string.Empty;
                    var errorMessage = validationAttr.ErrorMessage ??
                        validationAttr.FormatErrorMessage(displayName);
                    sb.Append($"data-val-{validationType}=\"{System.Net.WebUtility.HtmlEncode(errorMessage)}\" ");
                }
            }

            // Only add data-val="true" if we have at least one validation attribute
            if (hasValidation)
            {
                sb.Append("data-val=\"true\" ");
            }
        }
    }
}
