using ECOM_PROJECT.Shared.Services.Abstract;
using ECOM_PROJECT.Web.Mvc.Models.Basket;
using ECOM_PROJECT.Web.Mvc.Models.Campaign;
using ECOM_PROJECT.Web.Mvc.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Controllers
{
  
    public class BasketController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketController(ICatalogService catalogService, IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _catalogService = catalogService;
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _basketService.Get());
        }
        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var product = await _catalogService.GetByProductId(productId);
           

            var basketItem = new BasketItemViewModel
            {
                ProductId = product.ProductViewModel.Id,
                ProductName = product.ProductViewModel.Name,
                Price = product.ProductViewModel.Price,

            };

            await _basketService.AddBasketItem(basketItem);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            var result = await _basketService.RemoveBasketItem(productId);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ApplyDiscount(DiscountApplyInput discountApplyInput)
        {
            if (!ModelState.IsValid)
            {
                TempData["discountError"] = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).First();
                return RedirectToAction(nameof(Index));
            }
            var discountStatus = await _basketService.ApplyDiscount(discountApplyInput.Code);

            TempData["discountStatus"] = discountStatus;
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CancelApplyDiscount()
        {
            await _basketService.CancelApplyDiscount();
            return RedirectToAction(nameof(Index));
        }
    }
}
