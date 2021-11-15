using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models.Order
{
    public class OrderItemViewModel
    {
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [JsonPropertyName("pictureUrl")]
        public string PictureUrl { get; set; }
        [JsonPropertyName("price")]
        public Decimal Price { get; set; }
    }
}
