using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models.Basket
{
    public class BasketItemViewModel
    {
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; } = 1;
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        private decimal? DiscountAppliedPrice;
        
        public decimal GetCurrentPrice
        {
            get => DiscountAppliedPrice != null ? DiscountAppliedPrice.Value : Price;
        }

        public void AppliedDiscount(decimal discountPrice)
        {
            DiscountAppliedPrice = discountPrice;
        }
    }
}
