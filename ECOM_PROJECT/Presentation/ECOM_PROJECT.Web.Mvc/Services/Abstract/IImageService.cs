using ECOM_PROJECT.Web.Mvc.Models.Image;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Services.Abstract
{
    public interface IImageService
    {
        Task<ImageViewModel> UploadAsync(IFormFile imageFile);

        Task<bool> DeletePhoto(string imageUrl);
    }
}
