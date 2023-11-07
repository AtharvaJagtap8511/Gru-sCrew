using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Sheetal Kandhare
    /// Chandrashekhar Pawar
    /// Atharva Jagtap
    /// Aishwarya Patil
    /// Testing merge conflict

    /// <summary>
    /// Index page is loaded on the start of the application
    /// </summary>
    public class IndexModel : PageModel
    {
        // Using ILogger to log error messages 
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Logger
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        // Data middle tier
        public JsonFileProductService ProductService { get; }

        // Get or set for Products
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
