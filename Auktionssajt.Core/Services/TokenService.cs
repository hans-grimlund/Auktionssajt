using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auktionssajt.Core.Services
{
    public class TokenService : ITokenService
    {

        public string GenerateToken(UserEntity user)
        {
            
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bGEPiWwrvQR1REZdXgw1QE9wbwi1V3BFn5qV9iT5BGStYhpMyG")),
                SecurityAlgorithms.HmacSha256);

            List<Claim> claims = [];

            claims.Add(new Claim("UserId", user.UserID.ToString()));

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5002/",
                audience: "http://localhost:5002/",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }
    }
}