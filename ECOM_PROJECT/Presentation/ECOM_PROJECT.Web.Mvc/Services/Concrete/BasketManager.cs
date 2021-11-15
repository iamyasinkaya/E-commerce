using ECOM_PROJECT.Shared.Services.Abstract;
using ECOM_PROJECT.Web.Mvc.Models.Basket;
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
    public class BasketManager : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly ISharedIdentityService _shared;
        private readonly IDiscountService _discountService;


        public BasketManager(HttpClient httpClient, ISharedIdentityService shared, IDiscountService discountService)
        {
            _httpClient = httpClient;
            _shared = shared;
            _discountService = discountService;
        }

        public async Task AddBasketItem(BasketItemViewModel basketItemViewModel)
        {
            var basket = await Get();
            if (basket != null)
            {
                if (!basket.BasketItems.Any(x => x.ProductId == basketItemViewModel.ProductId))
                {
                    basket.BasketItems.Add(basketItemViewModel);
                }
            }
            else
            {
                basket = new BasketViewModel();
                basket.UserId = _shared.GetUserId;
                basket.BasketItems.Add(basketItemViewModel);
            }

            await SaveOrUpdate(basket);
        }

        public async Task<bool> ApplyDiscount(string discountCode)
        {
            await CancelApplyDiscount();

            var basket = await Get();
            if (basket == null)
            {
                return false;
            }

            var hasDiscount = await _discountService.GetDiscount(discountCode);
            if (hasDiscount == null)
            {
                return false;
            }

            basket.ApplyDiscount(hasDiscount.DiscountViewModel.Code, hasDiscount.DiscountViewModel.Rate);
            await SaveOrUpdate(basket);
            return true;
        }

        public async Task<bool> CancelApplyDiscount()
        {
            var basket = await Get();

            if (basket == null || basket.DiscountCode == null)
            {
                return false;
            }

            basket.CancelDiscount();
            await SaveOrUpdate(basket);
            return true;
        }

        public async Task<bool> Delete()
        {
            var result = await _httpClient.DeleteAsync("basket");

            return result.IsSuccessStatusCode;
        }

        public async Task<BasketViewModel> Get()
        {
            var response = await _httpClient.GetAsync("basket");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<Response<BasketViewModel>>(result.Result);
            //var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();
            json.Data.UserId = _shared.GetUserId;
            return json.Data;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var basket = await Get();

            if (basket == null)

            {
                return false;
            }

            var deleteBasketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            if (deleteBasketItem == null)
            {
                return false;
            }

            var deleteResult = basket.BasketItems.Remove(deleteBasketItem);

            if (!deleteResult)
            {
                return false;
            }

            if (!basket.BasketItems.Any())
            {
                basket.DiscountCode = null;
            }

            return await SaveOrUpdate(basket);
        }

        public async Task<bool> SaveOrUpdate(BasketViewModel basketViewModel)
        {
            basketViewModel.BasketItems.Where(x => x.Price == x.GetCurrentPrice);

            var response = await _httpClient.PostAsJsonAsync("basket", basketViewModel);

            return response.IsSuccessStatusCode;
        }
    }
}
