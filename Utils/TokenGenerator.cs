using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using backend.Entities;

namespace backend.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static string AccessToken(User user, IConfiguration configuration)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    configuration.GetSection("AppSettings:JWT_SECRET_KEY").Value!
                )
            );

            var credential = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha512Signature
            );

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credential
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}