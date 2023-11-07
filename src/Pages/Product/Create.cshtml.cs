using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Create Page
    /// </summary>
    public class CreateModel : PageModel
    {
        /// <summary>
        /// Data Middle tier (services)
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// The data to show
        /// </summary>
        public ProductModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet()
        {
            Product = ProductService.CreateData();

            // Redirect the webpage to the Update page populated with the data so the user can fill in the fields
            return RedirectToPage("./Update", new { Id = Product.Id });
        }
    }
}
