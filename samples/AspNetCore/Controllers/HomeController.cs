using System.Diagnostics;
using BootstrapMultiSelectExamples.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapMultiSelectExamples.Controllers;

/// <summary>
/// Main controller for the application home pages
/// </summary>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class
    /// </summary>
    /// <param name="logger">The logger instance for logging application events</param>
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Displays the application home page
    /// </summary>
    /// <returns>The index view</returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Displays the privacy policy page
    /// </summary>
    /// <returns>The privacy view</returns>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// Displays the error page
    /// </summary>
    /// <returns>The error view with request tracking information</returns>
    /// <remarks>
    /// This action is not cached to ensure fresh error information is always displayed
    /// </remarks>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
