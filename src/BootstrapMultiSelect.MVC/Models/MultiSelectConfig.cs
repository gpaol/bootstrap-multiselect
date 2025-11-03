namespace BootstrapMultiSelect.MVC.Models
{
    /// <summary>
    /// Configuration options for the Bootstrap MultiSelect plugin
    /// </summary>
    public class MultiSelectConfig
    {
        /// <summary>
        /// Gets or sets the placeholder text
        /// </summary>
        public string Placeholder { get; set; } = "Select items...";

        /// <summary>
        /// Gets or sets the maximum number of items that can be selected (0 = unlimited)
        /// </summary>
        public int MaxSelection { get; set; } = 0;

        /// <summary>
        /// Gets or sets whether to show the Select All/Deselect All buttons
        /// </summary>
        public bool SelectAll { get; set; } = true;

        /// <summary>
        /// Gets or sets whether to enable the search functionality
        /// </summary>
        public bool Search { get; set; } = true;

        /// <summary>
        /// Gets or sets the width of the dropdown
        /// </summary>
        public string Width { get; set; } = "100%";

        /// <summary>
        /// Gets or sets the Bootstrap theme (primary, success, danger, warning, info, secondary, dark)
        /// </summary>
        public string Theme { get; set; } = "primary";

        /// <summary>
        /// Gets or sets whether to close the dropdown when an item is selected
        /// </summary>
        public bool CloseOnSelect { get; set; } = false;

        /// <summary>
        /// Gets or sets the custom button CSS class
        /// </summary>
        public string? ButtonClass { get; set; }

        /// <summary>
        /// Gets or sets the custom dropdown CSS class
        /// </summary>
        public string? DropdownClass { get; set; }

        /// <summary>
        /// Gets or sets the search input placeholder
        /// </summary>
        public string SearchPlaceholder { get; set; } = "Search...";

        /// <summary>
        /// Gets or sets the text for the Select All button
        /// </summary>
        public string SelectAllText { get; set; } = "Select All";

        /// <summary>
        /// Gets or sets the text for the Deselect All button
        /// </summary>
        public string DeselectAllText { get; set; } = "Deselect All";

        /// <summary>
        /// Gets or sets the text shown when no results are found
        /// </summary>
        public string NoResultsText { get; set; } = "No results found";

        /// <summary>
        /// Gets or sets the maximum height of the dropdown
        /// </summary>
        public string MaxHeight { get; set; } = "300px";

        /// <summary>
        /// Gets or sets the text shown when multiple items (4+) are selected (e.g., "items selected", "elementi selezionati")
        /// </summary>
        public string ItemsSelectedText { get; set; } = "items selected";

        /// <summary>
        /// Gets or sets the language code for localization (e.g., "it", "es", "fr", "de", "pt")
        /// </summary>
        /// <remarks>
        /// When set, the plugin will use the corresponding language file for all text strings.
        /// Available languages: en (default), it, es, fr, de, pt
        /// Requires the language file to be loaded: ~/js/langs/jquery-bootstrap-multiselect.{lang}.js
        /// </remarks>
        public string? Lang { get; set; }
    }
}
