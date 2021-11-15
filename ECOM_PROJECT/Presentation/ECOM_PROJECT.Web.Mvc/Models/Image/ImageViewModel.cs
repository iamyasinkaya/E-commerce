using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models.Image
{
    public class ImageViewModel
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

    }

   
}
