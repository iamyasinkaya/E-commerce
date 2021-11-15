using ECOM_PROJECT.Basket.WebAPI.Dtos;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Basket.WebAPI.Services.Abstract
{
    public interface IBasketService
    {
        Task<IDataResult<BasketDto>> GetBasketAsync(string userId);
        Task<IDataResult<bool>> SaveOrUpdateAsync(BasketDto basketDto);
        Task<IDataResult<bool>> DeleteAsync(string userId);
    }
}
