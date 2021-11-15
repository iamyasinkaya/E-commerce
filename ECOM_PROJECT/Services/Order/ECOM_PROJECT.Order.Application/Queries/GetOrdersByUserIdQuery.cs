using ECOM_PROJECT.Order.Application.Dtos;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<IDataResult<OrderListDto>>
    {
        public string UserId { get; set; }
    }
}
