using ECOM_PROJECT.Web.Mvc.Models.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Services.Abstract
{
    public interface IDiscountService
    {
        Task<DiscountDto> GetDiscount(string discountCode);
    }
}
