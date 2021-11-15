using AutoMapper;
using ECOM_PROJECT.Catalog.WebAPI.Data.Abstract;
using ECOM_PROJECT.Catalog.WebAPI.Dtos;
using ECOM_PROJECT.Catalog.WebAPI.Models;
using ECOM_PROJECT.Catalog.WebAPI.Services.Abstract;
using ECOM_PROJECT.Shared.Utilities;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using ECOM_PROJECT.Shared.Utilities.Result.ComplexTypes;
using ECOM_PROJECT.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Catalog.WebAPI.Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> CreateAsync(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            if (product != null)
            {
                await _productRepository.AddAsync(product);
                return new Result(ResultStatus.Success, Messages.Product.Add(product.Name));
            }
            return new Result(ResultStatus.Error, Messages.Product.NotFound(isPlural: false));
        }

        public async Task<IResult> DeleteAsync(string id)
        {
            var product = await _productRepository.GetAsync(x => x.Id == id);
            if (product != null)
            {
                await _productRepository.DeleteAsync(product);
                return new Result(ResultStatus.Success, Messages.Product.Delete(product.Name));
            }
            return new Result(ResultStatus.Error, Messages.Product.NotFound(false));
        }

        public async Task<IDataResult<ProductListDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            if (products.Any())
            {
                foreach (var item in products)
                {
                    item.Category = await _categoryRepository.GetAsync(x => x.Id == item.CategoryId);
                }
            }
            else
            {
                products = new List<Product>();
            }

            ProductListDto productListDto = new ProductListDto
            {
                Products = products
            };
            return new DataResult<ProductListDto>(ResultStatus.Success, productListDto);


        }

        public async Task<IDataResult<ProductDto>> GetAsync(string id)
        {
            var product = await _productRepository.GetAsync(x => x.Id == id);
            if (product != null)
            {

                var mapProduct = _mapper.Map<Product>(product);

                return new DataResult<ProductDto>(ResultStatus.Success, $"{mapProduct.Name} adlı ürün başarıyla getirilmiştir!", new ProductDto()
                {
                    Product = mapProduct
                });

            }
            return new DataResult<ProductDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: false), new ProductDto
            {
                Product = null,
            });
        }

        public async Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Product>(productUpdateDto);
            await _productRepository.UpdateAsync(product, x => x.Id == product.Id);
            if (product != null)
            {
                return new Result(ResultStatus.Success, Messages.Product.Update(product.Name));
            }

            return new Result(ResultStatus.Error, Messages.Product.NotFound(false));
        }
    }
}
