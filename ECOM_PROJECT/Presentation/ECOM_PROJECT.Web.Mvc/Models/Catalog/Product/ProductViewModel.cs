using ECOM_PROJECT.Web.Mvc.Models.Catalog.Category;
using ECOM_PROJECT.Web.Mvc.Models.Catalog.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models.Catalog.Product
{
    public class ProductViewModel
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonIgnore]
        public string ShortDescription
        {
            get => Description.Length > 100 ? Description.Substring(0, 100) + "..." : Description;
        }

        [JsonPropertyName("sku")]
        public string SKU { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonIgnore]
        public string StockPictureUrl { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedTime { get; set; }
        [JsonPropertyName("feature")]
        public FeatureViewModel Feature { get; set; }
        [JsonPropertyName("categoryId")]
        public string CategoryId { get; set; }
        [JsonPropertyName("category")]
        public CategoryViewModel Category { get; set; }


    }

    public class ProductDto
    {
        [JsonPropertyName("product")]
        public ProductViewModel ProductViewModel { get; set; }
    }
    public class ProductList
    {
        [JsonPropertyName("products")]
        public List<ProductViewModel> ProductViewModels { get; set; }
    }


}
