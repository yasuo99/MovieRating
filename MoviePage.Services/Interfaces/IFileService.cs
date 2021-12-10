using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services.Interfaces
{
    public interface IFileService
    {
        string UploadFile(IFormFile formFile, string path);
        void DeleteFile(string path);
    }
}
