using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.TokenServices
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            if (user is null)
            {
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            string privateKey = configuration.GetSection("JWTKey").Value ?? "";

            if (String.IsNullOrEmpty(privateKey))
            {
                throw new ArgumentNullException($"{nameof(privateKey)} must be not null");
            }

            var key = Encoding.ASCII.GetBytes(privateKey);
            ClaimsIdentity claimsIdentity = new(new[] {
                new Claim("Name", user.NameSurname),
                new Claim("Identity", user.Identity.Substring(6)),
                new Claim("DateOfBirth", user.DateOfBirth.ToString()),
                new Claim("Language", user.Language),
                new Claim("Age", user.Age.ToString()),
                new Claim("Nationality", user.Nationality.ToString()),
                new Claim("PlaceOfBirth", user.PlaceOfBirth.ToString())
            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.UtcNow,
                Issuer = user.ID.ToString(),
                NotBefore = DateTime.UtcNow
            };
            SecurityToken JwtObj = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(JwtObj);
            return token;
        }
    }
}
