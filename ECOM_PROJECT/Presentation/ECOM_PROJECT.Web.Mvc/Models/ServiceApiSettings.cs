using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }
        public string ImageBaseUrl { get; set; }

        public ServiceApi Catalog { get; set; }

        public ServiceApi Image { get; set; }

        public ServiceApi Basket { get; set; }

        public ServiceApi Campaign { get; set; }

        public ServiceApi Payment { get; set; }
        public ServiceApi Order { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}

