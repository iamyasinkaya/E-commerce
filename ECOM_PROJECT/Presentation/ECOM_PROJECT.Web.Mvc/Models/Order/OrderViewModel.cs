using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models.Order
{
    
    public class OrderViewModel
    {
        [JsonPropertyName("id")]

        public int Id { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        //Ödeme geçmişimde adress alanına ihtiyaç olmadığından dolayı alınmadı
        [JsonPropertyName("address")]
        public AddressDto Address { get; set; }

        [JsonPropertyName("buyerId")]
        public string BuyerId { get; set; }
        [JsonPropertyName("orderItems")]
        public List<OrderItemViewModel> OrderItems { get; set; }
    }
    
    public class OrderDto
    {
        [JsonPropertyName("orders")]
        public List<OrderViewModel>  OrderViewModel { get; set; }
    }
}
