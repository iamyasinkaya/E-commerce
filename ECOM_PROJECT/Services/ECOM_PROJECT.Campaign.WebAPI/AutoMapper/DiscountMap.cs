using AutoMapper;
using ECOM_PROJECT.Campaign.WebAPI.Dtos;
using ECOM_PROJECT.Campaign.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Campaign.WebAPI.AutoMapper
{
    public class DiscountMap : Profile
    {
        public DiscountMap()
        {
            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Discount, DiscountListDto>().ReverseMap();
            CreateMap<Discount, DiscountCreateDto>().ReverseMap();
            CreateMap<Discount, DiscountUpdateDto>().ReverseMap();
        }
    }
}
