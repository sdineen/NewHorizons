using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Examples.Security
{
    public class JwtToken
    {
        public static void Main()
        {
            string token1 = GetToken("acc1");
            Console.WriteLine(token1);
        }
        public static string GetToken(string username)
        {
            byte[] key = Encoding.ASCII.GetBytes("minimum 16 characters");
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor();
            Claim[] claims = { new Claim(ClaimTypes.Name, username) };
            tokenDescriptor.Subject = new ClaimsIdentity(claims);
            tokenDescriptor.Expires = DateTime.Now.AddDays(7);            
            tokenDescriptor.SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature);

            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

/*
https://en.wikipedia.org/wiki/JSON_Web_Token 
JWT debugger https://jwt.io/
 */
