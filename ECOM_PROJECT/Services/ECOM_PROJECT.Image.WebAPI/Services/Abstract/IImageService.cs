using ECOM_PROJECT.Image.WebAPI.Dtos;
using ECOM_PROJECT.Shared.Entities.ComplexTypes;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Image.WebAPI.Services.Abstract
{
    public interface IImageService
    {
        IDataResult<ImageDto> Upload(IFormFile pictureFile);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
