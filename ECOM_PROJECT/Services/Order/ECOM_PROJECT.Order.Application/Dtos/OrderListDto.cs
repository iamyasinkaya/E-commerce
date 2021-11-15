using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Order.Application.Dtos
{
    public class OrderListDto
    {
        public List<ECOM_PROJECT.Order.Domain.OrderAggregate.Order> Orders { get; set; }
    }
}
