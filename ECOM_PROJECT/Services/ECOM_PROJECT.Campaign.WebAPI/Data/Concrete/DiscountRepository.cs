using ECOM_PROJECT.Campaign.WebAPI.Data.Abstract;
using ECOM_PROJECT.Campaign.WebAPI.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Linq.Expressions;

namespace ECOM_PROJECT.Campaign.WebAPI.Data.Concrete
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }
        public async Task<int> AddAsync(Discount entity)
        {
            entity.CreatedAt = DateTime.Now;
            var saveStatus = await _dbConnection.ExecuteAsync("INSERT INTO discount (userid,rate,code) VALUES(@UserId,@Rate,@Code)", entity);
            return saveStatus;

        }
        public async Task<int> DeleteAsync(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where id=@Id", new { Id = id });
            return status;

        }
        public async Task<IReadOnlyList<Discount>> GetAllAsync()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("Select * from discount");
            return discounts.ToList();
        }

      

        public async Task<Discount> GetAsync(string code, string userId)
        {
            var discounts = await _dbConnection.QueryAsync<Discount>("select * from discount where userid=@UserId and code=@Code", new { UserId = userId, Code = code });
            var hasDiscount = discounts.FirstOrDefault();
            return hasDiscount;
        }

        public async Task<Discount> GetByIdAsync(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount where id=@Id", new { Id = id })).SingleOrDefault();
            return discount;
        }
        public async Task<int> UpdateAsync(Discount entity)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid=@UserId, code=@Code, rate=@Rate where id=@Id", new { Id = entity.Id, UserId = entity.UserId, Code = entity.Code, Rate = entity.Rate });
            return status;
        }
    }
}
