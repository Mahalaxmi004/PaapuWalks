﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaapuWalks.Repositories
{
    public class TokenRepository : ITokenRepository
    {

        // we are using constructor injection. using IConfiguration we can access appsetting.json file

        private readonly IConfiguration configuration;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string CreateJWTToken(IdentityUser user, List<string> roles)
        {
            //Create claims 
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

            //var k = new JwtSecurityTokenHandler();
            //return k.WriteToken(token);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
