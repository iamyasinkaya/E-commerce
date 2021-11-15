using ECOM_PROJECT.Catalog.WebAPI.Data.Abstract;
using ECOM_PROJECT.Catalog.WebAPI.Models;
using ECOM_PROJECT.Shared.Data.Abstract.MongoDB;
using ECOM_PROJECT.Shared.Data.Concrete.MongoDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Catalog.WebAPI.Data.Concrete
{
    public class CategoryRepository : MongoEntityRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IOptions<DatabaseSettings> options) : base(options)
        {

        }
    }
}
