using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        private readonly JsonFileProductService ProductService;

        [BindProperty]
        // get or set Product
        public ProductModel Product { get; set; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// REST Get request
        /// </summary>
        public IActionResult OnGet(string v)
        {
            if (Product == null)
            {
                Product = new ProductModel(); // Initialize only if it's null
            }

            return Page();
        }

        /// <summary>
        /// REST Post request
        /// </summary>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Stay on the Create page if there are validation errors
            }

            ProductService.CreateProduct(Product);
            return RedirectToPage("Index"); // Redirect to the product list page after creating the product
        }
    }
}