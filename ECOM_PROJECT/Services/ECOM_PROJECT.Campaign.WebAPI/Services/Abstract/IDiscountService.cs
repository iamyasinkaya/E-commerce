using ECOM_PROJECT.Campaign.WebAPI.Dtos;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Campaign.WebAPI.Services.Abstract
{
    public interface IDiscountService
    {
        Task<IDataResult<DiscountListDto>> GetAllAsync();
        Task<IDataResult<DiscountDto>> GetAsync(int id);
        Task<IResult> CreateAsync(DiscountCreateDto discountCreateDto);
        Task<IResult> UpdateAsync(DiscountUpdateDto discountUpdateDto);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<DiscountDto>> GetByCodeAndUserId(string code, string userId);
    }
}
