using Microsoft.AspNetCore.Http;
using MoviePage.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services.Interfaces
{
    public interface ICloudImageService<TResponse>
    {
        TResponse UploadImage(IFormFile file, TransformImageOptions options);
        bool DeleteImage(string path);
        TResponse TransformImage(string path, TransformImageOptions options);
    }
}
