using ECOM_PROJECT.Catalog.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Catalog.WebAPI.Dtos
{
    public class ProductListDto
    {
        public List<Product> Products { get; set; }
    }
}
