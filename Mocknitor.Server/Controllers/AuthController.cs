using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Mocknitor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] MyUserModel login)
        {
            IActionResult response = Unauthorized();

            MyUserModel user = AuthenticateUser(login);

            if (user != null)
            {
                string tokenString = GenerateJsonWebToken(user);
                response = Ok(new {token = tokenString});
            }

            return response;
        }

        private string GenerateJsonWebToken(MyUserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }

        private MyUserModel AuthenticateUser(MyUserModel login)
        {
            MyUserModel user = null;

            if (login.UserName == "admin" && login.Password == "admin")
            {
                user = new MyUserModel { UserName = "admin" , Password = "admin" };
            }
            return user;
        }
    }

    public class MyUserModel
    {
            public string UserName { get; set; }
            public string Password { get; set; }
        
    }
}
