using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Class to handle operations related to Privacy page
    /// </summary>
    public class PrivacyModel : PageModel
    {
        // Using ILogger to log error messages
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Logger
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
        }
    }
}
