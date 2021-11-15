using ECOM_PROJECT.Order.Application.AutoMapper;
using ECOM_PROJECT.Order.Application.Dtos;
using ECOM_PROJECT.Order.Application.Queries;
using ECOM_PROJECT.Order.Infrastucture.Data.EntityFramework;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using ECOM_PROJECT.Shared.Utilities.Result.ComplexTypes;
using ECOM_PROJECT.Shared.Utilities.Result.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Order.Application.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, IDataResult<OrderListDto>>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GetOrdersByUserIdQueryHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IDataResult<OrderListDto>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _applicationDbContext.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();
            if (!orders.Any())
            {
                return new DataResult<OrderListDto>(ResultStatus.Success, new OrderListDto
                {
                    Orders = orders
                });
            }

            //var ordersDto = ObjectMapper.Mapper.Map<OrderListDto>(orders);
            return new DataResult<OrderListDto>(ResultStatus.Success, new OrderListDto
            {
                Orders = orders
            });

        }
    }
}
