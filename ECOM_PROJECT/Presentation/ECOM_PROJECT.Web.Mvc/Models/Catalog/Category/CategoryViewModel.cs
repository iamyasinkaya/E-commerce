using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models.Catalog.Category
{
    public class CategoryViewModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
    }

    public class CategoryList
    {
        [JsonPropertyName("categories")]
        public List<CategoryViewModel> Category { get; set; }
    }
  
    
}
