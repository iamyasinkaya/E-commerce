using ECOM_PROJECT.Campaign.WebAPI.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Campaign.WebAPI.Services
{
    public interface IUnitOfWork
    {
        IDiscountRepository Discounts { get; set; }
    }
}
