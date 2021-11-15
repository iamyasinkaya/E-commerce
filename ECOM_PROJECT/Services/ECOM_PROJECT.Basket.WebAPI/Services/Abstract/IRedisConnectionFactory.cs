using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Basket.WebAPI.Services.Abstract
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
    }
}
