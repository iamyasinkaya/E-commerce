using ECOM_PROJECT.Basket.WebAPI.Configurations;
using ECOM_PROJECT.Basket.WebAPI.Dtos;
using ECOM_PROJECT.Basket.WebAPI.Services.Abstract;
using ECOM_PROJECT.Shared.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Basket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;
        public BasketController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var response = await _basketService.GetBasketAsync(_sharedIdentityService.GetUserId);

            if (ModelState.IsValid)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            var response = await _basketService.SaveOrUpdateAsync(basketDto);

            if (ModelState.IsValid)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var response = await _basketService.DeleteAsync(_sharedIdentityService.GetUserId);

            if (ModelState.IsValid)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
