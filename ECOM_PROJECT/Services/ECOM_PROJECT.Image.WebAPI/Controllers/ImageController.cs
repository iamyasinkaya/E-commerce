    using ECOM_PROJECT.Image.WebAPI.Dtos;
using ECOM_PROJECT.Image.WebAPI.Services.Abstract;
using ECOM_PROJECT.Shared.Entities.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Image.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile pictureFile)
        {
            var image = _imageService.Upload(pictureFile);

            if (ModelState.IsValid)
            {
                return Ok(image);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(string imageName)
        {
            var response = _imageService.Delete(imageName);
            if (ModelState.IsValid)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
