using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly JsonFileProductService ProductService;

        [BindProperty]
        public ProductModel Product { get; set; }

        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public IActionResult OnGet()
        {
            if (Product == null)
            {
                Product = new ProductModel(); // Initialize only if it's null
            }

            return Page();
        }

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
