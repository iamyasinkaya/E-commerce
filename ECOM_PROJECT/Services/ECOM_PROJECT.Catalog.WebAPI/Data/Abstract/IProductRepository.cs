using ECOM_PROJECT.Catalog.WebAPI.Models;
using ECOM_PROJECT.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Catalog.WebAPI.Data.Abstract
{
    public interface IProductRepository : IMongoEntityRepository<Product,string>
    {
    }
}
