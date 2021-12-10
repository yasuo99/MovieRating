using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using MoviePage.Models.Dtos.Cloudinary;
using MoviePage.Models.Options;
using MoviePage.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services.Handlers
{
    public class CloudinaryHandler : ICloudImageService<CloudinaryUploadResponseDTO>
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryHandler(Account account)
        {
            _cloudinary = new Cloudinary(account);
        }
        public bool DeleteImage(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = _cloudinary.Destroy(deleteParams);
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public CloudinaryUploadResponseDTO TransformImage(string path, TransformImageOptions options)
        {
            throw new NotImplementedException();
        }

        public CloudinaryUploadResponseDTO UploadImage(IFormFile file, TransformImageOptions options)
        {
            if(file == null)
            {
                return null;
            }
            var uploadResult = new ImageUploadResult();
            if(file.Length > 0)
            {
                using(var fileStream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, fileStream),
                        Transformation = new Transformation().Width(options.Width).Height(options.Height).Crop("fill").Gravity("face")
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            else
            {
                return null;
            }
            if(uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new CloudinaryUploadResponseDTO
                {
                    PublicId = uploadResult.PublicId,
                    PublicUrl = uploadResult.Url.ToString()
                };
            }
            return null;
        }
    }
}
