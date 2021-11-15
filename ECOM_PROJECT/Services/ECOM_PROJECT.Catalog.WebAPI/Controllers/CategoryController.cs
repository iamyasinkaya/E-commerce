using ECOM_PROJECT.Catalog.WebAPI.Dtos;
using ECOM_PROJECT.Catalog.WebAPI.Services.Abstract;
using FluentValidation;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        /// <summary>
        /// Parametre girişine göre ilgili kategoriyi getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            var category = await _categoryService.GetAsync(id);

            if (ModelState.IsValid)
                return Ok(category);
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            if (categories != null)
            {
                return Ok(categories);
            }
            return NotFound();
        }
        /// <summary>
        /// İsteğe göre yeni kategori yaratır
        /// </summary>
        /// <param name="categoryCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {

            var newCategory = await _categoryService.CreateAsync(categoryCreateDto);

            if (ModelState.IsValid)
            {
                return Ok(newCategory);
            }

            return BadRequest();
        }
        /// <summary>
        /// Parametreye göre ilgili kategoriyi siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _categoryService.DeleteAsync(id);
            if (ModelState.IsValid)
            {
                return Ok(category);
            }

            return NotFound();
        }
        /// <summary>
        /// İsteğe göre ilgili kategoriyi günceller
        /// </summary>
        /// <param name="categoryUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _categoryService.UpdateAsync(categoryUpdateDto);
            if (ModelState.IsValid)
            {
                return Ok(category);
            }
            return NotFound();
        }

    }
}
