using ECOM_PROJECT.Image.WebAPI.Dtos;
using ECOM_PROJECT.Image.WebAPI.Services.Abstract;
using ECOM_PROJECT.Shared.Entities.ComplexTypes;
using ECOM_PROJECT.Shared.Utilities.Extensions;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using ECOM_PROJECT.Shared.Utilities.Result.ComplexTypes;
using ECOM_PROJECT.Shared.Utilities.Result.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Image.WebAPI.Services.Concrete
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private const string imgFolder = "img";
        //private const string userImagesFolder = "userImages";
        //private const string postImagesFolder = "postImages";
        public ImageService(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }
        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}/", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Success, $"{pictureName} adlı resim başarıyla silinmiştir.", imageDeletedDto);
            }
            else
            {
                return new DataResult<ImageDeletedDto>(ResultStatus.Error, $"Böyle bir resim bulunamadı.", null);
            }
        }

        public IDataResult<ImageDto> Upload(IFormFile pictureFile)
        {
            /* Eğer folderName değişkeni null gelir ise, o zaman resim tipine göre (PictureType) klasör adı ataması yapılır. */
            //folderName ??= pictureType == PictureType.User ? userImagesFolder : postImagesFolder;

            /* Eğer folderName değişkeni ile gelen klasör adı sistemimizde mevcut değilse, yeni bir klasör oluşturulur. */
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}");
            }

            /* Resimin yüklenme sırasındaki ilk adı oldFileName adlı değişkene atanır. */
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);

            /* Resimin uzantısı fileExtension adlı değişkene atanır. */
            string fileExtension = Path.GetExtension(pictureFile.FileName);


            Regex regex = new Regex("[*'\",._&#^@]");


            DateTime dateTime = DateTime.Now;
            /*
            // Parametre ile gelen değerler kullanılarak yeni bir resim adı oluşturulur.
            // Örn: AlperTunga_587_5_38_12_3_10_2020.png
            */
            string newFileName = $"{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";

            /* Kendi parametrelerimiz ile sistemimize uygun yeni bir dosya yolu (path) oluşturulur. */
            var path = Path.Combine($"{_wwwroot}/{imgFolder}", newFileName);

            /* Sistemimiz için oluşturulan yeni dosya yoluna resim kopyalanır. */
            using (var stream = new FileStream(path, FileMode.Create))
            {
                pictureFile.CopyTo(stream);
            }

            /* Resim tipine göre kullanıcı için bir mesaj oluşturulur. */


            return new DataResult<ImageDto>(ResultStatus.Success, new ImageDto { Url = path });
        }
    }
}
