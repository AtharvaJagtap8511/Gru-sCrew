using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Using ResponseCache attribute to set response caching headers.
    /// Class is used to handle operations related to Errors
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        // Get or Set RequestId
        public string RequestId { get; set; }

        // Checking if the RequestId is not NULL or Empty
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Using Ilogger to log error messages
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// logger for error model
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}