using Business.Interfaces;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TokenManager:InterfaceTokenService
    {
        private readonly IConfiguration Configuration;

        public TokenManager(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }   
        public async Task<IDataResult<string>> CreateJwtTokenAsync(IdentityUser user, List<string> roles, bool rememberMe)
        {
            try
            {
                var identityUser = user as IdentityUser;

                var tokenHandler = new JwtSecurityTokenHandler();

                // JWT için kullanılacak anahtarı byte dizisine çevir
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));

                // JWT token'da bulunacak talepleri tanımla
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, identityUser.UserName), // Kullanıcı adını içeren talep
                    new Claim(ClaimTypes.Email, identityUser.Email), // E-postayı içeren talep
                    new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
                };

                // Rolleri taleplere ekle
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                // JWT token parametrelerini belirle
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = Configuration["Jwt:Issuer"],
                    Audience = Configuration["Jwt:Audience"],
                    Subject = new ClaimsIdentity(claims),
                    Expires = rememberMe ? DateTime.UtcNow.AddMonths(1) : DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                };

                // Token oluştur
                var token = tokenHandler.CreateToken(tokenDescriptor);

                // Token'ı string olarak döndür
                var tokenString = tokenHandler.WriteToken(token);

                return new SuccessDataResult<string>(tokenString, "JWT token başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(ex.Message);
            }
        }
    }
}
