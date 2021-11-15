using ECOM_PROJECT.Basket.WebAPI.Configurations;
using ECOM_PROJECT.Basket.WebAPI.Dtos;
using ECOM_PROJECT.Basket.WebAPI.Services.Abstract;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using ECOM_PROJECT.Shared.Utilities.Result.ComplexTypes;
using ECOM_PROJECT.Shared.Utilities.Result.Concrete;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Basket.WebAPI.Services.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly Configuration _redis;
        private readonly IDistributedCache _cache;
        private readonly IRedisConnectionFactory _fact;
        public BasketService(IOptions<Configuration> redis, IDistributedCache cache, IRedisConnectionFactory factory)
        {
            _redis = redis.Value;
            _cache = cache;
            _fact = factory;
        }

        public async Task<IDataResult<bool>> DeleteAsync(string userId)
        {
            var status = await _fact.Connection().GetDatabase().KeyDeleteAsync(userId);
            return status ? new DataResult<bool>(ResultStatus.Success, status) : new DataResult<bool>(ResultStatus.Error, status);

        }

        public async Task<IDataResult<BasketDto>> GetBasketAsync(string userId)
        {
            var existBasket = await _fact.Connection().GetDatabase().StringGetAsync(userId);
            var jsonBasket = JsonSerializer.Deserialize<BasketDto>(existBasket);
            if (String.IsNullOrEmpty(existBasket))
            {
                return new DataResult<BasketDto>(ResultStatus.Error, jsonBasket);
            }


            return new DataResult<BasketDto>(ResultStatus.Success, jsonBasket);
        }

        public async Task<IDataResult<bool>> SaveOrUpdateAsync(BasketDto basketDto)
        {
            var status = await _fact.Connection().GetDatabase().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
            return status ? new DataResult<bool>(ResultStatus.Success, status) : new DataResult<bool>(ResultStatus.Error, status);
        }
    }
}
