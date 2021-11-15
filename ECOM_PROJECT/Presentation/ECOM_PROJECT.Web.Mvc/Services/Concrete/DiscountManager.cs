using ECOM_PROJECT.Web.Mvc.Models.Campaign;
using ECOM_PROJECT.Web.Mvc.Services.Abstract;
using ECOM_PROJECT.Web.Mvc.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Services.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DiscountDto> GetDiscount(string discountCode)
        {
            //[controller]/[action]/{code}

            var response = await _httpClient.GetAsync($"discount/GetByCode/{discountCode}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var result = response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<Response<DiscountDto>>(result.Result);
            return json.Data;
        }
    }
}
