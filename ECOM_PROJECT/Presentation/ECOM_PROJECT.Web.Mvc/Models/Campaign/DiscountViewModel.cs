using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models.Campaign
{
    public class DiscountViewModel
    {
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        [JsonPropertyName("rate")]
        public int Rate { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class DiscountDto
    {
        [JsonPropertyName("discount")]
        public DiscountViewModel DiscountViewModel { get; set; }
    }
}
