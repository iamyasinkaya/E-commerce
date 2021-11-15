using ECOM_PROJECT.Catalog.WebAPI.Dtos;
using ECOM_PROJECT.Catalog.WebAPI.Models;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Catalog.WebAPI.Services.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<ProductListDto>> GetAllAsync();
        Task<IDataResult<ProductDto>> GetAsync(string id);
        Task<IResult> CreateAsync(ProductCreateDto productCreateDto);
        Task<IResult> DeleteAsync(string id);
        Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto);
    }
}
