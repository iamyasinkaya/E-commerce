using AutoMapper;
using ECOM_PROJECT.Catalog.WebAPI.Dtos;
using ECOM_PROJECT.Catalog.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Catalog.WebAPI.AutoMapper
{
    public class FeatureMap : Profile
    {
        public FeatureMap()
        {
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
