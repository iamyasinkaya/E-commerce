using ECOM_PROJECT.Web.Mvc.Helpers;
using ECOM_PROJECT.Web.Mvc.Models.Catalog.Category;
using ECOM_PROJECT.Web.Mvc.Models.Catalog.Product;
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
    public class CatalogManager : ICatalogService
    {
        private readonly HttpClient _client;
        private readonly ImageHelper _imageHelper;
        private readonly IImageService _imageService;

        public CatalogManager(HttpClient client, ImageHelper imageHelper, IImageService imageService)
        {
            _client = client;
            _imageHelper = imageHelper;
            _imageService = imageService;
        }

        public async Task<bool> CreateProductAsync(ProductCreateInput productCreateInput)
        {

            var resultPhotoService = await _imageService.UploadAsync(productCreateInput.ImageFile);
            if (resultPhotoService != null)
            {
                productCreateInput.Image = resultPhotoService.Url;
            }
            var response = await _client.PostAsJsonAsync<ProductCreateInput>("product", productCreateInput);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(string productId)
        {
            var response = await _client.DeleteAsync($"product/{productId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            var response = await _client.GetAsync("category");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<Response<CategoryList>>(result.Result);
            //var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();

            return json.Data.Category;
        }

        public async Task<ProductList> GetAllProductAsync()
        {
            var response = await _client.GetAsync("product");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<Response<ProductList>>(result.Result);
            //var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();
            json.Data.ProductViewModels.ForEach(x =>
            {
                x.StockPictureUrl = _imageHelper.GetPhotoStockUrl(x.Image);
            });

            return json.Data;
        }

        public Task<List<ProductViewModel>> GetAllProductByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetByProductId(string productId)
        {
            var response = await _client.GetAsync($"product/{productId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<Response<ProductDto>>(result.Result);
            //json.Data.ProductViewModel.StockPictureUrl = _imageHelper.GetPhotoStockUrl(json.Data.ProductViewModel.Image);
            return json.Data;
        }

        public async Task<bool> UpdateProductAsync(ProductUpdateInput productUpdateInput)
        {
            var resultPhotoService = await _imageService.UploadAsync(productUpdateInput.ImageFile);
            if (resultPhotoService != null)
            {
                await _imageService.DeletePhoto(productUpdateInput.Image);
            }
            var response = await _client.PutAsJsonAsync<ProductUpdateInput >("product", productUpdateInput);

            return response.IsSuccessStatusCode;
        }
    }
}
