using AutoMapper;
using ECOM_PROJECT.Order.Application.Dtos;
using ECOM_PROJECT.Order.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Order.Application.AutoMapper
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<OrderListDto, Domain.OrderAggregate.Order>().ReverseMap();
        }
    }
}
