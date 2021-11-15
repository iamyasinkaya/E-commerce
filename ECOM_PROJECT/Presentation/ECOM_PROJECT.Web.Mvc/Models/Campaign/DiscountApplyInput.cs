using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models.Campaign
{
    public class DiscountApplyInput
    {
        [JsonPropertyName("discountCode")]
        public string Code { get; set; }
    }
}
