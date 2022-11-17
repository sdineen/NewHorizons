using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System;
using ClassLibrary.Service;
using System.Security.Authentication;
using ClassLibrary.Entity;
using Microsoft.Extensions.Configuration;
using ReactApp.DTO;

namespace ReactApp.Controllers
{
    /// <summary>
    ///  WebAPI controller
    /// Called from React and WebAPIClient
    /// </summary>
    [ApiController]
    [Route("api/[controller]")] 
    public class AccountController : ControllerBase
    {
        private IEcommerceService ecommerceService;
        private string key;

        public AccountController(IEcommerceService ecommerceService, IConfiguration configuration)
        {
            this.ecommerceService = ecommerceService;
            key = configuration.GetValue<string>("settings:key");
        }

        /// <summary>
        /// /api/account/authenticate 
        /// Returns JWT token
        /// </summary>
        /// <param name="model">username and password from request body</param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserParameters model)
        {
            try
            {
                Account account = ecommerceService.SelectAuthenticatedAccount(model.Username, model.Password);
                model.Token = GetToken(model.Username);
                model.Name = account.Name;
                model.Password = null; //don't send password back to client
            }
            catch (AuthenticationException ex)
            {
                return Unauthorized(new { message = "Username or password is incorrect" });
            }
            return Ok(model);
        }

        /// <summary>
        /// Creates Json Web Tokens
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Json Web Token</returns>
        /// <exception cref="AuthenticationException ">invalid username and password</exception>
        private string GetToken(string username)
        {    
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor();
            
            Claim[] claims = { new Claim(ClaimTypes.Name, username) };
            tokenDescriptor.Subject = new ClaimsIdentity(claims);
            
            tokenDescriptor.Expires = DateTime.UtcNow.AddDays(7);

            byte[] byteKey = Encoding.ASCII.GetBytes(key);

            tokenDescriptor.SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(byteKey), 
                SecurityAlgorithms.HmacSha256Signature);

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        /*
        https://en.wikipedia.org/wiki/JSON_Web_Token 
        JWT debugger https://jwt.io/
        https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api#running-react
         */
    }
}
