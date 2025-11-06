using BootstrapMultiSelectExamples.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BootstrapMultiSelectExamples.Controllers
{
    /// <summary>
    /// Controller for Bootstrap MultiSelect library examples
    /// </summary>
    public class ExamplesController : Controller
    {
        private readonly ILogger<ExamplesController> _logger;

        public ExamplesController(ILogger<ExamplesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Displays the jQuery plugin examples page
        /// </summary>
        /// <returns>The plugin examples view</returns>
        public IActionResult Plugin()
        {
            return View();
        }

        /// <summary>
        /// Displays the MVC library examples page with various MultiSelect scenarios
        /// </summary>
        /// <returns>The MVC examples view</returns>
        public IActionResult MVC()
        {
            var model = new ExampleViewModel();
            LoadSelectLists();
            return View(model);
        }

        /// <summary>
        /// Handles form submission with validation
        /// </summary>
        /// <param name="model">The submitted form data</param>
        /// <returns>Result view or validation errors</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MVC(ExampleViewModel model)
        {
            // Custom validation: check if skills count is within limit
            if (model.SelectedSkills != null && model.SelectedSkills.Count > 3)
            {
                ModelState.AddModelError(nameof(model.SelectedSkills),
                    "You can select a maximum of 3 skills");
            }

            if (ModelState.IsValid)
            {
                // Log the submitted data
                _logger.LogInformation("Form submitted successfully");
                _logger.LogInformation("Name: {Name}", model.Name);
                _logger.LogInformation("Email: {Email}", model.Email);
                _logger.LogInformation("Countries: {Countries}",
                    string.Join(", ", model.SelectedCountries ?? new List<string>()));
                _logger.LogInformation("Skills: {Skills}",
                    string.Join(", ", model.SelectedSkills ?? new List<string>()));
                _logger.LogInformation("Technologies: {Technologies}",
                    string.Join(", ", model.SelectedTechnologies ?? new List<string>()));
                _logger.LogInformation("Departments: {Departments}",
                    string.Join(", ", model.SelectedDepartments ?? new List<string>()));
                _logger.LogInformation("Languages: {Languages}",
                    string.Join(", ", model.SelectedLanguages ?? new List<string>()));

                // Store success message in TempData
                TempData["SuccessMessage"] = "Form submitted successfully!";
                TempData["SubmittedData"] = System.Text.Json.JsonSerializer.Serialize(model);

                return RedirectToAction(nameof(Success));
            }

            // If validation failed, reload the select lists and return the view
            LoadSelectLists();
            return View(model);
        }

        /// <summary>
        /// Displays the success page after form submission
        /// </summary>
        /// <returns>Success view</returns>
        public IActionResult Success()
        {
            if (TempData["SubmittedData"] is string jsonData)
            {
                var model = System.Text.Json.JsonSerializer.Deserialize<ExampleViewModel>(jsonData);
                LoadSelectLists();
                return View(model);
            }

            return RedirectToAction(nameof(MVC));
        }

        /// <summary>
        /// AJAX endpoint to get filtered items based on search
        /// </summary>
        /// <param name="searchTerm">The search term</param>
        /// <returns>JSON array of matching items</returns>
        [HttpGet]
        public IActionResult GetFilteredCountries(string searchTerm)
        {
            var countries = GetCountries()
                .Where(c => string.IsNullOrEmpty(searchTerm) ||
                           c.Text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .Select(c => new { value = c.Value, text = c.Text });

            return Json(countries);
        }

        /// <summary>
        /// AJAX endpoint to validate skills selection
        /// </summary>
        /// <param name="skills">Selected skills</param>
        /// <returns>JSON validation result</returns>
        [HttpPost]
        public IActionResult ValidateSkills([FromBody] List<string> skills)
        {
            if (skills == null || skills.Count == 0)
            {
                return Json(new { valid = false, message = "Please select at least one skill" });
            }

            if (skills.Count > 3)
            {
                return Json(new { valid = false, message = "You can select a maximum of 3 skills" });
            }

            return Json(new { valid = true, message = "Selection is valid" });
        }

        /// <summary>
        /// Loads all select lists into ViewBag
        /// </summary>
        private void LoadSelectLists()
        {
            ViewBag.Countries = GetCountries();
            ViewBag.Skills = GetSkills();
            ViewBag.Technologies = GetTechnologies();
            ViewBag.Departments = GetDepartments();
            ViewBag.Languages = GetLanguages();
            ViewBag.Cities = GetCities();
        }

        /// <summary>
        /// Gets the list of countries
        /// </summary>
        /// <returns>List of SelectListItem</returns>
        private List<SelectListItem> GetCountries()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "US", Text = "United States" },
                new SelectListItem { Value = "UK", Text = "United Kingdom" },
                new SelectListItem { Value = "CA", Text = "Canada" },
                new SelectListItem { Value = "AU", Text = "Australia" },
                new SelectListItem { Value = "DE", Text = "Germany" },
                new SelectListItem { Value = "FR", Text = "France" },
                new SelectListItem { Value = "IT", Text = "Italy" },
                new SelectListItem { Value = "ES", Text = "Spain" },
                new SelectListItem { Value = "JP", Text = "Japan" },
                new SelectListItem { Value = "CN", Text = "China" },
                new SelectListItem { Value = "IN", Text = "India" },
                new SelectListItem { Value = "BR", Text = "Brazil" },
                new SelectListItem { Value = "MX", Text = "Mexico" },
                new SelectListItem { Value = "RU", Text = "Russia" },
                new SelectListItem { Value = "KR", Text = "South Korea" }
            };
        }

        /// <summary>
        /// Gets the list of skills
        /// </summary>
        /// <returns>List of SelectListItem</returns>
        private List<SelectListItem> GetSkills()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "csharp", Text = "C# Programming" },
                new SelectListItem { Value = "javascript", Text = "JavaScript" },
                new SelectListItem { Value = "python", Text = "Python" },
                new SelectListItem { Value = "java", Text = "Java" },
                new SelectListItem { Value = "sql", Text = "SQL/Database" },
                new SelectListItem { Value = "html-css", Text = "HTML/CSS" },
                new SelectListItem { Value = "react", Text = "React" },
                new SelectListItem { Value = "angular", Text = "Angular" },
                new SelectListItem { Value = "vue", Text = "Vue.js" },
                new SelectListItem { Value = "docker", Text = "Docker" },
                new SelectListItem { Value = "kubernetes", Text = "Kubernetes" },
                new SelectListItem { Value = "aws", Text = "AWS" },
                new SelectListItem { Value = "azure", Text = "Azure" },
                new SelectListItem { Value = "git", Text = "Git/Version Control" }
            };
        }

        /// <summary>
        /// Gets the list of technologies organized by category (optgroups)
        /// </summary>
        /// <returns>List of SelectListItem with groups</returns>
        private List<SelectListItem> GetTechnologies()
        {
            return new List<SelectListItem>
            {
                // Frontend
                new SelectListItem { Value = "react", Text = "React", Group = new SelectListGroup { Name = "Frontend" } },
                new SelectListItem { Value = "angular", Text = "Angular", Group = new SelectListGroup { Name = "Frontend" } },
                new SelectListItem { Value = "vue", Text = "Vue.js", Group = new SelectListGroup { Name = "Frontend" } },
                new SelectListItem { Value = "svelte", Text = "Svelte", Group = new SelectListGroup { Name = "Frontend" } },

                // Backend
                new SelectListItem { Value = "aspnet", Text = "ASP.NET Core", Group = new SelectListGroup { Name = "Backend" } },
                new SelectListItem { Value = "nodejs", Text = "Node.js", Group = new SelectListGroup { Name = "Backend" } },
                new SelectListItem { Value = "django", Text = "Django", Group = new SelectListGroup { Name = "Backend" } },
                new SelectListItem { Value = "spring", Text = "Spring Boot", Group = new SelectListGroup { Name = "Backend" } },

                // Database
                new SelectListItem { Value = "sqlserver", Text = "SQL Server", Group = new SelectListGroup { Name = "Database" } },
                new SelectListItem { Value = "postgresql", Text = "PostgreSQL", Group = new SelectListGroup { Name = "Database" } },
                new SelectListItem { Value = "mongodb", Text = "MongoDB", Group = new SelectListGroup { Name = "Database" } },
                new SelectListItem { Value = "redis", Text = "Redis", Group = new SelectListGroup { Name = "Database" } },

                // DevOps
                new SelectListItem { Value = "docker", Text = "Docker", Group = new SelectListGroup { Name = "DevOps" } },
                new SelectListItem { Value = "kubernetes", Text = "Kubernetes", Group = new SelectListGroup { Name = "DevOps" } },
                new SelectListItem { Value = "jenkins", Text = "Jenkins", Group = new SelectListGroup { Name = "DevOps" } },
                new SelectListItem { Value = "github-actions", Text = "GitHub Actions", Group = new SelectListGroup { Name = "DevOps" } }
            };
        }

        /// <summary>
        /// Gets the list of departments
        /// </summary>
        /// <returns>List of SelectListItem</returns>
        private List<SelectListItem> GetDepartments()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "IT", Text = "Information Technology" },
                new SelectListItem { Value = "HR", Text = "Human Resources" },
                new SelectListItem { Value = "FIN", Text = "Finance" },
                new SelectListItem { Value = "MKT", Text = "Marketing" },
                new SelectListItem { Value = "SALES", Text = "Sales" },
                new SelectListItem { Value = "OPS", Text = "Operations" },
                new SelectListItem { Value = "RND", Text = "Research & Development" },
                new SelectListItem { Value = "LEGAL", Text = "Legal" },
                new SelectListItem { Value = "ADMIN", Text = "Administration" }
            };
        }

        /// <summary>
        /// Gets the list of languages with some disabled options
        /// </summary>
        /// <returns>List of SelectListItem</returns>
        private List<SelectListItem> GetLanguages()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "en", Text = "English" },
                new SelectListItem { Value = "es", Text = "Spanish" },
                new SelectListItem { Value = "fr", Text = "French" },
                new SelectListItem { Value = "de", Text = "German" },
                new SelectListItem { Value = "it", Text = "Italian" },
                new SelectListItem { Value = "pt", Text = "Portuguese" },
                new SelectListItem { Value = "ru", Text = "Russian", Disabled = true },
                new SelectListItem { Value = "zh", Text = "Chinese" },
                new SelectListItem { Value = "ja", Text = "Japanese", Disabled = true },
                new SelectListItem { Value = "ko", Text = "Korean" },
                new SelectListItem { Value = "ar", Text = "Arabic" },
                new SelectListItem { Value = "hi", Text = "Hindi", Disabled = true }
            };
        }

        /// <summary>
        /// Gets the list of major world cities (for pagination example)
        /// </summary>
        /// <returns>List of SelectListItem</returns>
        private List<SelectListItem> GetCities()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "tokyo", Text = "Tokyo" },
                new SelectListItem { Value = "delhi", Text = "Delhi" },
                new SelectListItem { Value = "shanghai", Text = "Shanghai" },
                new SelectListItem { Value = "saopaulo", Text = "São Paulo" },
                new SelectListItem { Value = "mumbai", Text = "Mumbai" },
                new SelectListItem { Value = "beijing", Text = "Beijing" },
                new SelectListItem { Value = "cairo", Text = "Cairo" },
                new SelectListItem { Value = "dhaka", Text = "Dhaka" },
                new SelectListItem { Value = "mexicocity", Text = "Mexico City" },
                new SelectListItem { Value = "osaka", Text = "Osaka" },
                new SelectListItem { Value = "karachi", Text = "Karachi" },
                new SelectListItem { Value = "chongqing", Text = "Chongqing" },
                new SelectListItem { Value = "istanbul", Text = "Istanbul" },
                new SelectListItem { Value = "buenosaires", Text = "Buenos Aires" },
                new SelectListItem { Value = "kolkata", Text = "Kolkata" },
                new SelectListItem { Value = "lagos", Text = "Lagos" },
                new SelectListItem { Value = "kinshasa", Text = "Kinshasa" },
                new SelectListItem { Value = "manila", Text = "Manila" },
                new SelectListItem { Value = "rio", Text = "Rio de Janeiro" },
                new SelectListItem { Value = "guangzhou", Text = "Guangzhou" },
                new SelectListItem { Value = "lahore", Text = "Lahore" },
                new SelectListItem { Value = "bangalore", Text = "Bangalore" },
                new SelectListItem { Value = "moscow", Text = "Moscow" },
                new SelectListItem { Value = "chennai", Text = "Chennai" },
                new SelectListItem { Value = "paris", Text = "Paris" },
                new SelectListItem { Value = "bogota", Text = "Bogotá" },
                new SelectListItem { Value = "jakarta", Text = "Jakarta" },
                new SelectListItem { Value = "lima", Text = "Lima" },
                new SelectListItem { Value = "bangkok", Text = "Bangkok" },
                new SelectListItem { Value = "seoul", Text = "Seoul" },
                new SelectListItem { Value = "nagoya", Text = "Nagoya" },
                new SelectListItem { Value = "hyderabad", Text = "Hyderabad" },
                new SelectListItem { Value = "london", Text = "London" },
                new SelectListItem { Value = "tehran", Text = "Tehran" },
                new SelectListItem { Value = "chicago", Text = "Chicago" },
                new SelectListItem { Value = "chengdu", Text = "Chengdu" },
                new SelectListItem { Value = "nanjing", Text = "Nanjing" },
                new SelectListItem { Value = "wuhan", Text = "Wuhan" },
                new SelectListItem { Value = "hochiminh", Text = "Ho Chi Minh City" },
                new SelectListItem { Value = "luanda", Text = "Luanda" },
                new SelectListItem { Value = "ahmedabad", Text = "Ahmedabad" },
                new SelectListItem { Value = "kualalumpur", Text = "Kuala Lumpur" },
                new SelectListItem { Value = "xian", Text = "Xi'an" },
                new SelectListItem { Value = "hongkong", Text = "Hong Kong" },
                new SelectListItem { Value = "dongguan", Text = "Dongguan" },
                new SelectListItem { Value = "hangzhou", Text = "Hangzhou" },
                new SelectListItem { Value = "foshan", Text = "Foshan" },
                new SelectListItem { Value = "shenyang", Text = "Shenyang" },
                new SelectListItem { Value = "riyadh", Text = "Riyadh" },
                new SelectListItem { Value = "baghdad", Text = "Baghdad" }
            };
        }
    }
}
