using ECOM_PROJECT.Web.Mvc.Models.Catalog.Category;
using ECOM_PROJECT.Web.Mvc.Models.Catalog.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Services.Abstract
{
    public interface ICatalogService
    {
        Task<ProductList> GetAllProductAsync();

        Task<List<CategoryViewModel>> GetAllCategoryAsync();

        Task<List<ProductViewModel>> GetAllProductByUserIdAsync(string userId);

        Task<ProductDto> GetByProductId(string productId);

        Task<bool> CreateProductAsync(ProductCreateInput productCreateInput);

        Task<bool> UpdateProductAsync(ProductUpdateInput productUpdateInput);

        Task<bool> DeleteProductAsync(string productId);
    }
}
