using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.JwtToken
{
    public class Token
    {
        public IConfiguration configration;
        public Token(IConfiguration configration)
        {
            this.configration= configration;
        }
        public string GenerateToken(string email, int userId,string Role)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configration["Jwt:key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim("Email",email),
                new Claim("UserID",userId.ToString()),
                new Claim(ClaimTypes.Role ,Role)
                };
                var token = new JwtSecurityToken(configration["Jwt:Issuer"],
                    configration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
