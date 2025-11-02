namespace BootstrapMultiSelectExamples.Models;

/// <summary>
/// View model for error pages
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// Gets or sets the request identifier for tracking errors
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Gets a value indicating whether to show the request ID
    /// </summary>
    /// <value>
    /// <c>true</c> if the request ID should be displayed; otherwise, <c>false</c>.
    /// </value>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
