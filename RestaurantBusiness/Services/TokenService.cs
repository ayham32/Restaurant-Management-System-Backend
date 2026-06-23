using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestaurantBusiness.InterfaceServices;
using RestaurantDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBusiness.Services
{
    public class TokenService:ITokenService
    {

        private readonly string _secretKey;
        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration["JWT_SECRET_KEY:Key"]
                ?? throw new Exception("JWT secret key not found");
        }

        public async Task<string> GenerateToken(User user, List<string> roles)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));


            var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_secretKey));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: "RestaurantApi",
                audience: "RestaurantApiUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return accessToken;
        }

        public async Task<string> GenerateRefreshToken()
        {
            var bytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }


    }
}
