using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models.Catalog.Feature
{
    public class FeatureViewModel
    {
        [JsonPropertyName("dateOfProduction")]
        public DateTime DateOfProduction { get; set; }
        [JsonPropertyName("productionSite")]
        public string ProductionSite { get; set; }
    }
}
