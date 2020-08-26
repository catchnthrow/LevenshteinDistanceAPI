using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GleacAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        List<User> validUsers = new List<User>();
        public TokenController(IConfiguration config)
        {
            _configuration = config;
            validUsers.Add(
            new User() {
                Email = "prashant@gleac.com",
                FirstName = "Prashant",
                LastName = "Singh",
                UserId = "prashant19sep",
                Password = "pass123"
            });

            validUsers.Add(
                new User()
                {
                    Email = "admin@gleac.com",
                    FirstName = "AdminF",
                    LastName = "AdminL",
                    UserId = "admin",
                    Password = "pass1234"
                });
        }

        [HttpPost]
        public IActionResult Post(User userData)
        {

            if (userData != null && userData.Email != null && userData.Password != null)
            {
                var user = validUsers.Where(u => u.Email.Equals(userData.Email) && u.Password.Equals(userData.Password))
                    .FirstOrDefault();

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.UserId.ToString()),
                        new Claim("FirstName", user.FirstName),
                        new Claim("LastName", user.LastName),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"])), signingCredentials: signIn);

                    return Ok(new { message = "Success", token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}