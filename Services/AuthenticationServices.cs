using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly AppSettings _appSettings;
        public AuthenticationServices(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public User Autheticate(string userName, string passWord)
        {
            User user = new User();
            var result = user.getOneUserTesting().SingleOrDefault(x => x.userName == userName && x.userPass == passWord);
            if (result == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, result.idUser.ToString()),
                    new Claim(ClaimTypes.Role, result.userRoles.ToString()),
                    new Claim(ClaimTypes.Version, "")
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            result.token = tokenHandler.WriteToken(token);
            result.userPass = "";
            return result;


        }
    }
}
