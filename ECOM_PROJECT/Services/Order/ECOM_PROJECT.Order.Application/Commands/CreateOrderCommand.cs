using ECOM_PROJECT.Order.Application.Dtos;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<IDataResult<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

        public AddressDto Address { get; set; }
    }
}
