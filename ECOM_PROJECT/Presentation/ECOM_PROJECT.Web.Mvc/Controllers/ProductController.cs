using ECOM_PROJECT.Shared.Services.Abstract;
using ECOM_PROJECT.Web.Mvc.Models.Catalog.Product;
using ECOM_PROJECT.Web.Mvc.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Controllers
{

    public class ProductController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public ProductController(ICatalogService catalogService, ISharedIdentityService sharedIdentityService)
        {
            _catalogService = catalogService;
            _sharedIdentityService = sharedIdentityService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _catalogService.GetAllProductAsync());
        }
        public async Task<IActionResult> Create()
        {
            var categories = await _catalogService.GetAllCategoryAsync();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateInput productCreateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            productCreateInput.UserId = _sharedIdentityService.GetUserId;

            await _catalogService.CreateProductAsync(productCreateInput);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(string id)
        {
            var course = await _catalogService.GetByProductId(id);
                var categories = await _catalogService.GetAllCategoryAsync();

            if (course == null)
            {
                //mesaj göster
                RedirectToAction(nameof(Index));
            }
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", course.ProductViewModel.Id);
            ProductUpdateInput productUpdateInput = new()
            {
                Id = course.ProductViewModel.Id,
                Name = course.ProductViewModel.Name,
                Description = course.ProductViewModel.Description,
                Price = course.ProductViewModel.Price,
                Feature = course.ProductViewModel.Feature,
                CategoryId = course.ProductViewModel.CategoryId,
                UserId = course.ProductViewModel.UserId,
                Image = course.ProductViewModel.Image
            };

            return View(productUpdateInput);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateInput productUpdateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", productUpdateInput.Id);
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _catalogService.UpdateProductAsync(productUpdateInput);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _catalogService.DeleteProductAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
