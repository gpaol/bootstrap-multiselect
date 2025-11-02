namespace BootstrapMultiSelect.MVC.Models
{
    /// <summary>
    /// Represents a single option in the multi-select dropdown
    /// </summary>
    public class MultiSelectOption
    {
        /// <summary>
        /// Gets or sets the option value
        /// </summary>
        public required string Value { get; set; }

        /// <summary>
        /// Gets or sets the option display text
        /// </summary>
        public required string Text { get; set; }

        /// <summary>
        /// Gets or sets whether the option is selected by default
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets whether the option is disabled
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets the option group (if any)
        /// </summary>
        public string? Group { get; set; }
    }
}
