using ECOM_PROJECT.Catalog.WebAPI.Dtos;
using ECOM_PROJECT.Catalog.WebAPI.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Catalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Parametreye göre ilgili ürünü getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productService.GetAsync(id);
            if (ModelState.IsValid)
            {
                return Ok(product);
            }
            return BadRequest();
        }
        /// <summary>
        /// Tüm ürünleri getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            if (ModelState.IsValid)
            {
                return Ok(products);
            }
            return NotFound();
        }
        /// <summary>
        /// Parametrelere göre yeni ürün yaratır
        /// </summary>
        /// <param name="productCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto productCreateDto)
        {
            var product = await _productService.CreateAsync(productCreateDto);
            if (ModelState.IsValid)
            {
                return Ok(product);
            }
            return BadRequest();
        }
        /// <summary>
        /// Parametrelere göre ilgili ürünü günceller
        /// </summary>
        /// <param name="productUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var product = await _productService.UpdateAsync(productUpdateDto);
            if (ModelState.IsValid)
            {
                return Ok(product);
            }
            return BadRequest();
        }
        /// <summary>
        /// Parametereye göre ilgili ürünü siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productService.DeleteAsync(id);
            if (ModelState.IsValid)
            {
                return Ok(product);
            }
            return BadRequest();
        }
    }
}
