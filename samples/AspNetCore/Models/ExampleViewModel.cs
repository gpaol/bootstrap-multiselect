using System.ComponentModel.DataAnnotations;

namespace BootstrapMultiSelectExamples.Models
{
    /// <summary>
    /// View model for Bootstrap MultiSelect examples
    /// </summary>
    public class ExampleViewModel
    {
        /// <summary>
        /// Gets or sets the selected countries (basic example)
        /// </summary>
        [Display(Name = "Select Countries")]
        [Required(ErrorMessage = "Please select at least one country")]
        [MinLength(1, ErrorMessage = "Please select at least one country")]
        public List<string> SelectedCountries { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the selected skills (with max selection)
        /// </summary>
        [Display(Name = "Select Your Skills (Max 3)")]
        [Required(ErrorMessage = "Please select at least one skill")]
        [MaxLength(3, ErrorMessage = "You can select up to 3 skills")]
        public List<string> SelectedSkills { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the selected technologies (with optgroups)
        /// </summary>
        [Display(Name = "Select Technologies")]
        public List<string>? SelectedTechnologies { get; set; }

        /// <summary>
        /// Gets or sets the selected departments (with pre-selected values)
        /// </summary>
        [Display(Name = "Select Departments")]
        [Required(ErrorMessage = "Please select at least one department")]
        public List<string> SelectedDepartments { get; set; } = new List<string> { "IT", "HR" };

        /// <summary>
        /// Gets or sets the selected languages (with disabled options)
        /// </summary>
        [Display(Name = "Select Languages")]
        public List<string>? SelectedLanguages { get; set; }

        /// <summary>
        /// Gets or sets the selected cities (with pagination)
        /// </summary>
        [Display(Name = "Select Cities")]
        public List<string>? SelectedCities { get; set; }

        /// <summary>
        /// Gets or sets the user's name
        /// </summary>
        [Display(Name = "Your Name")]
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's email
        /// </summary>
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets additional comments
        /// </summary>
        [Display(Name = "Comments")]
        [StringLength(500, ErrorMessage = "Comments cannot exceed 500 characters")]
        public string? Comments { get; set; }
    }
}
