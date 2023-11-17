using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Manage the Update of the data for a single record
    /// </summary>
    public class UpdateModel : PageModel
    {
        /// <summary>
        /// Data Middle tier (services)
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            // Load the product data based on the provided ID
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            if (Product == null)
            {
                // If the product is not found, redirect to the Index page
                return RedirectToPage("./Index");
            }
            return Page();
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, stay on the current page to show validation errors
                return Page();
            }

            // Call the data service to update the product data
            ProductService.UpdateData(Product);

            // After updating, redirect to the Index page
            return RedirectToPage("./Index");
        }
    }
}