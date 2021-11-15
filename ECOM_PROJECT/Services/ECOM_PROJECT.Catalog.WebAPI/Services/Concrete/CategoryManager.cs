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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            var category = _mapper.Map<Category>(categoryCreateDto);
            await _categoryRepository.AddAsync(category);
            return new Result(ResultStatus.Success, $"{category.Name} adlı ürün eklendi!");
        }

        public async Task<IResult> DeleteAsync(string id)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == id);

            if (category != null)
            {
                await _categoryRepository.DeleteAsync(category);
                return new Result(ResultStatus.Success, Messages.Category.Delete(category.Name));
            }
            return new Result(ResultStatus.Error, Messages.Category.NotFound(false));
        }

        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            if (!categories.Any())
            {
                categories = new List<Category>();
            }
            

            CategoryListDto categoryListDto = new CategoryListDto
            {
                Categories = categories
            };
            return new DataResult<CategoryListDto>(ResultStatus.Success, categoryListDto);


        }

        public async Task<IDataResult<CategoryDto>> GetAsync(string id)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == id);
            if (category != null)
            {

                var mapCategory = _mapper.Map<Category>(category);

                return new DataResult<CategoryDto>(ResultStatus.Success, $"{category.Name} adlı kategori başarıyla getirilmiştir!", new CategoryDto()
                {
                    Category = mapCategory
                });

            }
            return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), new CategoryDto
            {
                Category = null,
            });
        }

        public async Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            await _categoryRepository.UpdateAsync(category, x => x.Id == category.Id);
            if (category != null)
            {
                return new Result(ResultStatus.Success, Messages.Category.Update(category.Name));
            }

            return new Result(ResultStatus.Error, Messages.Category.NotFound(false));
        }
    }
}
