using ECOM_PROJECT.Shared.Data.Concrete.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Catalog.WebAPI.Extension
{
    public static class MongoDatabaseSettings
    {
        public static IServiceCollection AddMongoDbSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.Configure<DatabaseSettings>(options =>
            {
                options.ConnectionString = configuration
                    .GetSection(nameof(DatabaseSettings) + ":" + DatabaseSettings.ConnectionStringValue).Value;
                options.Database = configuration
                    .GetSection(nameof(DatabaseSettings) + ":" + DatabaseSettings.DatabaseValue).Value;
            });
        }
    }
}
