using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Models.Dtos.Identity;
using MoviePage.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services.Handlers
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Account> _userManager;
        public AuthService(IConfiguration configuration, ApplicationDbContext db, UserManager<Account> userManager)
        {
            _configuration = configuration;
            _db = db;
            _userManager = userManager;
        }
        public async Task<Response<string>> GenerateToken(LoginDTO loginDTO)
        {

            var account = await _db.Accounts.AsNoTracking().Where(acc => acc.Email.ToLower().Equals(loginDTO.Username.ToLower()) || acc.UserName.ToLower().Equals(loginDTO.Username.ToLower()) || acc.PhoneNumber.Equals(loginDTO.Username))
                .Include(inc => inc.Roles).ThenInclude(inc => inc.Role)
                .FirstOrDefaultAsync();
            if(account == null)
            {
                return Response.Unauthorized(data: loginDTO.Username);
            }
            if (!await _userManager.CheckPasswordAsync(account, loginDTO.Password))
            {
                return Response.Unauthorized(data: loginDTO.Username);
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.MobilePhone, account.PhoneNumber ?? "0000000000")
            };
            foreach(var role in account.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("Secret:Token_Key").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddDays(7)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var secureToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(secureToken);
            return Response.Ok("Authentication successful", data: token);
        }

        public async Task<Response<RegisterDTO>> RegisterAccount(RegisterDTO registerDTO)
        {
            var account = new Account
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Email,
                Sex = registerDTO.Sex
            };
            if(await _db.Accounts.AnyAsync(acc => acc.Email.ToLower().Equals(registerDTO.Email.ToLower()) || acc.UserName.ToLower().Equals(registerDTO.Username.ToLower())))
            {
                return Response.Conflic("Email | Username was registered", data: registerDTO);
            }
            var registerResult = await _userManager.CreateAsync(account, registerDTO.Password);
            if (registerResult.Succeeded)
            {
                return Response.Ok("Register successful", data: registerDTO);
            }
            return Response.Fail("Register fail", data: registerDTO);
        }
    }
}
