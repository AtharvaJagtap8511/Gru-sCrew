using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model class for a Product.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Gets or sets the Product ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Maker of the product.
        /// </summary>
        public string Maker { get; set; }

        /// <summary>
        /// Gets or sets the image URL to JSON.
        /// </summary>
        [JsonPropertyName("img")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the Age of the Product.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the URL of the Product.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Title of the Product.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Skills of the Product.
        /// </summary>
        public string Skills { get; set; }

        /// <summary>
        /// Gets or sets the Description of the Product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Email of the Product.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Ratings of the Product.
        /// </summary>
        public int[] Ratings { get; set; }

        /// <summary>
        /// Gets or sets an error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Uses JsonSerializer to serialize the ProductModel to a JSON string.
        /// </summary>
        /// <returns>A JSON representation of the object.</returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}
