using ECOM_PROJECT.Shared.Utilities.Extensions;
using ECOM_PROJECT.Shared.Utilities.Result.Concrete;
using ECOM_PROJECT.Web.Mvc.Models.Image;
using ECOM_PROJECT.Web.Mvc.Services.Abstract;
using ECOM_PROJECT.Web.Mvc.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Services.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly HttpClient _httpClient;


        public ImageManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> DeletePhoto(string imageUrl)
        {
            var response = await _httpClient.DeleteAsync($"image?pictureName={imageUrl}");
            return response.IsSuccessStatusCode;
        }



        public async Task<ImageViewModel> UploadAsync(IFormFile ImageFile)
        {

            //// we need to send a request with multipart/form-data
            //var multiForm = new MultipartFormDataContent();

            //// add API method parameters
            //multiForm.Add(new StringContent(imageViewModel.Name), "name");
            //multiForm.Add(new StringContent(imageViewModel.PictureType.ToString()), "pictureType");

            //var path = $"C:/Users/YasinKaya/Desktop/PERSONAL FİLES/Taksim/{imageViewModel.ImageFile.FileName}";
            //// add file and directly upload it
            //FileStream fs = File.OpenRead(path);
            //multiForm.Add(new StreamContent(fs), "file", Path.GetFileName(imageViewModel.ImageFile.FileName));

            //// send request to API
            //var response = await _httpClient.PostAsync("image", multiForm);
            //return response.IsSuccessStatusCode;

            if (ImageFile == null || ImageFile.Length <= 0)
            {
                return null;
            }

            var randonFilename = $"{Guid.NewGuid().ToString()}{Path.GetExtension(ImageFile.FileName)}";
            using var ms = new MemoryStream();

            await ImageFile.CopyToAsync(ms);
            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new ByteArrayContent(ms.ToArray()), "pictureFile", randonFilename);

            var response = await _httpClient.PostAsync("image", multipartContent);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<ImageViewModel>>();

            return responseSuccess.Data;

        }
    }
}
