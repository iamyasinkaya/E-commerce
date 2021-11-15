using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Campaign.WebAPI.Dtos
{
    public class DiscountCreateDto
    {
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
    }
}
