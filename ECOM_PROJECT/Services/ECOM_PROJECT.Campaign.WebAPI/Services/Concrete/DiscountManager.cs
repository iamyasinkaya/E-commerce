using AutoMapper;
using ECOM_PROJECT.Campaign.WebAPI.Data.Abstract;
using ECOM_PROJECT.Campaign.WebAPI.Dtos;
using ECOM_PROJECT.Campaign.WebAPI.Models;
using ECOM_PROJECT.Campaign.WebAPI.Services.Abstract;
using ECOM_PROJECT.Shared.Utilities;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using ECOM_PROJECT.Shared.Utilities.Result.ComplexTypes;
using ECOM_PROJECT.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Campaign.WebAPI.Services.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountManager(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(DiscountCreateDto discountCreateDto)
        {
            var newDiscount = _mapper.Map<Discount>(discountCreateDto);
            await _discountRepository.AddAsync(newDiscount);
            if (newDiscount != null)
            {
                return new Result(ResultStatus.Success, Messages.Discount.Add(newDiscount.Code));
            }
            return new Result(ResultStatus.Error, Messages.Discount.NotFound(false));
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var discount = await _discountRepository.GetByIdAsync(id);
            if (discount == null)
            {
                return new Result(ResultStatus.Error, Messages.Discount.NotFoundById(id));
            }
            await _discountRepository.DeleteAsync(id);
            return new Result(ResultStatus.Success, Messages.Discount.Delete(discount.Code));
        }

        public Task<IDataResult<DiscountListDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<DiscountDto>> GetAsync(int id)
        {
            var discount = await _discountRepository.GetByIdAsync(id);
            if (discount != null)
            {

                var mapDiscount = _mapper.Map<Discount>(discount);

                return new DataResult<DiscountDto>(ResultStatus.Success, $"{discount.Code} adlı indirim kodu başarıyla getirilmiştir!", new DiscountDto()
                {
                    Discount = mapDiscount
                });

            }
            return new DataResult<DiscountDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), new DiscountDto
            {
                Discount = null,
            });
        }

        public async Task<IDataResult<DiscountDto>> GetByCodeAndUserId(string code, string userId)
        {
            var discounts = await _discountRepository.GetAsync(code, userId);

            
            if (discounts != null)
            {
                return new DataResult<DiscountDto>(ResultStatus.Success, new DiscountDto
                {
                    Discount = discounts
                });
            }

            return new DataResult<DiscountDto>(ResultStatus.Success, null);
        }

        public async Task<IResult> UpdateAsync(DiscountUpdateDto discountUpdateDto)
        {
            var discount = _mapper.Map<Discount>(discountUpdateDto);
            await _discountRepository.UpdateAsync(discount);
            if (discount != null)
            {
                return new Result(ResultStatus.Success, Messages.Discount.Update(discount.Code));
            }

            return new Result(ResultStatus.Error, Messages.Discount.NotFound(false));
        }
    }
}
