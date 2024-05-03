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
                var identityUser = user;

                var tokenHandler = new JwtSecurityTokenHandler();

                // Retrieve JWT key asynchronously from configuration
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));

                // Retrieve JWT issuer and audience asynchronously from configuration
                var issuer = Configuration["Jwt:Issuer"];
                var audience = Configuration["Jwt:Audience"];

                // JWT token'da bulunacak talepleri tanımla
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName), // Kullanıcı adını içeren talep
            new Claim(ClaimTypes.Email, user.Email), // E-postayı içeren talep
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

                // Rolleri taleplere ekle
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                // JWT token parametrelerini belirle
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = issuer,
                    Audience = audience,
                    Subject = new ClaimsIdentity(claims),
                    Expires = rememberMe ? DateTime.UtcNow.AddMonths(1) : DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                };

                // Token oluştur (async olarak işaretlenmiş özelliği kullandık)
                var token = await Task.Run(() => tokenHandler.CreateToken(tokenDescriptor));

                // Token'ı string olarak döndür
                var tokenString = tokenHandler.WriteToken(token);

                return new SuccessDataResult<string>(tokenString, "JWT token başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(ex.Message);
            }
        }

        public async Task<IDataResult<IDictionary<string, string>>> DecodeJwtToken(string token)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
                var tokenHandler = new JwtSecurityTokenHandler();

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = key
                };

                // Synchronously decode and validate the JWT token
                SecurityToken securityToken;
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                // Extract claims from the validated token
                var claims = new Dictionary<string, List<string>>();

                // Iterate through each claim in the claimsPrincipal
                foreach (var claim in claimsPrincipal.Claims)
                {
                    if (!claims.ContainsKey(claim.Type))
                    {
                        claims[claim.Type] = new List<string>();
                    }

                    claims[claim.Type].Add(claim.Value);
                }

                // Flatten the claims dictionary to have a single string value per key
                var flattenedClaims = new Dictionary<string, string>();

                foreach (var kvp in claims)
                {
                    string concatenatedValues = string.Join(",", kvp.Value);
                    flattenedClaims.Add(kvp.Key, concatenatedValues);
                }

                // Return the flattened claims as a SuccessDataResult<IDictionary<string, string>>
                return new SuccessDataResult<IDictionary<string, string>>(flattenedClaims, "JWT token decoded successfully");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error result
                return new ErrorDataResult<IDictionary<string, string>>(null, $"Error decoding JWT token: {ex.Message}");
            }
        }


    }
}
