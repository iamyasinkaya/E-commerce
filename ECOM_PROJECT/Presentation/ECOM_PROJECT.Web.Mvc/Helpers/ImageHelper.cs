using ECOM_PROJECT.Web.Mvc.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Helpers
{
    public class ImageHelper
    {
        private readonly ServiceApiSettings _serviceApiSettings;

        public ImageHelper(IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public string GetPhotoStockUrl(string imageUrl)
        {
            return $"{_serviceApiSettings.ImageBaseUrl}/image/{imageUrl}";
        }
    }
}
