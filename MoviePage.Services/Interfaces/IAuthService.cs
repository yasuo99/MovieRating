using MoviePage.Models;
using MoviePage.Models.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Response<string>> GenerateToken(LoginDTO loginDTO);
        Task<Response<RegisterDTO>> RegisterAccount(RegisterDTO registerDTO);
    }
}
