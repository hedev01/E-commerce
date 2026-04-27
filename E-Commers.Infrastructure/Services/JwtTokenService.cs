using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Identity;
using E_Commers.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace E_Commers.Application.Services
{


    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _config; // یا مقادیر خوانده شده از تنظیمات

        public JwtTokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(ApplicationUserIdentity user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var SignKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JWT:SecritKey"])); // نام کلید اصلاح شد

            var signingCredentials = new SigningCredentials(SignKey, SecurityAlgorithms.HmacSha256);

            var mytoken = new JwtSecurityToken(
                issuer: _config["JWT:ValidIss"],
                audience: _config["JWT:ValidAud"],
                expires: DateTime.Now.AddHours(1),
                claims: claims, // myclaims به claims تغییر یافت
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(mytoken);
        }
    }
}
