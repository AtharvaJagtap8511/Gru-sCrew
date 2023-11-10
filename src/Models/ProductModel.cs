using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model class for Product
    /// </summary>
    public class ProductModel
    {
        // get or set the Product ID
        public string Id { get; set; }

        // get or set the Maker of the product
        public string Maker { get; set; }

        // get or set the image URL to JSON
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // get or set the Age of the Profile
        public int Age { get; set; }

        // get or set the image URL to JSON
        public string Url { get; set; }

        // get or set the Title of the Profile
        public string Title { get; set; }

        // get or set the Skills of the Profile
        public string Skills { get; set; }

        // get or set the Preference of the Profile
        public string Preference { get; set; }


        // get or set the Description of the Profile
        public string Description { get; set; }

        // get or set the Email of the Profile
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        // get or set the Ratings of the Product
        public int[] Ratings { get; set; }
        public string ErrorMessage { get; set; }

        // JsonSerializer to serialize ProductModel
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}
