using ECOM_PROJECT.Shared.Entities.Abstract.PostgreSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Campaign.WebAPI.Models
{
    [Dapper.Contrib.Extensions.Table("discount")]
    public class Discount : PostgreBaseEntity
    {
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
    }
}
