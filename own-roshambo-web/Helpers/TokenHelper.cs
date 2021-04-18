using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OwnRoshamboWeb.Interfaces.Helpers;
using OwnRoshamboWeb.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Helpers
{
    public class TokenHelper : ITokenHelper
    {
        private const string IsActive = "IsActive";
        private const string Score = "Score";

        private readonly AppSettings _appSettings;
        public TokenHelper(IOptions<AppSettings> appSettions)
        {
            _appSettings = appSettions.Value;
        }

        public string GetToken(UserModel userModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JwtTokenSecret);
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetUserClaims(userModel)),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }

        public UserModel GetUserFromClaims(IEnumerable<Claim> claims)
        {
            int.TryParse(GetValuesFromClaims(claims, ClaimTypes.NameIdentifier), out int userId);
            int.TryParse(GetValuesFromClaims(claims, Score), out int score);
            bool.TryParse(GetValuesFromClaims(claims, IsActive), out bool isActive);
            var username = GetValuesFromClaims(claims, ClaimTypes.Name);
            var email = GetValuesFromClaims(claims, ClaimTypes.Email);

            return new UserModel
            {
                Id = userId,
                Username = username,
                Email = email,
                Score = score,
                IsActive = isActive,
            };
        }

        private Claim[] GetUserClaims(UserModel userModel)
        {
            return new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
                new Claim(ClaimTypes.Name, userModel.Username),
                new Claim(ClaimTypes.Email, userModel.Email),
                new Claim(Score, userModel.Score.ToString()),
                new Claim(IsActive, userModel.IsActive.ToString()),
            };
        }

        private string GetValuesFromClaims(IEnumerable<Claim> claims, string name)
        {
            return claims.FirstOrDefault(c => c.Type == name)?.Value;
        }
    }
}
