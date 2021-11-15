using ECOM_PROJECT.Web.Mvc.Models.Catalog.Feature;
using ECOM_PROJECT.Web.Mvc.Models.Image;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Models.Catalog.Product
{
    public class ProductCreateInput
    {
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        public string Description { get; set; }

        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }

        public string SKU { get; set; }
        public string Image { get; set; }

        public string UserId { get; set; }

        public FeatureViewModel Feature { get; set; }

        [Display(Name = "Kategori")]
        public string CategoryId { get; set; }

        [Display(Name = "Kurs Resim")]
        public IFormFile ImageFile
        {
            get; set;
        }
    }
}
