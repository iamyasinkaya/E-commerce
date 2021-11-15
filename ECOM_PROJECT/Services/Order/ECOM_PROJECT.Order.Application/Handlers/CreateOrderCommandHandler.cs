using ECOM_PROJECT.Order.Application.Commands;
using ECOM_PROJECT.Order.Application.Dtos;
using ECOM_PROJECT.Order.Domain.OrderAggregate;
using ECOM_PROJECT.Order.Infrastucture.Data.EntityFramework;
using ECOM_PROJECT.Shared.Utilities;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using ECOM_PROJECT.Shared.Utilities.Result.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, IDataResult<CreatedOrderDto>>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CreateOrderCommandHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IDataResult<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line);
            Order.Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);
            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });
            await _applicationDbContext.Orders.AddAsync(newOrder);
            await _applicationDbContext.SaveChangesAsync();
            return new DataResult<CreatedOrderDto>(Shared.Utilities.Result.ComplexTypes.ResultStatus.Success, Messages.Order.Create(newOrder.Id), new CreatedOrderDto
            {
                OrderId = newOrder.Id
            });

        }
    }
}
