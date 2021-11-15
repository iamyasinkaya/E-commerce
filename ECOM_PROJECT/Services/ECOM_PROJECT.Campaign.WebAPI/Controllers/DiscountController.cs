using ECOM_PROJECT.Campaign.WebAPI.Data.Abstract;
using ECOM_PROJECT.Campaign.WebAPI.Dtos;
using ECOM_PROJECT.Campaign.WebAPI.Models;
using ECOM_PROJECT.Campaign.WebAPI.Services.Abstract;
using ECOM_PROJECT.Shared.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Campaign.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public DiscountController(IDiscountService discountService, ISharedIdentityService sharedIdentityService)
        {
            _discountService = discountService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _discountService.GetAsync(id);
                if (response == null)
                {
                    return NotFound(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(DiscountCreateDto discount)
        {
            try
            {
                var response = await _discountService.CreateAsync(discount);
                return Ok(response);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(DiscountUpdateDto discount)
        {
            try
            {
                var response = await _discountService.GetAsync(discount.Id);
                if (response == null)
                {
                    return NotFound();

                }
                await _discountService.UpdateAsync(discount);
                return Ok(response);
            }
            catch (Exception ex)
            {

                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _discountService.GetAsync(id);
                if (response == null)
                {
                    return NotFound();
                }
                await _discountService.DeleteAsync(response.Data.Discount.Id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/[action]/{code}")]
        public async Task<IActionResult> GetByCode(string code)

        {
            var userId = _sharedIdentityService.GetUserId;

            var discount = await _discountService.GetByCodeAndUserId(code, userId);

            if (ModelState.IsValid)
            {
                return Ok(discount);
            }
            return NotFound();
        }
    }
}
