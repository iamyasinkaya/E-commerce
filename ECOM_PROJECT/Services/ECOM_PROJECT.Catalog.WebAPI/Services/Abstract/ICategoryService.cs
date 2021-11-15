using ECOM_PROJECT.Catalog.WebAPI.Dtos;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Catalog.WebAPI.Services.Abstract
{
    public interface ICategoryService 
    {
        Task<IDataResult<CategoryListDto>> GetAllAsync();
        Task<IDataResult<CategoryDto>> GetAsync(string id);
        Task<IResult> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<IResult> DeleteAsync(string id);
        Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        
    }
}
