using ECOM_PROJECT.Shared.Entities.Abstract.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Catalog.WebAPI.Models
{
    public class Category : MongoDbEntity
    {
        public string Name { get; set; }
    }
}
