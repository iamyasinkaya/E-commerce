using System.Text.Json.Serialization;

namespace ECOM_PROJECT.Web.Mvc.Models.Order
{
    public class AddressDto
    {
        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("district")]
        public string District { get; set; }
        [JsonPropertyName("street")]

        public string Street { get; set; }

        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }
        [JsonPropertyName("line")]

        public string Line { get; set; }
    }
}