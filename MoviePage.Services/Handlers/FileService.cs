using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MoviePage.Models.Configurations;
using MoviePage.Models.Constants;
using MoviePage.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MoviePage.Services.Handlers
{
    public class FileService : IFileService
    {
        private readonly Cloudinary _cloudinary;
        public FileService(IOptions<CloudinarySettings> cloudinaryOptions)
        {
            _cloudinary = new Cloudinary(new Account
            {
                Cloud = cloudinaryOptions.Value.CloudName,
                ApiKey = cloudinaryOptions.Value.ApiKey,
                ApiSecret = cloudinaryOptions.Value.ApiSecret
            });
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public string UploadFile(IFormFile formFile, string path)
        {
            var uploadLocation = Path.Combine(path, SD.Image_Path);
            var fileUploadPath = Path.Combine(uploadLocation, formFile.FileName);
            using(var fileStream = new FileStream(fileUploadPath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return Path.Combine(SD.Image_Path, $"{formFile.FileName}");
        }
    }
}
