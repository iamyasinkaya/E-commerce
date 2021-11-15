using ECOM_PROJECT.Campaign.WebAPI.Models;
using ECOM_PROJECT.Shared.Data.Abstract.PostgreSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Campaign.WebAPI.Data.Abstract
{
    public interface IDiscountRepository : IPostgreEntityRepository<Discount,int>
    {
    }
}
